using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fapwad.Classes.Characters.Enemy;
using Fapwad.Classes.Characters.Hero;
using Fapwad.Classes.Obstacles;
using Fapwad.Classes.AbstractClass;
using System.Drawing;
using Fapwad.Classes.Weapons;


namespace Fapwad.Classes.Levels
{
    
    public class Level
    {
        public List<EnemyClass> characters { get; set; }
        public List<Obstacles.Rectangle> Rectangles { get; set; }
        public HeroClass Hero { get; set; }
        //public List<Index> indices { get; set; }
        //public List<ReportedSheet> reportedSheets { get; set; }
        public int ID { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        Random rand = new Random();
        public enum CHARACTER_TYPE
        {
            HERO,
            ENEMY
        }
        public Level(int ID, int width, int height, HeroClass Hero)
        {
            this.ID = ID;
            this.Width = width;
            this.Height = height;
            characters = new List<EnemyClass>();
            // NEED TO BE CHANGED
            this.Hero = Hero;
            Rectangles = new List<Obstacles.Rectangle>();
            AddCharacter(100, 100, 450, 400);
            AddRectangle(300,600,100,20);
            //indices = new List<Index>();
            //reportedSheets = new List<ReportedSheet>();
        }

        public void AddCharacter(int x, int y,int width,int height)
        {
            // CHANGE !!
            for (int i = 0; i < 4; i++)
            {
                int posX = rand.Next(x, x + width);
                int posY = rand.Next(y, y + height);
                int demage = ID * 10;
                int HP = ID * 10;
                if (i == 0)
                {
                    demage += 10;
                    HP += 20;
                }
                EnemyClass c = new EnemyClass(posX, posY, 50, 100, demage,  HP);
                characters.Add(c);
            }
            
        }
        public void AddRectangle(int x, int y, int width, int height)
        {
            for (int i = 0; i < 3; i++)
            {
                Obstacles.Rectangle r = null;
                if (i == 0)
                {
                    r = new Obstacles.Rectangle( x, y, width, height);
                }

                if (i == 1)
                {
                    r = new Obstacles.Rectangle(x+150,y+150,width,height);
                }
                
                if (i == 2)
                {
                    r = new Obstacles.Rectangle(x-150,y+150,width,height);
                }
                
                Rectangles.Add(r);
            }
            
        }
        public void Dying()
        {
            for(int i = 0; i < characters.Count; i++)
            {
                if (characters[i].isDead)
                {
                    characters.RemoveAt(i);
                }
            }
        }
        public void Draw(Graphics g)
        {
            foreach (EnemyClass c in characters)
            {
                c.Draw(g);
            }
            foreach (Obstacles.Rectangle r in Rectangles)
            {
                r.Draw(g);
            }
            Hero.Draw(g);
        }
       
        public void MoveObjects()
        {
            foreach (EnemyClass c in characters)
            {
                c.Move(0, 0, 800, 500);
                c.MoveSheets(Rectangles, Hero);
            }

            Hero.MoveIndexes(Rectangles,characters);
        }

        public void MoveHero(String direction)
        {
            Hero.Move(Width,Height,direction,Rectangles);
        }
        
        public void EnemyFires()
        {
            int br = rand.Next(0, characters.Count);
            for(int i = 0; i < br; i++)
            {
                characters[i].Fire();
            }
        }
    }
}
