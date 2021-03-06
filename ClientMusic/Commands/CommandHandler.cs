﻿using System.Collections.Generic;
using System.Linq;
using ClientMusic.Transfers;

namespace ClientMusic.Commands
{
    class CommandHandler
    {
        private ICommandBehavior commandBehavior;

        private Dictionary<string, ICommandBehavior> commandDict;
        public Dictionary<string, ICommandBehavior> CommandDict
        {
            get { return new Dictionary<string, ICommandBehavior>(commandDict); }
        }

        public string PerformDoSomeCommand(string command, ref bool exit, Transfer transfer)
        {
            commandBehavior = commandDict[command];
            if (commandBehavior is Quit)
            {
                exit = true;
            }

            return commandBehavior.DoCommand(transfer);
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
