namespace DocumentLibrary.Exceptions
{
    // Thrown when a book's publication year is before the invention of printing (1440)
    public class InvalidPublicationYearException : Exception
    {
        public InvalidPublicationYearException() { }

        public InvalidPublicationYearException(string message) : base(message) { }

        public InvalidPublicationYearException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
