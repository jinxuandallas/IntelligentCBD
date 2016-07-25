using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Core
{
    public class CommentClass:Database
    {
        public CommentClass()
        {

        }

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

        public string UploadCommentPic(HttpFileCollection uploadFiles, string filepath, Guid commentID)
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
                        newFilename = DateTime.Now.ToString("yyyyMMddhhmmss") + random.Next(10000)  + i + extName;

                        //上传文件
                        newFilepath = filepath + newFilename;
                        postedFile.SaveAs(newFilepath);

                        //添加新的数据库记录
                        bool result = AddCommentDbPic(newFilename, commentID);
                        if (!result)
                            return "上传记录不成功";

                    }
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }
            return "";
        }

        public bool AddCommentDbPic(string filename, Guid commentID)
        {
            Guid ID = Guid.NewGuid();
            //只能服务器使用相对路径，使用绝对路径客户端打不开（调用的是客户端文件）
            string filepath = "~/Upload/CommentUploadPic/" + filename;
            sql = "insert 评论图片(ID,所属评论,图片地址) values(@ID,@commentID,@filepath)";
            int rtn = ExecuteSql(sql, new SqlParameter[] {
                new SqlParameter("@ID",ID),
                new SqlParameter("@commentID",commentID),
                new SqlParameter("@filepath", filepath)
            });
            if (rtn == 1)
                return true;
            return false;
        }


        public Guid AddComment(Guid companyID,string username,int score,string comment,bool anonymity)
        {
            Guid ID = Guid.NewGuid();
            sql = @"insert into 评论(ID,所属企业,录入人,星级,内容,[是否匿名]) values (@ID,@companyID,@username,@score,@comment,@anonymity) 
            exec 添加评分 @companyID,@score";

            ExecuteTranSQL(sql, new SqlParameter[] {new SqlParameter("@ID",ID),
                new SqlParameter("@companyID",companyID),
                new SqlParameter("@username",username),
                new SqlParameter("@score",score),
                new SqlParameter("@comment",comment),
                new SqlParameter("@anonymity",anonymity)
            });

            return ID;
        }

        //public DataSet GetComments(Guid companyID)
        //{
        //    sql = "SELECT [ID] ,[内容] ,[录入人] ,[星级],[是否匿名]  FROM [评论] where [所属企业]=@companyID";
        //    return GetDataSet(sql, new SqlParameter[] { new SqlParameter("@companyID", companyID) });
        //}
    }
}
