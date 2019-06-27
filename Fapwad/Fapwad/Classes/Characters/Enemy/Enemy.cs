using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fapwad.Classes.Obstacles;
using System.Drawing;
using System.Drawing.Drawing2D;
using Fapwad.Classes.AbstractClass;
using Fapwad.Classes.Characters.Hero;
using Fapwad.Classes.Levels;
using Fapwad.Classes.Weapons;
namespace Fapwad.Classes.Characters.Enemy
{
    public class EnemyClass : AbstractClass.Character
    {
        public List<ReportedSheet> reportedSheets { get; set; }

        public double Angle { get; set; }
        private double velocity;
        private double velocityX;
        private double velocityY;
        Random rand = new Random();
        public bool isDead { get; set; }    
        public EnemyClass(int x, int y, int characterWidth, int characterHeight, int demage, int HP) : base(x, y, characterWidth, characterHeight, demage, HP)
        {
            velocity = 10;
            Angle = rand.NextDouble() * 2 * Math.PI;
            velocityX = (Math.Cos(Angle) * velocity);
            velocityY = (Math.Sin(Angle) * velocity);
            isDead = false;
        }
        public override void Die()
        {
            if (base.Health < 0)
            {
                isDead = true;
            }

            
            
        }

        public override void Draw(Graphics g)
        {
            // REPORTED_SHEETS !!
            Brush b = new SolidBrush(Color.Red);
            g.FillRectangle(b,X,Y,characterWidth,characterHeight);
            
        }

       

        public override void Fire(Level.CHARACTER_TYPE type)
        {
            if (type == Level.CHARACTER_TYPE.HERO)
                return;

            ReportedSheet new_ReportedSheet = new ReportedSheet(X, Y, 25, 50);
            reportedSheets.Add(new_ReportedSheet);
            
        }


        

        private bool distance(int recX, int recY, int recWidth, int recHeight)
        {
            return (recX < this.X + this.characterWidth) &&
                   (this.X < (recX + recWidth)) &&
                   (recY < this.Y + this.characterHeight) &&
                   (this.Y < recY + recHeight);

        }

        public void MoveSheets(List<Obstacles.Rectangle> rectangles, HeroClass Hero)
        {
            foreach (ReportedSheet sheet in reportedSheets)
            {
                sheet.Move();
                sheet.IsCollided(rectangles);
                sheet.HitAHero(Hero, this.WeaponStrength);
            }

            for (int i = 0; i < reportedSheets.Count; i++)
            {
                if (reportedSheets[i].colided)
                {
                    reportedSheets.RemoveAt(i);
                }
            }
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

            throw new NotImplementedException();
        }

        
        //da se opraj
        public void Move(int left, int top, int width, int height)
        {
            int nextX = (int)(this.X + velocityX);
            int nextY = (int)(this.Y + velocityY);
            int lft = left + characterWidth;
            int rgt = left + width - characterWidth;
            int tp = top + characterHeight;
            int btm = top + height - characterHeight;

            if (nextX <= lft)
            {
                nextX = lft + (lft - nextX);
                velocityX = -velocityX;
            }
            if (nextX >= rgt)
            {
                nextX = rgt - (nextX - rgt);
                velocityX = -velocityX;

            }
            if (nextY <= tp)
            {
                nextY = tp + (tp - nextY);
                velocityY = -velocityY;
            }

            if (nextY >= btm)
            {
                nextY = btm - (nextY - btm);
                velocityY = -velocityY;
            }
            this.X = nextX;
            this.Y = nextY;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void Hurt(int demage)
        {
            this.Health -= demage;
            Die();  
        }
    }
}
