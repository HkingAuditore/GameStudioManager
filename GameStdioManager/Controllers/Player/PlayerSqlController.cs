using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using GameStdioManager.Controllers.Studio;

namespace GameStdioManager.Controllers.Player
{
    public class PlayerSqlController : ControllerBase
    {
        public static Models.Player.Player ReadPlayerInfoSql(string playerNumber,bool isNew)
        {
            Models.Player.Player player = null;

            using (var sqlConnection = new SqlConnection(ConString))
            {
                // 使用了Target占位符表示目标ID
                var sqlCommand = new SqlCommand("SELECT * FROM PlayerInfo WHERE PlayerNumber = @Target", sqlConnection);
                // 构造Parameter对象
                var targetSqlParameter = new SqlParameter("@Target", SqlDbType.VarChar, 255);
                targetSqlParameter.Value = playerNumber;
                sqlCommand.Parameters.Add(targetSqlParameter);

                sqlConnection.Open();
                var result = sqlCommand.ExecuteReader();

                if (result.HasRows)
                {
                    result.Read();
                    player =
                        new Models.Player.Player(StudioSQLController.ReadStudioInfoSql(result["PlayerStudioNumber"]
                                                                                          .ToString(), isNew));
                    player.PlayerStudioNumber = result["PlayerStudioNumber"].ToString();
                    player.PlayerNumber = result["PlayerNumber"].ToString();
                    player.PlayerStartTime    = DateTime.Parse(result["PlayerStartTime"].ToString());
                    player.PlayerNowTime      = DateTime.Parse(result["PlayerNowTime"].ToString());
                }

                result.Close();
            }

            return player;
        }

        /// <summary>
        ///     更新数据库的Player数据
        /// </summary>
        /// <param name="origin">旧实例</param>
        /// <param name="target">新实例</param>
        public static void UpdatePlayerInfoSql(Models.Player.Player origin, Models.Player.Player target)
        {
            try
            {
                // 属性比对，生成的SQL语句只包含要修改的部分
                var properties = origin.GetType().GetProperties();
                var updateList = new List<PropertyInfo>();
                foreach (var property in properties)
                    if (!Equals(origin.GetPropertyValue(property.Name), target.GetPropertyValue(property.Name)))
                        updateList.Add(property);

                // 生成SQL语句
                var commandStringBuilder = new StringBuilder("UPDATE PlayerInfo SET ");

                var cur = 1;
                foreach (var targetProperty in updateList)
                {
                    if (targetProperty.PropertyType.Name == "String" || targetProperty.PropertyType.Name == "DateTime")
                        commandStringBuilder.Append(targetProperty.Name + " = " +
                                                    ConvertStringToSql(target
                                                                      .GetPropertyValue(targetProperty.Name).ToString()));
                    else
                        commandStringBuilder.Append(targetProperty.Name + " = " +
                                                    (int)target.GetPropertyValue(targetProperty.Name));

                    if (cur++ < updateList.Count) commandStringBuilder.Append(", ");
                }

                commandStringBuilder.Append(" WHERE PlayerNumber = " + ConvertStringToSql(origin.PlayerNumber));

                // 执行
                using (var sqlConnection = new SqlConnection(ConString))
                {
                    var sqlCommand = new SqlCommand(commandStringBuilder.ToString(), sqlConnection);

                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }

}