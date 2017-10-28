using System;
using System.Collections.Generic;
using System.Drawing;

namespace Engine
{
    public class World
    {
        public Bot PlayerBot { get; private set; }

        private CodeParser parser;

        public Bot ComputerBot { get; private set; }

        public World(Bot playerBot, Bot computerBot)
        {
            PlayerBot = playerBot;
            ComputerBot = computerBot;

            String[] lines =
            {
                "movement.left = true",
            };

            HashSet<String> inputVariables = new HashSet<String>()
            {
                "eyes.left",
                "eyes.right",
            };

            HashSet<String> outputVariables = new HashSet<String>()
            {
                "movement.left",
                "movement.right",
                "movement.forward",
                "movement.backward",
            };

            parser = new CodeParser(lines, inputVariables, outputVariables);
        }

        private Dictionary<String, object> GetBotInputs(Bot from, Bot target)
        {
            float xDist = target.Position.X - from.Position.X;
            float yDist = target.Position.Y - from.Position.Y;

            float angleTo = NormalizeAngle((float)Math.Atan2(-yDist, xDist) - from.Angle);
            float distance = (float)Math.Sqrt(xDist * xDist + yDist * yDist);

            float relativeAngle = NormalizeAngle(target.Angle - from.Angle);

            return new Dictionary<String, object> {
                ["eyes.left"] = angleTo < 0.5 || angleTo > 2 * Math.PI - 0.1,
                ["eyes.right"] = angleTo > 2 * Math.PI - 0.5 || angleTo < 0.1,
            };
        }

        public void Update()
        {
            Dictionary<String, object> state = GetBotInputs(PlayerBot, ComputerBot);
            state["control.left"] = false;
            state["control.right"] = false;
            state["control.forward"] = false;
            state["control.backward"] = false;

            Dictionary<String, object> result = parser.Execute(state);

            if(result["control.left"] is bool turnLeft)
            {
                if(turnLeft)
                {
                    PlayerBot.Angle = PlayerBot.Angle + 1f;
                }
            }
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
