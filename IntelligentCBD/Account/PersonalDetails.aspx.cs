using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core;
namespace IntelligentCBD.Account
{
    public partial class PersonalDetails : System.Web.UI.Page
    {
        protected UserClass uc;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            uc = new UserClass();
            Label_Username.Text = Session["Username"].ToString();
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

            uc.UpdateDetail(Session["Username"].ToString());
            
        }
        /*protected void Page_PreRenderComplete(object sender, EventArgs e)
{
   Label_Username.Text = Session["Username"].ToString();
}*/
    }
}