using System;
using System.Collections.Generic;
using System.IO;

class Dishwasher
{
    public string ItemNumber { get; set; }
    public string Brand { get; set; }
    public int Quantity { get; set; }
    public int Wattage { get; set; }
    public string Color { get; set; }
    public double Price { get; set; }
    public string Feature { get; set; }
    public string SoundRating { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Dishwasher> dishwashers = new List<Dishwasher>();

        // Read data from appliances.txt
        string filePath = "appliances.txt";
        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split(';');
                    Dishwasher dishwasher = new Dishwasher
                    {
                        ItemNumber = data[0],
                        Brand = data[1],
                        Quantity = int.Parse(data[2]),
                        Wattage = int.Parse(data[3]),
                        Color = data[4],
                        Price = double.Parse(data[5]),
                        Feature = data[6],
                        SoundRating = data[7]
                    };
                    char firstDigit = dishwasher.ItemNumber[0];
                    if ((firstDigit == '4' || firstDigit == '5') && IsSoundRatingValid(dishwasher.SoundRating))
                    {
                        dishwashers.Add(dishwasher);
                    }
                }
            }

            // Display dishwashers that meet the criteria
            Console.WriteLine("Dishwashers meeting the criteria:");
            foreach (Dishwasher dishwasher in dishwashers)
            {
                Console.WriteLine($"ItemNumber: {dishwasher.ItemNumber}, Brand: {dishwasher.Brand}, Quantity: {dishwasher.Quantity}, Wattage: {dishwasher.Wattage}, Color: {dishwasher.Color}, Price: {dishwasher.Price}, Feature: {dishwasher.Feature}, SoundRating: {dishwasher.SoundRating}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error reading file: {e.Message}");
        }
    }

    static bool IsSoundRatingValid(string soundRating)
    {
        return soundRating == "Qt" || soundRating == "Qr" || soundRating == "Qu" || soundRating == "M";
    }
}

