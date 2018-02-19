using System.Collections.Generic;
using System.Linq;
using ServerMusic.Transfers;

namespace ServerMusic.Commands
{
    class CommandHandler
    {
        private ICommandBehavior commandBehavior;

        private Dictionary<string, ICommandBehavior> commandDict;
        public Dictionary<string, ICommandBehavior> CommandDict
        {
            get { return commandDict; }
        }

        public List<Song> PerformDoSomeCommand(List<Song> songs, TransferData transferData, Transfer transfer)
        {
            commandBehavior = commandDict[transferData.Command.Name];
            
            return commandBehavior.DoCommand(songs, transferData, transfer);
        }

        public CommandHandler()
        {
            commandDict = GetDictionary();
        }

        private Dictionary<string, ICommandBehavior> GetDictionary()
        {
            return new Dictionary<string, ICommandBehavior>
            {
                {"list", new ShowAllList() },
                {"search", new Search() },
                {"add", new Add() },
                {"quit", new Quit() },
                {"del", new Del() },
                {"save", new Save() },
                {"load", new Load() },
                
            };
        }

        public bool IsCommandContain(string command)
        {
            return CommandDict.Keys.Contains(command);
        }
    }
}
