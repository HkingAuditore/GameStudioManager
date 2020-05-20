using System;

namespace GameStdioManager.Models.Player
{
    public class Player : SimulatorBase
    {
        public DateTime PlayerStartTime;

        public Studio.Studio PlayerStudio;

        public DateTime PlayerNowTime;

        public Player(Studio.Studio studio) => PlayerStudio = studio;
    }
}