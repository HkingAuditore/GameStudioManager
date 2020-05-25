using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using GameStdioManager.Controllers;
using GameStdioManager.Controllers.Staff;
using GameStdioManager.Models.Staff;
using GameStdioManager.Pages;
using WebGrease.Css.Extensions;

namespace GameStdioManager.Views.Editors
{
    public partial class StaffEditor : CustomUserEditorControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        #region 操作逻辑

        /// <summary>
        ///     从当前页面的展示数据生成一个Staff
        /// </summary>
        /// <returns></returns>
        private Models.Staff.Staff GenerateStaffThisPanel() => new Models.Staff.Staff(StaffNumber.Text,
                                                                                      StaffName.Text,
                                                                                      (Gender) GetStaffGender(),
                                                                                      int.Parse(StaffSalary.Text),
                                                                                      (Rank) int.Parse(StaffRank.Text),
                                                                                      (Occupation) int.Parse(StaffOccupation.Text),
                                                                                      int.Parse(StaffStrength.Text),
                                                                                      int.Parse(StaffIntelligence.Text),
                                                                                      int.Parse(StaffLoyalty.Text),
                                                                                      int.Parse(StaffProperty.Text),
                                                                                      GetStaffTemperament(),
                                                                                      int.Parse(TimeToWork.Text),
                                                                                      int.Parse(TimeToQuit.Text),
                                                                                      int.Parse(WeekdaysLength.Text),
                                                                                      PageBase.PagePlayer.PlayerStudio.StudioNumber
                                                                                     );

        /// <summary>
        ///     插入Staff
        /// </summary>
        private Models.Staff.Staff InsertStaff()
        {
            var staff = GenerateStaffThisPanel();
            ControllerBase.InsertInfoSql(staff);
            return staff;
        }

        /// <summary>
        ///     从当前页面信息获取性格数据
        /// </summary>
        /// <returns></returns>
        private Temperament GetStaffTemperament()
        {
            Temperament result             = 0;
            if (Friendly.Checked) result   |= Models.Staff.Temperament.Friendly;
            if (Indecisive.Checked) result |= Models.Staff.Temperament.Indecisive;
            if (Gifted.Checked) result     |= Models.Staff.Temperament.Gifted;
            if (Malevolent.Checked) result |= Models.Staff.Temperament.Malevolent;
            if (Charisma.Checked) result   |= Models.Staff.Temperament.Charisma;
            return result;
        }

        /// <summary>
        ///     从当前页面信息获取性别
        /// </summary>
        /// <returns></returns>
        private int GetStaffGender() => Male.Checked ? 0 : 1;

        /// <summary>
        ///     重置页面
        /// </summary>
        private void ResetStaffInfoPanel()
        {
            (from Control ct in Controls
             where ct.GetType().ToString()
                     .Equals("System.Web.UI.WebControls.TextBox")
             select (TextBox) ct).ForEach(textBox => textBox.Text = "");

            (from Control ct in Controls
             where ct.GetType().ToString()
                     .Equals("System.Web.UI.WebControls.DropDownList")
             select (DropDownList) ct).ForEach(dropDownList => dropDownList.SelectedIndex = 0);

            // (from Control ct in Controls
            //  where ct.GetType().ToString()
            //          .Equals("System.Web.UI.WebControls.CheckBox")
            //  select (CheckBox)ct).ForEach(checkBox => checkBox.Checked = false);

            (from Control ct in Temperament.Controls
             where ct.GetType().ToString()
                     .Equals("System.Web.UI.WebControls.CheckBox")
             select (CheckBox) ct).ForEach(checkBox => checkBox.Checked = false);

            Male.Checked   = false;
            Female.Checked = false;
        }

        /// <summary>
        ///     在当前页面显示Staff数据
        /// </summary>
        /// <param name="staff">目标Staff对象</param>
        private void ShowStaffInfo(Models.Staff.Staff staff)
        {
            StaffNumber.Text       = staff.StaffNumber;
            StaffName.Text         = staff.StaffName;
            // StaffStudio.Text       = staff.StaffStudio;
            StaffSalary.Text       = staff.StaffSalary.ToString();
            StaffStrength.Text     = staff.StaffStrength.ToString();
            StaffIntelligence.Text = staff.StaffIntelligence.ToString();
            StaffLoyalty.Text      = staff.StaffLoyalty.ToString();
            StaffProperty.Text     = staff.StaffProperty.ToString();
            TimeToWork.Text        = staff.TimeToWork.ToString();
            TimeToQuit.Text        = staff.TimeToQuit.ToString();
            WeekdaysLength.Text    = staff.WeekdaysLength.ToString();

            StaffRank.SelectedIndex       = (int) staff.StaffRank;
            StaffOccupation.SelectedIndex = (int) staff.StaffOccupation;

            if (staff.StaffGender == Gender.Male)
                Male.Checked = true;
            else
                Female.Checked = true;

            foreach (Control ct in Temperament.Controls)
                if (ct.GetType().ToString().Equals("System.Web.UI.WebControls.CheckBox"))
                {
                    var cb = (CheckBox) ct;
                    if (staff.StaffTemperament.HasFlag((Temperament) Enum.Parse(typeof(Temperament), ct.ID)))
                        cb.Checked = true;
                }
        }

        #endregion 操作逻辑

        #region 交互

        protected void Update_OnClick(object sender, EventArgs e)
        {
            var origin = StaffSQLController.ReadStaffInfoSql(StaffNumber.Text);
            var target = GenerateStaffThisPanel();
            StaffSQLController.UpdateStaffInfoSql(origin, target);
        }

        protected void Reset_OnClick(object sender, EventArgs e)
        {
            StaffNumber.ReadOnly = false;
            ResetStaffInfoPanel();
        }

        protected void ReadFromSQL_OnClick(object sender, EventArgs e)
        {
            var staff = StaffSQLController.ReadStaffInfoSql(StaffNumber.Text.Trim());
            ResetStaffInfoPanel();
            ShowStaffInfo(staff);
            StaffNumber.ReadOnly = true;
        }

        protected void Confirm_OnClick(object sender, EventArgs e)
        {
            try
            {
                var staff = InsertStaff();
                PageBase.PagePlayer.PlayerStudio.AddStaff(staff);
                staff.GenerateWorkCheckpoints();

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('输入有误，请检查输入‘）</script>");
            }

        }

        #endregion 交互
    }
}