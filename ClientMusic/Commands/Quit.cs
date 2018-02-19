using System.Collections.Generic;
using ClientMusic.Transfers;

namespace ClientMusic.Commands
{
    class Quit : ICommandBehavior
    {
        public List<Song> DoCommand(List<Song> songs)
        {
            return songs;
        }

        public string DoCommand(Transfer transfer)
        {
            throw new System.NotImplementedException();
        }
    }
}
