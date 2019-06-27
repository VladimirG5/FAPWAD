using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fapwad.Classes.Obstacles;
using System.Drawing;
using System.Windows.Forms;
using Fapwad.Classes;
using Fapwad.Classes.AbstractClass;
using Fapwad.Classes.Characters.Enemy;
using Fapwad.Classes.Levels;
using Fapwad.Classes.Weapons;
namespace Fapwad.Classes.Characters.Hero
{

    public class HeroClass : AbstractClass.Character

    {
        public List<Index> indices { get; set; }
        public bool isDead { get; set; }    
        public HeroClass(int x, int y, int characterWidth, int characterHeight ,int demage, int HP) : base(x, y, characterWidth, characterHeight, demage, HP)
        {
            indices = new List<Index>();
            isDead = false;
        }
        public override void Die()
        {
            if (Health < 0)
            {
                isDead = true;
            }
            
        }

        public override void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color.Blue);
            g.FillRectangle(b, X, Y, characterWidth, characterHeight);
            foreach(Index i in indices)
            {
                i.Draw(g);
            }
            // INDICES TO BE DONE!
            b.Dispose();
          
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

       public override void Fire()
        {
          
                // WIDTH AND HEIGHT TO BE DONE
                Index new_Index = new Index(X + 12, Y - 50, 25, 50);
                indices.Add(new_Index);
                // TO BE DONE !
            
            
        }
     

        private bool distance(int recX, int recY, int recWidth, int recHeight)
        {
            return (recX < this.X + this.characterWidth) &&
                   (this.X < (recX + recWidth)) &&
                   (recY < this.Y + this.characterHeight) &&
                   (this.Y < recY + recHeight);

        }

        public override bool IsCollided(List<Obstacles.Rectangle> rectangles)
        {
            
            foreach (Obstacles.Rectangle rec in rectangles)
            {
                if (distance(rec.X, rec.Y, rec.Width, rec.Height))
                {
                    return true;
                }
            }

            return false;
         
        }

        

        public void MoveIndexes(List<Obstacles.Rectangle> rectangles, List<EnemyClass> enemies)
        {
            foreach (Index i in indices)
            {
                i.Move();
                i.IsCollided(rectangles);
                i.HitAnEnemy(enemies);
            }

               for (int i = 0; i < indices.Count; i++)
                {
                    if (indices[i].colided)
                    {
                        indices.RemoveAt(i);
                    }
                }
            
            
        }

        public void Hurt(int demage)
        {
            this.Health -= demage;
            Die();
        }

        public void Move(int width, int height, String direction, List<Obstacles.Rectangle> rectangles)
        {
            int oldX = this.X;
            int oldY = this.Y;
            if (direction == "UP")
            {
                this.Y -= 10;
                if (IsCollided(rectangles) || this.Y < 0)
                {
                    this.Y = oldY;
                }
            }
            if (direction == "DOWN")
            {
                this.Y += 10;
                if (IsCollided(rectangles) || this.Y > height)
                {
                    this.Y = oldY;
                }
            }
            if (direction == "LEFT")
            {
                this.X -= 10;
                if (IsCollided(rectangles) || this.X < 0)
                {
                    this.X = oldX;
                }
            }
            if (direction == "RIGHT")
            {
                this.X += 10;
                if (IsCollided(rectangles) || this.X > width)
                {
                    this.X = oldX;
                }

            }

            // INDICES TO BE DONE !
            
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
