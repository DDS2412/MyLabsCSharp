using System;
using System.Collections.Generic;
using ServerMusic.Transfers;

namespace ServerMusic.Commands
{
    class ShowAllList : ICommandBehavior
    {
        public List<Song> DoCommand(List<Song> songs)
        {
            Console.WriteLine("All compositions in catalog");
            foreach (var composition in songs)
            {
                Console.WriteLine("{0} - {1}", composition.Author, composition.Name);
            }
            return songs;
        }

        public string DoCommand(Transfer transfer)
        {
            throw new NotImplementedException();
        }

        public List<Song> DoCommand(List<Song> songs, TransferData transferData, Transfer transfer)
        {
            throw new NotImplementedException();
        }
    }
}
