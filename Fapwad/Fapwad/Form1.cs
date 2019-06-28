using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fapwad.Classes.MainClass;

namespace Fapwad
{
    public partial class Form1 : Form
    {
        public GameClass gameClass { get; set; }
        public Timer timer { get; set; }
        public int count { get; set; }

        public Form1()
        {
            gameClass = new GameClass();
            this.count = 0;
            this.DoubleBuffered = true;
            this.BackgroundImage = Properties.Resources.Level1;
            InitializeComponent();
            timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 50;
            this.Location = new Point(0, 0);
            this.Height = 1000;
            this.Width = 1000;
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode.Equals(Keys.Up))
            {
                gameClass.MoveHero("UP");
            }
            else if (e.KeyCode.Equals(Keys.Down))
            {
                gameClass.MoveHero("DOWN");
            }
            else if (e.KeyCode.Equals(Keys.Left))
            {
                gameClass.MoveHero("LEFT");
            }
            else if (e.KeyCode.Equals(Keys.Right))
            {
                gameClass.MoveHero("RIGHT");
            }
            
            Invalidate(true);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(gameClass.currentLevel.ID == 2)
            {
                this.BackgroundImage = Properties.Resources.Level2;
            }
            if(gameClass.currentLevel.ID == 3)
            {
                this.BackgroundImage = Properties.Resources.Level3;
            }
            count++;
            gameClass.MoveObjects();
            gameClass.currentLevel.Dying();

            gameClass.CheckLevel();
            if(count % 10 == 0)
                gameClass.EnemyFires();
           
            Invalidate(true);

        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.Clear(Color.Gray);
            gameClass.Draw(e.Graphics);
            
        }

        private void Form1_Resize(object sender, EventArgs e)
        {

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                gameClass.HeroFires();
                Invalidate(true);
            }
        }
    }
}
