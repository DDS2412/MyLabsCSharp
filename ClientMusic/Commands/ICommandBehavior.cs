using ClientMusic.Transfers;

namespace ClientMusic.Commands
{
    interface ICommandBehavior
    {
        string DoCommand(Transfer transfer);
    }
}
