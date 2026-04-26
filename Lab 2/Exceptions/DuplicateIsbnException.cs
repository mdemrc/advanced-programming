namespace DocumentLibrary.Exceptions
{
    // Thrown when trying to add a document with an ISBN that already exists
    public class DuplicateIsbnException : Exception
    {
        public DuplicateIsbnException() { }

        public DuplicateIsbnException(string message) : base(message) { }

        public DuplicateIsbnException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
