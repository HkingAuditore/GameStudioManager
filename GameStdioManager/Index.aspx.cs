using System;
using System.Web.UI;
using GameStdioManager.Controllers.Staff;
using GameStdioManager.Models;
using GameStdioManager.Models.Game;

namespace GameStdioManager
{
    public partial class Index : Page
    {
        private static StudioBehavior game;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (game == null)
            {
                game = new StudioBehavior();
                game.Start();
                var develop = new Game("99","The Last of Us");
                develop.StartDevelop(1);
            }
            Label1.Text = SimulatorTimer.GameTimeNow.ToString();
            // if(!IsPostBack)Show();
        }

        private void Show()
        {
            var staff = StaffSQLController.ReadStaffInfoSql("1");
            Response.Write("<script>alert('" + staff.ToString() + "')</script>");

        }
    }
}