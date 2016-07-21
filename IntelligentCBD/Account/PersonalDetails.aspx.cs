using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core;
using System.Data.SqlClient;

namespace IntelligentCBD.Account
{
    public partial class PersonalDetails : System.Web.UI.Page
    {
        protected UserClass uc;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //if (!IsPostBack)
            uc = new UserClass();
            if (!IsPostBack)
            {
                Label_Username.Text = Session["Username"].ToString();
                using (SqlDataReader sdr = uc.GetDetails(Session["Username"].ToString()))
                {
                    if (sdr.Read())
                    {
                        TextBox_Nickname.Text = sdr["昵称"].ToString();
                        RadioButtonList_Sex.SelectedValue= sdr["性别"].ToString();
                        TextBox_Phone.Text = sdr["手机号码"].ToString();
                        TextBox_Email.Text = sdr["电子邮箱"].ToString();
                        TextBox_Question.Text = sdr["密保问题"].ToString();
                        TextBox_Answer.Text = sdr["密保答案"].ToString();
                    }
                    else return;
                }
            }
                
            //Session["Username"] = "s345";
            //Label_Username.Text = Session["Username"].ToString();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //uc.Username = Label_Username.Text;
            uc.Nickname = TextBox_Nickname.Text;
            uc.Sex = RadioButtonList_Sex.SelectedItem.Value;
            uc.Phone = TextBox_Phone.Text;
            uc.Email = TextBox_Email.Text;
            uc.Question = TextBox_Question.Text;
            uc.Answer = TextBox_Answer.Text;

            if (uc.UpdateDetails(Session["Username"].ToString())) LabelSucceed.Text = "修改成功";
            else LabelSucceed.Text = "修改不成功";
            
        }
        /*protected void Page_PreRenderComplete(object sender, EventArgs e)
{
   Label_Username.Text = Session["Username"].ToString();
}*/
    }
}