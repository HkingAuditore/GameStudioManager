using System;
using System.Diagnostics;
using System.Web.UI;
using GameStdioManager.Controllers.Player;
using GameStdioManager.Models;
using GameStdioManager.Models.Checkpoint;
using GameStdioManager.Pages;
using System.Web.Script.Services;
using System.Web.Services;
using GameStdioManager.Controllers;

namespace GameStdioManager.Views
{
    public partial class MainMaster : MasterPage
    {
        public static string MasterPlayerNumber;
        public static bool GameInitChecker = false;
        

        private void MasterPageInit()
        {
            La_StudioName.Text = PageBase.PagePlayer.PlayerStudio.StudioName;
            GameInitChecker = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GameInitChecker)
            {
                MasterPageInit();
            }

            La_StudioName.Text = PageBase.PagePlayer.PlayerStudio.StudioName;
            La_Timer.Text = SimulatorTimer.GameTimeNow.DayOfWeek.ToString() + SimulatorTimer.GameTimeNow.ToString();
            La_StudioProperty.Text = PageBase.PagePlayer.PlayerStudio.StudioProperty.ToString();
        }

        protected void B_SaveGame_OnClick(object sender, EventArgs e)
        {
            PageBase.SaveGame();
        }

        protected void L_Game_OnClick(object sender, EventArgs e)
        {
            Server.Transfer("../Pages/GameDevelopment.aspx");
        }

        protected void L_Staff_OnClick(object sender, EventArgs e)
        {
            Server.Transfer("../Pages/StaffEmploy.aspx");
        }

        protected void L_Studio_OnClick(object sender, EventArgs e)
        {
            Server.Transfer("../Pages/StudioEdit.aspx");
        }



    }
}