using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fapwad.Classes.Obstacles;
using System.Drawing;
using System.Drawing.Drawing2D;
using Fapwad.Classes.AbstractClass;
using Fapwad.Classes.Levels;
using Fapwad.Classes.Weapons;
namespace Fapwad.Classes.Characters.Enemy
{
    public class EnemyClass : AbstractClass.Character
    {
        public List<ReportedSheet> reportedSheets { get; set; }

        public EnemyClass(int x, int y, int cWidth, int cHeight, int demage, int lives, int HP) : base(x, y, cWidth, cHeight, demage, lives, HP)
        {

        }
        public override Boolean Die()
        {
            if (base.Health < 0)
            {
                return true;
            }

            return false;
            //throw new NotImplementedException();
        }

        public override void Draw(Graphics g)
        {
            // REPORTED_SHEETS !!
            Brush b = new SolidBrush(Color.Red);
            g.FillRectangle(b,X,Y,characterWidth,characterHeight);
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override void Fire(Level.CHARACTER_TYPE type)
        {
            if (type == Level.CHARACTER_TYPE.HERO)
                return;
            else
            {
                // WIDTH AND HEIGHT TO BE DECIDED
                ReportedSheet new_ReportedSheet = new ReportedSheet(X, Y, 100, 100);
                reportedSheets.Add(new_ReportedSheet);
                // TO BE DONE !
            }
            throw new NotImplementedException();
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        private bool distance(int recX, int recY, int recWidth, int recHeight)
        {
            return this.X > recX &&
                   this.X < recX + recWidth &&
                   this.Y > recY &&
                   this.Y < recY + recHeight;

        }

        public override bool IsCollided(List<Obstacles.Rectangle> rectangles)
        {
            foreach(Obstacles.Rectangle rec in rectangles)
            {
                return distance(rec.X, rec.Y, rec.Width, rec.Height);

            }

            throw new NotImplementedException();
        }

        public override bool IsHit(List<Index> indeksi)
        {
            foreach (Index i in indeksi)
            {
                return distance(i.X, i.Y, i.Width, i.Height);

            }
            throw new NotImplementedException();
        }

        public override void Move(int width, int height, List<Obstacles.Rectangle> rectangles)
        {

            // REPORTED_SHEETS TO BE DONE !
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
