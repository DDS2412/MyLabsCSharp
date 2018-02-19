using System.Collections.Generic;
using ServerMusic.Transfers;

namespace ServerMusic.Commands
{
    interface ICommandBehavior
    {
        List<Song> DoCommand(List<Song> songs, TransferData transferData ,Transfer transfer);
    }
}
