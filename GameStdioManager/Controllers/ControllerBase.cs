using System;
using GameStdioManager.Models;
using GameStdioManager.Models.Game;
using GameStdioManager.Models.Staff;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace GameStdioManager.Controllers
{
    public class ControllerBase
    {
        public static readonly string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

        #region SQL语句转换

        /// <summary>
        ///     将string类型转换为SQL语句使用的格式
        /// </summary>
        /// <param name="target">目标字符串</param>
        /// <returns></returns>
        protected static string ConvertStringToSql(string target) => " '" + target + "' ";

        /// <summary>
        ///     给入任意一个SimulatorBase派生的实例插入到数据库
        /// </summary>
        /// <typeparam name="T">SimulatorBase派生的类</typeparam>
        /// <param name="simulatorObject">目标实例</param>
        public static void InsertInfoSql<T>(T simulatorObject)
            where T : IPropertyGetter
        {
            using (var sqlConnection = new SqlConnection(ConString))
            {
                var commandStringBuilderFirstPart =
                    new StringBuilder("INSERT INTO " + simulatorObject.GetTypeName() + "Info (");
                var commandStringBuilderSecondPart = new StringBuilder(") VALUES (");
                var properties = simulatorObject.GetType().GetProperties();

                // 抓取属性名称生成SQL语句
                var cur = 1;
                foreach (var property in properties)
                {
                    commandStringBuilderFirstPart.Append(property.Name);
                    if (property.PropertyType.Name == "String")
                        commandStringBuilderSecondPart
                           .Append(ConvertStringToSql((string)simulatorObject.GetPropertyValue(property.Name)));

                    else if (property.PropertyType.Name == "Temperament")
                        commandStringBuilderSecondPart.Append((int)(Temperament)
                                                              simulatorObject.GetPropertyValue(property.Name));

                    else if (property.PropertyType.Name == "DateTime")
                        commandStringBuilderSecondPart.Append(ConvertStringToSql(simulatorObject.GetPropertyValue(property.Name).ToString()));

                    else if (property.PropertyType.Name == "Boolean")
                        commandStringBuilderSecondPart.Append(Convert.ToInt32((bool)
                                                              simulatorObject.GetPropertyValue(property.Name)));

                    else if (property.PropertyType.Name == "Genres")
                        commandStringBuilderSecondPart.Append((int)(Genres)
                                                              simulatorObject.GetPropertyValue(property.Name));

                    else
                        commandStringBuilderSecondPart.Append((int)simulatorObject.GetPropertyValue(property.Name));
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

        #endregion SQL语句转换
    }
}