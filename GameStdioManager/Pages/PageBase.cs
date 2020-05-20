using GameStdioManager.Models;
using GameStdioManager.Models.Player;
using GameStdioManager.Models.Studio;

namespace GameStdioManager.Pages
{
    public class PageBase : System.Web.UI.Page
    {
        public static Player PagePlayer = null;
        public static StudioBehavior PageGame = null;

    }
}