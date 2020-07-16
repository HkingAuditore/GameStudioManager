using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.UI;
using GameStdioManager.Controllers;
using GameStdioManager.Controllers.Player;
using GameStdioManager.Controllers.Studio;
using GameStdioManager.Models;
using GameStdioManager.Models.Player;
using GameStdioManager.Models.Staff;
using GameStdioManager.Models.Studio;

namespace GameStdioManager.Pages
{
    public class PageBase : System.Web.UI.Page
    {
        public static Player PagePlayer = null;
        public static StudioBehavior PageGame = null;
        public static List<Staff> StaffList = null;
        public static List<Studio> StudioList = null;
        public static Loader Loader;

        public static void SaveGame()
        {
            Debug.WriteLine(PageBase.PagePlayer.PlayerNumber);
            PageBase.PagePlayer.PlayerNowTime = SimulatorTimer.GameTimeNow;
            PlayerSqlController
               .UpdatePlayerInfoSql(PlayerSqlController.ReadPlayerInfoSql(PageBase.PagePlayer.PlayerNumber,false, PageBase.Loader),
                                    PageBase.PagePlayer);
            StudioSQLController.UpdateStudioInfoSql(StudioSQLController.ReadStudioInfoSql(PageBase.PagePlayer.PlayerStudio.StudioNumber,false, PageBase.Loader),
                                                    PageBase.PagePlayer.PlayerStudio);
            PageBase.PagePlayer.PlayerStudio.SaveSalesGameData();
            SimulatorTimer.SaveCheckpointListXml(PageBase.PagePlayer);
            PagePlayer.SaveStaffCurWorkDataListXml();


        }

        public static Staff FindStaff(string staffNumber) =>
            (from s in StaffList
             where s.StaffNumber == staffNumber
             select s)?.First();

        public static  Models.Studio.Studio FindStudio(string studioNumber) =>
            (from studio in StudioList
             where studio.StudioNumber == studioNumber
             select studio)?.First();
    }
}