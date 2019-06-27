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
        public Level currentLevel;
        public Level Levels { get; set; }
        private HeroClass Hero;
        public GameClass()
        {
            HeroClass Hero = new HeroClass(500,800,50,100, 10);
        }


    }
}
