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
        //还需增加企业内容有错举报
        protected CompanyClass cc;
        protected Tools t;
        protected Guid companyID;
        protected CommentClass commentc;
        protected double bigStar;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["comID"] == null || string.IsNullOrWhiteSpace(Request.QueryString["comID"]))
                Response.Redirect("~/default.aspx");

            cc = new CompanyClass();
            t = new Tools();
            companyID = Guid.Parse(Request.QueryString["comID"]);
            commentc = new CommentClass();

            //处理企业宣传页（翻页效果）
            DataSet ds = cc.GetCompanyAdvertises(companyID);
            Repeater1.DataSource = ds;
            Repeater2.DataSource = ds;
            Repeater2.DataBind();
            Repeater1.DataBind();


            //处理企业星级显示
            bigStar = commentc.GetCompanyStar(companyID);
            //ListViewResult.DataBind();

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
                Repeater rpt4 = e.Item.FindControl("Repeater4") as Repeater;
                if (rpt4 != null && e.Item.DataItem != null)
                {
                    int picType = int.Parse(((DataRowView)e.Item.DataItem).Row[0].ToString());
                    if (picType != 0)
                    {
                        rpt4.DataSource = cc.GetPicShowAddress(companyID, picType);
                        rpt4.DataBind();
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
                    break;
                case 2:
                    ListViewResult.DataSource = commentc.GetComments(companyID);
                    ListViewResult.DataBind();
                    break;
                default:
                    break;

            }
        }

        protected void ListViewResult_ItemCreated(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Repeater rpt = e.Item.FindControl("Repeater5") as Repeater;
                if (rpt != null)
                {
                    if (e.Item.DataItem == null)
                        return;
                    Guid id = Guid.Parse(((DataRowView)e.Item.DataItem).Row["ID"].ToString());
                    if (id != null)
                    {
                        rpt.DataSource = commentc.GetCommentPic(id);
                        rpt.DataBind();
                    }
                }
            }
        }

        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{
        //    Session["CompanyID"] = companyID;
        //    Response.Redirect("../Comment/AddComment.aspx");
            //Response.Write("<script language='javascript'>window.open('../Comment/AddComment.aspx');</script>");
            //Response.Write("<script>");
            //Response.Write("window.open('EditCompany.aspx','_blank')");
            //Response.Write("</script>");
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/JavaScript'>alert('xxx');</script>");
        //}
    }
}