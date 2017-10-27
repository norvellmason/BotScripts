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
        /// Construct a new bot with at the given x and y cooridnates, and the
        /// given angle.
        /// </summary>
        /// 
        /// <param name="x">the x cooridnate of the bot</param>
        /// <param name="y">the y cooridnate of the bot</param>
        /// <param name="angle">the angle of the bot</param>
        public Bot(float x, float y, float angle)
        {
            Position = new PointF(x, y);
            Angle = angle;
        }

        /// <summary>
        /// Construct a new bot at the given position and the given angle.
        /// </summary>
        /// 
        /// <param name="position">the position of the bot</param>
        /// <param name="angle">the angle of the bot</param>
        public Bot(PointF position, float angle)
        {
            Position = position;
            Angle = angle;
        }
    }
}
