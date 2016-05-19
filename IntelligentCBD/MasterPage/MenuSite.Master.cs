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
        protected void Page_Load(object sender, EventArgs e)
        {
            //测试用
            Session["Username"] = "s345";
            if (Session["Username"] == null) Response.Redirect("~/Account/Login.aspx");

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