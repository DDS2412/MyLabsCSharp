using System.Collections.Generic;

namespace AlternativeLabaCS1.Commands
{
    class Quit : ICommandBehavior
    {
        //Завершение работы 
        public List<Song> DoSomeCommand(List<Song> songs)
        {
            return songs;
        }
    }
}
