namespace GameStdioManager.Models.Studio
{
    public class PlayerStudio : Studio
    {
        public PlayerStudio(string studioNumber, string studioName, int studioProperty, int studioReputation) :
            base(studioNumber, studioName, studioProperty, studioReputation)
        {
        }
    }
}