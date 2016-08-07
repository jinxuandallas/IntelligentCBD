using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Web;

namespace Core
{
    public class ProblemsClass:Database
    {
        public ProblemsClass()
        {

        }

        /// <summary>
        /// 添加反馈问题
        /// </summary>
        /// <param name="username">录入人</param>
        /// <param name="content">问题内容（已包含HtmlEncode处理）</param>
        /// <returns>返回新添加的问题ID</returns>
        public Guid AddProblem(string username,  string content)
        {
            Guid ID = Guid.NewGuid();
            sql = @"insert into 网站反馈问题(ID,反馈问题,录入人) values (@ID,@content,@username)"; 

            int rtn=ExecuteSql(sql, new SqlParameter[] {new SqlParameter("@ID",ID),
                new SqlParameter("@content",HttpUtility.HtmlEncode(content)),
                new SqlParameter("@username",username)
                
            });

            return ID;
        }


        /// <summary>
        /// 上传问题图片
        /// </summary>
        /// <param name="uploadFiles">包含所有上传文件的HttpFileCollection</param>
        /// <param name="filepath">在服务器端的文件路径</param>
        /// <param name="problemID">问题ID</param>
        /// <returns>返回上传结果</returns>
        public string UploadProblemPic(HttpFileCollection uploadFiles, string filepath, Guid problemID)
        {
            //检查文件个数
            if (uploadFiles.Count < 1 || uploadFiles.Count > 5)
                return "上传失败";

            //检查文件大小与类型
            string examResult = ExamFiles(uploadFiles);
            if (examResult != "文件检查成功")
                return examResult;

            //检查目录是否存在
            if (!System.IO.Directory.Exists(filepath))//判断文件夹是否已经存在
            {
                System.IO.Directory.CreateDirectory(filepath);//创建文件夹
            }

            //上传文件
            string extName, newFilename, newFilepath;
            for (int i = 0; i < uploadFiles.Count; i++)
            {
                HttpPostedFile postedFile = uploadFiles[i];
                try
                {
                    if (postedFile.ContentLength > 0)
                    {
                        //产生新的文件名
                        extName = System.IO.Path.GetExtension(postedFile.FileName).ToLower();
                        // 生成随机文件名
                        Random random = new Random(DateTime.Now.Millisecond);
                        newFilename = DateTime.Now.ToString("yyyyMMddhhmmss") + random.Next(10000) + i + extName;

                        //上传文件
                        newFilepath = filepath + newFilename;
                        postedFile.SaveAs(newFilepath);

                        //添加新的数据库记录
                        bool result = AddProblemDbPic(newFilename, problemID);
                        if (!result)
                            return "上传记录不成功";
                    }
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }
            return "上传成功";
        }

        /// <summary>
        /// 检查上传文件是否符合规定
        /// </summary>
        /// <param name="uploadFiles">包含上传文件的HttpFileCollection</param>
        /// <returns>返回上传结果</returns>
        public string ExamFiles(HttpFileCollection uploadFiles)
        {
            int filesSize = 0;

            ////获取已存在的文件，便于下一步取得已存在文件的大小
            //DataSet ds = GetPicbyCompany(companyID, picType);
            //System.IO.FileInfo fi;

            ////检查存于数据库中的文件大小，用于计算所有上传文件是否超过5M
            //foreach (DataRow dr in ds.Tables[0].Rows)
            //{
            //    fi = new FileInfo(HttpContext.Current.Server.MapPath(dr[0].ToString()));
            //    filesSize += int.Parse(fi.Length.ToString());
            //}


            string extName;
            //此处只能使用for不能使用foreach因为uf可能为空，将导致异常
            //foreach(HttpPostedFile uf in uploadFiles)
            for (int i = 0; i < uploadFiles.Count; i++)
            {
                if (uploadFiles[i].ContentLength > 0)
                {
                    extName = System.IO.Path.GetExtension(uploadFiles[i].FileName).ToLower();

                    if (extName != ".jpg" && extName != ".jpeg" && extName != ".gif" && extName != ".png")
                        return "只能上传jpg，gif，png文件";

                    if (uploadFiles[i].ContentLength > 2097152)
                        return "单个文件不能超过2M";

                    filesSize += uploadFiles[i].ContentLength;
                    if (filesSize > 5242880)
                        return "总文件不能超过5M";
                }
            }
            return "文件检查成功";
        }

        /// <summary>
        /// 添加问题图片的数据库信息
        /// </summary>
        /// <param name="filename">图片的文件名</param>
        /// <param name="commentID">问题ID</param>
        /// <returns>返回是否成功</returns>
        public bool AddProblemDbPic(string filename, Guid problemID)
        {
            Guid ID = Guid.NewGuid();
            //只能服务器使用相对路径，使用绝对路径客户端打不开（调用的是客户端文件）
            string filepath = "~/Upload/ProblemUploadPic/" + filename;
            sql = "insert 反馈问题图片(ID,所属问题,图片地址) values(@ID,@problemID,@filepath)";
            int rtn = ExecuteSql(sql, new SqlParameter[] {
                new SqlParameter("@ID",ID),
                new SqlParameter("@problemID",problemID),
                new SqlParameter("@filepath", filepath)
            });
            if (rtn == 1)
                return true;
            return false;
        }
    }
}
