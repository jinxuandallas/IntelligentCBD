using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core;
using System.Data;

namespace IntelligentCBD.Search
{
    public partial class Result : System.Web.UI.Page
    {
        protected SearchClass sc;
        protected void Page_Load(object sender, EventArgs e)
        {
            //测试
            //Response.Write(Server.HtmlEncode(Request.QueryString["query"]));
            /*string s = string.IsNullOrWhiteSpace("") ? "ok" : "no";
            Response.Write(s);
            string s= Request.QueryString["query"];
            List<string> a = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries ).ToList<string>();
            foreach (string b in a)
                Response.Write(b + "<br/>");
                */
            if (Request.QueryString["query"]==null || string.IsNullOrWhiteSpace(Request.QueryString["query"]))
                Response.Redirect("~/default.aspx");

            if (!IsPostBack)
                TextBoxSearch.Text = Request.QueryString["query"];
            sc = new SearchClass();
            DataSet ds = sc.GetSearchResult(Request.QueryString["query"]);
            Repeater1.DataSource = ds;
            Repeater1.DataBind();

        }

        protected void ImgBtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Result.aspx?query=" + HttpUtility.UrlEncode(TextBoxSearch.Text));
        }
    }
}