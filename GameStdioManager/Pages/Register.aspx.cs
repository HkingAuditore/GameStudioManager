using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GameStdioManager.Controllers;
using GameStdioManager.Controllers.Login;
using GameStdioManager.Models.Player;
using GameStdioManager.Models.Studio;

namespace GameStdioManager.Pages
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Confirm_OnClick(object sender, EventArgs e)
        {
            try
            {
                Studio studio = new Studio(C_PlayerNumber.Text + "Studio", C_CompanyName.Text, 8000, 80);
                Player player = new Player(studio, C_PlayerNumber.Text);
                ControllerBase.InsertInfoSql(studio);
                LoginController.RegisterPlayer(player, C_Password.Text);

            }
            catch (Exception exception)
            {
                Response.Write("<script>alert('" + exception.Message + "')</script>");
            }
        }

        protected void Login_OnClick(object sender, EventArgs e)
        {
            Server.Transfer("Login.aspx");

        }
    }
}