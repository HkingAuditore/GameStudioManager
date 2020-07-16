using System.Collections.Generic;
using GameStdioManager.Controllers.Login;
using GameStdioManager.Controllers.Player;
using GameStdioManager.Controllers.Staff;
using GameStdioManager.Pages;

namespace GameStdioManager.Controllers
{
    public class Loader : ControllerBase
    {
        public List<Models.Staff.Staff> StaffList;
        public Models.Player.Player PlayerTarget;

        public Loader(LoginController loginController)
        {
            if (loginController.IsCorrespond)
            {
                StaffList = StaffSQLController.GenerateStaffList();

                //TODO 这里要优化
                PageBase.StaffList = StaffList;

                PlayerTarget = PlayerSqlController.ReadPlayerInfoSql(loginController.PlayerNumber, true);

            }
        }
    }
}