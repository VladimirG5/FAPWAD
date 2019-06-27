using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fapwad.Classes.Characters.Hero;
using Fapwad.Classes.Obstacles;

namespace Fapwad.Classes.Weapons
{
    public class ReportedSheet
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int reportedSheetWidth { get; set; }
        public int reportedSheetHeight { get; set; }
        public bool colided { get; set; }
        public ReportedSheet(int x, int y, int width, int height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.reportedSheetWidth = 25;
            this.reportedSheetHeight = 50;
            colided = false;
        }

        public void Draw(Graphics g)
        {
            // TO BE IMPLEMENTED
            Brush solid = new SolidBrush(Color.Black);
            g.FillRectangle(solid, X, Y, reportedSheetWidth, reportedSheetHeight);
            solid.Dispose();
        }
        public void Move()
        {
            // TO BE IMPLEMENTED
            this.Y = Y + 5;
        }

        public void HitAHero(HeroClass Hero, int demage)
        {
            if (IsHit(Hero.X, Hero.Y, Hero.characterWidth, Hero.characterHeight))
            {
                colided = true;
                Hero.Hurt(demage);
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
