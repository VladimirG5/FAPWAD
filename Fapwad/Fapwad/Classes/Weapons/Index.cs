using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using Fapwad.Classes;
using Fapwad.Classes.Characters.Hero;
using Fapwad.Classes.Characters.Enemy;

namespace Fapwad.Classes.Weapons
{
    public class Index
    {
        public int X;
        public int Y;
        public int indexWidth;
        public int indexHeight;
        public int Width;
        public int Height;
        public bool colided;
        public HeroClass Hero;

        public Index(int x, int y, int width, int height, HeroClass Hero)
        {
            this.X = x;
            this.Y = y;
            this.indexWidth = 25;
            this.indexHeight = 50;
            this.Width = width;
            this.Height = height;
            this.colided = false;
            this.Hero = Hero;

        }

        public void Draw(Graphics g)
        {
            // TO BE IMPLEMENTED
            Brush solid = new SolidBrush(Color.Red);
            //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
            g.FillRectangle(solid, X, Y, indexWidth, indexHeight);
            solid.Dispose();
        }
        /*public void Move()
        {
            // TO BE IMPLEMENTED
            this.Y = Y - 5;
        }*/
        public void MoveIndex(List<Obstacles.Rectangle> rectangles, List<EnemyClass> enemies)
        {
            this.Y = Y - 5;
            this.IsCollided(rectangles);
            this.HitAnEnemy(enemies, Hero);
            /*foreach (Index i in indices)
            {
                i.Move();
                i.IsCollided(rectangles);
                i.HitAnEnemy(enemies, this);
            }

            THIS IS AT LEVEL  !!!!

            for (int i = 0; i < indices.Count; i++)
            {
                if (indices[i].colided)
                {
                    indices.RemoveAt(i);
                }
            }*/


        }

        public void HitAnEnemy(List<EnemyClass> enemies, HeroClass Hero)
        {
            foreach (EnemyClass enemy in enemies)
            {
                if (IsHit(enemy.X, enemy.Y, enemy.characterWidth, enemy.characterHeight))
                {
                    colided = true;
                    enemy.Hurt(15);
                    Hero.GradeUp(false);
                    break;
                }
            }
        }

        public void IsCollided(List<Obstacles.Rectangle> rectangles)
        {
            // TO BE IMPLEMENTED
            // Checking the window
            if (this.X < 0 || this.X > 800 || this.Y < 0)
            {
                colided = true;
            }
            foreach(Obstacles.Rectangle r in rectangles)
            {
                if (IsHit(r.X, r.Y, r.Width, r.Height))
                {
                    colided = true;
                    break;
                }
            }
            

        }

       /* public void HitAnEnemy(List<EnemyClass> enemies, int demage)
        {
            foreach (EnemyClass enemy in enemies)
            {
                if (IsHit(enemy.X, enemy.Y, enemy.characterWidth, enemy.characterHeight))
                {
                    enemy.Hurt(demage);
                    break;
                }
                
            }
            
        }*/

        private bool IsHit(int recX, int recY, int recWidth, int recHeight)
        {
            //int recX, int recY, int recWidth, int recHeight
            return (recX < this.X + this.Width) &&
                   (this.X < (recX + recWidth)) &&
                   (recY < this.Y + this.Height) &&
                   (this.Y < recY + recHeight);

        }
    }
}
