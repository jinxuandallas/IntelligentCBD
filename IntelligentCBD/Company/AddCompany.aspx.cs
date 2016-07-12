using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core;

namespace IntelligentCBD.Company
{
    public partial class AddCompany : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Next_Click(object sender, EventArgs e)
        {

            /*测试DateTime未录入情况（即为空值）
            DateTime dd;
            DateTime.TryParse(TextBox_RegistrationDate.Text,out dd);
            cc.RegistrationDate = dd;
            TextBox_RegistrationDate.Text = cc.RegistrationDate.ToShortDateString();
            Response.Write(cc.RegistrationDate);
            */
            //cc.ID=Guid.NewGuid();

            Guid id = AddCompanyBaseInfo();
            
            //将用户的账号类型从个人改为商户
            UserClass uc = new UserClass();
            if (uc.UpdateAccountType(Session["Username"].ToString(), 2) && id != Guid.Empty)
            {
                Session["CompanyID"] = id;
                Response.Redirect("UploadCredentials.aspx");
            }
            else
                LabelNotice.Text = "添加失败";

            //考虑到数据库存储问题，此处不使用Server.HtmlEncode方法，因为会增大数据库存储容量造成溢出错误；
            /*
            cc.CompanyName = Server.HtmlEncode(TextBox_CompanyName.Text);
            cc.Capital = t.CapitalString2Long(TextBox_Capital.Text, DropDownList_Units.SelectedValue);
            cc.Industry = Server.HtmlEncode(TextBox_Industry.Text);
            //此处需如此处理面积
            int area;
            int.TryParse(TextBox_Area.Text,out area);
            cc.Area = area;
            cc.RoomNum = Server.HtmlEncode(TextBox_RoomNum.Text);
            cc.Address = Server.HtmlEncode(TextBox_Address.Text);
            cc.Vector = DropDownList_Vector.SelectedValue;
            cc.Introduction =  Server.HtmlEncode(TextBox_Introduction.Text);
            cc.BusinessScope = Server.HtmlEncode(TextBox_BusinessScope.Text);
            cc.RegisteredAddress = Server.HtmlEncode(TextBox_RegisteredAddress.Text);
            cc.RegistrationDate = TextBox_RegistrationDate.Text;
            cc.Contact = Server.HtmlEncode(TextBox_Contact.Text);
            cc.Phone = Server.HtmlEncode(TextBox_Phone.Text);
            cc.Email = Server.HtmlEncode(TextBox_Email.Text);
            cc.QQ = Server.HtmlEncode(TextBox_QQ.Text);
            cc.Content = elm1.InnerText;
            Response.Write(cc.Content);
            /*
            
            /*测试
            //cc.Address = TextBox_Address.Text;
            LabelSucceed.Text = Server.HtmlDecode(cc.Address);
            TextBox1.Text = Server.HtmlDecode(cc.Address);
            Response.Write(Server.HtmlDecode(cc.Address));
            */
        }

        protected Guid AddCompanyBaseInfo()
        {
            CompanyClass cc = new CompanyClass();
            Tools t = new Tools();

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

            Guid id = cc.AddCompanyBaseInformation(Session["Username"].ToString());
            return id;
        }

        protected void AddAgain_Click(object sender, EventArgs e)
        {

            Guid id= AddCompanyBaseInfo();
            //Guid id = Guid.NewGuid();
            if (id != null && id != Guid.Empty)
            {
                LabelNotice.Text = "添加成功";
                InitTextBox();
            }
            else
                LabelNotice.Text = "添加失败";
        }

        void InitTextBox()
        {
            TextBox_CompanyName.Text = "";

            //填充注册资本，这里比较麻烦
            //string capitalUnit, capitalStr;
            //capitalStr = t.LongStr2CapitalStr(cc.Capital.ToString());//此处得到的字符串是“100亿”如此
            TextBox_Capital.Text = "";//返回前面的数字复制到TextBox_Capital.Text
            //capitalUnit = capitalStr.Substring(capitalStr.Length - 1);//返回最后的单位
            DropDownList_Units.SelectedValue = "1";//将单位赋值到DropDownList_Units控件中

            TextBox_Industry.Text = "";
            TextBox_Area.Text = "";
            TextBox_RoomNum.Text = "";
            TextBox_Address.Text = "";
            //DropDownList_Vector.SelectedValue = "1";
            TextBox_Introduction.Text = "";
            TextBox_BusinessScope.Text = "";
            TextBox_RegisteredAddress.Text = "";

            //此处Datetime需要转化一下
            TextBox_RegistrationDate.Text ="";
            TextBox_Contact.Text = "";
            TextBox_Phone.Text = "";
            TextBox_Email.Text = "";
            TextBox_QQ.Text = "";
            elm1.InnerText = "";
        }
    }
}