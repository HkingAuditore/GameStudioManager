using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GameStdioManager.Models;

namespace GameStdioManager.Pages
{
    public partial class GameDevelopment : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddGame_OnClick(object sender, ImageClickEventArgs e)
        {
            AddButtonPanel.Visible = false;
            AddGamePanel.Visible = true;
        }

        protected void CancelDevelop_OnClick(object sender, ImageClickEventArgs e)
        {
            AddButtonPanel.Visible = true;
            AddGamePanel.Visible = false;
        }

        protected void ConfirmDevelop_OnClick(object sender, ImageClickEventArgs e)
        {
            Models.Game.Game newGame = new Models.Game.Game(T_GameNumber.Text, T_GameName.Text, PageBase.PagePlayer.PlayerNumber);
            newGame.StartDevelop(int.Parse(T_GameDDL.Text), 0);
            AddButtonPanel.Visible = true;
            AddGamePanel.Visible = false;
        }


    }
}