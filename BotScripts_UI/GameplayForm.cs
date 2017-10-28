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

            testBot  = new Bot(new PointF(50, 300), 0.0f, new Renderable(new List<PointF>(), true));
            testBot2 = new Bot(new PointF(350, 300), (float)Math.PI, new Renderable(new List<PointF>() , true));

            botsToRender.Add(testBot);
            botsToRender.Add(testBot2);

            PlayerPanel.Width = Width / 4;
            PlayerPanel.Height = Height;

            BotPanel.Width = Width / 4;
            BotPanel.Height = Height;
        }

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
                bot.Renderable.Render(new PointF(bot.Position.X + Width / 4, bot.Position.Y), bot.Angle, Color.Black, e.Graphics);
            }

            System.Threading.Thread.Sleep(16);
            Invalidate();
        }

        private void GameplayForm_Resize(object sender, EventArgs e)
        {
            PlayerPanel.Width = Width / 4;
            PlayerPanel.Height = Height;

            BotPanel.Width = Width / 4;
            BotPanel.Height = Height;
        }
    }
}
