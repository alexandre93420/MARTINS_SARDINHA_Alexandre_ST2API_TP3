//using AndroidX.Interpolator.View.Animation;
using Microsoft.Maui.Layouts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using MyWeather.Data;

namespace MyWeather.ViewModels
{
    public class CitiesViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<City> _cities;

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                if (_isRefreshing == value)
                    return;

                _isRefreshing = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsRefreshing)));
            }
        }

        private bool _isBusy = false;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy == value)
                    return;

                _isBusy = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsBusy)));
            }
        }

        private City _selectedCity;
        public City SelectedCity
        {
            get => _selectedCity;
            set
            {
                if (_selectedCity == value)
                    return;

                _selectedCity = value;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedCity)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public CitiesViewModel()
        {            
            _cities = new ObservableCollection<City>();
            LoadDataCommand = new Command(async () => await LoadData());
            CitySelectedCommand = new Command(async () => await CitySelected());
            AddNewCityCommand = new Command(async () => await Shell.Current.GoToAsync("addcity"));

            MessagingCenter.Subscribe<AddCityViewModel>(this, "refresh", async (sender) => await LoadData());

            Task.Run(LoadData);
        }

        private async Task CitySelected()
        {
            if (SelectedCity == null)
                return;

            var navigationParameter = new Dictionary<string, object>()
            {
                { "city", SelectedCity }
            };

            await Shell.Current.GoToAsync("addcity", navigationParameter);

            //MainThread.BeginInvokeOnMainThread(() => SelectedCity = null);

            SelectedCity = null;
        }

        public ObservableCollection<City> Cities
        {
            get => _cities;
            set => _cities = value;
        }

        public ICommand LoadDataCommand { get; private set; }

        public ICommand CitySelectedCommand { get; private set; }

        public ICommand AddNewCityCommand { get; private set; }

        public async Task LoadData()
        {
            if (IsBusy)
                return;

            try
            {
                IsRefreshing = true;
                IsBusy = true;

                var citiesCollection = await App.MyWeatherRepo.GetAllCity();

                // MainThread.BeginInvokeOnMainThread

                Cities.Clear();

                foreach (CityTbl city in citiesCollection)
                {
                    var cityEntry = new City();

                    cityEntry.CityID = city.Id;
                    cityEntry.CityName = city.Name;
                    cityEntry.CityLon = city.Lon;
                    cityEntry.CityLat = city.Lat;

                    Cities.Add(cityEntry);
                }
            }
            finally
            {    
                IsRefreshing = false;
                IsBusy = false;
            }
        }

    }
}
