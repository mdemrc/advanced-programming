namespace ContactsLibrary;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class InfoAttribute : Attribute
{
    public string Author { get; set; }

    public InfoAttribute()
    {
    }

    public InfoAttribute(string author)
    {
        Author = author;
    }
}
