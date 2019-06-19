using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fapwad.Classes.Obstacles;

namespace Fapwad.Classes.Characters.Hero
{

    public class Hero : AbstractClass.Character

    {
        public Hero(int x, int y, int demage, int lives, int HP) : base(x, y, demage, lives, HP)
        {

        }
        public override void Die()
        {
            throw new NotImplementedException();
        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override void Fire()
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool IsCollided(int width, int height, List<Rectangle> rectangles)
        {
            throw new NotImplementedException();
        }

        public override void IsHit(float x, float y)
        {
            throw new NotImplementedException();
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
