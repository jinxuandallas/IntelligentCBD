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
            CompanyClass cc = new CompanyClass();
            Tools t = new Tools();
            /*测试DateTime未录入情况（即为空值）
            DateTime dd;
            DateTime.TryParse(TextBox_RegistrationDate.Text,out dd);
            cc.RegistrationDate = dd;
            TextBox_RegistrationDate.Text = cc.RegistrationDate.ToShortDateString();
            Response.Write(cc.RegistrationDate);
            */
            //cc.ID=Guid.NewGuid();

            cc.CompanyName = TextBox_CompanyName.Text;
            cc.Capital = t.CapitalString2Long(TextBox_Capital.Text, DropDownList_Units.SelectedValue);
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

            Guid id=cc.AddCompanyBaseInformation(Session["username"].ToString());
            Session["companyID"] = id;
            //将用户的账号类型从个人改为商户
            UserClass uc = new UserClass();
            if (uc.UpdateAccountType(Session["username"].ToString(), 2) && id != Guid.Empty)
                Response.Redirect("Credentials.aspx");
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
    }
}