using GameStdioManager.Models.Checkpoint;

namespace GameStdioManager.Models.Game
{
    public partial class Game
    {
        #region 销售

        public void StartSales()
        {
            var arg = new CheckpointArgs();
            arg.CheckTime = SimulatorTimer.GameTimeNow;
            var cp = new Checkpoint.Checkpoint(this.GameNumber,
                                               SimulatorTimer.GameTimeNow,
                                               new[] {"EndSales"},
                                               new[] {"UpdateSales"},
                                               "CheckSalesEnd",
                                               this,
                                               arg,
                                               GetTypeName(),
                                               true,
                                               true
                                              );
            SimulatorTimer.AddCheckpoint(cp);
        }

        public static bool CheckSalesEnd(SimulatorBase sender, CheckpointArgs args) => false;

        public static void UpdateSales(SimulatorBase sender, CheckpointArgs args)
        {
            var game = (Game) sender;
            game.GameSales +=(int)((game.GameArt + game.GameMusic) * game.GameFun * 0.5);
        }

        public static void EndSales(SimulatorBase sender, CheckpointArgs args)
        {
        }

        #endregion
    }
}