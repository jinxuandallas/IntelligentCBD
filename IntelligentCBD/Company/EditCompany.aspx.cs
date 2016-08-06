using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core;

namespace IntelligentCBD.Company
{
    public partial class EditCompany : System.Web.UI.Page
    {
        public CompanyClass cc;
        Guid companyID;
        public Tools t;
        protected void Page_Load(object sender, EventArgs e)
        {
            //测试用
            //Session["CompanyID"] = System.Configuration.ConfigurationManager.AppSettings["companyID"];

            if (Session["CompanyID"]==null ||string.IsNullOrWhiteSpace( Session["CompanyID"].ToString()))
                Response.Redirect("~/Account/Login.aspx");

            cc = new CompanyClass();
            companyID = Guid.Parse(Session["CompanyID"].ToString());
            t = new Tools();

            if (!IsPostBack)
                FillTextbox();
        }

        /// <summary>
        /// 将CompanyClass中的数据填充到页面Textbox控件中
        /// </summary>
        protected void FillTextbox()
        {
            cc.FillCompanyInfo(companyID);
            TextBox_CompanyName.Text = cc.CompanyName;

            //填充注册资本，这里比较麻烦
            string capitalUnit,capitalStr;
            capitalStr = t.LongStr2CapitalStr(cc.Capital.ToString());//此处得到的字符串是“100亿”如此
            TextBox_Capital.Text = capitalStr.Substring(0,capitalStr.Length-1);//返回前面的数字复制到TextBox_Capital.Text
            capitalUnit = capitalStr.Substring(capitalStr.Length - 1);//返回最后的单位
            DropDownList_Units.SelectedValue = capitalUnit;//将单位赋值到DropDownList_Units控件中

            TextBox_Industry.Text = cc.Industry;
            TextBox_Area.Text = cc.Area.ToString();
            TextBox_RoomNum.Text = cc.RoomNum;
            TextBox_Address.Text = cc.Address;
            DropDownList_Vector.SelectedValue = cc.Vector;
            TextBox_Introduction.Text = cc.Introduction;
            TextBox_BusinessScope.Text = cc.BusinessScope;
            TextBox_RegisteredAddress.Text = cc.RegisteredAddress;

            //此处Datetime需要转化一下
            TextBox_RegistrationDate.Text = cc.RegistrationDate;
            TextBox_Contact.Text = cc.Contact;
            TextBox_Phone.Text = cc.Phone;
            TextBox_Email.Text = cc.Email;
            TextBox_QQ.Text = cc.QQ;
            elm1.InnerText = cc.Content;

            /*
            cc.CompanyName = TextBox_CompanyName.Text;
            cc.Capital = t.CapitalStr2Long(TextBox_Capital.Text, DropDownList_Units.SelectedValue);
            cc.Industry = TextBox_Industry.Text;
            //此处需如此处理面积
            int area;
            int.TryParse(TextBox_Area.Text, out area);
            cc.Area = area;
            cc.RoomNum = TextBox_RoomNum.Text;
            cc.Address = TextBox_Address.Text;
            cc.Vector = DropDownList_Vector.SelectedValue;
            cc.Introduction = TextBox_Introduction.Text;
            cc.BusinessScope = TextBox_BusinessScope.Text;
            cc.RegisteredAddress = TextBox_RegisteredAddress.Text;
            cc.RegistrationDate = TextBox_RegistrationDate.Text;
            cc.Contact = TextBox_Contact.Text;
            cc.Phone = TextBox_Phone.Text;
            cc.Email = TextBox_Email.Text;
            cc.QQ = TextBox_QQ.Text;
            cc.Content = elm1.InnerText;
            */

        }

        protected void Next_Click(object sender, EventArgs e)
        {
            FillComInfo(companyID); //填充CompanyClass中的企业基本信息
            bool result=cc.UpdateCompanyInfo(); //更新企业基本信息

            if (result)
                Response.Redirect("UploadCredentials.aspx");
            else
                LabelNotice.Text = "更新失败";
        }


        /// <summary>
        /// 将页面控件中的值填充到CompanyClass中去
        /// </summary>
        /// <param name="companyID">填充的企业ID</param>
        protected void FillComInfo(Guid companyID)
        {
            cc.ID = companyID;
            cc.CompanyName = TextBox_CompanyName.Text;
            cc.Capital = t.CapitalStr2Long(TextBox_Capital.Text, DropDownList_Units.SelectedValue);
            cc.Industry = TextBox_Industry.Text;
            //此处需如此处理面积
            int area;
            int.TryParse(TextBox_Area.Text, out area);
            cc.Area = area;
            cc.RoomNum = TextBox_RoomNum.Text;
            cc.Address = TextBox_Address.Text;
            cc.Vector = DropDownList_Vector.SelectedValue;
            cc.Introduction = TextBox_Introduction.Text;
            cc.BusinessScope = TextBox_BusinessScope.Text;
            cc.RegisteredAddress = TextBox_RegisteredAddress.Text;
            cc.RegistrationDate = TextBox_RegistrationDate.Text;
            cc.Contact = TextBox_Contact.Text;
            cc.Phone = TextBox_Phone.Text;
            cc.Email = TextBox_Email.Text;
            cc.QQ = TextBox_QQ.Text;
            cc.Content = elm1.InnerText;
        }

        protected void ButtonReset_Click(object sender, EventArgs e)
        {
            FillTextbox();
        }

        protected void Finish_Click(object sender, EventArgs e)
        {
            FillComInfo(companyID); //填充CompanyClass中的企业基本信息
            bool result = cc.UpdateCompanyInfo(); //更新企业基本信息

            if (result)
                Response.Redirect("ManageCompany.aspx");
            else
                LabelNotice.Text = "更新失败";
        }
    }
}