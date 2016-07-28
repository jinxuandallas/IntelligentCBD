using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core;
using System.Data;

namespace IntelligentCBD.Test
{
    public partial class CommentTest : System.Web.UI.Page
    {
        protected CommentClass commentc;
        protected void Page_Load(object sender, EventArgs e)
        {
            //测试用
            Session["CompanyID"] = System.Configuration.ConfigurationManager.AppSettings["companyID"];

            commentc = new CommentClass();
        }

        protected void ListViewResult_ItemCreated(object sender, ListViewItemEventArgs e)
        {
            //if (e.Item.ItemType ==ListItemType.Item)
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Repeater rpt = e.Item.FindControl("Repeater1") as Repeater;
                if (rpt != null)
                {
                    //int picType = int.Parse(((DataRowView)e.Item.DataItem).Row[0].ToString());
                    //if (picType != 0)
                    //Guid id = Guid.Parse((e.Item.FindControl("ID") as Label).Text);
                    Guid id = Guid.Parse(((DataRowView)e.Item.DataItem).Row["ID"].ToString());
                    if (id!=null)
                    {
                        rpt.DataSource = commentc.GetCommentPic(id);
                        rpt.DataBind();
                    }
                }
            }
        }
    }
}