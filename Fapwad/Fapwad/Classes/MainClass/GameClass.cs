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
        public String[] listOfStrings { get; set; }
        public int[] coordinates { get; set; }


        public GameClass()
        {
            this.Width = 800;
            this.Height = 1000;
            Hero = new HeroClass(350, 700, 50, 100, 10, 100,"Hero");
            this.ID = 1;
            this.Points = 0;
            this.listOfStrings = new String[]{ "al3", "al3", "al3", "al3"};
            this.coordinates = new int[] { 350, 100, 500, 500, 400, 450 };
            Level firstLevel = new Level(ID, Width, Height, Hero,listOfStrings,coordinates,"Level1", "ogradaMini_2");
            currentLevel = firstLevel;

        }
        public void updateLevel()
        {
            // RESET THE HERO COORDINATES !!!
            if(ID == 1)
            {
                ID = 2;
                listOfStrings = new String[] { "al3", "al3", "al3", "al3" };
                this.coordinates = new int[] { 200, 700, 600, 500};
                Level secondLevel = new Level(ID, Width, Height, Hero,listOfStrings, coordinates,"Level2", "ogradaMini_2");
                Hero.X = 350;
                Hero.Y = 700;
                currentLevel = secondLevel;
            }
            else if (ID == 2)
            {
                ID = 3;
                listOfStrings = new String[] { "al3", "al3", "al3", "al3" };
                this.coordinates = new int[] {350, 550};
                Level thirdLevel = new Level(ID, Width, Height, Hero,listOfStrings,coordinates,"Level3","ogradaMini_2");
                Hero.X = 350;
                Hero.Y = 700;
                currentLevel = thirdLevel;
            }
        }
        public void CheckLevel()
        {
            if(currentLevel.characters.Count == 0)
            {
                updateLevel();
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
