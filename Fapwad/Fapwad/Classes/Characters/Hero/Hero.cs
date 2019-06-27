using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fapwad.Classes.Obstacles;
using System.Drawing;
using Fapwad.Classes;
using Fapwad.Classes.AbstractClass;
using Fapwad.Classes.Levels;
using Fapwad.Classes.Weapons;
namespace Fapwad.Classes.Characters.Hero
{

    public class HeroClass : AbstractClass.Character

    {
        public List<Index> indices { get; set; }

        public HeroClass(int x, int y, int demage, int lives, int HP) : base(x, y, demage, lives, HP)
        {

        }
        public override void Die()
        {
            throw new NotImplementedException();
        }

        public override void Draw(Graphics g)
        {
            // INDICES TO BE DONE!
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

       public override void Fire(Level.CHARACTER_TYPE type)
        {
            if (type == Level.CHARACTER_TYPE.ENEMY)
                return;
            else
            {
                // WIDTH AND HEIGHT TO BE DONE
                Index new_Index = new Index(X, Y, 100, 100);
                indices.Add(new_Index);
                // TO BE DONE !
            }
            
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
            // INDICES TO BE DONE !
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
