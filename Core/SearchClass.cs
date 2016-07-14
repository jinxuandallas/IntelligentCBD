using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Core
{
    public class SearchClass :Database
    {
        public SearchClass()
        {

        }

        /// <summary>
        /// 根据查询关键词获取查询结果
        /// </summary>
        /// <param name="queryString">查询关键词</param>
        /// <returns>返回DataSet查询结果</returns>
        public DataSet GetSearchResult(string queryString)
        {
            DataSet result;
            string[] queryWord = queryString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);//RemoveEmptyEntries参数去掉多余的空格
            sql = @"SELECT   dbo.企业.ID, dbo.企业.企业名称, dbo.企业.注册资本, dbo.企业.行业, dbo.企业.物业面积, dbo.企业.房间号, 
                 dbo.企业.联系人,dbo.载体.载体名称,dbo.图片.图片地址
FROM      dbo.企业 LEFT OUTER JOIN
                dbo.载体 ON dbo.企业.载体 = dbo.载体.ID LEFT OUTER JOIN
                dbo.图片 ON dbo.企业.默认图片 = dbo.图片.ID where contains((企业名称,企业简介,经营范围),@para1) ";
            //SqlParameterCollection spc=new SqlParameterCollection();
            //spc.AddWithValue("@para1", queryWord[0]);
            SqlParameter [] sp=new SqlParameter[queryWord.Count<string>()];
            //s.
            sp[0] = new SqlParameter("@para1", ConvertSearchWord(queryWord[0]));
            if(queryWord.Count<string>()>1)
                for(int i=1;i< queryWord.Count<string>();i++)
                {
                    sql += "and contains((企业名称,企业简介,经营范围),@para" + (i + 1) + ")";
                    sp[i]= new SqlParameter("@para" + (i + 1), ConvertSearchWord(queryWord[i]));
                }

            result = GetDataSet(sql, sp);
            return result;
        }

        /// <summary>
        /// 转换查询关键字为全文检索能接受的字段
        /// </summary>
        /// <param name="queryWord">原查询关键词</param>
        /// <returns>转换后的关键词</returns>
        public string ConvertSearchWord(string queryWord)
        {
            string searchWord = queryWord.Replace("\"","\"\"");
            searchWord = "\"" + searchWord + "\"";
            return searchWord;
        }
    }
}
