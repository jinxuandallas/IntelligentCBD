﻿using System;
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
        /// 上传评论图片
        /// </summary>
        /// <param name="uploadFiles">包含所有上传文件的HttpFileCollection</param>
        /// <param name="filepath">在服务器端的文件路径</param>
        /// <param name="commentID">评论ID</param>
        /// <returns>返回上传结果</returns>
        public string UploadCommentPic(HttpFileCollection uploadFiles, string filepath, Guid commentID)
        {
            //检查文件个数
            if (uploadFiles.Count < 1 || uploadFiles.Count > 5)
                return "上传文件数大于5或者小于1";

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
            return "上传成功";
        }

        /// <summary>
        /// 添加评论图片的数据库信息
        /// </summary>
        /// <param name="filename">图片的文件名</param>
        /// <param name="commentID">评论ID</param>
        /// <returns>返回是否成功</returns>
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

        /// <summary>
        /// 添加评论
        /// </summary>
        /// <param name="companyID">所属企业</param>
        /// <param name="username">录入人</param>
        /// <param name="score">星级</param>
        /// <param name="comment">评论内容（已包含HtmlEncode处理）</param>
        /// <param name="anonymity">是否匿名</param>
        /// <returns>返回新评论的ID</returns>
        public Guid AddComment(Guid companyID,string username,int score,string comment,bool anonymity)
        {
            Guid ID = Guid.NewGuid();
            sql = @"insert into 评论(ID,所属企业,录入人,星级,内容,[是否匿名]) values (@ID,@companyID,@username,@score,@comment,@anonymity) 
            exec 添加评分 @companyID,@score";

            ExecuteTranSQL(sql, new SqlParameter[] {new SqlParameter("@ID",ID),
                new SqlParameter("@companyID",companyID),
                new SqlParameter("@username",username),
                new SqlParameter("@score",score),
                new SqlParameter("@comment",HttpUtility.HtmlEncode(comment)),
                new SqlParameter("@anonymity",anonymity)
            });

            return ID;
        }

        //public DataSet GetComments(Guid companyID)
        //{
        //    sql = "SELECT [ID] ,[内容] ,[录入人] ,[星级],[是否匿名]  FROM [评论] where [所属企业]=@companyID";
        //    return GetDataSet(sql, new SqlParameter[] { new SqlParameter("@companyID", companyID) });
        //}

        /// <summary>
        /// 自动生成匿名账户的用户名显示内容
        /// </summary>
        /// <param name="username">录入人</param>
        /// <param name="anonymity">是否匿名</param>
        /// <returns>返回处理过的用户名</returns>
        public string ShowAnonymity(string username,int anonymity)
        {
            if (anonymity == 1)
                return username.Substring(0, 1) + "***" + username.Substring(username.Length - 1)+"（匿名）";
            else
                return username;
        }

        /// <summary>
        /// 将长时间转换为需要的短时间格式
        /// </summary>
        /// <param name="date">长时间字符串</param>
        /// <returns>返回符合格式需要的短时间字符串</returns>
        public string ConvertDate(string date)
        {
            DateTime dt;
            bool result = DateTime.TryParse(date,out dt);
            if(result)
                return dt.ToString("yyyy.MM.dd");
            else
                return "";

        }

        /// <summary>
        /// 获取评论图片
        /// </summary>
        /// <param name="commentID">要获取的评论ID</param>
        /// <returns>返回DataSet的图片地址表</returns>
        public DataSet GetCommentPic(Guid commentID)
        {
            sql = "select 图片地址 from 评论图片 where 所属评论=@CommentID";
            return GetDataSet(sql, new SqlParameter[] { new SqlParameter("@CommentID", commentID) });
        }

        /// <summary>
        /// 获取评论
        /// </summary>
        /// <param name="companyID">企业ID</param>
        /// <returns>返回包含当前企业的所有评论DataSet</returns>
        public DataSet GetComments(Guid companyID)
        {
            sql = "SELECT [ID], [内容], [录入人], [星级], [录入时间], [是否匿名] FROM [评论] WHERE ([所属企业] = @所属企业)";
            return GetDataSet(sql, new SqlParameter[] { new SqlParameter("@所属企业", companyID) });
        }

        /// <summary>
        /// 调用数据库计算出企业的星级评分
        /// </summary>
        /// <param name="companyID">企业ID</param>
        /// <returns>返回星级评分</returns>
        public double GetCompanyStar(Guid companyID)
        {
            sql = "exec [dbo].[获取企业星级] @companyID";
            using (SqlDataReader sdr = GetDataReader(sql, new SqlParameter[] { new SqlParameter("@companyID", companyID) }))
            {
                if (sdr.Read())
                    return double.Parse(sdr[0].ToString());
                else
                    return 0.0;
            }
        }

        /// <summary>
        /// 获取当前用户的所有企业评论（14天内）
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>返回一个DataSet</returns>
        public DataSet GetManagementComments(string username)
        {
            sql = "select ID,企业名称,内容,录入人,录入时间,星级 from 评论企业视图  where (所属企业 in (select ID from 企业 where 录入人=@username)) and (DATEDIFF(DAY,录入时间,GETDATE())<=14)";
                //select * from 评论 where (DATEDIFF(DAY,录入时间,GETDATE())<=14) and 录入人=@username";
            return GetDataSet(sql, new SqlParameter[] { new SqlParameter("@username", username) });
        }


        /// <summary>
        /// 添加评论解释
        /// </summary>
        /// <param name="commentID">评论ID</param>
        /// <param name="content">解释内容</param>
        /// <param name="username">录入人</param>
        /// <returns>返回是否成功</returns>
        public bool AddExplanation(Guid commentID,string content,string username)
        {
            Guid ExplanationID = Guid.NewGuid();
            sql = "insert 解释 (ID,所属评论,内容,录入人) values (@ID,@comment,@content,@username) update 评论 set 是否有解释=1 where ID=@comment";
            bool result = ExecuteTranSQL(sql, new SqlParameter[] { new SqlParameter("@ID",ExplanationID),
            new SqlParameter("@comment",commentID),
            new SqlParameter("@content",content),
            new SqlParameter("@username",username)});
            return result;
        }

        /// <summary>
        /// 返回评论是否有追加解释
        /// </summary>
        /// <param name="commentID">评论ID</param>
        /// <returns>返回是否有追加解释</returns>
        public bool HasExplanation(Guid commentID)
        {
            sql = "select 是否有解释 from 评论 where ID=@commentID";
            using (SqlDataReader sdr = GetDataReader(sql, new SqlParameter[] { new SqlParameter("@commentID", commentID) }))
            {
                if (sdr.Read())
                    if (bool.Parse(sdr[0].ToString()))
                        return true;
            }
            return false;
        }

        /// <summary>
        /// 获取评论的解释内容
        /// </summary>
        /// <param name="commentID">评论ID</param>
        /// <returns>返回解释内容</returns>
        public string GetExplanation(Guid commentID)
        {
            sql = "select 内容 from 解释 where 所属评论=@commentID";
            using (SqlDataReader sdr = GetDataReader(sql, new SqlParameter[] { new SqlParameter("@commentID", commentID) }))
            {
                if (sdr.Read())
                    return sdr[0].ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取当前企业的评论总数
        /// </summary>
        /// <param name="companyID">企业ID</param>
        /// <returns>评论数量</returns>
        public int GetCommentSum(Guid companyID)
        {
            sql = "select count(ID) from 评论 where 所属企业=@companyID";
            using (SqlDataReader sdr = GetDataReader(sql, new SqlParameter[] { new SqlParameter("@companyID", companyID) }))
            {
                if (sdr.Read())
                    return int.Parse(sdr[0].ToString());
            }
            return 0;
        }

        /// <summary>
        /// 判断当前用户是否为企业主
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="companyID">企业ID</param>
        /// <returns>返回布尔变量</returns>
        public bool IsOwner(string username,Guid companyID)
        {
            sql = "select ID from 企业 where ID=@companyID and 录入人=@username";
            using (SqlDataReader sdr = GetDataReader(sql, new SqlParameter[] { new SqlParameter("@companyID", companyID),
            new SqlParameter("@username",username)}))
            {
                if (sdr.Read())
                    return true;
            }
            return false;
        }
    }
}
