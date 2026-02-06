using System;
namespace SmartFarm.Models
{
    public class SensorRecord
    {
        public int Id {get;private set;}
        public DateTime TimeStamp {get;private set;}
        public double Temperature {get;private set;}
        public double Humidity {get;private set;}

        public SensorRecord(
            int id,
            DateTime timeStamp,
            double temperature,
            double humidity
        )
        {
            Id = id;
            TimeStamp = timeStamp;
            Temperature = temperature;
            Humidity = humidity;
        }

        public override string ToString() =>
            $"ID: {Id}\nTimeStamp:{TimeStamp:dd-MM-yyyy|hh:mm}\nTemperature: {Temperature} C\nHumidity: {Humidity} %";
    }
}


