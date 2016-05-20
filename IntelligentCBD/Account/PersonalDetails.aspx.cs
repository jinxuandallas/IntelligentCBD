using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelligentCBD.Account
{
    public partial class PersonalDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Label_Username.Text = Session["Username"].ToString();
            //Session["Username"] = "s345";
            //Label_Username.Text = Session["Username"].ToString();
        }
        /*protected void Page_PreRenderComplete(object sender, EventArgs e)
        {
            Label_Username.Text = Session["Username"].ToString();
        }*/
    }
}