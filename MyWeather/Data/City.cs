using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeather.Data
{
    [Serializable]
    public class City : INotifyPropertyChanged
    {
        int _cityId;
        public int CityID
        {
            get => _cityId;
            set
            {
                if (_cityId == value)
                    return;

                _cityId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CityID)));
            }
        }

        string _cityName;
        public string CityName
        {
            get => _cityName;
            set
            {
                if (_cityName == value)
                    return;

                _cityName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CityName)));
            }
        }

        double _cityLon;
        public double CityLon
        {
            get => _cityLon;
            set
            {
                if (_cityLon == value)
                    return;

                _cityLon = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CityLon)));
            }
        }

        double _cityLat;
        public double CityLat
        {
            get => _cityLat;
            set
            {
                if (_cityLat == value)
                    return;

                _cityLat = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CityLat)));
            }
        }

        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
