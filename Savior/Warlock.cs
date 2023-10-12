using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savior
{
    internal class Warlock : Enemy
    {
        // constructor
        public Warlock(string a_name) : base(a_name)
        {
            health = 60;
            damage = randomNumber.Next(20, 25);
            weapon = "magical staff";
        }

        public override string Speak()
        {
            return "I am a warlock.";
        }
    }
}
