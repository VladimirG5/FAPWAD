using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fapwad.Classes.AbstractClass
{
    public abstract class Character
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int WeaponStrength { get; set; }
        public int LivesLeft { get; set; }
        public int Health { get; set; }
        // public int WeaponType { get; set; }

        public Character(int x, int y, int demage, int lives, int HP)
        {
            this.X = x;
            this.Y = y;
            this.WeaponStrength = demage;
            this.LivesLeft = lives;
            this.Health = HP;
        }

        public abstract void Draw();
        public abstract void IsHit(float x, float y);
        public abstract void Fire();
        public abstract void Die();
        public abstract void Move();
        public abstract Boolean IsCollided(int width, int height, List<Obstacles.Rectangle> rectangles);

        

    }
}
