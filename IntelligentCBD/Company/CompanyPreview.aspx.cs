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
        protected CommentClass commentc;
        protected double bigStar;

        protected void Page_Load(object sender, EventArgs e)
        {
            //测试用
            Session["CompanyID"] = System.Configuration.ConfigurationManager.AppSettings["companyID"];

            if (Session["CompanyID"] == null || Session["CompanyID"].ToString().Trim() == "")
                Response.Redirect("~/Account/Login.aspx");

            cc = new CompanyClass();
            t = new Tools();
            companyID =Guid.Parse(Session["CompanyID"].ToString());
            commentc = new CommentClass();

            //处理企业宣传页（翻页效果）
            DataSet ds = cc.GetCompanyAdvertises(companyID);
            Repeater1.DataSource = ds;
            Repeater2.DataSource = ds;
            Repeater2.DataBind();
            Repeater1.DataBind();

            //Repeater3.DataSource = cc.GetPicKind(companyID);
            //Repeater3.DataBind();
            TabPanelComments.HeaderText = @"评论&nbsp;<span style=""color:red"">" + commentc.GetCommentSum(companyID) + @"</span>";
            //处理企业星级显示
            bigStar = commentc.GetCompanyStar(companyID);

            FillComInfo();
        }

        private void FillComInfo()
        {
            //对字符串进行截断处理
            cc.FillCompanyInfoView(companyID);//已经过HTMLEncode处理
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

        protected void Repeater3_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rpt2 = e.Item.FindControl("Repeater4") as Repeater;
                if (rpt2 != null && e.Item.DataItem!=null)
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
                    break;
                case 2:
                    ListViewComment.DataSource = commentc.GetComments(companyID);
                    ListViewComment.DataBind();
                    break;
                default:
                    break;

            }
        }

        protected void ListViewComment_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Guid id;
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                id = Guid.Parse(((DataRowView)e.Item.DataItem).Row["ID"].ToString());
                Repeater rpt = e.Item.FindControl("RepeaterCommentPic") as Repeater;
                if (rpt != null)
                {
                    //if (e.Item.DataItem == null)
                    //    return;

                    if (id != null)
                    {
                        rpt.DataSource = commentc.GetCommentPic(id);
                        rpt.DataBind();
                    }
                }

                //判断是否有解释内容
                if (commentc.HasExplanation(id))
                {
                    Label lbExplanation = (e.Item.FindControl("LabelExplanation") as Label);
                    lbExplanation.Visible = true;
                    lbExplanation.Text = "解释：" + commentc.GetExplanation(id);
                }
                else
                {
                    (e.Item.FindControl("LabelExplanation") as Label).Visible = false;
                }
            }
        }

    }
}