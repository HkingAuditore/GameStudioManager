using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameStdioManager.Views
{
    public partial class StaffPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void L_StaffEmploy_OnClick(object sender, EventArgs e)
        {
            Server.Transfer("../Pages/StaffEmploy.aspx");
        }

        protected void L_StaffEdit_OnClick(object sender, EventArgs e)
        {
            Server.Transfer("../Pages/StaffEdit.aspx");
        }
    }
}