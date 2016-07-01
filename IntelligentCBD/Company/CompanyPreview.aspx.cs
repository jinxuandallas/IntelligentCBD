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
        protected void Page_Load(object sender, EventArgs e)
        {
            //测试用
            Session["CompanyID"] = System.Configuration.ConfigurationManager.AppSettings["companyID"];

            cc = new CompanyClass();
            t = new Tools();
            Guid companyID =Guid.Parse(Session["CompanyID"].ToString());

            DataSet ds = cc.GetCompanyAdvertises(companyID);
            Repeater1.DataSource = ds;
            Repeater2.DataSource = ds;
            Repeater2.DataBind();
            Repeater1.DataBind();

            cc.FillCompanyInfoView(companyID);
            LabelCompanyName.Text =t.cutStr(cc.CompanyName,80);
            LabelPhone.Text = cc.Phone;
            LabelContact.Text = cc.Contact;
            LabelVector.Text = cc.Vector;
            LabelCapital.Text = cc.CapitalStr;
            LabelAddress.Text = cc.Address;
            LabelRoomNum.Text = cc.RoomNum;
        }
    }
}