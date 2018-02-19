using System.IO;
using System;
using System.Text;
using System.Xml.Serialization;

namespace ServerMusic
{
    public class Song
    {
        public string Author;

        public string Name;

        public string Reference;

        public int Length;

        public Song(string author, string name, string reference, int length = -1)
        {
            Author = author;
            Name = name;
            Reference = reference;
            Length = -1;
        }

        public Song() { }

        public override string ToString()
        {
            return $"{Author} - {Name}";
        }

        public static string ConvertToXML(Song song)
        {
            XmlSerializer songSerializer = new XmlSerializer(typeof(Song));

            using(var stream = new MemoryStream())
            {
                songSerializer.Serialize(stream, song);
                return Encoding.UTF8.GetString(stream.GetBuffer());
            }
        }

        public static Song ConvertToSong(Byte[] receiveBytes)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Song));

            using(var stream = new MemoryStream())
            {
                stream.Write(receiveBytes, 0, receiveBytes.Length);
                stream.Position = 0;

                return (Song)formatter.Deserialize(stream);
            }
        }
    }
}
