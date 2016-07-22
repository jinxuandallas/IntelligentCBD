using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core;

namespace IntelligentCBD.Comment
{
    public partial class AddComment : System.Web.UI.Page
    {
        protected CompanyClass companyc;
        protected Guid companyID;
        protected CommentClass commentc;
        protected void Page_Load(object sender, EventArgs e)
        {
            ///因为引用的是MainSite.Master，所以都要重新判断Session的Username、CompanyID属性是否存在
            //测试用
            Session["Username"] = System.Configuration.ConfigurationManager.AppSettings["username"];
            //测试用
            Session["CompanyID"] = System.Configuration.ConfigurationManager.AppSettings["companyID"];

            //此处必须先判断Session["Username"]是否为null否则后面的IsNullOrWhiteSpace会抛出异常
            if (Session["Username"] == null || string.IsNullOrWhiteSpace(Session["Username"].ToString()))
                Response.Redirect("~/Account/Login.aspx");

            if (Session["CompanyID"] == null || string.IsNullOrWhiteSpace(Session["CompanyID"].ToString()))
                Response.Redirect("~/Account/Login.aspx");

            companyID = Guid.Parse(Session["CompanyID"].ToString());
            companyc = new CompanyClass();
            commentc = new CommentClass();

            if (!IsPostBack)
            {
                LabelCompanyName.Text = companyc.GetCompanyName(companyID);
            }

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(score.Value))
            {
                LabelStarPrompt.Visible = true;
                return;
            }

            //首先添加评论信息
            Guid commentID= commentc.AddComment(companyID, Session["Username"].ToString(), int.Parse(score.Value), TextBoxComment.Text, CheckBoxAnonymity.Checked);

                string filepath = Server.MapPath("~/Upload/CommentUploadPic") + "\\";

            string result = commentc.UploadCommentPic(Request.Files, filepath, commentID);

            LabelPrompt.Text = result;

            //最后还原控件初始状态
            LabelStarPrompt.Visible = false;
            score.Value = "";
        }
    }
}