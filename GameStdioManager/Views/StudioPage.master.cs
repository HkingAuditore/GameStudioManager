using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameStdioManager.Views.Staff
{
    public partial class StudioPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void L_StudioEdit_OnClick(object sender, EventArgs e)
        {
            Server.Transfer("../Pages/StudioEdit.aspx");
        }

        protected void L_StudioAdvertisement_OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}