using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core;

namespace IntelligentCBD.Account
{
    public partial class RegisterUser : System.Web.UI.Page
    {
        protected UserClass uc;
        protected void Page_Load(object sender, EventArgs e)
        {
            uc = new UserClass();
            if (!IsPostBack)
            {
                //用户名文本框获得焦点 
                ScriptManager1.SetFocus(UserName);
            }
        }

        protected void UserName_TextChanged(object sender, EventArgs e)
        {
            if (uc.ValidateUserName(UserName.Text))
            {
                Label1.Text = "可以使用";

            }
            else
            {
                Label1.Text = "用户名已被占用";
                //ScriptManager.RegisterStartupScript(this.UpdatePanel1, UpdatePanel1.GetType(), "", "document.getElementById('UserName').select();", true);
            }

            //检查完用户名后自动将焦点对准下一个输入密码控件，防止网页一片“蓝色选定”
            ScriptManager1.SetFocus(Password);

        }
    }
}