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
        public List<AbstractClass.Character> characters { get; set; }
        public List<Obstacles.Rectangle> Rectangles { get; set; }
        public HeroClass Hero { get; set; }
        //public List<Index> indices { get; set; }
        //public List<ReportedSheet> reportedSheets { get; set; }
        public int ID { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public enum CHARACTER_TYPE
        {
            HERO,
            ENEMY
        }
        public Level(int ID, int width, int height)
        {
            this.ID = ID;
            this.Width = width;
            this.Height = height;
            characters = new List<AbstractClass.Character>();
            // NEED TO BE CHANGED
            Hero = new HeroClass(55,66,66,66,66);
            Rectangles = new List<Obstacles.Rectangle>();
            //indices = new List<Index>();
            //reportedSheets = new List<ReportedSheet>();
        }
        public void AddCharacter(int x, int y, int demage, int lives, int HP, CHARACTER_TYPE type)
        {
            // CHANGE !!
            Character c = null;
            c = new EnemyClass(x, y, demage, lives, HP);
            characters.Add(c);
        }
        public void AddRectangle(int x, int y, int width, int height)
        {
            Obstacles.Rectangle r = new Obstacles.Rectangle(x, y, width, height);
            Rectangles.Add(r);
        }
        public void Draw(Graphics g)
        {
            foreach (AbstractClass.Character c in characters)
            {
                c.Draw(g);
            }
            foreach (Obstacles.Rectangle r in Rectangles)
            {
                r.Draw(g);
            }
            Hero.Draw(g);
        }
        /* public void CheckCollisions()
        {
            foreach(AbstractClass.Character c in characters)
            {
                c.IsCollided(Width,Height,Rectangles);
            }
        } */
        public void MoveObjects()
        {
            foreach (AbstractClass.Character c in characters)
            {
                c.Move(Width, Height, Rectangles);
            }
        }
        public void HeroFires()
        {
            foreach (AbstractClass.Character c in characters)
            {
                c.Fire(CHARACTER_TYPE.HERO);
            }


        }
        public void EnemyFires()
        {
            foreach (AbstractClass.Character c in characters)
            {
                c.Fire(CHARACTER_TYPE.ENEMY);
            }
        }
    }
}
