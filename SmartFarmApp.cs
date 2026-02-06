namespace SmartFarm;

public class SmartFarmApp
{
    private readonly SensorServices _sensorServices =new SensorServices();

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("=== Smart Farm ===");
            Console.WriteLine("1. Add Record");
            Console.WriteLine("2. Show All");
            Console.WriteLine("3. Show Average");
            Console.WriteLine("4. Search");
            Console.WriteLine("0. Exit");

            Console.Write("Please enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _sensorServices.AddRecord();
                    break;
                case "2":
                    _sensorServices.ShowAll();
                    break;
                case "3":
                    _sensorServices.ShowAverage();
                    break;
                case "4":
                    _sensorServices.SearchRecord();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
