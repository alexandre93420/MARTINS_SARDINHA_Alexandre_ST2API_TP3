using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using SQLite;

namespace MyWeather.Data
{
    [Table("city")]
    public class CityTbl
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250), Unique]
        public string Name { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public CityTbl()
        {
            Name = "";
            Lon = 0.0;
            Lat = 0.0;
            CreationDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
            UpdateDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
        }

        public CityTbl(string sName, double dLon, double dLat)
        {
            Name = sName;
            Lon = dLon;
            Lat = dLat;
            CreationDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
            UpdateDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
        }

    }
}
