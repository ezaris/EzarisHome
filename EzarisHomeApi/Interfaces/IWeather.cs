namespace EzarisHomeApi.Interfaces {
    public interface IWeather {
        string GetSynopticDataByStation(string city);
        string GetHydroData();
    }
}
