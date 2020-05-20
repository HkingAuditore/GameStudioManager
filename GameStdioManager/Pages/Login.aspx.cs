using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GameStdioManager.Controllers.Login;

namespace GameStdioManager.Pages
{
    public partial class Login : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Confirm_OnClick(object sender, EventArgs e)
        {
            PageBase.PagePlayer = new LoginController(C_PlayerNumber.Text,C_Password.Text).PlayerStudio;
            Debug.WriteLine(PageBase.PagePlayer.PlayerStudio.StudioName);
            Response.Redirect("GameDevelopment.aspx");
        }
    }
}