namespace ContactsLibrary;

public interface IPluginable
{
    string Format { get; }
    void Save(List<Contact> contacts, string filePath);
    List<Contact> Load(string filePath);
}
