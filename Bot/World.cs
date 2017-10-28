using System;
using System.Drawing;

namespace Engine
{
    public class World
    {
        public Bot PlayerBot { get; set; }

        public Bot ComputerBot { get; set; }

        public World(Bot playerBot, Bot computerBot)
        {
            PlayerBot = playerBot;
            ComputerBot = computerBot;
        }

        private void GetBotInputs(Bot from, Bot target)
        {
            float xDist = target.Position.X - from.Position.X;
            float yDist = target.Position.Y - from.Position.Y;

            float angleTo = (float)Math.Atan2(-yDist, xDist);
        }

        public void Update()
        {
            GetBotInputs(PlayerBot, ComputerBot);
        }

        private float NormalizeAngle(float angle)
        {
            angle %= 2 * (float)Math.PI;

            if(angle < 0)
                angle += 2 * (float)Math.PI;

            return angle;
        }

        public void Render(Graphics g)
        {
            g.Clear(Color.White);

            PlayerBot.Render(g);
            ComputerBot.Render(g);
        }
    }
}
