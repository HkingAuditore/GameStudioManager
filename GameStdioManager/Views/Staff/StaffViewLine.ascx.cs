using System;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using GameStdioManager.Models;
using GameStdioManager.Models.Staff;
using WebGrease.Css.Extensions;

namespace GameStdioManager.Views.Staff
{
    public partial class StaffViewLine : UserControl
    {
        public Models.Staff.Staff LineStaff;

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowStaffInfo();

            L_StaffName.ForeColor = LineStaff.IsWorking ? Color.FromArgb(51, 204, 255) : Color.FromArgb(28, 28, 28);
            LF_StaffCurStrength.Text = "("+LineStaff.StaffCurStrength.ToString()+")";
        }

        private void ShowStaffInfo()
        {
            Controls.Cast<Control>()
                    .Where(ct => ct.GetType().ToString().Equals("System.Web.UI.WebControls.Label") && ct.ID != "LF_StaffCurStrength")
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

        protected void Setting_OnClick(object sender, ImageClickEventArgs e)
        {
            var propertyName = ((ImageButton) sender).ID.Split('_')[1];
            propertyName = propertyName.Substring(0,propertyName.Length - 7);
            var     label = FindControl("L_" + propertyName);
            Control ct;
            var     isTextBox = true;

            if ((ct = FindControl("T_" + propertyName)) == null)
            {
                ct        = FindControl("D_" + propertyName);
                isTextBox = false;
            }


            if (label.Visible)
            {
                label.Visible = false;
                ct.Visible    = true;

                SimulatorTimer.Pause();
            }
            else
            {
                if (isTextBox)
                {
                    try
                    {
                        LineStaff.GetType().GetProperty(propertyName)?.SetValue(LineStaff, int.Parse(((TextBox)ct).Text));

                    }
                    catch (Exception exception)
                    {
                        LineStaff.GetType().GetProperty(propertyName)?.SetValue(LineStaff, int.Parse(((TextBox)ct).Text));
                        throw;
                    }
                }
                else
                {
                    if (propertyName == "StaffRank")
                        LineStaff.GetType().GetProperty(propertyName)
                                ?.SetValue(LineStaff, (Rank) int.Parse(((DropDownList) ct).SelectedValue));
                    else
                        LineStaff.GetType().GetProperty(propertyName)
                                ?.SetValue(LineStaff, (Occupation) int.Parse(((DropDownList) ct).SelectedValue));
                }

                ct.Visible    = false;
                label.Visible = true;

                LineStaff.UpdateSql();

                SimulatorTimer.GoOn();
            }
        }
    }
}