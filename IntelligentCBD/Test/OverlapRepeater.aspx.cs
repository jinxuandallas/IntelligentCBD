using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Core;

namespace IntelligentCBD.Test
{
    public partial class OverlapRepeater : System.Web.UI.Page
    {
        protected CompanyClass cc;
        protected Tools t;
        protected Guid companyID;
        protected void Page_Load(object sender, EventArgs e)
        {
            //测试用
            Session["CompanyID"] = System.Configuration.ConfigurationManager.AppSettings["companyID"];

            if (Session["CompanyID"] == null || Session["CompanyID"].ToString().Trim() == "")
                Response.Redirect("~/Account/Login.aspx");

            cc = new CompanyClass();
            t = new Tools();
            companyID = Guid.Parse(Session["CompanyID"].ToString());
            Repeater1.DataSource = cc.GetPicKind(companyID);
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            //return;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rpt2 = e.Item.FindControl("Repeater2") as Repeater;
                if (rpt2 != null)
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
    }
}