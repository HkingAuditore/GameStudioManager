﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using GameStdioManager.Controllers.Game;
using GameStdioManager.Controllers.Staff;
using GameStdioManager.Pages;

namespace GameStdioManager.Controllers.Studio
{
    public class StudioSQLController : ControllerBase
    {
        /// <summary>
        ///     从数据库中读取工作室数据并生成对象
        /// </summary>
        /// <param name="staffNumber">工作室编号</param>
        /// <returns></returns>
        public static Models.Studio.Studio ReadStudioInfoSql(string studioNumber,bool isNew,Loader loader)
        {
            Models.Studio.Studio studio = null;

            using (var sqlConnection = new SqlConnection(ConString))
            {
                // 使用了Target占位符表示目标ID
                var sqlCommand = new SqlCommand("SELECT * FROM StudioInfo WHERE StudioNumber = @Target", sqlConnection);
                // 构造Parameter对象
                var targetSqlParameter = new SqlParameter("@Target", SqlDbType.VarChar, 255);
                targetSqlParameter.Value = studioNumber;
                sqlCommand.Parameters.Add(targetSqlParameter);

                sqlConnection.Open();
                var result = sqlCommand.ExecuteReader();

                if (result.HasRows)
                {
                    result.Read();
                    studio = new Models.Studio.Studio(result["StudioNumber"].ToString(),
                                                      result["StudioName"].ToString(),
                                                      int.Parse(result["StudioProperty"].ToString()),
                                                      int.Parse(result["StudioReputation"].ToString())
                                                     );
                    FillStudioStaffSql(studio, loader);
                    if (isNew)
                    {
                        foreach (var staff in studio.StudioStaffs)
                        {
                            staff.GenerateWorkCheckpoints();
                        }

                    }

                    FillStudioGameSql(studio, loader);

                }

                result.Close();
            }

            return studio;
        }

        /// <summary>
        /// 向Studio中填充员工
        /// </summary>
        /// <param name="studio"></param>
        public static void FillStudioStaffSql(Models.Studio.Studio studio,Loader loader)
        {
            using (var sqlConnection = new SqlConnection(ConString))
            {
                // 使用了Target占位符表示目标ID
                var sqlCommand = new SqlCommand("SELECT StaffNumber FROM StaffInfo WHERE StaffStudio = @Target", sqlConnection);
                // 构造Parameter对象
                var targetSqlParameter = new SqlParameter("@Target", SqlDbType.VarChar, 255);
                targetSqlParameter.Value = studio.StudioNumber;
                sqlCommand.Parameters.Add(targetSqlParameter);

                sqlConnection.Open();
                var result = sqlCommand.ExecuteReader();

                while (result.Read())
                {
                    studio.AddStaff(loader.FindStaff(result["StaffNumber"].ToString()));
                }

                result.Close();
            }

        }

        /// <summary>
        /// 向Studio中填充游戏
        /// </summary>
        /// <param name="studio"></param>
        public static void FillStudioGameSql(Models.Studio.Studio studio,Loader loader)
        {
            using (var sqlConnection = new SqlConnection(ConString))
            {
                // 使用了Target占位符表示目标ID
                var sqlCommand = new SqlCommand("SELECT GameNumber FROM GameInfo WHERE GameStudio = @Target", sqlConnection);
                // 构造Parameter对象
                var targetSqlParameter = new SqlParameter("@Target", SqlDbType.VarChar, 255);
                targetSqlParameter.Value = studio.StudioNumber;
                sqlCommand.Parameters.Add(targetSqlParameter);

                sqlConnection.Open();
                var result = sqlCommand.ExecuteReader();

                while (result.Read())
                {
                    Models.Game.Game game = GameSQLController.ReadGameInfoFromStudioSql(result["GameNumber"].ToString(),studio,loader);

                    if (game.GameIsDeveloping)
                    {
                        studio.AddDevelopingGame(game);
                    }
                    else
                    {
                        studio.AddDevelopedGame(game);
                        // game.StartSales();
                    }
                }

                result.Close();
            }

        }


        /// <summary>
        ///     向数据库插入工作室数据
        /// </summary>
        /// <param name="studio"></param>
        [Obsolete("使用基类的 InsertInfoSql<T>(t)")]
        public static void InsertStudioInfoSql(Models.Studio.Studio studio)
        {
            using (var sqlConnection = new SqlConnection(ConString))
            {
                var commandStringBuilderFirstPart  = new StringBuilder("INSERT INTO StudioInfo (");
                var commandStringBuilderSecondPart = new StringBuilder(") VALUES (");
                var properties                     = studio.GetType().GetProperties();

                // 抓取属性名称生成SQL语句
                var cur = 1;
                foreach (var property in properties)
                {
                    commandStringBuilderFirstPart.Append(property.Name);
                    if (property.PropertyType.Name == "String")
                        commandStringBuilderSecondPart
                           .Append(ConvertStringToSql((string) studio.GetPropertyValue(property.Name)));
                    else
                        commandStringBuilderSecondPart.Append((int) studio.GetPropertyValue(property.Name));
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
        ///     更新数据库的Studio数据
        /// </summary>
        /// <param name="origin">旧实例</param>
        /// <param name="target">新实例</param>
        public static void UpdateStudioInfoSql(Models.Studio.Studio origin, Models.Studio.Studio target)
        {
            // 属性比对，生成的SQL语句只包含要修改的部分
            var properties = origin.GetType().GetProperties();
            var updateList = new List<PropertyInfo>();
            foreach (var property in properties)
                if (!Equals(origin.GetPropertyValue(property.Name), target.GetPropertyValue(property.Name)))
                    updateList.Add(property);

            // 生成SQL语句
            var commandStringBuilder = new StringBuilder("UPDATE StudioInfo SET ");

            var cur = 1;
            foreach (var targetProperty in updateList)
            {
                if (targetProperty.PropertyType.Name == "String")
                    commandStringBuilder.Append(targetProperty.Name + " = " +
                                                ConvertStringToSql((string) target
                                                                      .GetPropertyValue(targetProperty.Name)));
                else
                    commandStringBuilder.Append(targetProperty.Name + " = " +
                                                (int) target.GetPropertyValue(targetProperty.Name));

                if (cur++ < updateList.Count) commandStringBuilder.Append(", ");
            }

            commandStringBuilder.Append(" WHERE StudioNumber = " + ConvertStringToSql(origin.StudioNumber));

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
            catch (Exception e)
            {
                Console.WriteLine("无变化"+e.Message);
                Console.WriteLine(commandStringBuilder.ToString());
            }
        }

        public static List<Models.Studio.Studio> GenerateStudioList(Loader loader)
        {
            List<Models.Studio.Studio> studioList = new List<Models.Studio.Studio>();
            using (var sqlConnection = new SqlConnection(ConString))
            {
                var sqlCommand = new SqlCommand("SELECT StudioNumber FROM StudioInfo", sqlConnection);

                sqlConnection.Open();
                var result = sqlCommand.ExecuteReader();

                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        studioList.Add(ReadStudioInfoSql(result["StudioNumber"].ToString(),true,loader));
                    }
                }

                result.Close();
            }

            return studioList;

        }
    }
}