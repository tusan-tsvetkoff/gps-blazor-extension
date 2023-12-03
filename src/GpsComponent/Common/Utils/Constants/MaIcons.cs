using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GpsComponent.Utils.Constants;

public static class MaIcons
{
    public const string Default = "place";
    public const string MyLocation = "my_location";
    public const string Attractions = "attractions";
    public const string Bar = "sports_bar";
    public const string Restaurant = "restaurant";
    public const string Museum = "museum";
    public const string Train = "train";
    public const string PushPin = "push_pin";
    public const string HomeWork = "home_work";

    public static IEnumerable<string> GetIcons()
    {
        return new List<string>
        {
            Default,
            MyLocation,
            Attractions,
            Bar,
            Restaurant,
            Museum,
            Train,
            PushPin,
            HomeWork
        };
    }
}
