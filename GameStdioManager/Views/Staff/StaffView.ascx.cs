using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using GameStdioManager.Models;
using GameStdioManager.Models.Staff;
using GameStdioManager.Pages;
using GameStdioManager.Views.Game.GameSales;
using WebGrease.Css.Extensions;

namespace GameStdioManager.Views.Staff
{
    public partial class StaffView : UserControl
    {
        public static readonly string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

        private static List<Models.Staff.Staff> _studioStaffs = PageBase.PagePlayer.PlayerStudio.StudioStaffs;



        protected void Page_Load(object sender, EventArgs e)
        {

            if (!SimulatorTimer.IsTicking())
            {
                UP_UpdatePanel.UpdateMode = UpdatePanelUpdateMode.Conditional;
            }
            else
            {
                UP_UpdatePanel.UpdateMode = UpdatePanelUpdateMode.Always;
            }
            UpdateLines();
        }


        private void UpdateLines()
        {
            (from staff in _studioStaffs
             select staff).ForEach(staff =>
                                   {
                                       StaffViewLine dl = (StaffViewLine)LoadControl("StaffViewLine.ascx");
                                       dl.LineStaff = staff;
                                       GamesView.Controls.Add(dl);
                                   });
        }

    }
}