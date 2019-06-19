using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fapwad.Classes.Weapons
{
    public class ReportedSheet
    {
        public int X { get; set; }
        public int Y { get; set; }

        public ReportedSheet(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void Draw()
        {
            // TO BE IMPLEMENTED
        }
    }
}
