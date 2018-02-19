using System;
using System.Collections.Generic;
using ClientMusic.Transfers;

namespace ClientMusic.Commands
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
    }
}
