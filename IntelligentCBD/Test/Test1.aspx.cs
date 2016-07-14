using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelligentCBD.Test
{
    public partial class Test1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Label1.Text = "<script>alert(\"xx\");</script>";
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Write((((ImageButton)sender).Parent.FindControl("Label1") as Label).Text+"yy");
        }
    }
}