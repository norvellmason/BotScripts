using System;
using System.Collections.Generic;
using System.Drawing;
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

            ResizePanels();
        }

        /// <summary>
        /// Gets calles when a paint event triggers, and renders all of the on screen elements using
        /// the graphics objects passed in.
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameplayForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            foreach(Bot bot in botsToRender)
                bot.Render(e.Graphics);

            System.Threading.Thread.Sleep(16);
            Invalidate();
        }

        /// <summary>
        /// Resizes the code panels.
        /// </summary>
        private void ResizePanels()
        {
            int panelWidth = Width / 4;
            
            if(panelWidth > 1000)
                panelWidth = 1000;

            playerCodePanel.Width = panelWidth;
            botCodePanel.Width = panelWidth;
        }

        /// <summary>
        /// Called when the window resizes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameplayForm_Resize(object sender, EventArgs e)
        {
            ResizePanels();
        }
    }
}
