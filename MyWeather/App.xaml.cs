namespace MyWeather;

public partial class App : Application
{
    public static MyWeatherRepository MyWeatherRepo { get; private set; }
    
	public App(MyWeatherRepository repo)
	{
		InitializeComponent();

		MainPage = new AppShell();

        MyWeatherRepo = repo;
    }
}
