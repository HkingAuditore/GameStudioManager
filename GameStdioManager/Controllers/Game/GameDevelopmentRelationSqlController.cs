using System;
using System.Data;
using System.Data.SqlClient;
using GameStdioManager.Models.Game;

namespace GameStdioManager.Controllers.Game
{
    public class GameDevelopmentRelationSqlController : ControllerBase
    {

        /// <summary>
        /// 向数据库插入开发关系
        /// </summary>
        /// <param name="game"></param>
        /// <param name="developer"></param>
        public static void InsertDeveloperRelation(Models.Game.Game game, Models.Staff.Staff developer)
        {
            using (var sqlConnection = new SqlConnection(ConString))
            {
                var sqlCommand = new SqlCommand("INSERT INTO DeveloperRelation VALUES ("
                                              + ConvertStringToSql(developer.StaffNumber) + ","
                                              + ConvertStringToSql(game.GameNumber)
                                              + ")", sqlConnection);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }

        }

        /// <summary>
        /// 向数据库移除开发关系
        /// </summary>
        /// <param name="game"></param>
        /// <param name="developer"></param>
        public static void DeleteDeveloperRelation(Models.Game.Game game, Models.Staff.Staff developer)
        {
            using (var sqlConnection = new SqlConnection(ConString))
            {
                var sqlCommand = new SqlCommand("DELETE FROM DeveloperRelation WHERE ( DeveloperStaffNumber = "
                                              + ConvertStringToSql(developer.StaffNumber) + "AND DeveloperGameNumber = "
                                              + ConvertStringToSql(game.GameNumber)
                                              + ")", sqlConnection);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }

        }

    }
}