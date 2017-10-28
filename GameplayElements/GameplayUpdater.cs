using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace GameplayElements
{
    public class GameplayUpdater
    {
        public Score score;
        World world;

        public string winner;

        public GameplayUpdater(World world)
        {
            this.world = world;
            score = new Score(world.PlayerBot, world.ComputerBot);
        }

        public void Update()
        {
            world.Update();
            score.Update();
            score.tryGetWinner(out winner);
        }

        public void Reset()
        {
            score.Reset();
            world.ResetBots();
            winner = "";
        }
    }
}
