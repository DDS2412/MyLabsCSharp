using System.Collections.Generic;

namespace AlternativeLabaCS1.Commands
{
    class Command
    {
        private ICommandBehavior commandBehavior;

        private Dictionary<string, ICommandBehavior> commandDict;
        public Dictionary<string, ICommandBehavior> CommandDict
        {
            get { return commandDict; }
        }

        //Выбор команды из словаря команд
        public List<Song> PerformDoSomeCommand(List<Song> songs, string command, ref bool exit)
        {
            commandBehavior = commandDict[command];
            if(commandBehavior is Quit)
            {
                exit = true;
            }
            return commandBehavior.DoSomeCommand(songs);
        }

        public Command()
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
                {"del", new Del() }
                
            };
        }
    }
}
