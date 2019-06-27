using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Fapwad.Classes.Obstacles
{
    public class Rectangle
    {
        public int ID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int ID,int x, int y, int width, int height)
        {
            this.ID = ID;
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        public void Draw(System.Drawing.Graphics g)
        {
            Brush solid = new SolidBrush(Color.Red);
            
            if(ID == 0)
            {
                g.FillRectangle(solid, X, Y, Width, Height);
            }
            else if(ID == 1)
            {
                g.FillRectangle(solid, X-200, Y+200, Width, Height);
            }
            else
            {
                g.FillRectangle(solid, X+150, Y+150, Width, Height);
            }
            g.Dispose();
            // TO BE IMPLEMENTED


        }
    }
}
