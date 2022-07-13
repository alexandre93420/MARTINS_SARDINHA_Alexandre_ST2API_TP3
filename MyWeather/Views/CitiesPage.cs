using MyWeather.Data;
using MyWeather.ViewModels;

namespace MyWeather.Views
{
    public partial class CitiesPage : ContentPage
    {
        public CitiesPage()
        {
            InitializeComponent();

            BindingContext = new CitiesViewModel();
        }
    }
}