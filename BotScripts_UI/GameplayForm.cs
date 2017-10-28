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

        /// <summary>
        /// Initializes Form and bots
        /// </summary>
        public GameplayForm()
        {
            InitializeComponent();


            testBot = new Bot(new PointF(300, 300), 0.0f, new Renderable(new List<PointF> { new PointF(100, 100), new PointF(-100, -100) }, false));
            testBot2 = new Bot(new PointF(100, 100), 0.0f, new Renderable(new List<PointF> { new PointF(100, 100), new PointF(-100, -100) }, false));

            botsToRender.Add(testBot);
            botsToRender.Add(testBot2);
        }

        private float angle = 0;

        /// <summary>
        /// Gets calles when a paint event triggers, and renders all of the on screen elements using
        /// the graphics objects passed in.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameplayForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            foreach (Bot bot in botsToRender)
            {
                bot.Renderable.Render(bot.Position, angle, Color.Black, e.Graphics);
            }

            System.Threading.Thread.Sleep(33);
            Invalidate();
        }
    }
}
