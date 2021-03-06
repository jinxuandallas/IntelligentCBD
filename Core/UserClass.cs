﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
//using System.Web.Security;
using System.Security.Cryptography;
using System.Security;
using System.Web;

namespace Core
{
    public class UserClass : Database
    {
        public string Username { get; set; }
        public string Nickname { get; set; }
        public string Sex { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public UserClass()
        {

        }
        /// <summary>
        /// 验证用户名密码是否正确
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>返回布尔值</returns>
        public bool ValidateUser(string username, string password)
        {
            string sql = "select 盐值 from 用户 where 用户名=@username", salt;
            using (SqlDataReader sdr = GetDataReader(sql, new SqlParameter[] { new SqlParameter("@username", username) }))
            {
                if (sdr.Read())
                    salt = sdr[0].ToString();
                else return false;
            }

            password = TransformPassword(password, ref salt);

            sql = "select 用户名 from 用户 where 用户名=@username and 密码=@password";
            using (SqlDataReader sdr = GetDataReader(sql, new SqlParameter[] { new SqlParameter("@username", username),
                new SqlParameter("@password", password) }))
            {
                if (sdr.Read()) return true;
                else return false;
            }

        }

        /// <summary>
        /// 将密码明文转换为散列值
        /// </summary>
        /// <param name="password">原密码</param>
        /// <param name="salt">作为引用的盐值字符串。使用前先检查传入的盐值是否为空，如果已有则已有盐值生成新密码，如果无则生成随机盐值</param>
        /// <returns>返回散列的密码值</returns>
        public string TransformPassword(string password, ref string salt)
        {
            //string ret = string.Empty;

            //检查盐值是否为空，如果已有则已有盐值生成新密码，如果无则生成随机盐值
            if (string.IsNullOrEmpty(salt))
            {
                //生成盐值
                byte[] saltBytes = new byte[16];
                System.Security.Cryptography.RandomNumberGenerator rng = System.Security.Cryptography.RandomNumberGenerator.Create();
                rng.GetBytes(saltBytes);
                salt = Convert.ToBase64String(saltBytes);
            }
            //System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile已过时
            //ret = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile((salt + password), "SHA1");

            HashAlgorithm ha = HashAlgorithm.Create("SHA1");

            //另一种哈希算法
            //SHA1 shaM = new SHA1Managed();
            //byte[] newPassword = shaM.ComputeHash(Encoding.UTF8.GetBytes(salt + password));
            //SHA1 sha1 = new SHA1CryptoServiceProvider();
            //byte[] newPassword = sha1.ComputeHash(Encoding.UTF8.GetBytes( password+salt));
            //saltPassword = salt + password;
            //byte[] tp = new byte[27];

            byte[] newPassword = ha.ComputeHash(Encoding.UTF8.GetBytes(salt + password));
            
            //ret = Encoding.UTF8.GetString(data);
            //ret = BitConverter.ToString(data);
            //ret = Convert.ToBase64String(data);
            //newPassword.CopyTo(tp, 0);
            
            //经过测试只能用Convert.ToBase64String方法将byte[]转换成字符串；
            return Convert.ToBase64String(newPassword);
        }

        /// <summary>
        /// 注册用户（已包含对主键用户名重复的验证）
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">明文密码</param>
        /// <returns>返回是否注册成功</returns>
        public bool CreateUser(string userName, string password,int accountType)
        {
            //验证用户名是否已经注册过

            if (!ValidateUserName(userName)) return false;

            //转换密码
            string salt = null, Password;
            Password = TransformPassword(password, ref salt);

            //注册用户
            
            sql = "insert into [用户] (用户名,密码,盐值,账户类型) values (@username,@password,@salt,@type)";
            ExecuteSql(sql, new SqlParameter[]{
                    new SqlParameter("@username",userName),
                    new SqlParameter("@password",Password),
                    new SqlParameter("@salt",salt),
                    new SqlParameter("@type",accountType)
            });
            
            
            return true;
        }

        /// <summary>
        /// 验证用户名在数据库中是否已重复注册
        /// </summary>
        /// <param name="userName">要验证的用户名</param>
        /// <returns>不存在则返回ture，存在则返回false</returns>
        public bool ValidateUserName(string userName)
        {
            sql = "select 用户名 from 用户 where 用户名=@username";
            using (SqlDataReader sdr = GetDataReader(sql, new SqlParameter[] { new SqlParameter("@username", userName) }))
            {
                if (sdr.Read()) return false;
                else return true;
            }
        }

        /// <summary>
        /// 更新存于UserClass对象中的用户详细信息（更新时务必保证所有数据保存于UserClass类的访问器中）
        /// </summary>
        /// <param name="username">要更新的用户名</param>
        /// <returns>返回是否更新成功</returns>
        public bool UpdateDetails(string username)
        {
            sql = "update [用户] set 昵称=@nickname,性别=@sex,手机号码=@phone,电子邮箱=@email,密保问题=@question,密保答案=@answer where 用户名=@username";
            int rtn=ExecuteSql(sql, new SqlParameter[] { new SqlParameter("@username",username),
                new SqlParameter("@nickname",Nickname),
                new SqlParameter("@sex",Sex),
                new SqlParameter("@phone",Phone),
                new SqlParameter("@email",Email),
                new SqlParameter("@question",Question),
                new SqlParameter("@answer",Answer)
            });
            if (rtn == 1) return true;
            else return false;

        }
        /// <summary>
        /// 获取用户详细信息
        /// </summary>
        /// <param name="username">要返回信息的用户名</param>
        /// <returns>返回SqlDataReader对象</returns>
        public SqlDataReader GetDetails(string username)
        {
            sql = "select 昵称,性别,手机号码,电子邮箱,密保问题,密保答案 from [用户] where 用户名=@username";
            return  GetDataReader(sql, new SqlParameter[] { new SqlParameter("@username", username) }); 
            
        }

        /// <summary>
        /// 更换密码
        /// </summary>
        /// <param name="username">要更换的用户名</param>
        /// <param name="newPassowrd">新的密码</param>
        /// <returns>更新是否成功</returns>
        public bool UpdatePassword(string username,string newPassowrd)
        {
            string password, sql,salt = null;
            //获取新的密码和盐值
            password = TransformPassword(newPassowrd,ref salt);

            //更新新秘密和新盐值
            sql = "update [用户] set 密码=@password,盐值=@salt where 用户名=@username";

            int rtn = ExecuteSql(sql, new SqlParameter[] { new SqlParameter("@username",username),
            new SqlParameter("@password",password),
            new SqlParameter("@salt",salt)});
            if (rtn == 1) return true;
            else return false;
        }

        /// <summary>
        /// 获取密保问题
        /// </summary>
        /// <param name="username">要获取密保问题的用户名</param>
        /// <returns>返回密保问题</returns>
        public string GetQuestion(string username)
        {
            sql = "select 密保问题 from [用户] where 用户名=@username";
            using (SqlDataReader sdr = GetDataReader(sql, new SqlParameter[] { new SqlParameter("@username", username) }))
            {
                if (sdr.Read())
                    return sdr[0].ToString();
                else
                    return null;
            }
        }

        /// <summary>
        /// 验证密保问题答案
        /// </summary>
        /// <param name="username">要验证的密保问题的用户名</param>
        /// <param name="answer">提供的密保答案</param>
        /// <returns>返回是否验证通过</returns>
        public bool ValidateAnswer(string username,string answer)
        {
            sql = "select 用户名 from [用户] where 用户名=@username and 密保答案=@answer";
            using (SqlDataReader sdr = GetDataReader(sql, new SqlParameter[] { new SqlParameter("@username", username), new SqlParameter("@answer", answer) }))
            {
                if(sdr.Read())
                {
                    if (username == sdr[0].ToString())
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 修改用户的账户类型
        /// </summary>
        /// <param name="username">要修改的用户名</param>
        /// <param name="accountType">改为的账户类型值</param>
        /// <returns>返回是否成功</returns>
        public bool UpdateAccountType(string username,int accountType)
        {
            sql = "update [用户] set 账户类型=@accountType where 用户名=@username";
            int rtn = -1;
            rtn = ExecuteSql(sql, new SqlParameter[]
            {
                new SqlParameter ("@username",username),
                new SqlParameter ("@accountType",accountType)
            });
            if (rtn == 1)
                return true;
            return false;
        }

        /// <summary>
        /// 添加密码申诉
        /// </summary>
        /// <param name="username">申诉人</param>
        /// <param name="content">申诉内容（已经包括HTMLEncode）</param>
        /// <returns>返回是否添加成功</returns>
        public bool AddAppeal(string username,string content,string phone)
        {
            Guid id = Guid.NewGuid();
            sql = "insert 密码申诉 (ID,申诉人,申诉内容,联系电话) values(@ID,@username,@content,@phone)";
            int rtn = ExecuteSql(sql, new SqlParameter[]
            {
                new SqlParameter("@ID",id),
                new SqlParameter("@username",username),
                new SqlParameter("@content",HttpUtility.HtmlEncode(content)),
                new SqlParameter("@phone",HttpUtility.HtmlEncode(phone))
            });
            if (rtn == 1)
                return true;
            return false;
        }

        /// <summary>
        /// 判断用户是否以前申诉过
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>true为以前申诉过，false为未申诉过</returns>
        public bool HasAppel(string username)
        {
            sql = "select ID from 密码申诉 where 申诉人=@username";
            using (SqlDataReader sdr = GetDataReader(sql, new SqlParameter[] { new SqlParameter("@username", username) }))
            {
                if (sdr.Read())
                    return true;
                else
                    return false;
            }
        }
    }
}