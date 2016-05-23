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
        protected void Page_Load(object sender, EventArgs e)
        {
            uc = new UserClass();
            Question = uc.GetQuestion(Session["Username"].ToString());
            if (!IsPostBack)
            {
                if (string.IsNullOrWhiteSpace(Question))
                    MultiView1.ActiveViewIndex = 1;//显示申诉页面
                else
                {
                    MultiView1.ActiveViewIndex = 0;//验证密保页面
                    LabelQuestion.Text = Question;
                }
                    
            }
        }

        
        protected void SubmitAppeal_Click(object sender, EventArgs e)
        {
            //此处留着以后处理
        }

        protected void Next_Click(object sender, EventArgs e)
        {
            //还未测试
            if (uc.ValidateAnswer(Session["Username"].ToString(), TextBoxAnswer.Text))
                MultiView1.ActiveViewIndex = 2;
            else
                LabelNotice.Text = "答案不正确";
        }

        protected void SubmitChangepassword_Click(object sender, EventArgs e)
        {
            //更新密码
            if (uc.UpdatePassword(Session["Username"].ToString(), NewPassword.Text))
                LabelPasswordNotice.Text = "密码修改成功";
            else
                LabelPasswordNotice.Text = "密码修改失败";
        }
    }
}