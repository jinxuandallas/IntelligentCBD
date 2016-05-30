﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
//using System.Data;

namespace Core
{
    public class CompanyClass : Database
    {
        public Guid ID { get; set; }
        public string CompanyName {get;set;}
        public long Capital { get; set; }
        public string Industry { get; set; }
        public int Area { get; set; }
        public string RoomNum { get; set; }
        public string Address { get; set; }
        public string Vector { get; set; }
        public string Introduction { get; set; }

        public string BusinessScope { get; set; }
        public string RegisteredAddress { get; set; }
        public string RegistrationDate { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string QQ { get; set; }
        public string Content { get; set; }
        public CompanyClass()
        {

        }

        /// <summary>
        /// 获取用户的账户类型
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>返回账户类型字符串</returns>
        public string GetAccountType(string username)
        {
            string sql = "select 类型 from [用户视图] where 用户名=@username";
            using (SqlDataReader sdr = GetDataReader(sql, new SqlParameter[] { new SqlParameter("@username", username) }))
            {
                if (sdr.Read())
                    return sdr[0].ToString();
                else
                    return "";
               
            }
        }
    }
}