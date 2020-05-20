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

            SimulatorTimer.ReadCheckpointListXml();
            // Game newGame = new Game("10", "Test");
            // newGame.StartDevelop(2, 8);

            // SimulatorTimer.SaveCheckpointListXml();
        }

    }
}