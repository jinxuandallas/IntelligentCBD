using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Data.SqlClient;

namespace Core
{
    public class CommentClass:Database
    {
        public CommentClass()
        {

        }
        //public string UploadCommentPic(HttpFileCollection uploadFiles, string filepath, Guid commentID)
        //{
            //if (uploadFiles.Count < 1)
            //    return string.Empty;
            
            //检查文件大小与类型
            //string examResult = ExamFiles(uploadFiles, picType, companyID);
            //if (examResult != "文件检查成功")
            //    return examResult;

            ////检查目录是否存在
            //if (!System.IO.Directory.Exists(filepath))//判断文件夹是否已经存在
            //{
            //    System.IO.Directory.CreateDirectory(filepath);//创建文件夹
            //}

            ////上传文件
            //string extName, newFilename, newFilepath;
            //for (int i = 0; i < uploadFiles.Count; i++)
            //{
            //    HttpPostedFile postedFile = uploadFiles[i];
            //    try
            //    {
            //        if (postedFile.ContentLength > 0)
            //        {
            //            //产生新的文件名
            //            extName = System.IO.Path.GetExtension(postedFile.FileName).ToLower();
            //            // 生成随机文件名
            //            Random random = new Random(DateTime.Now.Millisecond);
            //            newFilename = DateTime.Now.ToString("yyyyMMddhhmmss") + random.Next(10000) + picType + i + extName;

            //            //上传文件
            //            newFilepath = filepath + newFilename;
            //            postedFile.SaveAs(newFilepath);

            //            //添加新的数据库记录
            //            bool result = AddCompanyDbPic(newFilename, companyID, picType);
            //            if (!result)
            //                return "上传记录不成功";

        //            }
        //        }
        //        catch (Exception Ex)
        //        {
        //            throw Ex;
        //        }
        //    }
        //    return "";
        //}


        public Guid AddComment(Guid companyID,string username,int score,string comment,bool anonymity)
        {
            Guid ID = Guid.NewGuid();
            sql = @"insert into 评论(ID,所属企业,录入人,星级,内容,[是否匿名]) values (@ID,@companyID,@username,@score,@comment,@anonymity) 
            exec 添加评分 @ID,@score";

            ExecuteTranSQL(sql, new SqlParameter[] {new SqlParameter("@ID",ID),
                new SqlParameter("@companyID",companyID),
                new SqlParameter("@username",username),
                new SqlParameter("@score",score),
                new SqlParameter("@comment",comment),
                new SqlParameter("@anonymity",anonymity)
            });

            return ID;
        }
    }
}
