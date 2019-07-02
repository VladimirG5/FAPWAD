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
using System.Threading;


namespace Fapwad
{
    public partial class Form1 : Form
    {
        public GameClass gameClass;
        public System.Windows.Forms.Timer timer;
        //public Timer timerEnemyShoot;
        public int count;
        public int ID;
        public int originalID;
        public Boolean changed;

        public Form1()
        {
            gameClass = new GameClass();
            this.count = 0;
            this.DoubleBuffered = true;
            this.BackgroundImage = Properties.Resources.Level1;
            InitializeComponent();
            this.Location = new Point(100, 0);
            this.Height = 1080;
            this.Width = 1000;
            this.ID = 1;
            this.changed = false;
            this.originalID = 1;
            timer = new System.Windows.Forms.Timer();
            timer.Enabled = true;
            timer.Interval = 80;
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
            

        }

        

       private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.N))
            {
                gameClass.updateLevel();
            }
           /* Thread thread = new Thread(() => {
                Action action = () =>
                this.BeginInvoke(action);
                
            });
            thread.Start();*/
            gameClass.MoveHero(e.KeyCode.ToString().ToUpper());
            Invalidate(true);
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.originalID = gameClass.CheckLevel();
            if (this.ID != originalID)
            {
                changed = true;
                this.ID = originalID;
            }
            if (changed)
            {
                if (gameClass.currentLevel.ID == 2)
                {
                    this.BackgroundImage = Properties.Resources.Level2;
                    changed = false;
                }
                if (gameClass.currentLevel.ID == 3)
                {
                    this.BackgroundImage = Properties.Resources.Level3;
                    changed = false;
                }
            }
           
            count++;
            gameClass.MoveObjects();
            gameClass.currentLevel.Dying();

            
            if(count % 25 == 0)
                gameClass.EnemyFires();
            
            Invalidate(true);

        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.Clear(Color.White);
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
    }
}
