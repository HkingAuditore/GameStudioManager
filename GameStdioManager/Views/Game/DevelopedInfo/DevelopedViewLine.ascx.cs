using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GameStdioManager.Models;
using GameStdioManager.Pages;
using GameStdioManager.Views.Game.Develop;

namespace GameStdioManager.Views.Game.DevelopedInfo
{
    public partial class DevelopedViewLine : System.Web.UI.UserControl
    {
        // 这一行要显示的游戏
        public Models.Game.Game LineGame;

        public static readonly string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;


        public DevelopedViewLine(Models.Game.Game game)
        {
            LineGame = game;
        }

        public DevelopedViewLine()
        {
            LineGame = null;
        }

        private void UpdateView()
        {
            C_GameNumber.Text = LineGame.GameNumber;
            C_GameName.Text = LineGame.GameName;
            C_GameStartDevelopTime.Text = LineGame.GameStartDevelopTime.ToString("yyyy-MM-dd");
            C_GameProcess.Text = LineGame.GameFinishDevelopTime.ToString("yyyy-MM-dd");
            C_GameFun.Text = LineGame.GameFun.ToString();
            C_GameArt.Text = LineGame.GameArt.ToString();
            C_GameMusic.Text = LineGame.GameMusic.ToString();
            ShowDevelopers();
        }

        private void ShowDevelopers()
        {
            foreach (var developer in LineGame.Developers)
            {
                if (developer.StaffStudio == PageBase.PagePlayer.PlayerStudioNumber)
                {
                    Developer dv = (Developer)LoadControl("Developer.ascx");
                    dv.ThisDeveloper = developer;
                    dv.ParentViewLine = this;
                    C_Developers.Controls.Add(dv);

                }
            }


        }

        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateView();
        }

    }
}