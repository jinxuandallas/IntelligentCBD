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
        protected Tools t;
        protected CommentClass commentc;

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
            //测试用

            if (Request.QueryString["query"] == null || string.IsNullOrWhiteSpace(Request.QueryString["query"]))
                Response.Redirect("~/default.aspx");
            commentc = new CommentClass();
            sc = new SearchClass();
            t = new Tools();


            if (!IsPostBack)
            {
                TextBoxSearch.Text = Request.QueryString["query"];

                //此处数据源绑定必须放在!IsPostBack判断里，否则ImageButton会报“回发或回调参数无效”错误
                DataSet ds = sc.GetSearchResult(Request.QueryString["query"]);

                ListViewResult.DataSource = ds;
                ListViewResult.DataBind();
            }

        }

        protected void ImgBtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Result.aspx?query=" + HttpUtility.UrlEncode(TextBoxSearch.Text));
        }

        
        protected void LinkButton企业名称_Click(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'>window.open('../Company/ShowCompany.aspx?comID="+(((LinkButton)sender).Parent.FindControl("LabelComID") as Label).Text + "');</script>");
            //Response.Write((((LinkButton)sender).Parent.FindControl("LabelComID") as Label).Text);
        }

       

        protected void Image企业宣传图片_Click(object sender, ImageClickEventArgs e)
        {
            Response.Write("<script language='javascript'>window.open('../Company/ShowCompany.aspx?comID=" + (((ImageButton)sender).Parent.FindControl("LabelComID") as Label).Text + "');</script>");
            //Response.Write((((ImageButton)sender).Parent.FindControl("LabelComID") as Label).Text);
        }
    }
}