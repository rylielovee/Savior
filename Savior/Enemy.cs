using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savior
{
    internal class Enemy
    {
        protected string name;
        public string Name { get; set; }

        protected int health;
        public int Health { get { return health; } set { health = value; } }

        protected int damage;
        public int Damage { get { return damage; } set { damage = value; } }

        protected string weapon;
        public string Weapon { get { return weapon; } }

        protected Random randomNumber = new Random();
        public Random RandomNumber { get { return randomNumber; } set { randomNumber = value; } }

        // constructor
        public Enemy(string a_name)
        {
            name = a_name;
        }

        // ToString method
        public override string ToString()
        {
            return name;
        }

        public virtual string Speak()
        {
            return "I am an enemy.";
        }

    }
}
