using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelligentCBD.Search
{
    public partial class Result : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //测试
            //Response.Write(HttpUtility.UrlDecode(Server.HtmlEncode(Request.QueryString["query"])));
            /*string s = string.IsNullOrWhiteSpace("") ? "ok" : "no";
            Response.Write(s);*/

            if (!string.IsNullOrWhiteSpace(Request.QueryString["query"]))
                Response.Redirect("~/default.aspx");

        }
    }
}