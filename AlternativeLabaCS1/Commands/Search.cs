using System;
using System.Collections.Generic;

namespace AlternativeLabaCS1.Commands
{
    class Search : ICommandBehavior
    {
        //Поиск песни в плей-листе
        public List<Song> DoSomeCommand(List<Song> songs)
        {
            Console.WriteLine("Input the part of the name to find composition in the catalog:");
            string query = Console.ReadLine();

            List<Song> queryList = songs.FindAll(n => n.Author.Contains(query) || n.Name.Contains(query));

            ShowAllList showAllList = new ShowAllList();
            showAllList.DoSomeCommand(queryList);

            return songs;
        }
    }
}
