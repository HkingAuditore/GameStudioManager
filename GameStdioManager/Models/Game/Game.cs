namespace GameStdioManager.Models.Game
{
    public class Game
    {
        /// <summary>
        ///     游戏编号
        /// </summary>
        public string GameNumber { get; }

        /// <summary>
        ///     游戏名称
        /// </summary>
        public string GameName { get; }

        /// <summary>
        ///     游戏价格
        /// </summary>
        public int GamePrice { get; set; }

        /// <summary>
        ///     游戏质量
        /// </summary>
        public int GameQuality { get; set; }

        /// <summary>
        ///     游戏销量
        /// </summary>
        public int GameSales { get; set; }

        /// <summary>
        ///     制作工作室编号
        /// </summary>
        public string GameStudio { get; }

        public Game(string gameNumber, string gameName, int gamePrice, int gameQuality, int gameSales, string gameStudio)
        {
            GameNumber = gameNumber;
            GameName = gameName;
            GamePrice = gamePrice;
            GameQuality = gameQuality;
            GameSales = gameSales;
            GameStudio = gameStudio;
        }
    }
}