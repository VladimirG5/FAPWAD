using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using Fapwad.Properties;

namespace Fapwad.Classes.Obstacles
{
    public class Rectangle
    {

        public int X;
        public int Y;
        public int Width;
        public int Height;
        public String obstaclePath;

        public Rectangle(int x, int y, int width, int height, String obstaclePath)
        {
            this.obstaclePath = obstaclePath;
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        public void Draw(System.Drawing.Graphics g)
        {
            
            Object O = Resources.ResourceManager.GetObject(obstaclePath);
            Image image = new Bitmap((Image)O);
            g.DrawImageUnscaled(image, X, Y);
        }
    }
}
