﻿using System;
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
            HiddenDelFiles.Value = string.Empty;//此处必须将hidden值清零，否则会导致上一次回发保存在hidden值这一次继续附加在hidden的value内

            Repeater1.DataSource = ds;
            Repeater1.DataBind();

            //此处改为服务器端处理默认按钮是否显示似乎更方便一些
            ShowDefault();
        }

        protected void DropDownList_PicType_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitBind();
        }

        protected void ShowDefault()
        {
            bool show = DropDownList_PicType.SelectedValue == "1" ? true : false;
            foreach (RepeaterItem ri in Repeater1.Items)
            {
                //ri.FindControl("divpic").FindControl("Button1").Visible = show;
                ri.FindControl("defaultButton").Visible = show;
            }

            //如果改变到别的选项清空HiddenDefault中的值
            if (!show)
            {
                HiddenDefault.Value = string.Empty;
                return;
            }

            string defaultPicPath = up.GetDefaultPic(companyID);

            if (!string.IsNullOrEmpty(defaultPicPath))
            {
                HiddenDefault.Value = defaultPicPath.Replace("~/Upload", "../Upload");
                foreach (RepeaterItem ri in Repeater1.Items)
                    if (defaultPicPath == ((Image)ri.FindControl("img")).ImageUrl)
                        ((System.Web.UI.HtmlControls.HtmlGenericControl)ri.FindControl("divpic")).Style.Add("background-color", "yellow");
                
                   
                
            }

        }
               
        protected void Submit_Click(object sender, EventArgs e)
        {

            //Response.Write(HiddenDelFiles.Value);
            //return;

            //1.第一步先删除客户端选定的文件(感觉删除文件要放在更新默认图片前面）
            //先判断要删除文件域中是否有信息，即用户是否点击过删除图片，如果没点击删除则不需进行下面处理
            if (!string.IsNullOrEmpty(HiddenDelFiles.Value))
            {
                //将客户端存于Hidden控件中的删除文件表，转化为可以使用的泛型列表
                List<string> delFilelist = up.GetFileList(HiddenDelFiles.Value);

                if (!up.DelPicFile(delFilelist))
                {
                    LabelPrompt.Text = "删除文件不成功";
                    return;
                }

                if (!up.DelDbPic(delFilelist,companyID))
                {
                    LabelPrompt.Text = "删除文件记录不成功";
                    return;
                }
            }

            //更新默认图片
            if (DropDownList_PicType.SelectedValue == "1" && !string.IsNullOrWhiteSpace(HiddenDefault.Value))
                up.UpdateDefaultPic(companyID, HiddenDefault.Value);

            //获取文件绝对路径
            string filepath = Server.MapPath("~/Upload/UploadCompanyPicture") + "\\";

            //上传文件
            string result= up.UploadPic(Request.Files, filepath, int.Parse(DropDownList_PicType.SelectedValue), companyID);

            InitBind();

            LabelPrompt.Text = result;
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            LabelPrompt.Text = "重置成功";
            InitBind();
        }

    
    }
}