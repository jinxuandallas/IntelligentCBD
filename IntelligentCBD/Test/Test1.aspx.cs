using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace IntelligentCBD.Test
{
    public partial class Test1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ts = "c:\\users\\administrator\\documents\\visual studio 2015\\Projects\\IntelligentCBD\\IntelligentCBD\\Upload\\ContentUploadPic\\day_160713\\201607130901342030.jpg";
            ts = ts.Substring(0, ts.LastIndexOf("\\"));
            if (Directory.GetFiles(ts).Length + Directory.GetDirectories(ts).Length == 0)
            {
                Directory.Delete(ts);
            }
            Response.Write(Directory.GetParent(ts) + "<br/>");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Write((((ImageButton)sender).Parent.FindControl("Label1") as Label).Text+"yy");
        }
    }
}