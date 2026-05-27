namespace DocumentLibrary.Exceptions
{
    // Thrown when a volume's number exceeds the total volumes in the series
    public class InvalidVolumeNumberException : Exception
    {
        public InvalidVolumeNumberException() { }

        public InvalidVolumeNumberException(string message) : base(message) { }

        public InvalidVolumeNumberException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
