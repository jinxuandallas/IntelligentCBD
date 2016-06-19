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
    public partial class UploadCredentials : System.Web.UI.Page
    {
        public int uploadNum;
        protected UploadPictureClass up;
        protected DataSet ds;
        protected Guid companyID;
        protected void Page_Load(object sender, EventArgs e)
        {
            //测试用
            Session["CompanyID"] = System.Configuration.ConfigurationManager.AppSettings["companyID"];
            //addNum = 5;
            up = new UploadPictureClass();
            companyID = Guid.Parse(Session["CompanyID"].ToString());
            if (!IsPostBack)
            {
                if (Session["CompanyID"] == null || Session["CompanyID"].ToString().Trim() == "")
                    Response.Redirect("~/Account/Login.aspx");

                DropDownList_PicType.DataBind();//手动绑定DropDownList控件，否则否则后面的取值会出错为-1

                //DropDownList_PicType.SelectedIndex = 4;//给DropDownList设置默认值，否则后面的取图片会出错
                //Response.Write(DropDownList_PicType.SelectedIndex);

                InitBind();
            }
        }

        protected void InitBind()
        {
            ///还差在载入时检查是否存在默认图片，并显示在客户端
            
            ds = up.GetPicbyCompany(companyID,int.Parse(DropDownList_PicType.SelectedValue));
            uploadNum = 5 - ds.Tables[0].Rows.Count;
            HiddenDelfiles.Value = string.Empty;//此处必须将hidden值清零，否则会导致上一次回发保存在hidden的值这一次继续附加在hidden的value内
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
            //Response.Write(DropDownList_PicType.SelectedIndex);
        }

        protected void DropDownList_PicType_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitBind();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //1.第一步先删除客户端选定的文件
            //先判断要删除文件域中是否有信息，即用户是否点击过删除图片，如果没点击删除则不需进行下面处理
            if (!string.IsNullOrEmpty(HiddenDelfiles.Value))
            {
                //将客户端存于Hidden控件中的删除文件表，转化为可以使用的泛型列表
                List<string> delFilelist = up.GetFileList(HiddenDelfiles.Value);

                if (!up.DelPicFile(delFilelist))
                {
                    LabelPrompt.Text = "删除文件不成功";
                    return;
                }

                if (!up.DelDbPic(delFilelist))
                {
                    LabelPrompt.Text = "删除文件记录不成功";
                    return;
                }
            }
            //获取文件绝对路径
            string filepath = Server.MapPath("~/Upload/UploadCompanyPicture") + "\\";

            up.UploadPic(Request.Files, filepath, int.Parse(DropDownList_PicType.SelectedValue), companyID);

            InitBind();
        }
    }
}