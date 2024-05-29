namespace MauiApp1;

public class Constants
{
    public static Uri ApiUrl = DeviceInfo.Platform == DevicePlatform.Android ? new Uri("http://10.0.2.2:5057/") : new Uri("http://localhost:5057/");
    
}