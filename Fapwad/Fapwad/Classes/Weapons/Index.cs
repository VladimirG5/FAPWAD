using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using Fapwad.Classes;
namespace Fapwad.Classes.Weapons
{
    public class Index
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int indexWidth { get; set; }
        public int indexHeight { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        //public Boolean isCollided { get; set; }
        public Index(int x, int y, int width, int height)
        {
            this.X = x;
            this.Y = y;
            this.indexWidth = 25;
            this.indexHeight = 50;
            this.Width = width;
            this.Height = height;

        }

        public void Draw(Graphics g)
        {
            // TO BE IMPLEMENTED
            Brush solid = new SolidBrush(Color.Red);
            g.FillRectangle(solid, X + 12, Y - 50, indexWidth, indexHeight);
            g.Dispose();
        }
        public void Move()
        {
            // TO BE IMPLEMENTED
            this.Y = Y - 5;
        }
        public Boolean IsCollided(List<Obstacles.Rectangle> rectangles)
        {
            // TO BE IMPLEMENTED
            // Checking the window
            if (this.X < 0 || this.X > Width || this.Y < indexHeight || this.Y > Height - indexHeight)
            {
                return true;
            }
            foreach(Obstacles.Rectangle r in rectangles)
            {
                if (IsHit(r))
                {
                    return true;
                }
            }
            return false;

        }
        public bool IsHit(Obstacles.Rectangle rect)
        {
            return (rect.X < this.X + this.Width) &&
            (this.X < (rect.X + rect.Width)) &&
            (rect.Y < this.Y + this.Height) &&
            (this.Y < rect.Y + rect.Height);
        }
    }
}
