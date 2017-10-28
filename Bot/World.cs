using System;
using System.Collections.Generic;
using System.Drawing;

namespace Engine
{
    public class World
    {
        public Bot PlayerBot { get; private set; }
        public Bot ComputerBot { get; private set; }

        private CodeParser playerParser;
        private CodeParser computerParser;

        private PointF playerBotStartPos;
        private float playerBotStartAngle;

        private PointF computerBotStartPos;
        private float computerBotStartAngle;


        public bool inEditor;

        public World(Bot playerBot, Bot computerBot)
        {
            inEditor = true;

            PlayerBot = playerBot;
            ComputerBot = computerBot;

            playerBotStartPos = PlayerBot.Position;
            playerBotStartAngle = PlayerBot.Angle;

            computerBotStartPos = computerBot.Position;
            computerBotStartAngle = computerBot.Angle;

            HashSet<String> inputVariables = new HashSet<String>() {
                "eyes.left",
                "eyes.left.distance",
                "eyes.right",
                "eyes.right.distance"
            };

            HashSet<String> outputVariables = new HashSet<String>() {
                "control.left",
                "control.right",
                "control.forward",
                "control.backward",
            };

            playerParser = new CodeParser(new String[0], inputVariables, outputVariables);
        }

        public void setPlayerCode(String[] code)
        {
            playerParser.SetCode(code);
        }

        public void setComputerCode(String[] code)
        {
            computerParser.SetCode(code);
        }

        private Dictionary<String, object> GetBotInputs(Bot from, Bot target)
        {
            float xDist = target.Position.X - from.Position.X;
            float yDist = target.Position.Y - from.Position.Y;

            float angleTo = NormalizeAngle((float)Math.Atan2(-yDist, xDist) - from.Angle);
            float distance = (float)Math.Sqrt(xDist * xDist + yDist * yDist);

            float relativeAngle = NormalizeAngle(target.Angle - from.Angle);

            // // //

            bool leftEye = angleTo < 0.5 || angleTo > 2 * Math.PI - 0.1;
            bool rightEye = angleTo > 2 * Math.PI - 0.5 || angleTo < 0.1;

            object leftDistance;
            if(leftEye)
                leftDistance = distance;
            else
                leftDistance = false;

            object rightDistance;
            if(rightEye)
                rightDistance = distance;
            else
                rightDistance = false;

            return new Dictionary<String, object> {
                ["eyes.left"] = leftEye,
                ["eyes.left.distance"] = leftDistance,
                ["eyes.right"] = rightEye,
                ["eyes.right.distance"] = rightDistance,
            };
        }

        public void Update()
        {
            UpdateBot(playerParser, PlayerBot, ComputerBot);
            UpdateBot(computerParser, ComputerBot, PlayerBot);
        }

        public void UpdateBot(CodeParser parser, Bot from, Bot target)
        {
            if(parser == null)
                return;

            Dictionary<String, object> state = GetBotInputs(from, target);
            state["control.left"] = false;
            state["control.right"] = false;
            state["control.forward"] = false;
            state["control.backward"] = false;

            Dictionary<String, object> result = parser.Execute(state);

            bool turnLeft = state["control.left"] is bool && (bool)state["control.left"];
            bool turnRight = state["control.right"] is bool && (bool)state["control.right"];

            if(turnLeft && !turnRight)
                from.Angle += 0.01f;
            if(turnRight && !turnLeft)
                from.Angle -= 0.01f;

            bool moveforward = state["control.forward"] is bool && (bool)state["control.forward"];
            bool moveBackward = state["control.backward"] is bool && (bool)state["control.backward"];

            if(moveforward && !moveBackward)
                from.Position = new PointF(from.Position.X + (float)Math.Cos(from.Angle) * 4, from.Position.Y - (float)Math.Sin(from.Angle) * 4);
            if(moveBackward && !moveforward)
                from.Position = new PointF(from.Position.X - (float)Math.Cos(from.Angle) * 4, from.Position.Y + (float)Math.Sin(from.Angle) * 4);
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

        public void ResetBots()
        {
            PlayerBot.Position = playerBotStartPos;
            PlayerBot.Angle = playerBotStartAngle;

            ComputerBot.Position = computerBotStartPos;
            ComputerBot.Angle = computerBotStartAngle;
        }
    }
}
