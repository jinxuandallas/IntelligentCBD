using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core;

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
            Session["Username"] = System.Configuration.ConfigurationManager.AppSettings["username"];

            if (Session["Username"] == null || Session["Username"].ToString().Trim()=="")
                Response.Redirect("~/Account/Login.aspx");
            if(!IsPostBack)
            {
                CompanyClass cc = new CompanyClass();
                string type = cc.GetAccountType(Session["Username"].ToString());
                //为不同的账户类型绑定不同的站点地图
                switch (type)
                {
                    case "个人":
                        SiteMapDataSource1.SiteMapProvider = "Individualsitemap";
                        break;
                    //商户和管理员共用Companysitemap站点地图
                    case "商户":
                    case "管理员":
                        SiteMapDataSource1.SiteMapProvider = "Companysitemap";
                        break;
                    default:
                        Response.Redirect("~/Account/Login.aspx");
                        break;
                }
                
            }
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