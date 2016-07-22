using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;


namespace Core
{
    public class UploadPictureClass:Database
    {
        public UploadPictureClass()
        {

        }

        /*
        public DataSet GetPicbyCompany(Guid comID)
        {
            DataSet ds = GetDataSet("select 图片地址 from 企业图片 where 所属企业=@comID", new SqlParameter[] { new SqlParameter("@comID", comID) });
            ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns[0] };
            //ds.Tables[0].Columns.Add(new DataColumn("Num",Type.GetType("System.Int")));
            //for(int i=1;i<6;i++)
            return ds;
        }
        */
        /// <summary>
        /// 获取已存在于数据库中的图片
        /// </summary>
        /// <param name="comID">要检索的企业ID</param>
        /// <param name="picType">要检索的图片类型</param>
        /// <returns>返回检索结果</returns>
        public DataSet GetPicbyCompany(Guid comID,int picType)
        {
            DataSet ds = GetDataSet("select 图片地址 from 企业图片 where 所属企业=@comID and 图片类型=@picType", new SqlParameter[] { new SqlParameter("@comID", comID),
            new SqlParameter("@picType",picType) });
            ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns[0] };
            //ds.Tables[0].Columns.Add(new DataColumn("Num",Type.GetType("System.Int")));
            //for(int i=1;i<6;i++)
            return ds;
        }

        /// <summary>
        /// 将存有多个文件名的字符串转换成List泛型的文件列表（包括客户端地址与服务器端地址转换）
        /// </summary>
        /// <param name="filestring">存有多个文件名的字符串</param>
        /// <returns>返回转换后的泛型列表</returns>
        public List<string> GetFileList(string filestring)
        {
            List<string> ll = filestring.Split(';').ToList<string>();
            List<string> ln = new List<string>();
            for (int i = 0; i < ll.Count; i++)
            {
                if (!string.IsNullOrWhiteSpace(ll[i]))
                    ///将客户端地址转换成服务端地址（数据库地址）
                    ///**此处还需根据具体目录重新修改
                    ln.Add(ll[i].Replace("../Upload", "~/Upload"));
            }

            return ln;
        }

        /// <summary>
        /// 删除服务端文件
        /// </summary>
        /// <param name="ls">包含文件的相对路径（服务器端的虚拟路径，已经过转换）</param>
        /// <returns>返回是否成功</returns>
        public bool DelPicFile(List<string> ls)
        {
            foreach (string s in ls)
            {
                File.Delete(HttpContext.Current.Server.MapPath(s));
            }
            return true;
        }


        /// <summary>
        /// 删除图片在数据库中的记录
        /// </summary>
        /// <param name="ls">包含要删除文件的泛型列表</param>
        /// <param name="companyID">要删除的企业ID，此参数是为了判断查找删除的文件是不是企业的默认图片而用</param>
        /// <returns>返回是否成功</returns>
        public bool DelDbPic(List<string> ls,Guid companyID)
        {
            foreach (string s in ls)
            {
                //删除图片还要判断是否是默认图片，并在企业表中更新默认图片记录
                //判断更新企业表还可以改为更有效率版本**
                sql = @"declare @picid uniqueidentifier;
                        set @picid = (select ID from [企业图片] where 图片地址 = @picpath);
                        if @picid=(select 默认图片 from 企业 where 企业.ID=@companyID)
                        begin
                            update [企业] set 默认图片=null where ID=@companyID;
                        end
                        delete from [企业图片] where ID=@picid";
                //sql = "delete from [企业图片] where 图片地址=@picpath ";
                bool resulat = ExecuteTranSQL(sql, new SqlParameter[] { new SqlParameter("@picpath",s),
                new SqlParameter("@companyID",companyID)
                });
                if (!resulat)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 上传图片文件
        /// </summary>
        /// <param name="uploadFiles">包含要上传文件的HttpFileCollection</param>
        /// <param name="filepath">文件的服务端绝对路径</param>
        /// <param name="picType">要上传的图片类型</param>
        /// <param name="companyID">要上传的企业ID</param>
        /// <returns></returns>
        public string UploadCompanyPic(HttpFileCollection uploadFiles,string filepath,int picType,Guid companyID)
        {
            //检查文件个数
            if (uploadFiles.Count < 1||uploadFiles.Count>5)
                return "上传失败";

            //检查文件大小与类型
            string examResult = ExamFiles(uploadFiles, picType, companyID);
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
                        newFilename = DateTime.Now.ToString("yyyyMMddhhmmss") + random.Next(10000) + picType + i + extName;
                        
                        //上传文件
                        newFilepath = filepath + newFilename;
                        postedFile.SaveAs(newFilepath);

                        //添加新的数据库记录
                        bool result = AddCompanyDbPic(newFilename,companyID,picType);
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

        /// <summary>
        /// 检查上传文件的大小和类型是否符合规定
        /// </summary>
        /// <param name="uploadFiles">包含要上传文件的HttpFileCollection</param>
        /// <param name="picType">要上传的图片类型</param>
        /// <param name="companyID">要上传的企业ID</param>
        /// <returns></returns>
        public string ExamFiles(HttpFileCollection uploadFiles, int picType, Guid companyID)
        {
            int filesSize = 0;

            //获取已存在的文件，便于下一步取得已存在文件的大小
            DataSet ds = GetPicbyCompany(companyID,picType);
            System.IO.FileInfo fi;

            //检查存于数据库中的文件大小，用于计算所有上传文件是否超过5M
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                fi = new FileInfo(HttpContext.Current.Server.MapPath(dr[0].ToString()));
                filesSize += int.Parse(fi.Length.ToString());
            }


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
        /// 添加上传图片记录到数据库中
        /// </summary>
        /// <param name="filename">上传的文件名（不包括路径）</param>
        /// <param name="comID">要上传的企业ID</param>
        /// <param name="picType">图片类型</param>
        /// <returns></returns>
        public bool AddCompanyDbPic(string filename,Guid comID,int picType)
        {
            Guid ID = Guid.NewGuid();
            //只能服务器使用相对路径，使用绝对路径客户端打不开（调用的是客户端文件）
            string filepath = "~/Upload/UploadCompanyPicture/" + filename;
            sql = "insert 企业图片(ID,所属企业,图片类型,图片地址) values(@ID,@comID,@picType,@filepath)";
            int rtn = ExecuteSql(sql, new SqlParameter[] {
                new SqlParameter("@ID",ID),
                new SqlParameter("@comID",comID),
                new SqlParameter("@picType",picType),
                new SqlParameter("@filepath", filepath)
            });
            if (rtn == 1)
                return true;
            return false;
        }

        /// <summary>
        /// 更新默认图片
        /// </summary>
        /// <param name="companyID">企业ID</param>
        /// <param name="picPath">客户端的默认图片地址</param>
        /// <returns></returns>
        public bool UpdateDefaultPic(Guid companyID,string picPath)
        {
            //将客户端的默认图片地址转换为服务器端的图片地址
            picPath = picPath.Replace("../Upload", "~/Upload");

            sql = "update [企业] set 默认图片=(select ID from [企业图片] where 图片地址=@picpath) where ID=@companyID";
            int rtn = ExecuteSql(sql, new SqlParameter[]
            {
                new SqlParameter("@picpath",picPath),
                new SqlParameter("@companyID",companyID)
            });
            if (rtn == 1)
                return true;
            return false;
        }

        /// <summary>
        /// 获取企业的默认图片地址
        /// </summary>
        /// <param name="companyID">企业ID</param>
        /// <returns></returns>
        public string GetDefaultPic(Guid companyID)
        {
            sql = "select 企业图片.图片地址 from 企业,企业图片 where (企业.ID=@companyID) and (企业.默认图片=企业图片.ID)";
            using (SqlDataReader sdr = GetDataReader(sql, new SqlParameter[] { new SqlParameter("@companyID", companyID) }))
            {
                if (sdr.Read())
                    return sdr[0].ToString();
                else
                    return string.Empty;
            }
        }
    }
}
