using System;
using System.Collections.Generic;

namespace AlternativeLabaCS1.Commands
{
    class Add : ICommandBehavior
    {
        string author;
        string name;
        string reference;

        string defaultValue = "default";

        string errorInfo;

        //Добавляет новую песню в плей-лист
        public List<Song> DoSomeCommand(List<Song> songs)
        {
            GetAuthor();

            if (GetName())
            {
                GetRef();

                Song composition = new Song(author, name, reference);
                songs.Add(composition);   
            }
            return songs;
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
            if((name = Console.ReadLine()) == string.Empty)
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
            if((reference = Console.ReadLine()) == string.Empty)
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
