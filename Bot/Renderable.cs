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
        public void Render(Graphics g, PointF position, float angle, Color color)
        {
            // 2d rotation matrix
            float[][] matrix = { new float[] { (float)Math.Cos(angle), -(float)Math.Sin(angle) },
                                 new float[] { (float)Math.Sin(angle),  (float)Math.Cos(angle) } };

            List<PointF> onScreenPoints = new List<PointF>();
            foreach(PointF point in points)
            {
                float xOffSet = matrix[0][0] * point.X + matrix[0][1] * point.Y;
                float yOffSet = matrix[1][0] * point.X + matrix[1][1] * point.Y;

                onScreenPoints.Add(new PointF(position.X + xOffSet, position.Y - yOffSet));
            }

            // draw the points on screen
            Pen pen = new Pen(color, 3);
            for(int i = 1; i < points.Count; i++)
                g.DrawLine(pen, onScreenPoints[i - 1], onScreenPoints[i]);

            if (closed)
                g.DrawLine(pen, onScreenPoints[onScreenPoints.Count - 1], onScreenPoints[0]);
        }
    }
}
