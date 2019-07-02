using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fapwad.Classes.Characters.Enemy;
using Fapwad.Classes.Characters.Hero;
using Fapwad.Classes.Obstacles;
using System.Drawing;
using Fapwad.Properties;
using Fapwad.Classes.Weapons;


namespace Fapwad.Classes.Levels
{
    
    public class Level
    {
        public List<EnemyClass> characters;
        public List<Obstacles.Rectangle> Rectangles;
        public List<Index> indices;
        public List<ReportedSheet> reportedSheets;
        public HeroClass Hero;
        public int ID;
        public int Width;
        public int Height;
        public String[] listOfPaths;
        public String levelPath;
        public int[] obstacleCoordinates;
        public String obstaclePath;
        Random rand = new Random();
        public enum CHARACTER_TYPE
        {
            HERO,
            ENEMY
        }
        public Level(int ID, int width, int height, HeroClass Hero, String[] listOfPaths, int[] obstacleCoordinates, String levelPath, String obstaclePath)
        {
            this.ID = ID;
            this.Width = width;
            this.Height = height;
            characters = new List<EnemyClass>();
            // NEED TO BE CHANGED
            this.Hero = Hero;
            Rectangles = new List<Obstacles.Rectangle>();
            this.indices = new List<Index>();
            this.reportedSheets = new List<ReportedSheet>();
            this.levelPath = levelPath;
            this.listOfPaths = listOfPaths;
            this.obstaclePath = obstaclePath;
            this.obstacleCoordinates = obstacleCoordinates;
            AddCharacter(100, 100, 450, 400);
            AddRectangle(obstacleCoordinates,100,50,obstaclePath);
            
            

        }

        public void AddCharacter(int x, int y,int width,int height)
        {
            // CHANGE !!
            for (int i = 0; i < 4; i++)
            {
                int posX = rand.Next(x, x + width);
                int posY = rand.Next(y, y + height);
                int demage = ID * 10;
                int HP = ID * 20;
                String path = listOfPaths[i];
                if (i == 0)
                {
                    demage += 10;
                    HP += 20;
                    

                }
                EnemyClass c = new EnemyClass(posX, posY, 50, 100, demage,  HP, path, Hero);
                characters.Add(c);
            }
            
        }
        public void AddRectangle(int[] coordinates, int width, int height, String obstaclePath)
        {
            int number = 0;
            if (ID == 1) number = 3;
            if (ID == 2) number = 2;
            if (ID == 3) number = 1;
            for (int i = 0; i < number; i++)
            {
                Obstacles.Rectangle r = null;
                int obstacleX = coordinates[i];
                int obstacleY = coordinates[i + number];
                r = new Obstacles.Rectangle(obstacleX, obstacleY, width, height, obstaclePath);
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
            if (Hero.isDead)
            {
                //Hero = null;
            }
            for(int i = 0; i < indices.Count; i++)
            {
                if (indices[i].colided)
                    indices.RemoveAt(i);
            }
            for(int i = 0; i < reportedSheets.Count; i++)
            {
                if (reportedSheets[i].colided)
                    reportedSheets.RemoveAt(i);
            }
            
        }

        public void Draw(Graphics g)
        {
           

            Hero.Draw(g);
            foreach (EnemyClass c in characters)
            {
                c.Draw(g);
            }
            foreach (Obstacles.Rectangle r in Rectangles)
            {
                r.Draw(g);
            }
            foreach(Index i in indices)
            {
                i.Draw(g);
            }
            foreach(ReportedSheet sh in reportedSheets)
            {
                sh.Draw(g);
            }
            
        }
        
       
        public void MoveObjects()
        {
            foreach (EnemyClass c in characters)
            {
                c.Move(0, 0, 800, 500);
                //c.MoveSheets(Rectangles, Hero);
            }
            foreach(Index i in indices)
            {
                i.MoveIndex(Rectangles, characters);
            }
            foreach(ReportedSheet sh in reportedSheets)
            {
                sh.MoveSheets(Rectangles, Hero);
            }
            //Hero.MoveIndexes(Rectangles,characters);
        }

        /*public void MoveHero(String direction)
        {
            //Hero.Move(Width,Height,direction,Rectangles);
        }*/
        
        public void EnemyFires()
        {
            int br = rand.Next(0, characters.Count + 1);
            for(int i = 0; i < br; i++)
            {
                ReportedSheet sheet = null;
                sheet = characters[i].Fire();
                reportedSheets.Add(sheet);
            }
        }
        public void HeroFires()
        {
            Index index = null;
            index = Hero.Fire();
            indices.Add(index);
        }
    }
}
