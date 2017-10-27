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
        public List<PointF> points = new List<PointF>();
        public bool closed;

        /// <summary>
        /// Constructs a renderable object containing a list of points, and a
        /// closed property which dictates if the final point will connect back
        /// to the starting point.
        /// </summary>
        /// 
        /// <param name="points">List of points that makes up the renderable</param>
        /// <param name="closed">True if last point connects to first point.</param>
        public Renderable(List<PointF> points, bool closed)
        {
            this.points = points;
            this.closed = closed;
        }

        /// <summary>
        /// Renders the object by drawing lines between the renderable's points relative
        /// to the passed in position. Uses the passed in graphics object.
        /// </summary>
        /// 
        /// <param name="position">position in world that points are relative to</param>
        /// <param name="angle">angle at which object is rendered</param>
        /// <param name="g">graphics object used to render renderable</param>
        public void Render(PointF position, float angle, Graphics g)
        {
            Pen blackPen = new Pen(Color.Black, 3);

            for (int i = 0; i < points.Count - 1; i++)
            {
                g.DrawLine(blackPen, points[i], points[i + 1]);
            }
        }
    }
}
