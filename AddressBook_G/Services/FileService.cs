namespace AddressBook_G.Services;

internal class FileService
{
    public void Save(string filePath, string contact)
    {
        using var sw = new StreamWriter(filePath);
        sw.WriteLine(contact);
    }

    public string Read(string filePath)
    {
        try
        {
            using var sr = new StreamReader(filePath);
            return sr.ReadToEnd();
        }
        catch { return null!; }
    }
}
