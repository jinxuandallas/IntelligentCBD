using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core;

namespace IntelligentCBD.Company
{
    public partial class ReportCompanyError : System.Web.UI.Page
    {
        protected Guid companyID;
        protected CompanyClass companyc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["comID"] == null || string.IsNullOrWhiteSpace(Request.QueryString["comID"]))
                Response.Redirect("~/default.aspx");

            companyID = Guid.Parse(Request.QueryString["comID"]);
            companyc = new CompanyClass();
            LabelCompanyName.Text = companyc.GetCompanyName(companyID);
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string username;
            if (Session["Username"] == null || string.IsNullOrWhiteSpace(Session["Username"].ToString()))
                username = string.Empty;
            else
                username = Session["Username"].ToString();
            bool result=companyc.SubmitCompanyError(companyID, TextBoxReport.Text, username);

            if (result)
            {
                Response.Write("<script>alert('问题提交成功')</script>");
                Response.Write("<script>window.close();</script>");
            }
            else
                LabelPrompt.Text = "问题提交不成功";
        }
    }
}