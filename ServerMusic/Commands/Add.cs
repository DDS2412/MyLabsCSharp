using System;
using System.Collections.Generic;
using ServerMusic.Transfers;

namespace ServerMusic.Commands
{
    class Add : ICommandBehavior
    {

        public List<Song> DoCommand(List<Song> songs, TransferData transferData, Transfer transfer)
        {
            transfer.SendBackMessage("Success!");
            songs.Add(transferData.Song);
            return songs;
        }
    }
}
