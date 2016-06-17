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
    }
}
