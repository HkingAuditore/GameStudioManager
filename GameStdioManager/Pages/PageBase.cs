using System.Diagnostics;
using GameStdioManager.Controllers.Player;
using GameStdioManager.Models;
using GameStdioManager.Models.Player;
using GameStdioManager.Models.Studio;

namespace GameStdioManager.Pages
{
    public class PageBase : System.Web.UI.Page
    {
        public static Player PagePlayer = null;
        public static StudioBehavior PageGame = null;

        public static void SaveGame()
        {
            Debug.WriteLine(PageBase.PagePlayer.PlayerNumber);
            PageBase.PagePlayer.PlayerNowTime = SimulatorTimer.GameTimeNow;
            PlayerSqlController
               .UpdatePlayerInfoSql(PlayerSqlController.ReadPlayerInfoSql(PageBase.PagePlayer.PlayerNumber,false),
                                    PageBase.PagePlayer);
            SimulatorTimer.SaveCheckpointListXml(PageBase.PagePlayer);
            PagePlayer.SaveStaffCurWorkDataListXml();

        }
    }
}