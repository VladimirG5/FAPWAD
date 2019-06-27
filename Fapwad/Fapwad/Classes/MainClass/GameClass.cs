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
using Fapwad.Classes.Levels;
using Fapwad.Classes.Weapons;

namespace Fapwad.Classes.MainClass
{
    public class GameClass
    {
        public Level currentLevel { get; set; }
        public Level Levels { get; set; }
        private HeroClass Hero { get; set; }
        public int ID { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Points { get; set; }


        public GameClass()
        {
            this.Width = 800;
            this.Height = 1000;
            Hero = new HeroClass(500, 800, 50, 100, 10, 100);
            this.ID = 1;
            this.Points = 0;
            Level firstLevel = new Level(ID, Width, Height, Hero);
            currentLevel = firstLevel;

        }
        public void updateLevel()
        {
            if(ID == 1)
            {
                ID = 2;
                Level secondLevel = new Level(ID, Width, Height, Hero);
                currentLevel = secondLevel;
            }
            if (ID == 2)
            {
                ID = 3;
                Level thirdLevel = new Level(ID, Width, Height, Hero);
                currentLevel = thirdLevel;
            }
        }
        // TICK CALL
        public void MoveObjects()
        {
            currentLevel.MoveObjects();
        }
        // MOVING THE FUCKING HERO !!!
        public void MoveHero(String direction)
        {
       
            Hero.Move(Width, Height, direction, currentLevel.Rectangles);


        }
        // HERO FIRES !!!
        public void HeroFires()
        {
            Hero.Fire();
        }

        public void EnemyFires()
        {
            currentLevel.EnemyFires();
        }

        public void Draw(Graphics g)
        {
            currentLevel.Draw(g);
        }




    }
}
