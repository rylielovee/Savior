using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Savior
{
    internal class Battle
    {
        public Battle()
        {

        }

        // use items?
        public void UseFood(Person a_warrior)
        {
            Console.WriteLine("If you have food, which food would you like to eat to restore health?");
            Console.WriteLine("If not, type no.");

            string input = Console.ReadLine().ToLower();
            Console.WriteLine("");

            if (input == "apple" || input == "sandwich" || input == "mysterious canned soup" || input == "cheese" || input == "carrot" 
                || input == "lamb chop" || input == "moldy bread")
            {
                a_warrior.Health += 50;
                a_warrior.ItemsList.Remove(input);
            }
            else
            {
                Console.WriteLine("");
            }

            Console.WriteLine("Your health is now " + a_warrior.Health + "\n");


        }


        // Options Function
        public void Options(Person a_warrior, Enemy a_enemy)
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("a) Looking at Items");
            Console.WriteLine("b) Attack");
            Console.WriteLine("c) Do Nothing");
            string answer = Console.ReadLine();
            Console.WriteLine("");
            if (answer.ToLower() == "a")
            {
                a_warrior.PrintItems();

                UseFood(a_warrior);

                Options(a_warrior, a_enemy);
            }
            else if (answer.ToLower() == "b")
            {
                Attack(a_warrior, a_enemy, a_enemy.Health, a_warrior.Health);
            }
            else
            {
                Attack(a_enemy, a_warrior, a_enemy.Health, a_warrior.Health);
            }
        }


        // PERSON Attack Method
        public void Attack(Person a_warrior, Enemy a_enemy, int newEnemyHealth, int newWarriorHealth)
        {
            // result on enemy's health when person attacks
            a_enemy.Health =+ newEnemyHealth - a_warrior.AttackDamage;
            Console.WriteLine("- You swing your sword and hit the " + a_enemy);
            Console.WriteLine("- The " + a_enemy +"'s health has decreased to " + a_enemy.Health + "\n");

            if (a_enemy.Health <= 0)
            {
                a_enemy.Health = 0;
                Console.WriteLine("You defeated the " + a_enemy + "!\n");
            }
            else
            {
                Attack(a_enemy, a_warrior, a_enemy.Health, a_warrior.Health);
            }
        }

        // ENEMY Attack Method
        public void Attack(Enemy a_enemy, Person a_warrior, int newEnemyHealth, int newWarriorHealth)
        {
            Console.WriteLine(a_enemy.Speak());
            // result on person's health when enemy attacks
            a_warrior.Health =+ newWarriorHealth - a_enemy.Damage;
            Console.WriteLine("- The " + a_enemy + " used its " + a_enemy.Weapon + " on you.");
            Console.WriteLine("- Your health has decreased to " + a_warrior.Health + "\n");

            if (a_warrior.Health <= 0)
            {
                a_warrior.Health = 0;
                Console.WriteLine("You Died :(\n");
                System.Environment.Exit(1);
            }
            else
            {
                Options(a_warrior, a_enemy);
                  
            }
        }
    }
}
