using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fapwad.Classes.Obstacles;
using System.Drawing;
using System.Windows.Forms;
using Fapwad.Classes;
using Fapwad.Classes.Characters.Enemy;
using Fapwad.Classes.Levels;
using Fapwad.Classes.Weapons;
using Fapwad.Properties;
namespace Fapwad.Classes.Characters.Hero
{

    public class HeroClass

    {
        public int X;
        public int Y;
        public int WeaponStrength;
        public int Health;
        public int characterWidth;
        public int characterHeight;
        public String ImagePath;
        //public List<Index> indices;
        public bool isDead;
        public double Grade;
        public HeroClass(int x, int y, int characterWidth, int characterHeight ,int demage, int HP, String ImagePath) 
        {
            this.X = x;
            this.Y = y;
            this.characterWidth = characterWidth;
            this.characterHeight = characterHeight;
            this.WeaponStrength = demage;
            this.Health = HP;
            this.ImagePath = ImagePath;

            //indices = new List<Index>();
            isDead = false;
            Grade = 5.0;
        }
        public  void Die()
        {
            if (Health < 0)
            {
                isDead = true;
            }
            
        }
       
        public  void Draw(Graphics g)
        {

            Object O = Resources.ResourceManager.GetObject(ImagePath);
            Image image = new Bitmap((Image)O);
            //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
             g.DrawImageUnscaled(image, X, Y);
           

           
            /*Image image = new Bitmap(Properties.Resources.Untitled);
           tBrush.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
             TextureBrush tBrush = new TextureBrush(image);
            g.FillRectangle(tBrush, X, Y, characterWidth, characterHeight);
            tBrush.Dispose();

            */
            /*foreach (Index i in indices)
            {
                i.Draw(g);
            }*/
        }


         public  Index Fire()
         {
          
            // WIDTH AND HEIGHT TO BE DONE
            Index new_Index = new Index(X + 12, Y - 50, 25, 50, this);
            return new_Index;    
            //indices.Add(new_Index);
            // TO BE DONE !
            
            
         }
     

        private bool distance(int recX, int recY, int recWidth, int recHeight)
        {
            return (recX < this.X + this.characterWidth) &&
                   (this.X < (recX + recWidth)) &&
                   (recY < this.Y + this.characterHeight) &&
                   (this.Y < recY + recHeight);

        }

        public  bool IsCollided(List<Obstacles.Rectangle> rectangles)
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

        

        /*public void MoveIndexes(List<Obstacles.Rectangle> rectangles, List<EnemyClass> enemies)
        {
            foreach (Index i in indices)
            {
                i.Move();
                i.IsCollided(rectangles);
                i.HitAnEnemy(enemies,this);
            }

               for (int i = 0; i < indices.Count; i++)
                {
                    if (indices[i].colided)
                    {
                        indices.RemoveAt(i);
                    }
                }
            
            
        }*/

        public void Hurt(int demage)
        {
            this.Health -= demage;
            Die();
        }

        public void moveUp(List<Obstacles.Rectangle> rectangles)
        {
            int oldY = this.Y;
            this.Y -= 10;
            if (IsCollided(rectangles) || this.Y < 0)
            {
                this.Y = oldY;
            }
        }

        public void moveDown(int height,List<Obstacles.Rectangle> rectangles)
        {
            int oldY = this.Y;
            this.Y += 10;
            if (IsCollided(rectangles) || this.Y > height - characterHeight)
            {
                this.Y = oldY;
            }
        }

        public void moveLeft(List<Obstacles.Rectangle> rectangles)
        {
            int oldX = this.X;
            this.X -= 10;
            if (IsCollided(rectangles) || this.X < 0)
            {
                this.X = oldX;
            }
        }

        public void moveRight(int width, List<Obstacles.Rectangle> rectangles)
        {
            int oldX = this.X;
            this.X += 10;
            if (IsCollided(rectangles) || this.X > width - characterWidth)
            {
                this.X = oldX;
            }
        }
        /*public void Move(int width, int height, String direction, List<Obstacles.Rectangle> rectangles)
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
           else if (direction == "DOWN")
            {
                this.Y += 10;
                if (IsCollided(rectangles) || this.Y > height)
                {
                    this.Y = oldY;
                }
            }
            else if (direction == "LEFT")
            {
                this.X -= 10;
                if (IsCollided(rectangles) || this.X < 0)
                {
                    this.X = oldX;
                }
            }
            else
            {
                this.X += 10;
                if (IsCollided(rectangles) || this.X > width - characterWidth)
                {
                    this.X = oldX;
                }

            }    
        }*/

        public void GradeUp(bool isHit)
        {
            if (isHit && Grade > 5)
                this.Grade -= 0.5;
            else if (!isHit && Grade < 10)
            {
                this.Grade += 0.5;
            }
        }


    }
}
