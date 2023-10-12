using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Savior
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // creating a graph starting at start
            Graph rooms = new Graph();


            // initializing and adding 25 rooms to graph
            Room start = rooms.AddRooms("Start");
            Room courtyard = rooms.AddRooms("Courtyard");
            Room stables = rooms.AddRooms("Stables", "Apple");
            Room forge = rooms.AddRooms("Forge", "Sandwich");
            Room armory = rooms.AddRooms("Armory", "Steel Sword");
            Room greatHall = rooms.AddRooms("Great Hall", "Mysterious Canned Soup");
            Room kitchen = rooms.AddRooms("Kitchen", "Cheese");
            Room pantry = rooms.AddRooms("Pantry", "Single Carrot");
            Room barn = rooms.AddRooms("Barn", "Lamb Chop");
            Room hallway = rooms.AddRooms("Hallway");
            Room servantBed = rooms.AddRooms("Servant Quarters", "Key 1");
            Room guestBed = rooms.AddRooms("Guest Bedroom");
            Room princessBed = rooms.AddRooms("Princess Cristina's Bedroom");
            Room kingBed = rooms.AddRooms("King Ronald's Bedroom");
            Room towerNW = rooms.AddRooms("Northwest Tower", "Key 2");
            Room towerNE = rooms.AddRooms("Northeast Tower");
            Room towerSW = rooms.AddRooms("Southwest Tower");
            Room towerSE = rooms.AddRooms("Southeast Tower");
            Room guardTower = rooms.AddRooms("Guard Tower");
            Room dungeon = rooms.AddRooms("Dungeon", "Moldy Bread");
            Room cell1 = rooms.AddRooms("Cell 1", "Key 3");
            Room cell3 = rooms.AddRooms("Cell 3");
            Room tortureChamber = rooms.AddRooms("Torture Chamber");
            Room royalGardens = rooms.AddRooms("Royal Gardens");
            Room wizardTower = rooms.AddRooms("Wizard's Tower");

            // connecting rooms
            rooms.Connect(start, courtyard); // start
            rooms.Connect(courtyard, stables, forge, greatHall); // courtyard
            rooms.Connect(stables, courtyard); // stables
            rooms.Connect(forge, armory, courtyard); // forge
            rooms.Connect(armory, forge); // armory

            
            rooms.Connect(greatHall, kitchen, hallway, courtyard, kingBed); // greatHall
            rooms.Connect(kitchen, pantry, barn, greatHall); // kitchen
            rooms.Connect(pantry, kitchen); // pantry
            rooms.Connect(barn, towerNW, greatHall); // barn
            rooms.Connect(hallway, servantBed, guestBed, princessBed, towerNE, greatHall); // hallway
            rooms.Connect(servantBed, hallway); // servant's bedroom
            rooms.Connect(guestBed, cell3, hallway); // guest's bedroom
            rooms.Connect(princessBed, hallway); // princess's bedroom

            rooms.Connect(kingBed, greatHall, royalGardens); // king's bedroom
            rooms.Connect(towerNW, towerSW, barn); // towerNW
            rooms.Connect(towerNE, hallway, towerSE); // towerNE
            rooms.Connect(towerSW, guardTower, towerNW); // towerSW
            rooms.Connect(towerSE, guardTower, towerNE, dungeon); // towerSE
            rooms.Connect(guardTower, towerSW, towerSE); // guard tower
            
            rooms.Connect(dungeon, tortureChamber, towerSE, cell1); // dungeon
            rooms.Connect(cell1, dungeon); // cell 1
            rooms.Connect(cell3, guestBed); // cell 3
            rooms.Connect(tortureChamber, dungeon); // torture chamber
            rooms.Connect(royalGardens, kingBed, wizardTower); // royal gardens
            rooms.Connect(wizardTower, royalGardens); // wizard's tower



            // STORY START ----------------------------------------------------------------------------------------------------------------

            

            // INTRO
            Console.WriteLine("You walk into the tavern on the outskirts of a kingdom just as the clock strikes midnight.");
            Console.WriteLine("You take a look around and see a figure with a hood covering his face by the back of room. You walk over.\n");
            Console.WriteLine("You ask him if he is the one looking for a warrior.\n");
            Console.WriteLine("He looks up at you. 'What is you name?'\n");
            Console.Write("Enter Name: ");

            Person warrior = new Person(Console.ReadLine());
            Console.WriteLine("");

            warrior.ItemsList.Add("rusty sword");
            //Item kingBedKey = new Item("key 1", "key");
            //Item rgKey = new Item("key 3", "key");
            //Item cell1Key = new Item("key 2", "key");


            Console.WriteLine("He removes his hood and you immediately recgonize him. It's the King.\n");
            Console.WriteLine("'I have heard you are the best warrior there is. I need your help.");
            Console.WriteLine("My kingdom has been overrun with ogres and warlocks.");
            Console.WriteLine("They have taken my daughter, Princess Cristina. Will you help me?'\n");

            Console.WriteLine("Yes or No:");
            while (true)
            {
                Console.WriteLine("");
                if (Console.ReadLine().ToLower() != "yes")
                {
                    Console.WriteLine("That's not the correct answer. Try Again.\n");
                    Console.WriteLine("Yes or No:\n");
                }
                else
                {
                    break;
                }
            }

            // At the Start
            rooms.Visited(start);
            Console.WriteLine("After taking a deep breath, you walk over the drawbridge into the Courtyard\n");

            Courtyard();




            // SPECIFIC ROOMS ---------------------------------------------------------------------------------------------------------


            // COURTYARD
            void Courtyard()
            {
                // if you have not visited room, then do battle stuff
                if (!rooms.VisitedRooms.Contains(courtyard))
                {
                    rooms.Visited(courtyard);

                    Enemy cyOgre1 = new Ogre("ogre");
                    Enemy cyOgre2 = new Ogre("ogre");

                    Console.WriteLine("You are faced with two ogres.\n");

                    Battle battle1ogre1 = new Battle();
                    battle1ogre1.Options(warrior, cyOgre1);

                    Console.WriteLine("Time for the second ogre.\n");

                    Battle battle1ogre2 = new Battle();
                    battle1ogre2.Options(warrior, cyOgre2);

                    Console.WriteLine("------------------------------\n");
                    Console.WriteLine("You look around and see a few different places to explore.");
                }

                while (true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Where would you like to go now?");
                    courtyard.PrintNeighbors();
                    Console.WriteLine("- See where you have already (visited)");

                    string answer = Console.ReadLine().ToLower();
                    Console.WriteLine("");
                    // if you pick this room, then go to that rooms function
                    if (answer == "stables")
                    {
                        Stables();
                        break;
                    }

                    else if (answer == "forge")
                    {
                        Forge();
                        break;
                    }
                    else if (answer == "great hall")
                    {
                        GreatHall();
                        break;
                    }
                    else if (answer == "visited")
                    {
                        rooms.PrintVisited();
                    }
                    else
                    {
                        Console.WriteLine("Please type one of the options.");
                    }
                }

            }


            // STABLES
            void Stables()
            {
                // if you have not visited room, then do battle stuff
                if (!rooms.VisitedRooms.Contains(stables))
                {
                    rooms.Visited(stables);

                    Enemy stablesWarlock = new Warlock("warlock");

                    Console.WriteLine("You are faced with one warlock.\n");

                    Battle battle2warlock = new Battle();
                    battle2warlock.Options(warrior, stablesWarlock);

                    Console.WriteLine("");
                    Console.WriteLine("As you look around, you see a nice juicy apple in a bowl. You take it.");

                    warrior.ItemsList.Add("apple");

                }

                while (true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Where would you like to go now?");
                    stables.PrintNeighbors();
                    Console.WriteLine("- See where you have already (visited)");

                    string answer = Console.ReadLine().ToLower();
                    Console.WriteLine("");
                    // if you pick this room, then go to that rooms function
                    if (answer == "courtyard")
                    {
                        Courtyard();
                        break;
                    }
                    else if (answer == "visited")
                    {
                        rooms.PrintVisited();
                    }
                    else
                    {
                        Console.WriteLine("Please type one of the options.");
                    }
                }

            }


            // FORGE
            void Forge()
            {
                // if you have not visited room, then do battle stuff
                if (!rooms.VisitedRooms.Contains(forge))
                {
                    rooms.Visited(forge);

                    Enemy forgeOgre1 = new Ogre("ogre");
                    Enemy forgeOgre2 = new Ogre("ogre");

                    Console.WriteLine("You are faced with two ogres.\n");

                    Battle battle3ogre1 = new Battle();
                    battle3ogre1.Options(warrior, forgeOgre1);

                    Console.WriteLine("Time for the second ogre.\n");

                    Battle battle3ogre2 = new Battle();
                    battle3ogre2.Options(warrior, forgeOgre2);

                    Console.WriteLine("");
                    Console.WriteLine("You see a not so great sandwich on the counter. At least it is something. You take it.");

                    warrior.ItemsList.Add("sandwich");
                }

                while (true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Where would you like to go now?");
                    forge.PrintNeighbors();
                    Console.WriteLine("- See where you have already (visited)");

                    string answer = Console.ReadLine().ToLower();
                    Console.WriteLine("");
                    // if you pick this room, then go to that rooms function
                    if (answer == "courtyard")
                    {
                        Courtyard();
                        break;
                    }
                    else if (answer == "armory")
                    {
                        Armory();
                        break;
                    }
                    else if (answer == "visited")
                    {
                        rooms.PrintVisited();
                    }
                    else
                    {
                        Console.WriteLine("Please type one of the options.");
                    }
                }

            }


            // ARMORY
            void Armory()
            {
                // if you have not visited room, then do battle stuff
                if (!rooms.VisitedRooms.Contains(armory))
                {
                    rooms.Visited(armory);

                    Enemy armoryWarlock1 = new Warlock("warlock");
                    Enemy armoryWarlock2 = new Warlock("warlock");


                    Console.WriteLine("You are faced with two warlock.\n");

                    Battle battle4warlock1 = new Battle();
                    battle4warlock1.Options(warrior, armoryWarlock1);

                    Console.WriteLine("Time for the second warlock.\n");

                    Battle battle4warlock2 = new Battle();
                    battle4warlock2.Options(warrior, armoryWarlock2);

                    Console.WriteLine("");
                    Console.WriteLine("You see a very nice steel sword hanging on the wall. You take it and leave your old rusty sword.");

                    warrior.ItemsList.Add("steal sword");
                    warrior.ItemsList.Remove("rusty sword");
                    warrior.AttackDamage = 20;
                }


                while (true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Where would you like to go now?");
                    armory.PrintNeighbors();
                    Console.WriteLine("- See where you have already (visited)");

                    string answer = Console.ReadLine().ToLower();
                    Console.WriteLine("");
                    // if you pick this room, then go to that rooms function
                    if (answer == "forge")
                    {
                        Forge();
                        break;
                    }
                    else if (answer == "visited")
                    {
                        rooms.PrintVisited();
                    }
                    else
                    {
                        Console.WriteLine("Please type one of the options.");
                    }
                }

            }


            // GREAT HALL
            void GreatHall()
            {
                // if you have not visited room, then do battle stuff
                if (!rooms.VisitedRooms.Contains(greatHall))
                {
                    rooms.Visited(greatHall);

                    Enemy armoryWarlock1 = new Warlock("warlock");
                    Enemy armoryWarlock2 = new Warlock("warlock");


                    Console.WriteLine("You are faced with two warlock.\n");

                    Battle battle5warlock1 = new Battle();
                    battle5warlock1.Options(warrior, armoryWarlock1);

                    Console.WriteLine("Time for the second warlock.\n");

                    Battle battle5warlock2 = new Battle();
                    battle5warlock2.Options(warrior, armoryWarlock2);

                    Console.WriteLine("");
                    Console.WriteLine("There is a mysterious canned soup that has been left on one of the tables.");
                    Console.WriteLine("An ogre must have left it. You take it.");

                    warrior.ItemsList.Add("mysterious canned soup");
                }


                while (true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Where would you like to go now?");
                    greatHall.PrintNeighbors();
                    Console.WriteLine("- See where you have already (visited)");

                    string answer = Console.ReadLine().ToLower();
                    Console.WriteLine("");
                    // if you pick this room, then go to that rooms function
                    if (answer == "courtyard")
                    {
                        Courtyard();
                        break;
                    }
                    else if (answer == "king ronald's bedroom")
                    {
                        if (warrior.ItemsList.Contains("key 1"))
                        {
                            KingBed();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Hmmm.... the door is locked.");
                        }
                    }
                    else if (answer == "kitchen")
                    {
                        Kitchen();
                        break;
                    }
                    else if (answer == "hallway")
                    {
                        Hallway();
                        break;
                    }
                    else if (answer == "visited")
                    {
                        rooms.PrintVisited();
                    }
                    else
                    {
                        Console.WriteLine("Please type one of the options.");
                    }
                }

            }


            // KITCHEN
            void Kitchen()
            {
                // if you have not visited room, then do battle stuff
                if (!rooms.VisitedRooms.Contains(kitchen))
                {
                    rooms.Visited(kitchen);

                    Enemy kitchenOgre = new Ogre("ogre");
                    Enemy kitchenWarlock = new Warlock("warlock");


                    Console.WriteLine("You are faced with one ogre and one warlock. Time for the ogre.\n");

                    Battle battle6ogre = new Battle();
                    battle6ogre.Options(warrior, kitchenOgre);

                    Console.WriteLine("Time for the warlock.\n");

                    Battle battle6warlock = new Battle();
                    battle6warlock.Options(warrior, kitchenWarlock);

                    Console.WriteLine("");
                    Console.WriteLine("There is a not so great smell throughout the kitchen. You follow it to a cupboard that has a piece of cheese.");
                    Console.WriteLine("Gross! But you take it anyway.");

                    warrior.ItemsList.Add("cheese");
                }


                while (true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Where would you like to go now?");
                    kitchen.PrintNeighbors();
                    Console.WriteLine("- See where you have already (visited)");

                    string answer = Console.ReadLine().ToLower();
                    Console.WriteLine("");
                    // if you pick this room, then go to that rooms function
                    if (answer == "pantry")
                    {
                        Pantry();
                        break;
                    }
                    else if (answer == "barn")
                    {
                        Barn();
                        break;
                    }
                    else if (answer == "great hall")
                    {
                        GreatHall();
                        break;
                    }
                    else if (answer == "visited")
                    {
                        rooms.PrintVisited();
                    }
                    else
                    {
                        Console.WriteLine("Please type one of the options.");
                    }
                }

            }


            // PANTRY
            void Pantry()
            {
                // if you have not visited room, then do battle stuff
                if (!rooms.VisitedRooms.Contains(pantry))
                {
                    rooms.Visited(pantry);

                    Console.WriteLine("");
                    Console.WriteLine("No enemies in here... but there is a single carrot. You take it.");

                    warrior.ItemsList.Add("carrot");
                }
               

                while (true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Where would you like to go now?");
                    pantry.PrintNeighbors();
                    Console.WriteLine("- See where you have already (visited)");

                    string answer = Console.ReadLine().ToLower();
                    Console.WriteLine("");
                    // if you pick this room, then go to that rooms function
                    if (answer == "kitchen")
                    {
                        Kitchen();
                        break;
                    }
                    else if (answer == "visited")
                    {
                        rooms.PrintVisited();
                    }
                    else
                    {
                        Console.WriteLine("Please type one of the options.");
                    }
                }

            }


            // BARN
            void Barn()
            {
                // if you have not visited room, then do battle stuff
                if (!rooms.VisitedRooms.Contains(barn))
                {
                    rooms.Visited(barn);

                    Enemy barnOgre1 = new Ogre("ogre");
                    Enemy barnOgre2 = new Ogre("ogre");
                    Enemy barnOgre3 = new Ogre("ogre");


                    Console.WriteLine("You are faced with three ogres.\n");

                    Battle battle7ogre1 = new Battle();
                    battle7ogre1.Options(warrior, barnOgre1);

                    Console.WriteLine("Time for the second ogre.\n");

                    Battle battle7ogre2 = new Battle();
                    battle7ogre1.Options(warrior, barnOgre2);

                    Console.WriteLine("Time for the third ogre.\n");

                    Battle battle7ogre3 = new Battle();
                    battle7ogre1.Options(warrior, barnOgre3);

                    Console.WriteLine("");
                    Console.WriteLine("Seems the ogres and warlocks have made the barn into a butcher shop.");
                    Console.WriteLine("You find a nice cooked lamb chop and take it.");

                    warrior.ItemsList.Add("lamb chop");


                    Console.WriteLine("You walk over to a window and look out at the Royal Gardens.");
                    Console.WriteLine("In the distance there is a tower connected by a flimsy bridge.");
                }


                while (true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Where would you like to go now?");
                    barn.PrintNeighbors();
                    Console.WriteLine("- See where you have already (visited)");

                    string answer = Console.ReadLine().ToLower();
                    Console.WriteLine("");
                    // if you pick this room, then go to that rooms function
                    if (answer == "northwest tower")
                    {
                        TowerNW();
                        break;
                    }
                    else if (answer == "kitchen")
                    {
                        Kitchen();
                        break;
                    }
                    else if (answer == "visited")
                    {
                        rooms.PrintVisited();
                    }
                    else
                    {
                        Console.WriteLine("Please type one of the options.");
                    }
                }

            }


            // HALLWAY
            void Hallway()
            {
                // if you have not visited room, then do battle stuff
                if (!rooms.VisitedRooms.Contains(hallway))
                {
                    rooms.Visited(hallway);

                    Console.WriteLine("Down the long dark hallway are a few doors.");
                    
                }


                while (true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Where would you like to go now?");
                    hallway.PrintNeighbors();
                    Console.WriteLine("- See where you have already (visited)");

                    string answer = Console.ReadLine().ToLower();
                    Console.WriteLine("");
                    // if you pick this room, then go to that rooms function
                    if (answer == "servant quarters")
                    {
                        ServantBed();
                        break;
                    }
                    else if (answer == "guest bedroom")
                    {
                        GuestBed();
                        break;
                    }
                    else if (answer == "princess christina's bedroom")
                    {
                        PrincessBed();
                        break;
                    }
                    else if (answer == "northeast tower")
                    {
                        TowerNE();
                        break;
                    }
                    else if (answer == "great hall")
                    {
                        GreatHall();
                        break;
                    }
                    else if (answer == "visited")
                    {
                        rooms.PrintVisited();
                    }
                    else
                    {
                        Console.WriteLine("Please type one of the options.");
                    }
                }

            }


            // SERVANT BED
            void ServantBed()
            {
                // if you have not visited room, then do battle stuff
                if (!rooms.VisitedRooms.Contains(servantBed))
                {
                    rooms.Visited(servantBed);

                    Console.WriteLine("");
                    Console.WriteLine("You find a key under a pillow on one of the beds. What might this open?");

                    warrior.ItemsList.Add("key 1");

                }


                while (true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Where would you like to go now?");
                    servantBed.PrintNeighbors();
                    Console.WriteLine("- See where you have already (visited)");

                    string answer = Console.ReadLine().ToLower();
                    Console.WriteLine("");
                    // if you pick this room, then go to that rooms function
                    if (answer == "hallway")
                    {
                        Hallway();
                        break;
                    }
                    else if (answer == "visited")
                    {
                        rooms.PrintVisited();
                    }
                    else
                    {
                        Console.WriteLine("Please type one of the options.");
                    }
                }

            }


            // GUEST BED
            void GuestBed()
            {
                // if you have not visited room, then do battle stuff
                if (!rooms.VisitedRooms.Contains(guestBed))
                {
                    rooms.Visited(guestBed);

                    Enemy guestBedOgre1 = new Ogre("ogre");

                    Console.WriteLine("You are faced with three ogres.\n");

                    Battle battle8ogre1 = new Battle();
                    battle8ogre1.Options(warrior, guestBedOgre1);

                    Console.WriteLine("You notice a trapdoor in the corner of the room.");

                }


                while (true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Where would you like to go now?");
                    guestBed.PrintNeighbors();
                    Console.WriteLine("- See where you have already (visited)");

                    string answer = Console.ReadLine().ToLower();
                    Console.WriteLine("");
                    // if you pick this room, then go to that rooms function
                    if (answer == "cell 3")
                    {
                        Cell3();
                        break;
                    }
                    else if (answer == "hallway")
                    {
                        Hallway();
                        break;
                    }
                    else if (answer == "visited")
                    {
                        rooms.PrintVisited();
                    }
                    else
                    {
                        Console.WriteLine("Please type one of the options.");
                    }
                }

            }


            // PRINCESS BED
            void PrincessBed()
            {
                // if you have not visited room, then do battle stuff
                if (!rooms.VisitedRooms.Contains(princessBed))
                {
                    rooms.Visited(princessBed);

                    Console.WriteLine("You look around Princess Cristina's bedroom, but don't find anything.");

                }


                while (true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Where would you like to go now?");
                    princessBed.PrintNeighbors();
                    Console.WriteLine("- See where you have already (visited)");

                    string answer = Console.ReadLine().ToLower();
                    Console.WriteLine("");
                    // if you pick this room, then go to that rooms function
                    if (answer == "hallway")
                    {
                        Hallway();
                        break;
                    }
                    else if (answer == "visited")
                    {
                        rooms.PrintVisited();
                    }
                    else
                    {
                        Console.WriteLine("Please type one of the options.");
                    }
                }

            }


            // KING BED
            void KingBed()
            {
                // if you have not visited room, then do battle stuff
                if (!rooms.VisitedRooms.Contains(kingBed))
                {
                    rooms.Visited(kingBed);

                    Console.WriteLine("You look around the King's bedroom, but don't find anything except a door.");

                }


                while (true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Where would you like to go now?");
                    kingBed.PrintNeighbors();
                    Console.WriteLine("- See where you have already (visited)");

                    string answer = Console.ReadLine().ToLower();
                    Console.WriteLine("");
                    // if you pick this room, then go to that rooms function
                    if (answer == "royal gardens")
                    {
                        if (warrior.ItemsList.Contains("key 3"))
                        {
                            RoyalGardens();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Hmmm.... the door is locked.");
                        }
                    }
                    else if (answer == "great hall")
                    {
                        GreatHall();
                        break;
                    }
                    else if (answer == "visited")
                    {
                        rooms.PrintVisited();
                    }
                    else
                    {
                        Console.WriteLine("Please type one of the options.");
                    }
                }

            }


            // NW TOWER
            void TowerNW()
            {
                // if you have not visited room, then do battle stuff
                if (!rooms.VisitedRooms.Contains(towerNW))
                {
                    rooms.Visited(towerNW);

                    Console.WriteLine("");
                    Console.WriteLine("There is a key on the floor. You take it. What might this open?");

                    warrior.ItemsList.Add("key 2");
                }


                while (true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Where would you like to go now?");
                    towerNW.PrintNeighbors();
                    Console.WriteLine("- See where you have already (visited)");

                    string answer = Console.ReadLine().ToLower();
                    Console.WriteLine("");
                    // if you pick this room, then go to that rooms function
                    if (answer == "southwest tower")
                    {
                        TowerSW();
                        break;
                    }
                    else if (answer == "barn")
                    {
                        Barn();
                        break;
                    }
                    else if (answer == "visited")
                    {
                        rooms.PrintVisited();
                    }
                    else
                    {
                        Console.WriteLine("Please type one of the options.");
                    }
                }

            }


            // NE TOWER
            void TowerNE()
            {
                // if you have not visited room, then do battle stuff
                if (!rooms.VisitedRooms.Contains(towerNE))
                {
                    rooms.Visited(towerNE);

                    Console.WriteLine("There is nothing in here, but there is a nice view of the royal gardens.");

                }


                while (true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Where would you like to go now?");
                    towerNE.PrintNeighbors();
                    Console.WriteLine("- See where you have already (visited)");

                    string answer = Console.ReadLine().ToLower();
                    Console.WriteLine("");
                    // if you pick this room, then go to that rooms function
                    if (answer == "southeast tower")
                    {
                        TowerSE();
                        break;
                    }
                    else if (answer == "hallway")
                    {
                        Hallway();
                        break;
                    }
                    else if (answer == "visited")
                    {
                        rooms.PrintVisited();
                    }
                    else
                    {
                        Console.WriteLine("Please type one of the options.");
                    }
                }

            }


            // SW TOWER
            void TowerSW()
            {
                // if you have not visited room, then do battle stuff
                if (!rooms.VisitedRooms.Contains(towerSW))
                {
                    rooms.Visited(towerSW);

                    Enemy towerSWogre = new Ogre("ogre");

                    Console.WriteLine("You are faced with one ogre.\n");

                    Battle battle9ogre = new Battle();
                    battle9ogre.Options(warrior, towerSWogre);

                    Console.WriteLine("There is nothing here, but there is a nice view of the kingdom.");

                }


                while (true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Where would you like to go now?");
                    towerSW.PrintNeighbors();
                    Console.WriteLine("- See where you have already (visited)");

                    string answer = Console.ReadLine().ToLower();
                    Console.WriteLine("");
                    // if you pick this room, then go to that rooms function
                    if (answer == "guard tower")
                    {
                        GuardTower();
                        break;
                    }
                    else if (answer == "northwest tower")
                    {
                        TowerNW();
                        break;
                    }
                    else if (answer == "visited")
                    {
                        rooms.PrintVisited();
                    }
                    else
                    {
                        Console.WriteLine("Please type one of the options.");
                    }
                }

            }


            // SE TOWER
            void TowerSE()
            {
                // if you have not visited room, then do battle stuff
                if (!rooms.VisitedRooms.Contains(towerSE))
                {
                    rooms.Visited(towerSE);

                    Enemy towerSEogre1 = new Ogre("ogre");
                    Enemy towerSEogre2 = new Ogre("ogre");
                    Enemy towerSEwarlock = new Warlock("warlock");

                    Console.WriteLine("You are faced with two ogres and one warlock.\n");

                    Battle battle10ogre1 = new Battle();
                    battle10ogre1.Options(warrior, towerSEogre1);

                    Console.WriteLine("Time for the second ogre.\n");

                    Battle battle10ogre2 = new Battle();
                    battle10ogre2.Options(warrior, towerSEogre2);

                    Console.WriteLine("Time for the warlock.\n");

                    Battle battle10warlock = new Battle();
                    battle10warlock.Options(warrior, towerSEwarlock);

                    Console.WriteLine("You notice a trapdoor on the floor.");

                }


                while (true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Where would you like to go now?");
                    towerSE.PrintNeighbors();
                    Console.WriteLine("- See where you have already (visited)");

                    string answer = Console.ReadLine().ToLower();
                    Console.WriteLine("");
                    // if you pick this room, then go to that rooms function
                    if (answer == "dungeon")
                    {
                        Dungeon();
                        break;
                    }
                    else if (answer == "northeast tower")
                    {
                        TowerNE();
                        break;
                    }
                    else if (answer == "guard tower")
                    {
                        GuardTower();
                        break;
                    }
                    else if (answer == "visited")
                    {
                        rooms.PrintVisited();
                    }
                    else
                    {
                        Console.WriteLine("Please type one of the options.");
                    }
                }

            }


            // GUARD TOWER
            void GuardTower()
            {
                // if you have not visited room, then do battle stuff
                if (!rooms.VisitedRooms.Contains(guardTower))
                {
                    rooms.Visited(guardTower);

                    Enemy guardtowerOgre1 = new Ogre("ogre");
                    Enemy guardtowerOgre2 = new Ogre("ogre");

                    Console.WriteLine("You are faced with two ogres.\n");

                    Battle battle11ogre1 = new Battle();
                    battle11ogre1.Options(warrior, guardtowerOgre1);

                    Console.WriteLine("Time for the second ogre.\n");

                    Battle battle11ogre2 = new Battle();
                    battle11ogre2.Options(warrior, guardtowerOgre2);

                    Console.WriteLine("You look around the guard tower, but don't find anything.");

                }


                while (true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Where would you like to go now?");
                    guardTower.PrintNeighbors();
                    Console.WriteLine("- See where you have already (visited)");

                    string answer = Console.ReadLine().ToLower();
                    Console.WriteLine("");
                    // if you pick this room, then go to that rooms function
                    if (answer == "southwest tower")
                    {
                        TowerSW();
                        break;
                    }
                    else if (answer == "southeast tower")
                    {
                        TowerSE();
                        break;
                    }
                    else if (answer == "visited")
                    {
                        rooms.PrintVisited();
                    }
                    else
                    {
                        Console.WriteLine("Please type one of the options.");
                    }
                }

            }


            // DUNGEON
            void Dungeon()
            {
                // if you have not visited room, then do battle stuff
                if (!rooms.VisitedRooms.Contains(dungeon))
                {
                    rooms.Visited(dungeon);

                    Console.WriteLine("");
                    Console.WriteLine("You look around and find some skeletons still shackled to the walls.");
                    Console.WriteLine("On the floor on a plate there is a slice of moldy bread. You reluctanty take it.");

                    warrior.ItemsList.Add("moldy bread");
                }


                while (true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Where would you like to go now?");
                    dungeon.PrintNeighbors();
                    Console.WriteLine("- See where you have already (visited)");

                    string answer = Console.ReadLine().ToLower();
                    Console.WriteLine("");
                    // if you pick this room, then go to that rooms function
                    if (answer == "torture chamber")
                    {
                        TortureChamber();
                        break;
                    }
                    else if (answer == "cell 1")
                    {
                        if (warrior.ItemsList.Contains("key 2"))
                        {
                            Cell1();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Hmmm.... the door is locked.");
                        }
                    }
                    else if (answer == "southeast tower")
                    {
                        TowerSE();
                        break;
                    }
                    else if (answer == "visited")
                    {
                        rooms.PrintVisited();
                    }
                    else
                    {
                        Console.WriteLine("Please type one of the options.");
                    }
                }

            }


            // CELL 1
            void Cell1()
            {
                // if you have not visited room, then do battle stuff
                if (!rooms.VisitedRooms.Contains(cell1))
                {
                    rooms.Visited(cell1);

                    Enemy cell1Warlock1 = new Warlock("warlock");
                    Enemy cell1Warlock2 = new Warlock("warlock");

                    Console.WriteLine("You are faced with two warlock.\n");

                    Battle battle12warlock1 = new Battle();
                    battle12warlock1.Options(warrior, cell1Warlock1);

                    Console.WriteLine("Time for the second warlock.\n");

                    Battle battle12warlock2 = new Battle();
                    battle12warlock2.Options(warrior, cell1Warlock2);

                    Console.WriteLine("");
                    Console.WriteLine("In the corner of the cell you notice a key. What might this open?");

                    warrior.ItemsList.Add("key 3");
                }


                while (true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Where would you like to go now?");
                    cell1.PrintNeighbors();
                    Console.WriteLine("- See where you have already (visited)");

                    string answer = Console.ReadLine().ToLower();
                    Console.WriteLine("");
                    // if you pick this room, then go to that rooms function
                    if (answer == "dungeon")
                    {
                        Dungeon();
                        break;
                    }
                    else if (answer == "visited")
                    {
                        rooms.PrintVisited();
                    }
                    else
                    {
                        Console.WriteLine("Please type one of the options.");
                    }
                }

            }


            // CELL 3
            void Cell3()
            {
                // if you have not visited room, then do battle stuff
                if (!rooms.VisitedRooms.Contains(cell3))
                {
                    rooms.Visited(cell3);

                    Console.WriteLine("The door to the cell is locked, but you can hear someone screaming from the torture chamber.");
                }


                while (true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Where would you like to go now?");
                    cell3.PrintNeighbors();
                    Console.WriteLine("- See where you have already (visited)");

                    string answer = Console.ReadLine().ToLower();
                    Console.WriteLine("");
                    // if you pick this room, then go to that rooms function
                    if (answer == "guest bedroom")
                    {
                        GuestBed();
                        break;
                    }
                    else if (answer == "visited")
                    {
                        rooms.PrintVisited();
                    }
                    else
                    {
                        Console.WriteLine("Please type one of the options.");
                    }
                }

            }


            // TORTURE CHAMBER
            void TortureChamber()
            {
                // if you have not visited room, then do battle stuff
                if (!rooms.VisitedRooms.Contains(tortureChamber))
                {
                    rooms.Visited(tortureChamber);

                    Enemy tcOgre1 = new Ogre("ogre");
                    Enemy tcOgre2 = new Ogre("ogre");
                    Enemy tcOgre3 = new Ogre("ogre");

                    Console.WriteLine("In the chamber, three ogres are torturing a knight from the kingdom. They come at you.\n");

                    Battle battle13ogre1 = new Battle();
                    battle13ogre1.Options(warrior, tcOgre1);

                    Console.WriteLine("Time for the second ogre.\n");

                    Battle battle13ogre2 = new Battle();
                    battle13ogre2.Options(warrior, tcOgre2);

                    Console.WriteLine("Time for the third ogre.\n");

                    Battle battle13ogre3 = new Battle();
                    battle13ogre3.Options(warrior, tcOgre3);

                    Console.WriteLine("'Phew! Thank you for saving me.' said the knight. I owe you my life.");
                    Console.WriteLine("Princess Cristina is being held in the Wizard's Tower. Please go save her!'");
                }


                while (true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Where would you like to go now?");
                    tortureChamber.PrintNeighbors();
                    Console.WriteLine("- See where you have already (visited)");

                    string answer = Console.ReadLine().ToLower();
                    Console.WriteLine("");
                    // if you pick this room, then go to that rooms function
                    if (answer == "dungeon")
                    {
                        Dungeon();
                        break;
                    }
                    else if (answer == "visited")
                    {
                        rooms.PrintVisited();
                    }
                    else
                    {
                        Console.WriteLine("Please type one of the options.");
                    }
                }

            }


            // ROYAL GARDENS
            void RoyalGardens()
            {
                // if you have not visited room, then do battle stuff
                if (!rooms.VisitedRooms.Contains(royalGardens))
                {
                    rooms.Visited(royalGardens);

                    Enemy rgOgre1 = new Ogre("ogre");
                    Enemy rgOgre2 = new Ogre("ogre");
                    Enemy rgOgre3 = new Ogre("ogre");

                    Console.WriteLine("You are faced with three ogres.\n");

                    Battle battle14ogre1 = new Battle();
                    battle14ogre1.Options(warrior, rgOgre1);

                    Console.WriteLine("Time for the second ogre.\n");

                    Battle battle14ogre2 = new Battle();
                    battle14ogre2.Options(warrior, rgOgre2);

                    Console.WriteLine("Time for the third ogre.\n");

                    Battle battle14ogre3 = new Battle();
                    battle14ogre3.Options(warrior, rgOgre3);

                    Console.WriteLine("You now can easily get to the Wizard's Tower.");

                }


                while (true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Where would you like to go now?");
                    royalGardens.PrintNeighbors();
                    Console.WriteLine("- See where you have already (visited)");

                    string answer = Console.ReadLine().ToLower();
                    Console.WriteLine("");
                    // if you pick this room, then go to that rooms function
                    if (answer == "wizard's tower")
                    {
                        WizardTower();
                        break;
                    }
                    else if (answer == "king ronald's bedroom")
                    {
                        KingBed();
                        break;
                    }
                    else if (answer == "visited")
                    {
                        rooms.PrintVisited();
                    }
                    else
                    {
                        Console.WriteLine("Please type one of the options.");
                    }
                }

            }


            // WIZARD TOWER
            void WizardTower()
            {
                // if you have not visited room, then do battle stuff
                if (!rooms.VisitedRooms.Contains(wizardTower))
                {
                    rooms.Visited(wizardTower);

                    Enemy OPWarlock = new Warlock("Powerful Warlock");

                    OPWarlock.Health = 80;
                    OPWarlock.Damage = 30;

                    Console.WriteLine("You make your way into the Wizard's Tower and up the long winding stairs.");
                    Console.WriteLine("At the top, you find Princess Christina tied up.");
                    Console.WriteLine("Right as you are about to free her, a more powerful warlock approaches.\n");
                    
                    Battle battle15warlock = new Battle();
                    battle15warlock.Options(warrior, OPWarlock);
                    

                }

                Console.WriteLine("You untie Princess Christina.");
                Console.WriteLine("Now that all the enemies are defeated, the kingdom is safe.");
                Console.WriteLine("The End");

            }



            





        }
    }
}