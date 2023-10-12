using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Savior
{
    internal class Room
    {
        // name of room
        private string name;
        public string Name { get; set; }

        // loot in the room
        private string loot;
        public string Loot { get { return loot; } }
        
        // list of neighbors
        private List<Room> neighbors;
        public List<Room> Neighbors { get { return neighbors; } set { neighbors = value; } }


        // constructor 1
        public Room(string a_name)
        {
            name = a_name;
            neighbors = new List<Room>();
        }

        // constructor 2
        public Room(string a_name, string a_loot)
        {
            name = a_name;
            loot = a_loot;
            neighbors = new List<Room>();
        }

        public override string ToString()
        {
            return name;
        }

        // prints the neighbors or room
        public void PrintNeighbors()
        {
            foreach (Room neighbor in neighbors)
            {
                Console.WriteLine("- " + neighbor);
            }
        }

    }
}
