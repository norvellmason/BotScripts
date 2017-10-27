using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// Object containing things that can be rendered on screen.
    /// </summary>
    public class Renderable
    {
        List<PointF> points = new List<PointF>();
        bool closed;

        /// <summary>
        /// Constructs a renderable object containing a list of points, and a
        /// closed property which dictates if the final point will connect back
        /// to the starting point.
        /// </summary>
        /// <param name="points">List of points that makes up the renderable</param>
        /// <param name="closed">True if last point connects to first point.</param>
        public Renderable(List<PointF> points, bool closed)
        {
            this.points = points;
            this.closed = closed;
        }
    }
}
