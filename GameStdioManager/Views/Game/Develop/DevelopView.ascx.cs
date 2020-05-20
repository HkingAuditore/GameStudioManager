using GameStdioManager.Controllers.Game;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using GameStdioManager.Models;
using GameStdioManager.Models.Checkpoint;
using GameStdioManager.Pages;
using WebGrease.Css.Extensions;

namespace GameStdioManager.Views.Game.Develop
{
    public partial class DevelopView : System.Web.UI.UserControl
    {
        public static readonly string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

        private static List<Models.Game.Game> _developingGames = new List<Models.Game.Game>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Models.Game.Game.UpdateDevelopEvent += UpdateGameDevelopment;
                Models.Game.Game.EndDevelopEvent += EndGameDevelopment;
            }
            UpdateLines();
        }

        public void UpdateGameDevelopment(SimulatorBase sender, CheckpointArgs args)
        {
            Models.Game.Game temp = (Models.Game.Game) sender;
            if (!_developingGames.Contains(temp)) _developingGames.Add(temp);
        }

        public void EndGameDevelopment(SimulatorBase sender, CheckpointArgs args)
        {
            Models.Game.Game temp = (Models.Game.Game)sender;
            if (_developingGames.Contains(temp)) _developingGames.Remove(temp);
        }

        private void UpdateLines()
        {
            (from developingGame in _developingGames 
             select developingGame).ForEach(developingGame =>
                                            {
                                                DevelopViewLine dl = (DevelopViewLine)LoadControl("DevelopViewLine.ascx");
                                                dl.LineGame = developingGame;
                                                GamesView.Controls.Add(dl);
                                            });
        }

    }
}
