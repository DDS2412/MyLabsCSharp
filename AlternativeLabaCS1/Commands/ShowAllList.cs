using System;
using System.Collections.Generic;

namespace AlternativeLabaCS1.Commands
{
    class ShowAllList : ICommandBehavior
    {
        //Вывод всего плей-листа
        public List<Song> DoSomeCommand(List<Song> songs)
        {
            Console.WriteLine("All compositions in catalog");
            foreach (var composition in songs)
            {
                Console.WriteLine("{0} - {1}", composition.Author, composition.Name);
            }
            return songs;
        }
    }
}
