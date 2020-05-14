using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using GameStdioManager.Controllers.Staff;
using GameStdioManager.Models.Staff;

namespace GameStdioManager.Views
{
    public partial class Inserter : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 从当前页面的展示数据生成一个Staff
        /// </summary>
        /// <returns></returns>
        private Staff GenerateStaffThisPanel()
        {
            var staff = new Staff(StaffNumber.Text,
                StaffName.Text,
                (Gender)GetStaffGender(),
                int.Parse(StaffSalary.Text),
                (Rank)int.Parse(StaffRank.Text),
                (Occupation)int.Parse(StaffOccupation.Text),
                int.Parse(StaffStrength.Text),
                int.Parse(StaffIntelligence.Text),
                int.Parse(StaffLoyalty.Text),
                int.Parse(StaffProperty.Text),
                GetStaffTemperament(),
                int.Parse(TimeToWork.Text),
                int.Parse(TimeToQuit.Text),
                int.Parse(WeekdaysLength.Text),
                StaffStudio.Text
            );
            return staff;
        }

        /// <summary>
        /// 新增Staff
        /// </summary>
        private void InsertStaff()
        {
            
            StaffSQLController.InsertStaffInfoSql(GenerateStaffThisPanel());
        }

        
        protected void Confirm_OnClick(object sender, EventArgs e)
        {
            InsertStaff();
        }

        /// <summary>
        /// 从当前页面信息获取性格数据
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
        /// 从当前页面信息获取性别
        /// </summary>
        /// <returns></returns>
        private int GetStaffGender()
        {
            return Male.Checked ? 0 : 1;
        }

        protected void ReadFromSQL_OnClick(object sender, EventArgs e)
        {
            var target = StaffNumber.Text;
            var staff  = StaffSQLController.ReadStaffInfoSql(target.Trim());
            ResetStaffInfoPanel();
            ShowStaffInfo(staff);
            StaffNumber.ReadOnly = true;
        }

        /// <summary>
        /// 重置页面
        /// </summary>
        private void ResetStaffInfoPanel()
        {
            StaffNumber.Text       = "";
            StaffName.Text         = "";
            StaffSalary.Text       = "";
            StaffStrength.Text     = "";
            StaffIntelligence.Text = "";
            StaffLoyalty.Text      = "";
            StaffProperty.Text     = "";
            TimeToWork.Text        = "";
            TimeToQuit.Text        = "";
            WeekdaysLength.Text    = "";
            StaffStudio.Text       = "";

            StaffRank.SelectedIndex       = 0;
            StaffOccupation.SelectedIndex = 0;

            Male.Checked       = false;
            Female.Checked     = false;
            Friendly.Checked   = false;
            Indecisive.Checked = false;
            Gifted.Checked     = false;
            Malevolent.Checked = false;
            Charisma.Checked   = false;
        }

        /// <summary>
        /// 在当前页面显示Staff数据
        /// </summary>
        /// <param name="staff">目标Staff对象</param>
        private void ShowStaffInfo(Staff staff)
        {
            StaffNumber.Text       = staff.StaffNumber;
            StaffName.Text         = staff.StaffName;
            StaffStudio.Text       = staff.StaffStudio;
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

        protected void Update_OnClick(object sender, EventArgs e)
        {
            Staff origin = StaffSQLController.ReadStaffInfoSql(StaffNumber.Text);
            Staff target = GenerateStaffThisPanel();
            StaffSQLController.UpdateStaffInfoSql(origin,target);
        }

        protected void Reset_OnClick(object sender, EventArgs e)
        {
            StaffNumber.ReadOnly = false;
            ResetStaffInfoPanel();
        }
    }
}