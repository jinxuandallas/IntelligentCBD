using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core;

namespace IntelligentCBD.Company
{
    public partial class ListViewTest : System.Web.UI.Page
    {
        public Tools t;
        protected void Page_Load(object sender, EventArgs e)
        {
            t = new Tools();
        }

        protected void edit_Click(object sender, EventArgs e)
        {
            string l = (((Button)sender).Parent.FindControl("Label企业ID") as Label).Text;
            Response.Write(l);
        }
    }
}