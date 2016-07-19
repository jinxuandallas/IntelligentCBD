using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Core;

namespace IntelligentCBD.Company
{
    public partial class ShowCompany : System.Web.UI.Page
    {
        protected CompanyClass cc;
        protected Tools t;
        protected Guid companyID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["comID"] == null || string.IsNullOrWhiteSpace(Request.QueryString["comID"]))
                Response.Redirect("~/default.aspx");

            cc = new CompanyClass();
            t = new Tools();
            companyID = Guid.Parse(Request.QueryString["comID"]);

            //处理企业宣传页（翻页效果）
            DataSet ds = cc.GetCompanyAdvertises(companyID);
            Repeater1.DataSource = ds;
            Repeater2.DataSource = ds;
            Repeater2.DataBind();
            Repeater1.DataBind();

            //Repeater3.DataSource = cc.GetPicKind(companyID);
            //Repeater3.DataBind();


            FillComInfo();
        }

        private void FillComInfo()
        {
            //对字符串进行截断处理
            cc.FillCompanyInfoView(companyID);//已经过HTMLEncode处理
            LabelCompanyName.Text = t.cutStr(cc.CompanyName, 80);
            LabelPhone.Text = t.cutStr(cc.Phone, 50);
            LabelContact.Text = t.cutStr(cc.Contact, 30);
            LabelVector.Text = cc.Vector;
            LabelCapital.Text = cc.CapitalStr;
            LabelAddress.Text = t.cutStr(cc.Address, 50);
            LabelRoomNum.Text = t.cutStr(cc.RoomNum, 30);
            LabelIndustry.Text = t.cutStr(cc.Industry, 30);
            LabelArea.Text = cc.Area.ToString();
            LabelIntroduction.Text = cc.Introduction;
            LabelBusinessScope.Text = cc.BusinessScope;
            LabelRegistrationDate.Text = cc.RegistrationDate;
            LabelRegisteredAddress.Text = t.cutStr(cc.RegisteredAddress, 30);
            LabelQQ.Text = cc.QQ;
            LabelEmail.Text = cc.Email;
            LabelContent.Text = cc.Content;
        }

        protected void Repeater3_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rpt2 = e.Item.FindControl("Repeater4") as Repeater;
                if (rpt2 != null && e.Item.DataItem != null)
                {
                    int picType = int.Parse(((DataRowView)e.Item.DataItem).Row[0].ToString());
                    if (picType != 0)
                    {
                        rpt2.DataSource = cc.GetPicShowAddress(companyID, picType);
                        rpt2.DataBind();
                    }
                }
            }
        }

        protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
        {
            switch (TabContainer1.ActiveTabIndex)
            {
                case 1:
                    Repeater3.DataSource = cc.GetPicKind(companyID);
                    Repeater3.DataBind();
                    //Repeater3.DataSource = cc.GetPicKind(companyID);
                    //Repeater3.DataBind();
                    break;
                default:
                    break;

            }
        }
    }
}