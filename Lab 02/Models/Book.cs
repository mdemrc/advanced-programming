namespace DocumentLibrary.Models
{
    // A book has an author on top of the basic document info
    public class Book : Document
    {
        public string Author { get; set; }

        public Book() : base()
        {
            Author = "";
        }

        public Book(string isbn, string title, int publicationYear, int pageCount, string author)
            : base(isbn, title, publicationYear, pageCount)
        {
            Author = author;
        }

        public override string ToString()
        {
            return base.ToString() + ", Author: " + Author;
        }

        public override bool Equals(object obj)
        {
            if (obj is Book)
            {
                Book other = (Book)obj;
                return this.ToString() == other.ToString();
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override string Print()
        {
            return "Printing book: " + Title + " by " + Author;
        }
    }
}
