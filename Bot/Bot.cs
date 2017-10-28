using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Engine
{
    /// <summary>
    /// A bot that exists in the world.
    /// </summary>
    public class Bot
    {
        public static HashSet<String> inputVariables = new HashSet<String>() {
                "eyes.left",
                "eyes.left.distance",
                "eyes.right",
                "eyes.right.distance",
            };

        public static HashSet<String> outputVariables = new HashSet<String>() {
                "control.left",
                "control.right",
                "control.forward",
                "control.backward",
            };

        public static HashSet<String> allVariables = new HashSet<string>(inputVariables.Union<String>(outputVariables));

        public static HashSet<String> operators = new HashSet<String>() {
                "*", "/", "+", "-", ">", ">=", "<", "<=", "==", "!=", "!", "&&", "||"
            };

        /// <summary>
        /// The position of the bot in the world.
        /// </summary>
        public PointF Position { get; set; }

        /// <summary>
        /// The angle that the bot is facing.
        /// </summary>
        public float Angle { get; set; }

        /// <summary>
        /// The path that defines the bot when it renders
        /// </summary>
        public Renderable Renderable { get; private set; }

        private PointF spikeLocation = new PointF();

        public PointF SpikeLocation {
            get
            {
                float[][] matrix = { new float[] { (float)Math.Cos(Angle), -(float)Math.Sin(Angle) },
                                     new float[] { (float)Math.Sin(Angle),  (float)Math.Cos(Angle) } };

                float xOffSet = matrix[0][0] * spikeLocation.X + matrix[0][1] * spikeLocation.Y;
                float yOffSet = matrix[1][0] * spikeLocation.X + matrix[1][1] * spikeLocation.Y;

                return new PointF(Position.X + xOffSet, Position.Y - yOffSet);

                //return spikeLocation;
            }
            private set
            {
                spikeLocation = value;
            }
        }

        /// <summary>
        /// Construct a new bot with at the given x and y cooridnates, and the
        /// given angle.
        /// </summary>
        /// 
        /// <param name="x">the x cooridnate of the bot</param>
        /// <param name="y">the y cooridnate of the bot</param>
        /// <param name="angle">the angle of the bot</param>
        /// <param name="renderable">the path that defines the bot when it renders</param>
        public Bot(float x, float y, float angle, Renderable renderable)
        {
            Position = new PointF(x, y);
            Angle = angle;
            Renderable = renderable;
            CreateBotRenderable(12, 50f, 50f);
        }

        /// <summary>
        /// Construct a new bot at the given position and the given angle.
        /// </summary>
        /// 
        /// <param name="position">the position of the bot</param>
        /// <param name="angle">the angle of the bot</param>
        /// <param name="renderable">the path that defines the bot when it renders</param>
        public Bot(PointF position, float angle, Renderable renderable)
        {
            Position = position;
            Angle = angle;
            Renderable = renderable;
            CreateBotRenderable(12, 30f, 30f);
        }

        public void Render(Graphics g)
        {
            Renderable.Render(g, Position, Angle, Color.Black);
        }

        public void CreateBotRenderable(int numPoints, float radius, float spikeLength)
        {
            spikeLocation = new PointF(radius + spikeLength, 0);

            Renderable.points.Add(spikeLocation);

            for(int i = 1; i < numPoints; i++)
            {
                float angle = (float)((i * 2 * Math.PI) / numPoints);

                Renderable.points.Add(new PointF((float)Math.Cos(angle) * radius, (float)Math.Sin(angle) * radius));
            }
        }
    }
}
