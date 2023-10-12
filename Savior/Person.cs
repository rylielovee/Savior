using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savior
{
    internal class Person
    {
        private string name;
        public string Name { get; set; }

        private static int health = 100;
        public int Health { get { return health; } set { health = value; } }

        private int attackDamage = 10;
        public int AttackDamage { get { return attackDamage; } set { attackDamage = value; } }

        // list of items
        private List<string> itemsList;
        public List<String> ItemsList { get { return itemsList; } }



        public Person(String a_name) 
        {
            name = a_name;
            health = 700;
            attackDamage = 10;

            itemsList = new List<String>();
        }

        public override string ToString()
        {
            return name;
        }

        //ITEM STUFF ---------------------------------------------------


        // print items in list
        public void PrintItems()
        {
            Console.WriteLine("Items:");

            int i = 0;
            foreach (String item in itemsList)
            {
                i++;
                Console.WriteLine(i + ". " + item);
            }
            Console.WriteLine("");

        }

        // remove items
        public void RemoveItems(string item)
        {
            itemsList.Remove(item);
        }

        











        /*

        // 
        public void ItemDoesThis(Item item)
        {
            if (item.type == "weapon")
            {

            }
            else if (item.type == "armor")
            {

            }
            else if (item.type == "key")
            {

            }
            else if (item.type == "food")
            {

            }
            else
            {

            }
        }

        */




    }
}
