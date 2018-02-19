using System;
using System.Collections.Generic;

namespace AlternativeLabaCS1.Commands
{
    class Del : ICommandBehavior
    {

        //Удаление песни из плей-листа
        public List<Song> DoSomeCommand(List<Song> songs)
        {
            Console.WriteLine("Input the full name of the track to remove:");
            string query = Console.ReadLine();

            if (songs.RemoveAll(n => (n.Author + " - " + n.Name) == query) > 0)
            {
                Console.WriteLine("Track \"{0}\" deleted", query);
            }
            else
            {
                Console.WriteLine("The collection doesn't contain this {0}", query);
            }

            return songs;
        }
    }
}
