using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core;
using System.Data;

namespace IntelligentCBD.Comment
{
    public partial class ManageCompanyComments : System.Web.UI.Page
    {
        protected CommentClass commentc;
        protected void Page_Load(object sender, EventArgs e)
        {
            commentc = new CommentClass();
            if (!IsPostBack)
            {
                ListViewComment.DataSource = commentc.GetManagementComments(Session["Username"].ToString());
                ListViewComment.DataBind();
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
                    (e.Item.FindControl("Explanation") as Button).Visible = false;
                    Label lbExplanation = (e.Item.FindControl("LabelExplanation") as Label);
                    lbExplanation.Visible = true;
                    lbExplanation.Text = "解释：" + commentc.GetExplanation(id);
                }
                else
                {
                    (e.Item.FindControl("Explanation") as Button).Visible = true;
                    (e.Item.FindControl("LabelExplanation") as Label).Visible = false;
                }
            }
            //id = Guid.Parse(((DataRowView)e.Item.DataItem).Row["ID"].ToString());
            
        }

        protected void Explanation_Click(object sender, EventArgs e)
        {
            AddExplanation.Visible = true;
            HiddenCommentID.Value = (((Button)sender).Parent.FindControl("CommentID") as Label).Text;
            //Guid id = Guid.Parse((((Button)sender).Parent.FindControl("CommentID") as Label).Text);
            //Response.Write(id);


        }


        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace( TextBoxExplanation.Text))
            {
                LabelPrompt.Text = "请输入解释内容";
                return;
            }
            bool result=commentc.AddExplanation(Guid.Parse(HiddenCommentID.Value), Server.HtmlEncode(TextBoxExplanation.Text), Session["Username"].ToString());
            //Response.Write(HiddenCommentID.Value);
            ClearPopup();
            if (result)
            {
                LabelPrompt.Text = "追加成功";
                AddExplanation.Visible = false;
                ListViewComment.DataSource = commentc.GetManagementComments(Session["Username"].ToString());
                ListViewComment.DataBind();
            }
            else
                LabelPrompt.Text = "追加失败";

        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            ClearPopup();
            AddExplanation.Visible = false;
        }

        protected void ClearPopup()
        {
            LabelPrompt.Text = "";
            TextBoxExplanation.Text = "";
        }

        
    }
}