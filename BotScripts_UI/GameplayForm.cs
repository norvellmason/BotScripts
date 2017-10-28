using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine;

namespace BotScripts_UI
{
    public partial class GameplayForm : Form
    {
        Bot testBot;
        Bot testBot2;
        List<Bot> botsToRender = new List<Bot>();

        Bitmap bitmap;
        Graphics g;

        /// <summary>
        /// Initializes Form and bots
        /// </summary>
        public GameplayForm()
        {
            InitializeComponent();


            testBot  = new Bot(new PointF(50, 300), 0.0f, new Renderable(new List<PointF>(), true));
            testBot2 = new Bot(new PointF(350, 300), (float)Math.PI, new Renderable(new List<PointF>() , true));

            botsToRender.Add(testBot);
            botsToRender.Add(testBot2);

            bitmap = new Bitmap(Width - 400, 672);
            g = Graphics.FromImage(bitmap);
        }

        /// <summary>
        /// Gets calles when a paint event triggers, and renders all of the on screen elements using
        /// the graphics objects passed in.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameplayForm_Paint(object sender, PaintEventArgs e)
        {
            g.Clear(Color.White);

            foreach (Bot bot in botsToRender)
            {
                bot.Renderable.Render(bot.Position, bot.Angle, Color.Black, g);
            }

            e.Graphics.DrawImage(bitmap, 200, 0);

            System.Threading.Thread.Sleep(16);
            Invalidate();
        }
    }
}
