using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core;

namespace IntelligentCBD.Company
{
    public partial class ManageCompany : System.Web.UI.Page
    {
        public Tools t;
        protected void Page_Load(object sender, EventArgs e)
        {
            //此处给客户端（aspx页面）调用，不能去掉
            t = new Tools();

            /*此处不可如此设置，因为一个企业也需要管理（可能要删除）
            if (ListViewCompany.Items.Count == 1)
            {
                Session["CompanyID"] = (ListViewCompany.Items[0].FindControl("Label企业ID") as Label).Text;
                Response.Redirect("EditCompany.aspx");
            }
            */
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            //将企业ID赋值到Session中
            Session["CompanyID"] = (((Button)sender).Parent.FindControl("Label企业ID") as Label).Text;
            Response.Redirect("EditCompany.aspx");
        }

        protected void ButtonDel_Click(object sender, EventArgs e)
        {
            ///删除企业，还没完成具体实现，包括删除图片和评论等所有企业信息
            Response.Write((((Button)sender).Parent.FindControl("Label企业ID") as Label).Text);
        }
    }
}