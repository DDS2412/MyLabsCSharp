using System;
using System.Collections.Generic;
using ServerMusic.Transfers;

namespace ServerMusic.Commands
{
    class Del : ICommandBehavior
    {
        public List<Song> DoCommand(List<Song> songs)
        {
            Console.WriteLine("Input the full name of the track to remove:");
            string query = Console.ReadLine();

            if (songs.RemoveAll(n => (n.Author + " - " + n.Name).Contains(query)) > 0)
            {
                Console.WriteLine("Track \"{0}\" deleted", query);
            }
            else
            {
                Console.WriteLine("The collection doesn't contain this {0}", query);
            }

            return songs;
        }

        public List<Song> DoCommand(List<Song> songs, TransferData transferData, Transfer transfer)
        {
            throw new NotImplementedException();
        }
    }
}
