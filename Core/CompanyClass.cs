using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
//using System.Data;

namespace Core
{
    public class CompanyClass:Database
    {
        public CompanyClass()
        {

        }
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
