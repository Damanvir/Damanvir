using System;
using System.IO;
using System.Text.Json;

public class Event
{
    public int EventNumber { get; set; }
    public string Location { get; set; }
}

class Program
{
    public static void Main(string[] args)
    {
        Event myEvent = new Event { EventNumber = 1, Location = "Calgary" };

        // Serialize the myEvent object to JSON and write it to a file
        string jsonString = JsonSerializer.Serialize(myEvent);
        File.WriteAllText("event.json", jsonString);

        // Read the JSON string from the file and deserialize it back to an Event object
        string jsonStringRead = File.ReadAllText("event.json");
        Event deserializedEvent = JsonSerializer.Deserialize<Event>(jsonStringRead);

        Console.WriteLine(deserializedEvent.EventNumber);
        Console.WriteLine(deserializedEvent.Location);

        // Assuming the "Tech Competition" output is desired but unrelated to the Event object
        Console.WriteLine("Tech Competition");

        // Call ReadFromFile method
        ReadFromFile("hackathon.txt");
    }

    private static void ReadFromFile(string fileName)
    {
        // Ensure the file exists to avoid FileNotFoundException
        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string content = File.ReadAllText(fileName);
        Console.WriteLine($"In Word: {content}");

        if (content.Length > 0)
        {
            Console.WriteLine($"The First Character is: \"{content[0]}\"");
            // Find the middle character considering both odd and even lengths
            int middleIndex = content.Length / 2;
            char middleChar = content.Length % 2 == 0 ? content[middleIndex - 1] : content[middleIndex];
            Console.WriteLine($"The Middle Character is: \"{middleChar}\"");
            Console.WriteLine($"The Last Character is: \"{content[content.Length - 1]}\"");
        }
    }
}
