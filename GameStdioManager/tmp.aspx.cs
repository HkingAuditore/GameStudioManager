using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GameStdioManager.Models.Game;

namespace GameStdioManager
{
    public partial class tmp : System.Web.UI.Page
    {
        private string ConString = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void InsertUserInfoSqlOld()
        {
            var userInfo = new
                           {
                               TmpUsername = Username.Text,
                               TmpPassword = Password.Text,
                               TmpPhone    = Phone.Text,
                               TmpGender   = Gender_Female.Checked ? "Female" : "Male",
                               TmpHobby = (from Control ct in Controls
                                           where ct.GetType().ToString()
                                                   .Equals("System.Web.UI.WebControls.CheckBox")
                                           select (CheckBox) ct
                                           into cb
                                           where cb.Checked
                                           select cb)
                                         .Aggregate("", (current, cb)
                                                            => current + cb.Text + ',').TrimEnd(','),

                               TmpSemester = Semester.SelectedValue,
                               TmpScore    = int.Parse(Score.Text)
                           };

            using (var sqlConnection = new SqlConnection(ConString))
            {
                var sqlCommand = new SqlCommand("INSERT INTO StaffInfo VALUES ("
                                              + "'" + userInfo.TmpUsername + "'" + ","
                                              + "'" + userInfo.TmpPassword + "'" + ","
                                              + "'" + userInfo.TmpPhone    + "'" + ","
                                              + "'" + userInfo.TmpGender   + "'" + ","
                                              + "'" + userInfo.TmpHobby    + "'" + ","
                                              + "'" + userInfo.TmpSemester + "'" + ","
                                              + userInfo.TmpScore
                                              + ")", sqlConnection);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}