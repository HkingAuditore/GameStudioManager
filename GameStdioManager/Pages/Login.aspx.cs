using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using GameStdioManager.Controllers.Login;
using GameStdioManager.Views;

namespace GameStdioManager.Pages
{
    public partial class Login : PageBase
    {
        private static bool result = false;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Confirm_OnClick(object sender, EventArgs e)
        {
            var lc =new LoginController(C_PlayerNumber.Text, C_Password.Text);
            PageBase.PagePlayer = lc.PlayerTarget;
            PageBase.StaffList = lc.StaffList;
            if (lc.IsCorrespond)
            {
                Session["PlayerNumber"] = lc.PlayerTarget.PlayerNumber;
                Session["PlayerStudioNumber"] = lc.PlayerTarget.PlayerStudio.StudioNumber;
                Debug.WriteLine(PageBase.PagePlayer.PlayerStudio.StudioName);
                result = true;
                Server.Transfer("GameDevelopment.aspx");

            }
            else
            {
                result = false;
                Response.Write("<script>alert('密码错误！')</script>");
            }
        }

        [WebMethod]
        public static string GetResult()
        {
            return result ? "1" : "0";
        }

        protected void Register_OnClick(object sender, EventArgs e)
        {
            Server.Transfer("Register.aspx");
        }
    }
}