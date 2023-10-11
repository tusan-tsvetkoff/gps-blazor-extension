namespace GpsComponent.Models;

public sealed class MarkerModel
{
    public string Name { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    private MarkerModel(string name, double latitude, double longitude) =>
        (Name, Latitude, Longitude) = (name, latitude, longitude);

    public static MarkerModel Create(string name, double latitude, double longitude) =>
        new(name, latitude, longitude);
}
