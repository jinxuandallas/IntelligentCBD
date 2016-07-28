using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelligentCBD
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //测试用
            Response.Redirect("~/Search/Result.aspx?query=谢谢");
        }

        protected void ImgBtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Search/Result.aspx?query="+HttpUtility.UrlEncode(TextBoxSearch.Text));
        }
    }
}