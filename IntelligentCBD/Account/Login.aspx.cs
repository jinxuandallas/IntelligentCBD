﻿using System;
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

            

            //验证是否登陆成功
            bool result = uc.ValidateUser(UserLogin.UserName, UserLogin.Password);
            if (result)
            {
                e.Authenticated = result;

                Session["Username"] = UserLogin.UserName;

                //Response.Redirect(Request.Url.ToString());

                //return;

                //判断是否有QueryString["url"]，如有直接跳转到参数指定的页面
                //此处只能使用UserLogin.DestinationPageUrl =""，不能使用Response.Redirect，否则登陆控件没有刷新
                if (Request.QueryString["url"] != null)
                    UserLogin.DestinationPageUrl = System.Web.HttpUtility.UrlDecode(Request.QueryString["url"].ToString());

                //返回登录前网页
                else if (ViewState["UrlReferrer"] != null)
                    UserLogin.DestinationPageUrl = ViewState["UrlReferrer"].ToString();
                else
                    UserLogin.DestinationPageUrl = "~/default.aspx";






            }
        }
    }
}