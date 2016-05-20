using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelligentCBD.MasterPage
{
    public partial class MenuSite : System.Web.UI.MasterPage
    {
        /// <summary>
        /// 在此处添加代码是要早于内容页的Page_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Init(object sender, EventArgs e)
        {
            //测试用
            Session["Username"] = "a3";
            if (Session["Username"] == null || Session["Username"].ToString().Trim()=="") Response.Redirect("~/Account/Login.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //测试用
            //Session["Username"] = "s345";
            //if (Session["Username"] == null) Response.Redirect("~/Account/Login.aspx");

        }

        protected void LoginStatus1_LoggedOut(object sender, EventArgs e)
        {
            Session.Remove("Username");
        }

        /*protected void Page_PreRender(object sender,EventArgs e)
        {
            if (Session["Username"] == null) Response.Redirect("~/Account/Login.aspx");
        }
        protected void Page_PreRenderComplete(object sender, EventArgs e)
        {
            if (Session["Username"] == null) Response.Redirect("~/Account/Login.aspx");
        }
        */
    }
}