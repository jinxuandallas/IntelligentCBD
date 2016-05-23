using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core;

namespace IntelligentCBD.Account
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /*
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx?url=" + System.Web.HttpUtility.UrlEncode(@"..\WebForm1.aspx"));
        }
        */
        protected void Submit_Click(object sender, EventArgs e)
        {
            //检查新秘密和重复输入密码是否一致
            if(NewPassword.Text!=ConfirmPassword.Text)
            {
                Label_Status.Text = "两次输入的密码需一致";
                return;
            }

            //检查原密码和新秘密是否不一致
            if (OriginalPassword.Text==NewPassword.Text)
            {
                Label_Status.Text = "原密码与新秘密需不一致";
                return;
            }
            UserClass uc = new UserClass();

            //验证原密码是否输入正确
            if (!uc.ValidateUser(Session["Username"].ToString(), OriginalPassword.Text))
            {
                Label_Status.Text = "原密码错误";
                return;
            }
            //更新密码
            if (uc.UpdatePassword(Session["Username"].ToString(), NewPassword.Text))
                Label_Status.Text = "密码修改成功";
            else Label_Status.Text = "密码修改失败";
        }
    }
}