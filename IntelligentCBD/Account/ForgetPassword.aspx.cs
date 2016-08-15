using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core;

namespace IntelligentCBD.Account
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        private string Question;
        protected UserClass uc;
        protected string username;

        protected void Page_Load(object sender, EventArgs e)
        {
            //此处还未登录，没有Session，不用验证
            //此处必须先判断Session["Username"]是否为null否则后面的IsNullOrWhiteSpace会抛出异常
            //if (Session["Username"] == null || string.IsNullOrWhiteSpace(Session["Username"].ToString()))
            //    Response.Redirect("Login.aspx");
            uc = new UserClass();
            if (!IsPostBack)
                MultiView1.ActiveViewIndex = 0;
            if (ViewState["username"] != null&& !string.IsNullOrWhiteSpace(ViewState["username"].ToString()))
                username = ViewState["username"].ToString();
        }

        
        protected void SubmitAppeal_Click(object sender, EventArgs e)
        {
            //每个用户只能申诉一次
            if (uc.HasAppel(username))
            {
                LabelAppealNotice.Text = "每个用户只能申诉一次";
                return;
            }
            if(string.IsNullOrWhiteSpace(TextBoxAppeal.Text))
            {
                LabelAppealNotice.Text = "请输入申诉内容";
                return;
            }

            bool result=uc.AddAppeal(username, TextBoxAppeal.Text,AppealPhone.Text);
            if (result)
                LabelAppealNotice.Text = "申诉成功，请等待";
            else
                LabelAppealNotice.Text = "申诉不成功，请重试";
        }

        protected void Next_Click(object sender, EventArgs e)
        {
            //还未测试
            if (uc.ValidateAnswer(username, TextBoxAnswer.Text))
                MultiView1.ActiveViewIndex = 3;
            else
                LabelNotice.Text = "答案不正确";
        }

        protected void SubmitChangepassword_Click(object sender, EventArgs e)
        {
            //更新密码
            if (uc.UpdatePassword(username, NewPassword.Text))
                LabelPasswordNotice.Text = "密码修改成功";
            else
                LabelPasswordNotice.Text = "密码修改失败";
        }

        protected void ButtonUsername_Click(object sender, EventArgs e)
        {
            if (uc.ValidateUserName(TextBoxUsername.Text))
            {
                //不存在用户名
                LabelUsername.Text = "不存在此用户";
                return;
            }

            username = TextBoxUsername.Text;
            ViewState["username"] = username;
            Question = uc.GetQuestion(username);
            
                if (string.IsNullOrWhiteSpace(Question))
                    MultiView1.ActiveViewIndex = 2;//显示申诉页面
                else
                {
                    MultiView1.ActiveViewIndex = 1;//验证密保页面
                    LabelQuestion.Text = Question;
                }

            
        }
    }
}