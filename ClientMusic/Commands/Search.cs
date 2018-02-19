using System;
using System.Collections.Generic;
using ClientMusic.Transfers;

namespace ClientMusic.Commands
{
    class Search : ICommandBehavior
    {
        public List<Song> DoCommand(List<Song> songs)
        {
            Console.WriteLine("Input the part of the name to find composition in the catalog:");
            string query = Console.ReadLine();

            List<Song> queryList = songs.FindAll(n => n.Author.Contains(query) || n.Name.Contains(query));

            ShowAllList showAllList = new ShowAllList();
            showAllList.DoCommand(queryList);
            var s = new Search();

            return songs;
        }

        public string DoCommand(Transfer transfer)
        {
            throw new NotImplementedException();
        }
    }
}
