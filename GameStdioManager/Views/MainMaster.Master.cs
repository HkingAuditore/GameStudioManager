using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GameStdioManager.Models;
using GameStdioManager.Pages;

namespace GameStdioManager.Views
{
    public partial class MainMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(PageBase.PageGame == null)
            {
                PageBase.PageGame = new StudioBehavior(true);
                PageBase.PageGame.Start();
                La_StudioName.Text = PageBase.PagePlayer.PlayerStudio.StudioName;
            }

            La_Timer.Text = SimulatorTimer.GameTimeNow.ToString();
        }
    }
}