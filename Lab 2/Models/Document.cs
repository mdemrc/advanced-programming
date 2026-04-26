namespace DocumentLibrary.Models
{
    // Base class for all documents - cannot be created directly
    public abstract class Document
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public int PageCount { get; set; }

        // Default constructor
        public Document()
        {
            Isbn = "";
            Title = "";
            PublicationYear = 0;
            PageCount = 0;
        }

        // Constructor with parameters
        public Document(string isbn, string title, int publicationYear, int pageCount)
        {
            Isbn = isbn;
            Title = title;
            PublicationYear = publicationYear;
            PageCount = pageCount;
        }

        public override string ToString()
        {
            return "ISBN: " + Isbn + ", Title: " + Title + ", Year: " + PublicationYear + ", Pages: " + PageCount;
        }

        // Two documents are equal if their ToString() matches
        public override bool Equals(object obj)
        {
            if (obj is Document)
            {
                Document other = (Document)obj;
                return this.ToString() == other.ToString();
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        // == operator uses Equals
        public static bool operator ==(Document a, Document b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            return a.Equals(b);
        }

        public static bool operator !=(Document a, Document b)
        {
            return !(a == b);
        }

        // Subclasses must implement this
        public abstract string Print();
    }
}
