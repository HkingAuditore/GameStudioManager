using System;
using System.Web.UI;
using GameStdioManager.Controllers.Staff;
using GameStdioManager.Models;

namespace GameStdioManager
{
    public partial class Index : Page
    {
        private static StudioBehavior game;

        protected void Page_Load(object sender, EventArgs e)
        {
            // var staff = StaffSQLController.ReadStaffInfoSql("0");
            if (game == null)
            {
                game = new StudioBehavior();
                game.Start();
            }
            Label1.Text = game.GameTimer.GameTimeNow.ToString();
            
        }

        private void Show(object sender, EventArgs e)
        {
            Response.Write("<script>alert('" + game.GameTimer.GameTimeNow + "')</script>");
        }
    }
}