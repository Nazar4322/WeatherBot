namespace WeatherProgramm
{
    internal class WeatherInfo
    {
        public TempInfo Main { get; set; }
        public CloudsInfo Clouds { get; set; }
        public List<Weather> Weather { get; set; }

    }
}
