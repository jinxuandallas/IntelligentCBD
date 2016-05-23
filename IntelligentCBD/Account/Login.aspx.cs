using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core;

namespace IntelligentCBD.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected UserClass uc;
        protected void Page_Load(object sender, EventArgs e)
        {
            uc = new UserClass();
            if (!IsPostBack)
            {
                if (Request.UrlReferrer != null)
                {
                    ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
                }
            }
        }

        protected void UserLogin_Authenticate(object sender, AuthenticateEventArgs e)
        {
            /*
            //验证是否登陆成功
            e.Authenticated = uc.ValidateUser(UserLogin.UserName, UserLogin.Password);
            //返回登录前网页
            if (ViewState["UrlReferrer"] != null)
                Response.Redirect(ViewState["UrlReferrer"].ToString());
                */

            if (Request.QueryString["url"]!=null) Response.Redirect(System.Web.HttpUtility.UrlDecode(Request.QueryString["url"].ToString()));
            //返回登录前网页
            if (ViewState["UrlReferrer"] != null)
                UserLogin.DestinationPageUrl=ViewState["UrlReferrer"].ToString();
            //验证是否登陆成功
            e.Authenticated = uc.ValidateUser(UserLogin.UserName, UserLogin.Password);
            Session["Username"] = UserLogin.UserName;
        }
    }
}