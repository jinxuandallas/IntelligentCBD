using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelligentCBD.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            //返回登录前网页
            if (ViewState["UrlReferrer"] != null)
                Response.Redirect(ViewState["UrlReferrer"].ToString());
        }
    }
}