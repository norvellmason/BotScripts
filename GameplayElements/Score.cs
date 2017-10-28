using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using System.Drawing;
using System.Diagnostics;

namespace GameplayElements
{
    public class Score
    {
        public Bot PlayerBot;
        public Bot EnemyBot;

        public string Winner = "";

        public int playerScore = 0;
        public float enemyScore = 200;

        public Score(Bot playerBot, Bot enemyBot)
        {
            PlayerBot = playerBot;
            EnemyBot = enemyBot;
        }

        public void tryGetWinner(out string winner)
        {
            //if (playerScore > 1)
            //{
            //    winner = "Player";
            //    return;
            //}
            //else if(enemyScore > 1)
            //{
            //    winner = "Enemy";
            //    return;
            //}
            winner = Winner;
        }

        public void Reset()
        {
            playerScore = 0;
            enemyScore = 0;
        }

        public void Update()
        {
            
            if (isHit(EnemyBot, PlayerBot.SpikeLocation))
            {
                playerScore += 1000;
                Winner = "Player";
            }
            else if (isHit(PlayerBot, EnemyBot.SpikeLocation))
            {
                enemyScore += 1000;
                Winner = "Enemy";
            }

            enemyScore -= ((EnemyBot.Position.X - PlayerBot.Position.X) * (EnemyBot.Position.X - PlayerBot.Position.X)
                           + (EnemyBot.Position.Y - PlayerBot.Position.Y) * (EnemyBot.Position.Y - PlayerBot.Position.Y))/100;
        }

        private bool isHit(Bot target, PointF spikeLocation)
        {
            if (GetSpikeDistance(target, spikeLocation) < 90f)
            {
                return true;
            }
            return false;
        }

        private float GetSpikeDistance(Bot target, PointF spikeLocation)
        {
            float spikeDistancetoTarget = ((spikeLocation.X - target.Position.X) * (spikeLocation.X - target.Position.X)
                           + (spikeLocation.Y - target.Position.Y) * (spikeLocation.Y - target.Position.Y));

            return spikeDistancetoTarget;
        }


    }
}
