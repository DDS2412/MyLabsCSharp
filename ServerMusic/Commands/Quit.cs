using System.Collections.Generic;
using ServerMusic.Transfers;

namespace ServerMusic.Commands
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

        public List<Song> DoCommand(List<Song> songs, TransferData transferData, Transfer transfer)
        {
            throw new System.NotImplementedException();
        }
    }
}
