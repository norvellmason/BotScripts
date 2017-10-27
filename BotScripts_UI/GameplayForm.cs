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


        public GameplayForm()
        {
            InitializeComponent();

            testBot = new Bot(new PointF(300, 300), 0.0f, new Renderable(new List<PointF> { new PointF(10, 10), new PointF(-10, -10) }, false));
        }

        private void GameplayForm_Paint(object sender, PaintEventArgs e)
        {
            testBot.BotRenderable.Render(testBot.Position, testBot.Angle, e.Graphics);
        }
    }
}
