using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using GameStdioManager.Controllers.Game;
using GameStdioManager.Controllers.Staff;
using GameStdioManager.Models;
using GameStdioManager.Pages;

namespace GameStdioManager.Views.Game.Develop
{
    public partial class DevelopViewLine : System.Web.UI.UserControl
    {
        // 这一行要显示的游戏
        public Models.Game.Game LineGame;

        public static readonly string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;


        public DevelopViewLine(Models.Game.Game game)
        {
            LineGame = game;
        }

        public DevelopViewLine()
        {
            LineGame = null;
        }

        private void UpdateView()
        {
            C_GameNumber.Text = LineGame.GameNumber;
            C_GameName.Text = LineGame.GameName;
            C_GameStartDevelopTime.Text = LineGame.GameStartDevelopTime.ToString("yyyy-MM-dd");
            C_GameProcess.Text = LineGame.GetGameDevelopProcess().ToString("F1") + "%";
            C_GameFun.Text = LineGame.GameFun.ToString();
            C_GameArt.Text = LineGame.GameArt.ToString();
            C_GameMusic.Text = LineGame.GameMusic.ToString();
            ShowDevelopers();
        }

        private void ShowDevelopers()
        {
            foreach (var developer in LineGame.Developers)
            {
                Developer dv = (Developer)LoadControl("Developer.ascx");
                dv.ThisDeveloper = developer;
                dv.ParentViewLine = this;
                C_Developers.Controls.Add(dv);
            }


        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GameStudioSimulator.SelectParameters["ThisGame"].DefaultValue = LineGame.GameNumber;
            UpdateView();
        }

        protected void B_AddDeveloper_OnClick(object sender, ImageClickEventArgs e)
        {
            D_Deverloper.DataBind();
            P_EditDeveloper.Visible = !P_EditDeveloper.Visible;
            SimulatorTimer.Pause();

        }

        protected void B_ConfirmButton_OnClick(object sender, ImageClickEventArgs e)
        {
            LineGame.AddDeveloper(PageBase.PagePlayer.PlayerStudio.FindStaff(D_Deverloper.SelectedValue));
            P_EditDeveloper.Visible = !P_EditDeveloper.Visible;
            PageBase.SaveGame();
            SimulatorTimer.GoOn();

        }

        protected string GetGameNumber() => LineGame.GameNumber;

        protected void B_CancelButton_OnClick(object sender, ImageClickEventArgs e)
        {
            P_EditDeveloper.Visible = !P_EditDeveloper.Visible;

            SimulatorTimer.GoOn();
        }
    }
}