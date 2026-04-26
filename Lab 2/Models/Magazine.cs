namespace DocumentLibrary.Models
{
    // A magazine is a periodical document
    public class Magazine : Document
    {
        public int Number { get; set; }
        public Frequency Frequency { get; set; }

        public Magazine() : base()
        {
            Number = 0;
            Frequency = Frequency.Monthly;
        }

        public Magazine(string isbn, string title, int publicationYear, int pageCount,
                        int number, Frequency frequency)
            : base(isbn, title, publicationYear, pageCount)
        {
            Number = number;
            Frequency = frequency;
        }

        public override string ToString()
        {
            return base.ToString() + ", Number: " + Number + ", Frequency: " + Frequency;
        }

        public override bool Equals(object obj)
        {
            if (obj is Magazine)
            {
                Magazine other = (Magazine)obj;
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
            return "Printing magazine: " + Title + " No." + Number + " (" + Frequency + ")";
        }
    }
}
