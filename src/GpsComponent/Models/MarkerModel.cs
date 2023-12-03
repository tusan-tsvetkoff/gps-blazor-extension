using GpsComponent.Common.Utils.Enums;
using GpsComponent.Utils.Constants;

namespace GpsComponent.Models;

public sealed class MarkerModel
{
    public string Name { get; private set; } = string.Empty;
    public double Latitude { get; private set; }
    public double Longitude { get; private set; }
    public Icons Icon { get; set; }
    internal bool IsAdded { get; set; } = false;

    private MarkerModel(string name, double latitude, double longitude) =>
        (Name, Latitude, Longitude) = (name, latitude, longitude);

    public static MarkerModel Create(string name, double latitude, double longitude) =>
        new(name, latitude, longitude);

    public void SetIcon(Icons iconName) => Icon
        = iconName;

    internal void SetAdded() => IsAdded = true;

    public override int GetHashCode() => HashCode.Combine(Name, Latitude, Longitude);

    public override bool Equals(object? obj) => obj is MarkerModel model &&
        Name == model.Name &&
        Latitude == model.Latitude &&
        Longitude == model.Longitude;
}
