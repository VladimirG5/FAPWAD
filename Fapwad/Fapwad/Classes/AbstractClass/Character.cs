using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fapwad.Classes.Levels;
using Fapwad.Classes.Weapons;

namespace Fapwad.Classes.AbstractClass
{
    public abstract class Character
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int WeaponStrength { get; set; }
        public int Health { get; set; }
        public int characterWidth { get; set; }
        public int characterHeight { get; set; }
        
        // public int WeaponType { get; set; }

        public Character(int x, int y, int characterWidth, int characterHeight, int demage, int HP)
        {
            this.X = x;
            this.Y = y;
            this.characterWidth = characterWidth;
            this.characterHeight = characterHeight;
            this.WeaponStrength = demage;
            this.Health = HP;
        }

        public abstract void Draw(System.Drawing.Graphics g);
        public abstract void Fire();
        public abstract void Die();

        public abstract Boolean IsCollided(List<Obstacles.Rectangle> rectangles);

        

    }
}
