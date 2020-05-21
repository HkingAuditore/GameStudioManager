using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameStdioManager.Views
{
    public partial class GamePage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void L_GameDevelopment_OnClick(object sender, EventArgs e)
        {
            Server.Transfer("../Pages/GameDevelopment.aspx");

        }

        protected void L_GameSales_OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void L_GameInfo_OnClick(object sender, EventArgs e)
        {
            Server.Transfer("../Pages/GameDevelopedInfo.aspx");

        }
    }
}