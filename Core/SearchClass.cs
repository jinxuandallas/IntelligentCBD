using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Core
{
    public class SearchClass :Database
    {
        public SearchClass()
        {

        }

        public DataSet GetSearchResult(string queryString)
        {
            return new DataSet();
        }
    }
}
