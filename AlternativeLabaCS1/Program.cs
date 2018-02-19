using System;
using System.Linq;
using System.Collections.Generic;
using AlternativeLabaCS1.Commands;

namespace AlternativeLabaCS1
{
    class Program
    {
        static void Main(string[] args)
        {
            GetInformation();

            StartWork();
        }

        static void StartWork()
        {
            List<Song> songs = new List<Song>();
            Command commandObject = new Command();

            bool exit = false;
            do
            {
                Console.WriteLine("Input the command:");
                string command = Console.ReadLine().ToLower();

                if (commandObject.CommandDict.Keys.Contains(command))
                {
                    songs = commandObject.PerformDoSomeCommand(songs, command, ref exit);
                }
                else
                {
                    Console.WriteLine("It was entered incorrect value");
                }

                Console.WriteLine("----");
            } while (!exit);
        }

        static void GetInformation()
        {
            Console.WriteLine("Usage:\n" +
                "\tType one of commnands:\n" +
                " \t\t\"list\" to display all items of catalog\n" +
                "\t\t\"search\" to go find items in catalog\n" +
                "\t\t\"add\" to add new item\n" +
                "\t\t\"del\" to remove some item from list\n" +
                "\t\t\"quit\" to exit");
        }
    }
}
