using System;
using ClientMusic.Transfers;

namespace ClientMusic.Commands
{
    class Add : ICommandBehavior
    {
        string author;
        string name;
        string reference;

        string defaultValue = "default";

        string errorInfo;

        public string DoCommand(Transfer transfer)
        {
            GetAuthor();

            if (GetName())
            {
                GetRef();

                Song song = new Song(author, name, reference);

                string transferData = TransferData.ConvertToXML(new TransferData(song, new Command("add")));

                return transfer.PostRequest(transferData).TrimEnd('\0');
            }

            return "Incorrect data";
        }

        private void GetAuthor()
        {
            Console.WriteLine("Input author's name:");
            if ((author = Console.ReadLine()) == string.Empty)
            {
                author = defaultValue;
            }
        }

        private bool GetName()
        {
            Console.WriteLine("Input the composition's name:");
            if ((name = Console.ReadLine()) == string.Empty)
            {
                errorInfo = "You enter empty name of song!";
                ShowError();

                return false;
            }

            return true;
        }

        private void GetRef()
        {
            Console.WriteLine("Input the reference:");
            if ((reference = Console.ReadLine()) == string.Empty)
            {
                reference = defaultValue;
            }
        }

        private void ShowError()
        {
            Console.WriteLine(errorInfo);
        }
    }
}
