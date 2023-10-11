using System.Collections.ObjectModel;

using GpsComponent.Models;

using Microsoft.AspNetCore.Components;

namespace GpsComponent;

public partial class LeafletMap : ComponentBase
{
    protected const string MapId = "map";
    private List<MarkerModel>? _markers;

    [Parameter]
    public double Latitude { get; set; }
    [Parameter]
    public double Longitude { get; set; }
    [Parameter]
    public EventCallback<MarkerModel> OnMarkerAdded { get; set; }

    protected override void OnInitialized()
    {
        _markers = new List<MarkerModel>();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JsInterop.InitializeMapAsync(MapId);
        }
    }

    public async Task AddMarker()
    {
        var marker = MarkerModel.Create("New", Latitude, Longitude);
        _markers?.Add(marker);
        await JsInterop.AddMarkerAsync(Latitude, Longitude);
        await OnMarkerAdded.InvokeAsync(marker);
    }

    public IReadOnlyList<MarkerModel> GetMarkers() => _markers?.AsReadOnly() ?? new ReadOnlyCollection<MarkerModel>(new List<MarkerModel>());
}