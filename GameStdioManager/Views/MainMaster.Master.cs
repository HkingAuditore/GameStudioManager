using System;
using System.Diagnostics;
using System.Web.UI;
using GameStdioManager.Controllers.Player;
using GameStdioManager.Models;
using GameStdioManager.Models.Checkpoint;
using GameStdioManager.Pages;

namespace GameStdioManager.Views
{
    public partial class MainMaster : MasterPage
    {
        public static string MasterPlayerNumber;
        public static event CheckpointHandler GameInit;
        public static bool GameInitChecker = false;

        private void MasterGameInit()
        {
            PageBase.PageGame = new StudioBehavior(true);
            // SimulatorTimer.ReadCheckpointListXml();
            PageBase.PageGame.Start();
            La_StudioName.Text = PageBase.PagePlayer.PlayerStudio.StudioName;

            GameInitChecker = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GameInitChecker)
            {
                MasterGameInit();
                GameInit?.Invoke(PageBase.PagePlayer,null);
            }

            La_Timer.Text = SimulatorTimer.GameTimeNow.ToString();
        }

        protected void B_SaveGame_OnClick(object sender, EventArgs e)
        {
            Debug.WriteLine(PageBase.PagePlayer.PlayerNumber);
            PageBase.PagePlayer.PlayerNowTime = SimulatorTimer.GameTimeNow;
            PlayerSqlController
                    .UpdatePlayerInfoSql(PlayerSqlController.ReadPlayerInfoSql(PageBase.PagePlayer.PlayerNumber),
                                         PageBase.PagePlayer);
        }

    }
}