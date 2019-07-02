using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fapwad.Classes.Characters.Enemy;
using Fapwad.Classes.Characters.Hero;
using Fapwad.Classes.Obstacles;
using System.Drawing;
using Fapwad.Classes.Levels;
using Fapwad.Classes.Weapons;

namespace Fapwad.Classes.MainClass
{
    public class GameClass
    {
        public Level currentLevel;
        public Level Levels;
        public HeroClass Hero;
        public int ID;
        public int Width;
        public int Height;
        public int Points;
        public String[] listOfStrings;
        public int[] coordinates;


        public GameClass()
        {
            GC.Collect();
            this.Width = 800;
            this.Height = 1080;
            Hero = new HeroClass(350, 890, 50, 100, 10, 100, "heroMini_back");
            this.ID = 1;
            this.Points = 0;
            this.listOfStrings = new String[]{ "fprofMini", "fprofMini", "fprofMini", "fprofMini"};
            this.coordinates = new int[] { 350, 100, 500, 500, 400, 450 };
            Level firstLevel = new Level(ID, Width, Height, Hero,listOfStrings,coordinates,"Level1", "ogradaMini_2");
            currentLevel = firstLevel;

        }
        public void updateLevel()
        {
            // RESET THE HERO COORDINATES !!!
            if(ID == 1)
            {
                GC.Collect();
                ID = 2;
                listOfStrings = new String[] { "profMini", "profMini", "profMini", "profMini" };
                this.coordinates = new int[] { 200, 500, 600, 500};
                Level secondLevel = new Level(ID, Width, Height, Hero,listOfStrings, coordinates,"Level2", "ogradaMini_2");
                Hero.X = 350;
                Hero.Y = 890;
                currentLevel = secondLevel;
            }
            else if (ID == 2)
            {
                GC.Collect();
                ID = 3;
                listOfStrings = new String[] { "fprofMini", "fprofMini", "profMini", "profMini" };
                this.coordinates = new int[] {350, 750};
                Level thirdLevel = new Level(ID, Width, Height, Hero,listOfStrings,coordinates,"Level3","ogradaMini_2");
                Hero.X = 350;
                Hero.Y = 950;
                currentLevel = thirdLevel;
            }
        }
        public int CheckLevel()
        {
            if(currentLevel.characters.Count == 0)
            {
                updateLevel();
            }
            return this.ID;
        }
        // TICK CALL
        public void MoveObjects()
        {
            currentLevel.MoveObjects();
        }
        // MOVING THE FUCKING HERO !!!
        public void MoveHero(String direction)
        {

            //Hero.Move(Width, Height, direction, currentLevel.Rectangles);
            switch (direction)
            {
                case "UP":
                    Hero.moveUp(currentLevel.Rectangles);
                    break;
                case "DOWN":
                    Hero.moveDown(this.Height, currentLevel.Rectangles);
                    break;
                case "LEFT":
                    Hero.moveLeft(currentLevel.Rectangles);
                    break;
                case "RIGHT":
                    Hero.moveRight(this.Width, currentLevel.Rectangles);
                    break;
            }
            /*if (direction == "UP")
                Hero.moveUp(currentLevel.Rectangles);
            else if (direction == "DOWN")
                Hero.moveDown(this.Height, currentLevel.Rectangles);
            else if (direction == "LEFT")
                Hero.moveLeft(currentLevel.Rectangles);
            else if (direction == "RIGHT")
                Hero.moveRight(this.Width, currentLevel.Rectangles);
                */
        }
        // HERO FIRES !!!
        public void HeroFires()
        {
            currentLevel.HeroFires();
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
