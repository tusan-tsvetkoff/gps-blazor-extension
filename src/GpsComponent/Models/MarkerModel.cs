namespace GpsComponent.Models;

public sealed class MarkerModel
{
    public string Name { get; private set; } = string.Empty;
    public double Latitude { get; private set; }
    public double Longitude { get; private set; }
    internal bool IsAdded { get; set; } = false;

    private MarkerModel(string name, double latitude, double longitude) =>
        (Name, Latitude, Longitude) = (name, latitude, longitude);

    public static MarkerModel Create(string name, double latitude, double longitude) =>
        new(name, latitude, longitude);

    internal void SetAdded() => IsAdded = true;
}
