using GameStdioManager.Models.Game;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace GameStdioManager.Controllers.Game
{
    public class GameSQLController : ControllerBase
    {
        /// <summary>
        ///     从数据库中读取游戏数据并生成实例
        /// </summary>
        /// <param name="gameNumber"></param>
        /// <returns></returns>
        public static Models.Game.Game ReadGameInfoSql(string gameNumber)
        {
            Models.Game.Game game = null;

            using (var sqlConnection = new SqlConnection(ConString))
            {
                // 使用了Target占位符表示目标ID
                var sqlCommand = new SqlCommand("SELECT * FROM GameInfo WHERE GameNumber = @Target", sqlConnection);
                // 构造Parameter对象
                var targetSqlParameter = new SqlParameter("@Target", SqlDbType.VarChar, 255);
                targetSqlParameter.Value = gameNumber;
                sqlCommand.Parameters.Add(targetSqlParameter);

                sqlConnection.Open();
                var result = sqlCommand.ExecuteReader();

                if (result.HasRows)
                {
                    result.Read();
                    game = new Models.Game.Game(result["GameNumber"].ToString(),
                                                result["GameName"].ToString(),
                                                int.Parse(result["GamePrice"].ToString()),
                                                int.Parse(result["GameFun"].ToString()),
                                                int.Parse(result["GameArt"].ToString()),
                                                int.Parse(result["GameMusic"].ToString()),
                                                int.Parse(result["GameSales"].ToString()),
                                                result["GameStudio"].ToString(),
                                                (Genres)int.Parse(result["GameGenres"].ToString()),
                                                Convert.ToBoolean(int.Parse(result["GameIsDeveloping"].ToString()))
                                               );
                }

                result.Close();
            }

            return game;
        }

        /// <summary>
        ///     根据实例向数据库插入信息
        /// </summary>
        /// <param name="game"></param>
        [Obsolete("使用基类的 InsertInfoSql<T>(t)")]
        public static void InsertGameInfoSql(Models.Game.Game game)
        {
            using (var sqlConnection = new SqlConnection(ConString))
            {
                var commandStringBuilderFirstPart = new StringBuilder("INSERT INTO GameInfo (");
                var commandStringBuilderSecondPart = new StringBuilder(") VALUES (");
                var properties = game.GetType().GetProperties();

                // 抓取属性名称生成SQL语句
                var cur = 1;
                foreach (var property in properties)
                {
                    commandStringBuilderFirstPart.Append(property.Name);
                    if (property.PropertyType.Name == "String")
                        commandStringBuilderSecondPart
                           .Append(ConvertStringToSql((string)game.GetPropertyValue(property.Name)));
                    else
                        commandStringBuilderSecondPart.Append((int)game.GetPropertyValue(property.Name));
                    if (cur++ < properties.Length)
                    {
                        commandStringBuilderFirstPart.Append(", ");
                        commandStringBuilderSecondPart.Append(", ");
                    }
                }

                var command = commandStringBuilderFirstPart + commandStringBuilderSecondPart.ToString() +
                              ")";
                var sqlCommand = new SqlCommand(command, sqlConnection);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     比对两个Game实例生成SQL语句
        /// </summary>
        /// <param name="origin">旧实例</param>
        /// <param name="target">新实例</param>
        public static void UpdateGameInfoSql(Models.Game.Game origin, Models.Game.Game target)
        {
            // 属性比对，生成的SQL语句只包含要修改的部分
            var properties = origin.GetType().GetProperties();
            var updateList = new List<PropertyInfo>();
            foreach (var property in properties)
                if (!Equals(origin.GetPropertyValue(property.Name), target.GetPropertyValue(property.Name)))
                    updateList.Add(property);

            // 生成SQL语句
            var commandStringBuilder = new StringBuilder("UPDATE GameInfo SET ");

            var cur = 1;
            foreach (var targetProperty in updateList)
            {
                if (targetProperty.PropertyType.Name == "String")
                    commandStringBuilder.Append(targetProperty.Name + " = " +
                                                ConvertStringToSql((string)target
                                                                      .GetPropertyValue(targetProperty.Name)));
                else if (targetProperty.PropertyType.Name == "Genres")
                    commandStringBuilder.Append(targetProperty.Name + " = " +
                                                (int)(Genres)target.GetPropertyValue(targetProperty.Name));

                else if (targetProperty.PropertyType.Name == "Boolean")
                    commandStringBuilder.Append(targetProperty.Name + " = " +
                                               Convert.ToInt32((bool)target.GetPropertyValue(targetProperty.Name)));
                else
                    commandStringBuilder.Append(targetProperty.Name + " = " +
                                                (int)target.GetPropertyValue(targetProperty.Name));
                if (cur++ < updateList.Count) commandStringBuilder.Append(", ");
            }

            commandStringBuilder.Append(" WHERE GameNumber = " + ConvertStringToSql(origin.GameNumber));

            // 执行
            try
            {
                using (var sqlConnection = new SqlConnection(ConString))
                {
                    var sqlCommand = new SqlCommand(commandStringBuilder.ToString(), sqlConnection);

                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }

            }
            catch
            {
                
            }
        }
    }
}