namespace AlternativeLabaCS1
{
    class Song
    {       
        private string author;
        public string Author
        {
            get
            {
                return author;
            }
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }

        }
        private string reference;
        public string Reference
        {
            get
            {
                return reference;
            }
        }

        private int length;
        public int Length
        {
            get
            {
                return length;
            }
        }

        public Song(string author, string name, string reference)
        {
            this.author = author;
            this.name = name;
            this.reference = reference;
            length = -1;
        }
    }
}
