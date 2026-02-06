using SmartFarm.Models;

namespace SmartFarm;

public class SensorServices
{
    private List<SensorRecord> _records = new();
    private int _nextId = 1;
    public void AddRecord()
    {
        double temperature = GetData("Adding Temperature: ");
        double humidity = GetData("Adding Humidity: ");

        var recode = new SensorRecord(
            _nextId++,
            DateTime.Now,
            temperature,
            humidity);
        _records.Add(recode);
        Console.WriteLine("Saved. ID = " + recode.Id);
    }

    public void ShowAll()
    {
        if (_records == null || _records.Count == 0)
        {
            Console.WriteLine("--- No Records to Display ---");
            return;
        }
        
        Console.WriteLine($"{"ID",-5} | {"Temp",-10} | {"Humidity",-10}");
        Console.WriteLine(new string('-', 30));
        
        foreach (var record in _records)
        {
            Console.WriteLine($"{record.Id,-5} | {record.Temperature,10:F1} | {record.Humidity,10:F1}");
        }
        
        Console.WriteLine(new string('-', 30));
        Console.WriteLine($"Total: {_records.Count} records.");
    }

    public void ShowAverage()
    {
        if (_records == null || _records.Count == 0)
        {
            Console.WriteLine("No Records Found");
            return;
        }
        
        double avgTemp = 0;
        double avgHum = 0;
        foreach (var recode in _records)
        {
            avgTemp+= recode.Temperature;
            avgHum += recode.Humidity;
        }
        double totalTemp = avgTemp / _records.Count;
        double totalHum = avgHum / _records.Count;
        Console.WriteLine($"Average Temp = {avgTemp:N2}");
        Console.WriteLine($"Average Humidity = {avgHum:N2}");
    }

    public void SearchRecord()
    {
        if (_records == null || _records.Count == 0)
        {
            Console.WriteLine("No Records Found");
            return;
        }

        Console.Write("Enter ID to search: ");
        if (int.TryParse(Console.ReadLine(), out int searchId))
        {
            var record = _records.Find(r => r.Id == searchId);
            if (record != null)
            {
                Console.WriteLine("\n--- Record Found ---");
                Console.WriteLine(record); 
            }
            else
            {
                Console.WriteLine($"Record with ID {searchId} not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    double GetData(string message)
    {
        while (true)
        {
            Console.Write(message);
            if(double.TryParse(Console.ReadLine(),out double value))
            {
                return value;
            }
            Console.WriteLine("Invalid Input");
        }
    }
    
}
