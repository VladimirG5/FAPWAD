using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fapwad.Classes.Weapons
{
    public class Index
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Index(int x, int y, int width, int height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;

        }

        public void Draw()
        {
            // TO BE IMPLEMENTED
        }
        public void Move()
        {
            // TO BE IMPLEMENTED
        }
        public Boolean IsCollided()
        {
            // TO BE IMPLEMENTED
            throw new NotImplementedException();
        }
        public Boolean IsHit()
        {
            // TO BE IMPLEMENTED
            throw new NotImplementedException();
        }
    }
}
