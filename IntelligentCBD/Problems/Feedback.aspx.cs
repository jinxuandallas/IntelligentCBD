using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core;

namespace IntelligentCBD.Problems
{
    public partial class Feedback : System.Web.UI.Page
    {
        protected ProblemsClass pc;
        protected void Page_Load(object sender, EventArgs e)
        {
            pc = new ProblemsClass();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string username;
            if (Session["Username"] == null || string.IsNullOrWhiteSpace(Session["Username"].ToString()))
                username = string.Empty;
            else
                username = Session["Username"].ToString();

            Guid problemID = pc.AddProblem(username, TextBoxProblem.Text);

            string filepath = Server.MapPath("~/Upload/ProblemUploadPic") + "\\";

            string result = pc.UploadProblemPic(Request.Files, filepath, problemID);

            LabelPrompt.Text = result;


            if (result == "上传成功")
            {
                Response.Write("<script>alert('评论问题成功，谢谢参与')</script>");
                Response.Write("<script>window.close();</script>");
            }
            else
                LabelPrompt.Text= "上传不成功";
        }
    }
}