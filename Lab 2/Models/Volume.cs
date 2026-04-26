namespace DocumentLibrary.Models
{
    // A volume is a book that belongs to a multi-book series
    public class Volume : Book
    {
        public int VolumeNumber { get; set; }
        public int TotalVolumes { get; set; }

        public Volume() : base()
        {
            VolumeNumber = 0;
            TotalVolumes = 0;
        }

        public Volume(string isbn, string title, int publicationYear, int pageCount,
                       string author, int volumeNumber, int totalVolumes)
            : base(isbn, title, publicationYear, pageCount, author)
        {
            VolumeNumber = volumeNumber;
            TotalVolumes = totalVolumes;
        }

        public override string ToString()
        {
            return base.ToString() + ", Volume: " + VolumeNumber + "/" + TotalVolumes;
        }

        public override bool Equals(object obj)
        {
            if (obj is Volume)
            {
                Volume other = (Volume)obj;
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
            return "Printing volume " + VolumeNumber + "/" + TotalVolumes + ": " + Title + " by " + Author;
        }
    }
}
