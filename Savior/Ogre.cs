using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savior
{
    internal class Ogre : Enemy
    {
        //constructor
        public Ogre(string a_name) : base(a_name) 
        {
            health = 40;
            damage = randomNumber.Next(10, 15);
            weapon = "club";
        }


        public override string Speak()
        {
            return "I am an ogre.";
        }


    }
}
