using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using ServerMusic.Transfers;

namespace ServerMusic.Commands
{
    class Load : ICommandBehavior
    {
        private string songReference;
        private string songAuthor;
        private string songName;
        private string songLength;

        public List<Song> DoCommand(List<Song> songs)
        {
            Console.WriteLine("Selected file");

            string[] filesname = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.pls");
            
            return СhooseFile(songs, filesname);
        }

        private List<Song> СhooseFile(List<Song> songs, string[] filesname)
        {
            int numberSelectedFile;
            ShowFiles(filesname);
            Console.WriteLine("Enter the number of the selected directory");

            string queryString = Console.ReadLine();

            if (Int32.TryParse(queryString, out numberSelectedFile)
                && numberSelectedFile < filesname.Length)
            {
                songs = LoadFile(filesname, numberSelectedFile);
            }
            else
            {
                Console.WriteLine("It was entered incorrect value");
            }

            return songs;
        }

        private List<Song> LoadFile(string[] filesname, int numberSelectedFile)
        {
            List<Song> songs = new List<Song>();

            using (StreamReader reader = new StreamReader(filesname[numberSelectedFile]))
            {
                int countOfEntries;
                string line = reader.ReadLine();
                string numberOfEntries = reader.ReadLine().Replace("NumberOfEntries=", "");
                
                if (line == "[playlist]" && Int32.TryParse(numberOfEntries, out countOfEntries))
                {
                    for (int i = 0; i < countOfEntries;)
                    {
                        line = reader.ReadLine();

                        while (IsField(line))
                        {
                            GetFields(line);

                            line = reader.ReadLine();
                        }

                        if (songAuthor != null || songName != null || songReference != null)
                        {
                            songs.Add(new Song(songAuthor, songName, songReference));
                            FreeField();
                            i++;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("It was entered incorrect value");
                }
            }

            return songs;
        }
        
        private void GetFields(string line)
        {
            string[] lines = line.Split('=');

            if (lines[0] != string.Empty)
            {
                try
                {
                    lines[0] = new string(lines[0].ToCharArray().Where(n => !char.IsDigit(n)).ToArray());
                    FillFild(lines[0], lines[1]);           
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void FreeField()
        {
            songAuthor = null;
            songReference = null;
            songLength = null;
            songName = null;
        }

        private void FillFild(string stringFild, string valueField)
        {
            switch (stringFild)
            {
                case "File":
                    {
                        songReference = valueField;
                        break;
                    }
                case "Title":
                    {
                        var splittedValueField = valueField.Split('-');
                        songName = splittedValueField[0];
                        songAuthor = splittedValueField[1];
                        break;
                    }
                case "Length":
                    {
                        songLength = valueField;
                        break;
                    }
            }
        }

        private bool IsField(string line)
        {
            bool isField = false;

            if (line != null &&
                (line.Contains("File") || line.Contains("Title") || line.Contains("Length")))
            {
                isField = true;
            }
            return isField;
        }

        private void ShowFiles(string[] files)
        {
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i, files[i]);
            }
        }

        public string DoCommand(Transfer transfer)
        {
            throw new NotImplementedException();
        }

        public List<Song> DoCommand(List<Song> songs, TransferData transferData, Transfer transfer)
        {
            throw new NotImplementedException();
        }
    }
}