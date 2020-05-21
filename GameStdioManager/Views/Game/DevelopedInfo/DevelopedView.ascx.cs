using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GameStdioManager.Controllers.Game;
using GameStdioManager.Models;
using GameStdioManager.Models.Checkpoint;
using GameStdioManager.Pages;
using GameStdioManager.Views.Game.Develop;
using Microsoft.Ajax.Utilities;

namespace GameStdioManager.Views.Game.DevelopedInfo
{
    public partial class DevelopedView : System.Web.UI.UserControl
    {
        public static readonly string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

        private static List<Models.Game.Game> _developedGames = PageBase.PagePlayer.PlayerStudio.StudioDevelopedGames;



        protected void Page_Load(object sender, EventArgs e)
        {
            // if (!IsPostBack)
            // {
            //      Models.Game.Game.EndDevelopEvent += EndGameDevelopment;
            //      _developedGames = PageBase.PagePlayer.PlayerStudio.StudioDevelopedGames;
            // }
            if (!SimulatorTimer.IsTicking())
            {
                UP_UpdatePanel.UpdateMode = UpdatePanelUpdateMode.Conditional;
            }
            else
            {
                UP_UpdatePanel.UpdateMode = UpdatePanelUpdateMode.Always;
            }
            UpdateLines();
        }



        // public void EndGameDevelopment(SimulatorBase sender, CheckpointArgs args)
        // {
        //     Models.Game.Game temp = (Models.Game.Game)sender;
        //     if (!_developedGames.Contains(temp)) _developedGames.Add(temp);
        // }

        private void UpdateLines()
        {
            (from developedGame in _developedGames
             select developedGame).ForEach(developedGame =>
                                            {
                                                DevelopedViewLine dl = (DevelopedViewLine)LoadControl("DevelopedViewLine.ascx");
                                                dl.LineGame = developedGame;
                                                GamesView.Controls.Add(dl);
                                            });
        }
    }
}
