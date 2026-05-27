using System.Text.Json;
using ContactsLibrary;

namespace JsonPlugin;

[Info(Author = "Mdmrc")]
public class JsonContactSerializer : IPluginable
{
    public string Format => "JSON";

    public void Save(List<Contact> contacts, string filePath)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(contacts, options);
        File.WriteAllText(filePath, json);
    }

    public List<Contact> Load(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<Contact>();
        }

        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<Contact>>(json) ?? new List<Contact>();
    }
}
