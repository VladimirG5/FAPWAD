using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fapwad.Classes.MainClass;
using System.Threading;
using System.Drawing.Text;
using System.Runtime.InteropServices;


namespace Fapwad
{
    public partial class Form1 : Form
    {
        [DllImport("gdi32.dll")]

        private static extern IntPtr
            AddFontMemResourceEx(IntPtr pbfont, uint cbfont, IntPtr pdv, [In] ref uint pcFonts);

        private FontFamily ff;
        private Font font;

        public GameClass gameClass;
        public System.Windows.Forms.Timer timer;
        //public Timer timerEnemyShoot;
        public int count;
        public int ID;
        public int originalID;
        public Boolean changed;
        public Boolean canMove;
        private String FileName;
        

        public Form1()
        {
            
            InitializeComponent();
            
            timer = new System.Windows.Forms.Timer();
            timer.Enabled = true;
            timer.Interval = 40;
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
            newGame();
            canMove = true;
             
             this.Location = new Point(0,0);
        }

        private void LoadFont()
        {
            byte[] FontArray = Fapwad.Properties.Resources.Bubblegum;
            int FontLength = Fapwad.Properties.Resources.Bubblegum.Length;

            IntPtr ptrData = Marshal.AllocCoTaskMem(FontLength);
            Marshal.Copy(FontArray, 0, ptrData, FontLength);

            uint cFonts = 0;

            AddFontMemResourceEx(ptrData, (uint)FontArray.Length, IntPtr.Zero, ref cFonts);

            PrivateFontCollection pfc = new PrivateFontCollection();

            pfc.AddMemoryFont(ptrData, FontLength);

            Marshal.FreeCoTaskMem(ptrData);

            ff = pfc.Families[0];
            font = new Font(ff, 15f, FontStyle.Bold);
        }

        private void AllocFont(Font f, Control c, float size)
        {
            FontStyle fontStyle = FontStyle.Regular;

            c.Font = new Font(ff, size, fontStyle);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadFont();
            AllocFont(font, this.lblGrade, 25);

        }

        public void newGame()
        {
            gameClass = new GameClass();
            this.count = 0;
            this.DoubleBuffered = true;
            this.BackgroundImage = Properties.Resources.Level1;
            this.pbVictory.Visible = false;
            this.lblVictory.Visible = false;
            this.canMove = true;
            this.timer.Start();
            this.Location = new Point(0, 0);
            this.Height = 1080;
            this.Width = 1000;
            this.ID = 1;
            this.changed = false;
            this.originalID = 1;
            FileName = null;
        }

       /*private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.N))
            {
                gameClass.updateLevel();
            }
           /* Thread thread = new Thread(() => {
                Action action = () =>
                this.BeginInvoke(action);
                
            });
            thread.Start();
           if(canMove)
             gameClass.MoveHero(e.KeyCode.ToString().ToUpper());
            Invalidate(true);
           
        }*/

        private void timer1_Tick(object sender, EventArgs e)
        {
            Victory();
            this.lblGrade.BackColor = Color.Transparent;
            this.lblGrade.Text = String.Format("Grade: {0:0.0}", gameClass.getGrade());
            this.originalID = gameClass.CheckLevel();
            if (this.ID != originalID)
            {
                changed = true;
                this.ID = originalID;
            }
            if (changed)
            {
                if (gameClass.currentLevel.ID == 1)
                {
                    timer.Interval = 40;
                    this.BackgroundImage = Properties.Resources.Level1;
                    changed = false;
                }
                else if (gameClass.currentLevel.ID == 2)
                {
                    timer.Interval = 30;
                    this.BackgroundImage = Properties.Resources.Level2;
                    changed = false;
                }
                else if (gameClass.currentLevel.ID == 3)
                {
                    timer.Interval = 25;
                    this.BackgroundImage = Properties.Resources.Level3;
                    changed = false;
                }
            }
           
            count++;
            gameClass.MoveObjects();
            if (gameClass.currentLevel.Dying())
            {
                canMove = false;
                pbVictory.BackColor = Color.Transparent;
                pbVictory.Image = Fapwad.Properties.Resources.wasted;
                pbVictory.Visible = true;
                this.lblVictory.BackColor = Color.Transparent;
                AllocFont(font, this.lblVictory, 30);
                lblVictory.Text = String.Format("Your final grade is: {0:0.0}", gameClass.getGrade());
                lblVictory.Visible = true;
                timer.Stop();
            }
                

            
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

        

        public void Victory()
        {
            if (this.ID == 3 && gameClass.currentLevel.characters.Count == 0)
            {
                GC.Collect();
                pbVictory.Visible = true;
                pbVictory.BackColor = Color.Transparent;
                pbVictory.Image = Fapwad.Properties.Resources.WinTheGame;
                this.lblVictory.BackColor = Color.Transparent;
                AllocFont(font, this.lblVictory, 30);              
                lblVictory.Text = String.Format("Your final grade is: {0:0.0}", gameClass.getGrade());
                lblVictory.Visible = true;
            }
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (canMove)
            {
                 if(e.Button == MouseButtons.Left)
                 {
                    gameClass.HeroFires();
                    Invalidate(true);
                 }
            }
            
        }

        

        private void saveFile()
        {
            if (FileName == null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "FAPWAD game file (*.fpd)|*.fpd";
                saveFileDialog.Title = "Save FAPWAD game";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileName = saveFileDialog.FileName;
                }
            }
            if (FileName != null)
            {
                using (FileStream fileStream = new FileStream(FileName, FileMode.Create))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fileStream, gameClass);
                }
            }
        }

        private void openFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "FAPWAD game file (*.fpd)|*.fpd";
            openFileDialog.Title = "Load FAPWAD game";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileName = openFileDialog.FileName;
                try
                {
                    using (FileStream fileStream = new FileStream(FileName, FileMode.Open))
                    {
                        IFormatter formater = new BinaryFormatter();
                        gameClass = (GameClass)formater.Deserialize(fileStream);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not read file: " + FileName);
                    FileName = null;
                    return;
                }
                Invalidate(true);
            }
        }


        private void pauseGame()
        {
            canMove = !canMove;
            if (canMove)
            {
                pbPause.Image = Fapwad.Properties.Resources.pause;
                timer.Start();
            }
            else
            {
                pbPause.Image = Fapwad.Properties.Resources.resume;
                timer.Stop();
            }
        }

        private void pbNewGame_Click(object sender, EventArgs e)
        {
            newGame();
            // gameClass = new GameClass();
        }

        private void pbPause_Click(object sender, EventArgs e)
        {
            pauseGame();
        }

        private void pbQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbSave_Click(object sender, EventArgs e)
        {
            pauseGame();
            FileName = null;
            saveFile();
            pauseGame();
        }

        private void pbLoad_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals('N'))
            {
                gameClass.updateLevel();
            }
            /* Thread thread = new Thread(() => {
                 Action action = () =>
                 this.BeginInvoke(action);

             });
             thread.Start();*/
            if (canMove)
                gameClass.MoveHero(e.KeyCode.ToString().ToUpper());
            Invalidate(true);
        }
    }
}
