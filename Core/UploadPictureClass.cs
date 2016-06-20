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
            DataSet ds = GetDataSet("select 图片地址 from 图片 where 所属企业=@comID", new SqlParameter[] { new SqlParameter("@comID", comID) });
            ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns[0] };
            //ds.Tables[0].Columns.Add(new DataColumn("Num",Type.GetType("System.Int")));
            //for(int i=1;i<6;i++)
            return ds;
        }
        */
        /// <summary>
        /// 为了下一步判断是否为企业宣传页即设定默认图片做准备（已解决）
        /// </summary>
        /// <param name="comID">要检索的企业ID</param>
        /// <param name="picType">要检索的图片类型</param>
        /// <returns>返回检索结果</returns>
        public DataSet GetPicbyCompany(Guid comID,int picType)
        {
            DataSet ds = GetDataSet("select 图片地址 from 图片 where 所属企业=@comID and 图片类型=@picType", new SqlParameter[] { new SqlParameter("@comID", comID),
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
                    ln.Add(ll[i].Replace("Upload/", "~/FileUpload/Upload/"));
            }

            return ln;
        }

        /// <summary>
        /// 删除服务端文件
        /// </summary>
        /// <param name="ls">包含文件的相对路径</param>
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
        /// <returns>返回是否成功</returns>
        public bool DelDbPic(List<string> ls)
        {
            string sql;
            foreach (string s in ls)
            {
                //删除图片还要判断是否是默认图片，并在企业表中更新默认图片记录
                sql = @"declare @pucid uniqueidentifier;
                        set @picid = (select ID from [图片] where 图片地址 = @picpath);
                        update [企业] set 默认图片='' where 默认图片=@picid;
                        delete from [图片] where ID=@picid";
                //sql = "delete from [图片] where 图片地址=@picpath ";
                int rtn = ExecuteSql(sql, new SqlParameter[] { new SqlParameter("@picpath", s) });
                if (rtn < 1)
                    return false;
            }
            return true;
        }

        public string UploadPic(HttpFileCollection uploadFiles,string filepath,int picType,Guid companyID)
        {
            if (uploadFiles.Count < 1)
                return string.Empty;
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
                        newFilename = DateTime.Now.ToString("yyyyMMddhhmmss") +picType +i + extName;
                        
                        //上传文件
                        newFilepath = filepath + newFilename;
                        postedFile.SaveAs(newFilepath);

                        //添加新的数据库记录
                        bool result = AddPic(newFilename,companyID,picType);
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

        public string ExamFiles(HttpFileCollection uploadFiles, int picType, Guid companyID)
        {
            int filesSize = 0;
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

        public bool AddPic(string filename,Guid comID,int picType)
        {
            Guid ID = Guid.NewGuid();
            //只能服务器使用相对路径，使用绝对路径客户端打不开（调用的是客户端文件）
            string filepath = "~/Upload/UploadCompanyPicture/" + filename;
            string sql = "insert 图片(ID,所属企业,图片类型,图片地址) values(@ID,@comID,@picType,@filepath)";
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
    }
}
