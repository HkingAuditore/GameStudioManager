using System.Collections.Generic;
using System.Linq;
using GameStdioManager.Controllers.Login;
using GameStdioManager.Controllers.Player;
using GameStdioManager.Controllers.Staff;
using GameStdioManager.Controllers.Studio;
using GameStdioManager.Models;
using GameStdioManager.Pages;

namespace GameStdioManager.Controllers
{
    public class Loader : ControllerBase
    {
        public List<Models.Staff.Staff> StaffList;
        public List<Models.Studio.Studio> StudioList;
        public Models.Player.Player PlayerTarget;
        public StudioBehavior GameBehavior;
        public bool _isLoaded = false;
        public bool _isInit = false;
        public bool _isStart = false;

        public Loader(LoginController loginController)
        {
            if (loginController.IsCorrespond)
            {
                StaffList = StaffSQLController.GenerateStaffList();
                StudioList = StudioSQLController.GenerateStudioList(this);
                PlayerTarget = PlayerSqlController.ReadPlayerInfoSql(loginController.PlayerNumber, true,this);

                // 资源加载完毕
                IsLoaded = true;
            }
        }

        public bool IsLoaded
        {
            get => _isLoaded;
            private set => _isLoaded = value;
        }

        public bool IsInit
        {
            get => _isInit;
            private set => _isInit = value;
        }

        public bool IsStart
        {
            get => _isStart;
            private set => _isStart = value;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void GameInit()
        {
            // 时间流生成
            GameBehavior = new StudioBehavior(true);

            if (PageBase.PagePlayer.PlayerStudio.FindWorkingStaffs().Count == 0)
                SimulatorTimer.SpeedSetQuick();

            //计时器
            GameBehavior.Init();
            IsInit = true;
        }


        /// <summary>
        /// 开始事务
        /// </summary>
        public void GameStart()
        {
            //加载Checkpoint
            SimulatorTimer.ReadCheckpointListXml(PageBase.PagePlayer);
            PageBase.PagePlayer.ReadStaffCurWorkDataListXml();

            GameBehavior.Start();
            IsStart = true;
        }

        public Models.Staff.Staff FindStaff(string staffNumber) =>
            (from s in this.StaffList
             where s.StaffNumber == staffNumber
             select s)?.First();

        public Models.Studio.Studio FindStudio(string studioNumber) =>
            (from studio in StudioList
             where studio.StudioNumber == studioNumber
             select studio)?.First();
    }
}