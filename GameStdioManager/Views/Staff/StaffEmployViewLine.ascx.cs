using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GameStdioManager.Models;
using GameStdioManager.Models.Staff;
using GameStdioManager.Pages;
using WebGrease.Css.Extensions;

namespace GameStdioManager.Views.Staff
{
    public partial class StaffEmployViewLine : System.Web.UI.UserControl
    {
        public Models.Staff.Staff LineStaff;

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowStaffInfo();
        }

        private void ShowStaffInfo()
        {
            Controls.Cast<Control>()
                    .Where(ct => ct.GetType().ToString().Equals("System.Web.UI.WebControls.Label") &&
                                 ct.ID != "LF_StaffCurStrength")
                    .Select(ct => (Label) ct)
                    .ForEach(label =>
                             {
                                 try
                                 {
                                     label.Text = LineStaff.GetPropertyValue(label.ID.Split('_')[1]).ToString();
                                 }
                                 catch
                                 {
                                     throw;
                                     // textBox.Text = ((int)staff.GetPropertyValue(textBox.ID.Split('_')[1])).ToString();
                                 }
                             });
        }

        protected void B_Employ_OnClick_OnClick(object sender, ImageClickEventArgs e)
        {
            PageBase.PagePlayer.PlayerStudio.AddStaff(LineStaff);
            LineStaff.UpdateSql();
        }
    }
}