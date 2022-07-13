using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using MyWeather.Data;
using MyWeather.Views;

namespace MyWeather.ViewModels
{
    public class AddCityViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand DoneEditingCommand { get; private set; }

        public ICommand SaveCommand { get; private set; }

        public ICommand DeleteCommand { get; private set; }

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

        public AddCityViewModel()
        {
            DoneEditingCommand = new Command(async () => await DoneEditing());
            SaveCommand = new Command(async () => await SaveData());
            DeleteCommand = new Command(async () => await DeleteCity());
        }

        private async Task SaveData()
        {
            if (CityID == 0)
                await InsertCity();
            else
                await UpdateCity();
        }

        private async Task InsertCity()
        {
            await App.MyWeatherRepo.AddNewCity(CityName, CityLon, CityLat);

            MessagingCenter.Send(this, "refresh");

            await Shell.Current.GoToAsync("..");
        }

        private async Task UpdateCity()
        {
            CityTbl cityToSave = new()
            {
                Id = CityID,
                Name = CityName,
                Lon = CityLon,
                Lat = CityLat
            };

            await App.MyWeatherRepo.UpdateCity(cityToSave);

            MessagingCenter.Send(this, "refresh");

            await Shell.Current.GoToAsync("..");
        }

        private async Task DeleteCity()
        {
            if (string.IsNullOrEmpty(CityID.ToString()))
                return;

            await App.MyWeatherRepo.DeleteCity(CityID);

            MessagingCenter.Send(this, "refresh");

            await Shell.Current.GoToAsync("..");
        }

        private async Task DoneEditing()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
