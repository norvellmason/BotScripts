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
        /// <summary>
        /// The position of the bot in the world.
        /// </summary>
        public PointF Position { get; private set; }

        /// <summary>
        /// The angle that the bot is facing.
        /// </summary>
        public float Angle { get; private set; }

        /// <summary>
        /// The path that defines the bot when it renders
        /// </summary>
        public Renderable Renderable { get; private set; }

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

        public void CreateBotRenderable(int numPoints, float radius, float spikeLength)
        {
            Renderable.points.Add(new PointF(radius + spikeLength, 0));

            for(int i = 1; i < numPoints; i++)
            {
                float angle = (float)((i * 2 * Math.PI) / numPoints);

                Renderable.points.Add(new PointF((float)Math.Cos(angle) * radius, (float)Math.Sin(angle) * radius));
            }


        }
    }
}
