using System;

namespace GameStdioManager.Models.Player
{
    public class Player : SimulatorBase
    {
        public string PlayerNumber { get; set; }

        public DateTime PlayerStartTime { get; set; }

        public string PlayerStudioNumber { get; set; }

        public Studio.Studio PlayerStudio;

        public DateTime PlayerNowTime { get; set; }

        public Player(Studio.Studio studio) => PlayerStudio = studio;
    }
}