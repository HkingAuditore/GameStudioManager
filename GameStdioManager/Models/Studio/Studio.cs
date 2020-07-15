using System;
using System.Collections.Generic;
using System.Linq;
using WebGrease.Css.Extensions;

namespace GameStdioManager.Models.Studio
{
    public class Studio : SimulatorBase
    {
        public Studio(string studioNumber, string studioName, int studioProperty, int studioReputation)
        {
            StudioNumber     = studioNumber;
            StudioName       = studioName;
            StudioProperty   = studioProperty;
            StudioReputation = studioReputation;
        }

        /// <summary>
        ///     工作室编号
        /// </summary>
        public string StudioNumber { get; }

        /// <summary>
        ///     工作室名称
        /// </summary>
        public string StudioName { get; }

        /// <summary>
        ///     工作室财产
        /// </summary>
        public int StudioProperty { get; set; }

        /// <summary>
        ///     工作室声誉
        /// </summary>
        public int StudioReputation { get; set; }

        /// <summary>
        /// 工作室开发中的游戏
        /// </summary>
        public List<Game.Game> StudioDevelopingGames = new List<Game.Game>();

        /// <summary>
        /// 工作室开发完的游戏
        /// </summary>
        public List<Game.Game> StudioDevelopedGames = new List<Game.Game>();

        #region 类基本操作

        #region 接口实现

        public override string GetObjectNumber() => StudioNumber;

        #endregion 接口实现

        #endregion 类基本操作

        #region 员工操作

        /// <summary>
        /// 员工
        /// </summary>
        public List<Staff.Staff> StudioStaffs = new List<Staff.Staff>();

        public void AddStaff(Staff.Staff staff)
        {
            StudioStaffs.Add(staff);
            staff.StaffStudioObject = this;
        }

        public void RemoveStaff(Staff.Staff staff)
        {
            StudioStaffs.Remove(staff);
            staff.StaffStudioObject = null;
        }


        /// <summary>
        /// 查找员工
        /// </summary>
        /// <param name="staffNumber"></param>
        /// <returns></returns>
        public Staff.Staff FindStaff(string staffNumber)
        {
            try
            {
               return (from s in StudioStaffs
                              where s.StaffNumber == staffNumber
                              select s)?.First();
            }
            catch (System.InvalidOperationException e)
            {
                return null;
            }
        }

        public List<Staff.Staff> FindWorkingStaffs() =>
            (from staff in StudioStaffs
             where staff.IsWorking
             select staff).ToList();

        #endregion

        #region 游戏表操作

        /// <summary>
        /// 添加一个开发中游戏
        /// </summary>
        /// <param name="game"></param>
        public void AddDevelopingGame(Game.Game game)
        {
            if (!StudioDevelopingGames.Contains(game)) StudioDevelopingGames.Add(game);
        }

        /// <summary>
        /// 移除一个开发中游戏
        /// </summary>
        /// <param name="game"></param>
        public void RemoveDevelopingGame(Game.Game game)
        {
            if (StudioDevelopingGames.Contains(game)) StudioDevelopingGames.Remove(game);
        }

        /// <summary>
        /// 添加一个开发完毕游戏
        /// </summary>
        /// <param name="game"></param>
        public void AddDevelopedGame(Game.Game game)
        {
            if (!StudioDevelopedGames.Contains(game)) StudioDevelopedGames.Add(game);
        }

        /// <summary>
        /// 移除一个开发完毕游戏
        /// </summary>
        /// <param name="game"></param>
        public void RemoveDevelopedGame(Game.Game game)
        {
            if (StudioDevelopedGames.Contains(game)) StudioDevelopedGames.Remove(game);
        }

        #endregion

        /// <summary>
        /// 查找目标游戏
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Game.Game FindGame(string value) =>
            (from g in StudioDevelopingGames.Union(StudioDevelopedGames)
             where g.GameNumber == value
             select g).First();

        public void SaveSalesGameData()
        {
            (from g in StudioDevelopedGames
             select g).ForEach(game => game.UpdateSql());
        }
    }
}