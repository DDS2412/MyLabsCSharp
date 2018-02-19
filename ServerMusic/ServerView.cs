using System.Collections.Generic;
using ServerMusic.Commands;
using ServerMusic.Transfers;

namespace ServerMusic
{
    class ServerView
    {
        private List<Song> songs;

        public ServerView()
        {
            songs = new List<Song>();
        }

        public void PerformCommand(TransferData transferData, Transfer transfer)
        {
            CommandHandler commandObject = new CommandHandler();
            songs = commandObject.PerformDoSomeCommand(songs, transferData, transfer);  
        }
    }
}
