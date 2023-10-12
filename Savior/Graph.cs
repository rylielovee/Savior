using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Savior
{
    internal class Graph
    {
        // list of rooms
        private List<Room> rooms;
        public List<Room> Rooms { get { return rooms; } set { rooms = value; } }

        // list of visited rooms
        private List<Room> visitedRooms;
        public List<Room> VisitedRooms { get { return visitedRooms; } set { visitedRooms = value; } }


        // constructor
        public Graph()
        {
            rooms = new List<Room>();
            VisitedRooms = new List<Room>();
        }

        // adding a room to rooms list with loot
        public Room AddRooms(string roomName, string roomLoot)
        {
            Room newRoom = new Room(roomName, roomLoot);
            rooms.Add(new Room(roomName, roomLoot));
            return newRoom;
        }

        // adding a room to rooms list with NO loot
        public Room AddRooms(string roomName)
        {
            Room newRoom = new Room(roomName);
            rooms.Add(new Room(roomName));
            return newRoom;
        }

        // Connect room and neighbor together
        public void Connect(Room a_original, params Room[] a_neighbors)
        {
            foreach (Room neighbor in a_neighbors)
            {
                a_original.Neighbors.Add(neighbor);
            }
        }

        // Put the currentRoom into VisitedRooms list
        public void Visited(Room currentRoom) 
        {
            // if currentRoom is not in VisitedRooms list, add it, and for every room in the list, print the room
            if (!VisitedRooms.Contains(currentRoom))
            {
                VisitedRooms.Add(currentRoom);
                Console.WriteLine("------------------------------");
                Console.WriteLine("You are at the " + currentRoom);
                Console.WriteLine("------------------------------\n");

            }
        }

        // print out the rooms your have visited already
        public void PrintVisited()
        {
            Console.WriteLine("Visited Rooms:");
            foreach (Room room in VisitedRooms)
                {
                    Console.WriteLine("- " + room);
                }
                Console.WriteLine("");
            
        }

        



        /*
        // Traverses though the visitedRooms                HUH?
        public void Traverse(Room currentRoom)
        {
            // for every neighboring room in the list of neighbors of currentRoom
            foreach (Room neighbor in currentRoom.neighbors)
            {
                // if VisitedRooms list contains the neighbor, Traverse the neighbor
                if (VisitedRooms.Contains(neighbor))
                {
                    Console.WriteLine(neighbor);
                    Traverse(neighbor);
                }
                
            }

        }
        */

    }
}
