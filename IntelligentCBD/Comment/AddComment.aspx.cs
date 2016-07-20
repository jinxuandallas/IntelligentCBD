using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core;

namespace IntelligentCBD.Comment
{
    public partial class AddComment : System.Web.UI.Page
    {
        protected CompanyClass comc;
        protected Guid comID;
        protected void Page_Load(object sender, EventArgs e)
        {
            ///因为引用的是MainSite.Master，所以都要重新判断Session的Username、CompanyID属性是否存在
            //测试用
            Session["Username"] = System.Configuration.ConfigurationManager.AppSettings["username"];
            //测试用
            Session["CompanyID"] = System.Configuration.ConfigurationManager.AppSettings["companyID"];

            //此处必须先判断Session["Username"]是否为null否则后面的IsNullOrWhiteSpace会抛出异常
            if (Session["Username"] == null || string.IsNullOrWhiteSpace(Session["Username"].ToString()))
                Response.Redirect("~/Account/Login.aspx");

            if (Session["CompanyID"] == null || string.IsNullOrWhiteSpace(Session["CompanyID"].ToString()))
                Response.Redirect("~/Account/Login.aspx");

            comID = Guid.Parse(Session["CompanyID"].ToString());
            comc = new CompanyClass();
            LabelCompanyName.Text = comc.GetCompanyName(comID);
        }
    }
}