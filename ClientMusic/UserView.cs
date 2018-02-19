using System;
using ClientMusic.Commands;
using ClientMusic.Transfers;

namespace ClientMusic
{
    static class UserView
    {
        public static void RunClient(Transfer transfer)
        {
            GetInformation();

            CommandHandler commandObject = new CommandHandler();

            bool exit = false;
            do
            {
                Console.WriteLine("Input the command:");
                string command = Console.ReadLine().ToLower();

                if (commandObject.IsCommandContain(command))
                {
                    Console.WriteLine(commandObject.PerformDoSomeCommand(command, ref exit, transfer));
                }
                else
                {
                    Console.WriteLine("It was entered incorrect value");
                }

                Console.WriteLine("----");
            } while (!exit);
        }

        private static void GetInformation()
        {
            Console.WriteLine("Usage:\n" +
                    "\tType one of commnands:\n" +
                    " \t\t\"list\" to display all items of catalog\n" +
                    "\t\t\"search\" to go find items in catalog\n" +
                    "\t\t\"add\" to add new item\n" +
                    "\t\t\"del\" to remove some item from list\n" +
                    "\t\t\"quit\" to exit\n" +
                    "\t\t\"save\" to save to the pls-file\n" +
                    "\t\t\"load\" to load the file");
        }
    }
}
