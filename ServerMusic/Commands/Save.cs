using System;
using System.IO;
using System.Collections.Generic;
using ServerMusic.Transfers;

namespace ServerMusic.Commands
{
    class Save : ICommandBehavior
    {
        public List<Song> DoCommand(List<Song> songs)
        {
            Console.WriteLine("Enter the name of the file");
            string fileName = Console.ReadLine();
            if (!fileName.Contains("/")
                && !fileName.Contains("\\")
                && fileName.Contains(".pls"))
            {
                try
                {
                    FileStream file = new FileStream(fileName, FileMode.Create);

                    using (StreamWriter writer = new StreamWriter(file))
                    {
                        writer.WriteLine("[playlist]\nNumberOfEntries={0}", songs.Count);

                        foreach (var song in songs)
                        {
                            writer.WriteLine("File1={0}", song.Reference);
                            writer.WriteLine("Title1={0}-{1}", song.Author, song.Name);
                            writer.WriteLine("Length={0}\n", song.Length);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("It was entered incorrect value");
            }
            return songs;
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
