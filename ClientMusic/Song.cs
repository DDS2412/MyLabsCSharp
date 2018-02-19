namespace ClientMusic
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
    }
}
