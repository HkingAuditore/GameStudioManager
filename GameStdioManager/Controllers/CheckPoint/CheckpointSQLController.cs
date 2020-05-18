using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using GameStdioManager.Models.Game;

namespace GameStdioManager.Controllers.CheckPoint
{
    public class CheckpointSQLController
    {
        private static string MergeStringArray(string[] source) => (source.Select(s => s)).Aggregate("", (current, s)
                                                                                                             => current + s).TrimEnd('.');
    }
}