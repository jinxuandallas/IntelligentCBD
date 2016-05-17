using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
//using System.Web.Security;
using System.Security.Cryptography;
using System.Security;

namespace Core
{
    public class UserClass : Database
    {
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
        /// 注册用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">明文密码</param>
        /// <returns>返回是否注册成功</returns>
        public bool CreateUser(string userName, string password)
        {
            //验证用户名是否已经注册过

            if (!ValidateUserName(userName)) return false;

            //转换密码
            string salt = null, Password;
            Password = TransformPassword(password, ref salt);

            //注册用户
            try
            {
                string sql = "insert into [用户] (用户名,密码,盐值) values (@username,@password,@salt)";
                Insert(sql, new SqlParameter[]{
                    new SqlParameter("@username",userName),
                    new SqlParameter("@password",Password),
                    new SqlParameter("@salt",salt)
                });
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

        /// <summary>
        /// 验证用户名在数据库中是否已重复注册
        /// </summary>
        /// <param name="userName">要验证的用户名</param>
        /// <returns>不存在则返回ture，存在则返回false</returns>
        public bool ValidateUserName(string userName)
        {
            string sql = "select 用户名 from 用户 where 用户名=@username";
            using (SqlDataReader sdr = GetDataReader(sql, new SqlParameter[] { new SqlParameter("@username", userName) }))
            {
                if (sdr.Read()) return false;
                else return true;
            }
        }
    }
}