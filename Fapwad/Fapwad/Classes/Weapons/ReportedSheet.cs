using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fapwad.Classes.Characters.Hero;
using Fapwad.Classes.Obstacles;
using Fapwad.Properties;
namespace Fapwad.Classes.Weapons
{
    [Serializable]
    public class ReportedSheet
    {
        public int X;
        public int Y;
        public int Width;
        public int Height;
        public int reportedSheetWidth;
        public int reportedSheetHeight;
        public bool colided;
        public HeroClass Hero;
        public int demage;
        public ReportedSheet(int x, int y, int width, int height, HeroClass Hero, int demage)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.reportedSheetWidth = 25;
            this.reportedSheetHeight = 50;
            this.Hero = Hero;
            this.demage = demage;
            colided = false;
        }

        public void Draw(Graphics g)
        {
            Object O = Resources.ResourceManager.GetObject("ReportedSheet");
            Image image = new Bitmap((Image)O);
            g.DrawImageUnscaled(image, X, Y);
        }
        /*public void Move()
        {
            // TO BE IMPLEMENTED
            this.Y = Y + 5;
        }*/

        public void MoveSheets(List<Obstacles.Rectangle> rectangles, HeroClass Hero)
        {
            this.Y = Y + 5;
            this.IsCollided(rectangles);
            this.HitAHero(Hero, this.demage);
            /*foreach (ReportedSheet sheet in reportedSheets)
            {
                sheet.Move();
                sheet.IsCollided(rectangles);
                sheet.HitAHero(Hero, this.WeaponStrength);
            }

            // FROM LEVEL !!!

            for (int i = 0; i < reportedSheets.Count; i++)
            {
                if (reportedSheets[i].colided)
                {
                    reportedSheets.RemoveAt(i);
                }
            }*/


        }

        public void HitAHero(HeroClass Hero, int demage)
        {
            if (IsHit(Hero.X, Hero.Y, Hero.characterWidth, Hero.characterHeight))
            {
                colided = true;
                Hero.Hurt(demage);
                Hero.GradeUp(true);
            }
        }

        public void IsCollided(List<Obstacles.Rectangle> rectangles)
        {
            // TO BE IMPLEMENTED
            if (this.X > 800|| this.Y > 1000)
            {
                colided =  true;
            }
            foreach (Obstacles.Rectangle r in rectangles)
            {
                if (IsHit(r.X, r.Y , r.Width , r.Height))
                {
                    colided =  true;
                }
            }
            
            
        }
        private bool IsHit(int recX, int recY, int recWidth, int recHeight)
        {
            return (recX < this.X + this.Width) &&
                   (this.X < (recX + recWidth)) &&
                   (recY < this.Y + this.Height) &&
                   (this.Y < recY + recHeight);

        }
    }
}
