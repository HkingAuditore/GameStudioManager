using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
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

        private static List<Models.Game.Game> _developedGames;
        private static bool IsInSearch = false;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsInSearch)
            {
                _developedGames = PageBase.PagePlayer.PlayerStudio.StudioDevelopedGames;
            }

            UP_UpdatePanel.UpdateMode = !SimulatorTimer.IsTicking() ? UpdatePanelUpdateMode.Conditional : UpdatePanelUpdateMode.Always;

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
             orderby developedGame.GameFinishDevelopTime descending
             select developedGame).ForEach(developedGame =>
                                                            {
                                                                DevelopedViewLine dl = (DevelopedViewLine)LoadControl("DevelopedViewLine.ascx");
                                                                dl.LineGame = developedGame;
                                                                GamesView.Controls.Add(dl);
                                                                Debug.WriteLine("LINE !");
                                                            });
        }

        protected void B_Search_OnClick(object sender, ImageClickEventArgs e)
        {
            if (T_Search.Text.Trim() != "")
            {
                string pattern = @".*" + T_Search.Text.Trim();
                _developedGames = (from game in PageBase.PagePlayer.PlayerStudio.StudioDevelopedGames
                                   where Regex.IsMatch(game.GameName, pattern)
                                   select game).ToList();
                IsInSearch = true;
            }
            else
            {
                _developedGames = PageBase.PagePlayer.PlayerStudio.StudioDevelopedGames;
                IsInSearch = false;
            }

            // UpdateLines();
        }
    }
}
