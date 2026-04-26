using DocumentLibrary.Models;
using DocumentLibrary.Exceptions;

namespace DocumentLibrary.Services
{
    // Manages a collection of documents
    public class DocumentManager
    {
        private List<Document> documents = new List<Document>();

        // Adds a document with validation
        public void AddDocument(Document document)
        {
            // Check for duplicate ISBN
            foreach (Document d in documents)
            {
                if (d.Isbn == document.Isbn)
                {
                    throw new DuplicateIsbnException(
                        "Document with ISBN " + document.Isbn + " already exists.");
                }
            }

            // Check volume number
            if (document is Volume)
            {
                Volume volume = (Volume)document;
                if (volume.VolumeNumber > volume.TotalVolumes)
                {
                    throw new InvalidVolumeNumberException(
                        "Volume number " + volume.VolumeNumber + " is bigger than total " + volume.TotalVolumes);
                }
            }

            // Check publication year (printing press invented in 1440)
            if (document is Book)
            {
                Book book = (Book)document;
                if (book.PublicationYear < 1440)
                {
                    throw new InvalidPublicationYearException(
                        "Year " + book.PublicationYear + " is before printing was invented (1440).");
                }
            }

            documents.Add(document);
        }

        // Find document by ISBN
        public Document GetDocumentByIsbn(string isbn)
        {
            foreach (Document d in documents)
            {
                if (d.Isbn == isbn)
                    return d;
            }
            return null;
        }

        // Find documents that contain a phrase in title
        public List<Document> SearchByTitle(string phrase)
        {
            List<Document> results = new List<Document>();
            foreach (Document d in documents)
            {
                if (d.Title.Contains(phrase))
                    results.Add(d);
            }
            return results;
        }

        // Get magazines with a specific frequency
        public List<Magazine> GetMagazinesByFrequency(Frequency frequency)
        {
            List<Magazine> results = new List<Magazine>();
            foreach (Document d in documents)
            {
                if (d is Magazine)
                {
                    Magazine mag = (Magazine)d;
                    if (mag.Frequency == frequency)
                        results.Add(mag);
                }
            }
            return results;
        }

        // Get all documents
        public List<Document> GetAllDocuments()
        {
            return documents;
        }
    }
}
