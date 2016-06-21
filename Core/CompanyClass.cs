using System;
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

        /// <summary>
        /// 添加企业基本信息
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Guid AddCompanyBaseInformation(string username)
        {
            ID = Guid.NewGuid();
            int rtn = -1;
            string sql = @"insert [企业] (ID,[企业名称],[注册资本],[行业],[物业面积],[房间号],[地址],[企业简介],[经营范围],[注册日期],[注册地],[联系人],[联系电话],[QQ],[电子邮箱],[内容],[载体],[录入人],[审核])
                values (@id,@companyName,@capital,@industry,@area,@roomNum,@address,@introduction,@businessScope,@registrationDate,@registeredAddress,@contact,@phone,@QQ,@email,@content,@Vector,@inputUser,@audit) ";
            rtn=ExecuteSql(sql, new SqlParameter[]
            {
                new SqlParameter ("@id",ID),
                new SqlParameter("@companyName",CompanyName),
                new SqlParameter("@capital",Capital),
                new SqlParameter("@industry",Industry),
                new SqlParameter("@area",Area),
                new SqlParameter("@roomNum",RoomNum),
                new SqlParameter("@address",Address),
                new SqlParameter("@introduction",Introduction),
                new SqlParameter("@businessScope",BusinessScope),
                new SqlParameter("@registrationDate",RegistrationDate),
                new SqlParameter("@registeredAddress",RegisteredAddress),
                new SqlParameter("@contact",Contact),
                new SqlParameter("@phone",Phone),
                new SqlParameter("@QQ",QQ),
                new SqlParameter("@email",Email),
                new SqlParameter("@Vector",Vector),
                new SqlParameter("@content",Content),
                new SqlParameter("@inputUser",username),

                //新添加的企业审核状态设为“添加未审核”
                new SqlParameter("@audit",1)
            });

            if (rtn == 1)
                return ID;
            else
                return Guid.Empty;
        }
    }
}
