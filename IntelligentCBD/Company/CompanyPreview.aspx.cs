using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core;
using System.Data;

namespace IntelligentCBD.Company
{
    public partial class CompanyPreview : System.Web.UI.Page
    {
        protected CompanyClass cc;
        protected Tools t;
        protected Guid companyID;
        protected void Page_Load(object sender, EventArgs e)
        {
            //测试用
            Session["CompanyID"] = System.Configuration.ConfigurationManager.AppSettings["companyID"];

            if (Session["CompanyID"] == null || Session["CompanyID"].ToString().Trim() == "")
                Response.Redirect("~/Account/Login.aspx");

            cc = new CompanyClass();
            t = new Tools();
            companyID =Guid.Parse(Session["CompanyID"].ToString());

            //处理企业宣传页（翻页效果）
            DataSet ds = cc.GetCompanyAdvertises(companyID);
            Repeater1.DataSource = ds;
            Repeater2.DataSource = ds;
            Repeater2.DataBind();
            Repeater1.DataBind();

            FillComInfo();
        }

        private void FillComInfo()
        {
            //对字符串进行截断处理
            cc.FillCompanyInfoView(companyID);
            LabelCompanyName.Text = t.cutStr(cc.CompanyName, 80);
            LabelPhone.Text = t.cutStr(cc.Phone,50);
            LabelContact.Text = t.cutStr(cc.Contact,30);
            LabelVector.Text = cc.Vector;
            LabelCapital.Text = cc.CapitalStr;
            LabelAddress.Text = t.cutStr(cc.Address,50);
            LabelRoomNum.Text = t.cutStr(cc.RoomNum,30);
            LabelIndustry.Text = t.cutStr(cc.Industry,30);
            LabelArea.Text = cc.Area.ToString();
            LabelIntroduction.Text = cc.Introduction;
            LabelBusinessScope.Text = cc.BusinessScope;
            LabelRegistrationDate.Text = cc.RegistrationDate;
            LabelRegisteredAddress.Text = t.cutStr(cc.RegisteredAddress,30);
            LabelQQ.Text = cc.QQ;
            LabelEmail.Text = cc.Email;
            LabelContent.Text = cc.Content;
        }
    }
}