using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fapwad.Classes.Obstacles;
using System.Drawing;
using Fapwad.Classes.AbstractClass;
using Fapwad.Classes.MainClass;
using Fapwad.Classes.Weapons;
namespace Fapwad.Classes.Characters.Enemy
{
    public class EnemyClass : AbstractClass.Character
    {
        public List<ReportedSheet> reportedSheets { get; set; }

        public EnemyClass(int x, int y, int demage, int lives, int HP) : base(x, y, demage, lives, HP)
        {

        }
        public override void Die()
        {
            throw new NotImplementedException();
        }

        public override void Draw(Graphics g)
        {
            // REPORTED_SHEETS !!
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override void Fire(GameClass.CHARACTER_TYPE type)
        {
            if (type == GameClass.CHARACTER_TYPE.HERO)
                return;
            else
            {
                // WIDTH AND HEIGHT TO BE DECIDED
                ReportedSheet new_ReportedSheet = new ReportedSheet(X, Y, 100, 100);
                // TO BE DONE !
            }
            throw new NotImplementedException();
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool IsCollided(List<Obstacles.Rectangle> rectangles)
        {
            throw new NotImplementedException();
        }

        public override void IsHit(float x, float y)
        {
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
