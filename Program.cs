using Newtonsoft.Json;
using Practice_DZ_10_Dedok;
using System.Xml;
using System.Xml.Serialization;

//1
Console.WriteLine("Task_1: ");
Album album = InputAlbum();
DisplayAlbum(album);

string filePath = "album.xml";

SerializeToXml(album, filePath);
Console.WriteLine("\nAlbum serialized to XML file.");

Album deserializedAlbum = DeserializeFromXml(filePath);
Console.WriteLine("\nDeserialized album:");
DisplayAlbum(deserializedAlbum);

EditAlbum(deserializedAlbum);
SerializeToXml(deserializedAlbum, filePath);
Console.WriteLine("\nEdited album serialized to XML file.");
    static Album InputAlbum()
{
    Console.Write("Enter album title: ");
    string title = Console.ReadLine();

    Console.Write("Enter performer: ");
    string performer = Console.ReadLine();

    Console.Write("Enter release year: ");
    int releaseYear = int.Parse(Console.ReadLine());

    Console.Write("Enter album duration (hh:mm:ss): ");
    TimeSpan duration = TimeSpan.Parse(Console.ReadLine());

    Console.Write("Enter recording studio: ");
    string studio = Console.ReadLine();

    Album album = new Album(title, performer, releaseYear, duration, studio);

    Console.Write("Enter the number of songs: ");
    int songCount = int.Parse(Console.ReadLine());

    for (int i = 0; i < songCount; i++)
    {
        Console.WriteLine($"\nSong {i + 1}:");
        Console.Write("Enter song title: ");
        string songTitle = Console.ReadLine();

        Console.Write("Enter song style: ");
        string style = Console.ReadLine();

        Console.Write("Enter song duration (hh:mm:ss): ");
        TimeSpan songDuration = TimeSpan.Parse(Console.ReadLine());

        album.Songs.Add(new Song(songTitle, style, songDuration));
    }

    return album;
}
static void DisplayAlbum(Album album)
{
    Console.WriteLine("\nAlbum Information:");
    Console.WriteLine(album);
}
static void SerializeToXml(Album album, string filePath)
{
    XmlSerializer serializer = new XmlSerializer(typeof(Album));
    using (StreamWriter writer = new StreamWriter(filePath))
    {
        serializer.Serialize(writer, album);
    }
}
static Album DeserializeFromXml(string filePath)
{
    XmlSerializer serializer = new XmlSerializer(typeof(Album));
    using (StreamReader reader = new StreamReader(filePath))
    {
        return (Album)serializer.Deserialize(reader);
    }
}
static void EditAlbum(Album album)
{
    Console.WriteLine("\nEditing album:");
    Console.Write("Enter new album title (leave empty to keep current): ");
    string newTitle = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(newTitle))
    {
        album.Title = newTitle;
    }

    Console.Write("Enter new performer (leave empty to keep current): ");
    string newPerformer = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(newPerformer))
    {
        album.Performer = newPerformer;
    }

    Console.Write("Enter new release year (leave empty to keep current): ");
    string newReleaseYear = Console.ReadLine();
    if (int.TryParse(newReleaseYear, out int releaseYear))
    {
        album.ReleaseYear = releaseYear;
    }

    Console.Write("Enter new album duration (leave empty to keep current): ");
    string newDuration = Console.ReadLine();
    if (TimeSpan.TryParse(newDuration, out TimeSpan duration))
    {
        album.Duration = duration;
    }

    Console.Write("Enter new recording studio (leave empty to keep current): ");
    string newStudio = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(newStudio))
    {
        album.Studio = newStudio;
    }
}
Console.WriteLine();
//2
Console.WriteLine("Task_2: ");
Journal journal = InputJournal();
DisplayJournal(journal);

string filePath_1 = "journal.json";

SerializeToJson(journal, filePath_1);
Console.WriteLine("\nJournal serialized to JSON file.");

Journal deserializedJournal = DeserializeFromJson(filePath_1);
Console.WriteLine("\nDeserialized journal:");

DisplayJournal(deserializedJournal);
    
    static Journal InputJournal()
{
    Console.Write("Enter journal title: ");
    string title = Console.ReadLine();

    Console.Write("Enter publisher: ");
    string publisher = Console.ReadLine();

    Console.Write("Enter publication date (yyyy-mm-dd): ");
    DateTime publicationDate = DateTime.Parse(Console.ReadLine());

    Console.Write("Enter number of pages: ");
    int pageCount = int.Parse(Console.ReadLine());

    Journal journal = new Journal(title, publisher, publicationDate, pageCount);

    Console.Write("Enter the number of articles: ");
    int articleCount = int.Parse(Console.ReadLine());

    for (int i = 0; i < articleCount; i++)
    {
        Console.WriteLine($"\nArticle {i + 1}:");
        Console.Write("Enter article title: ");
        string articleTitle = Console.ReadLine();

        Console.Write("Enter number of characters: ");
        int characterCount = int.Parse(Console.ReadLine());

        Console.Write("Enter article preview: ");
        string preview = Console.ReadLine();

        journal.Articles.Add(new Article(articleTitle, characterCount, preview));
    }

    return journal;
}

static void DisplayJournal(Journal journal)
{
    Console.WriteLine("\nJournal Information:");
    Console.WriteLine(journal);
}

static void SerializeToJson(Journal journal, string filePath)
{
    string json = JsonConvert.SerializeObject(journal, (Newtonsoft.Json.Formatting)System.Xml.Formatting.Indented);
    File.WriteAllText(filePath, json);
    Console.WriteLine($"Journal saved to {filePath}");
}

static Journal DeserializeFromJson(string filePath)
{
    string json = File.ReadAllText(filePath);
    Journal journal = JsonConvert.DeserializeObject<Journal>(json);
    return journal;
}