using GpsComponent.Models;

using Microsoft.AspNetCore.Components;

namespace GpsComponent;

public partial class LeafletMap : ComponentBase
{
    private bool _isInitialized = false;
    protected const string MapId = "map";
    private List<MarkerModel>? _previousMarkers = new();

    [Parameter]
    public List<MarkerModel>? Markers { get; set; }
    [Parameter]
    public EventCallback<List<MarkerModel>> MarkersChanged { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        if (!_isInitialized || Markers is null)
        {
            return;
        }

        if (Markers.Any(m => !m.IsAdded))
        {
            await AddMarkerAsync(Markers.FirstOrDefault(m => !m.IsAdded)!);
        }

        var removedMarkers = _previousMarkers.Except(Markers).ToList();
        if (removedMarkers.Any())
        {
            removedMarkers.ForEach(async x => await RemoveMarkerAsync(x));
        }
        _previousMarkers = new List<MarkerModel>(Markers);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JsInterop.InitializeMapAsync(MapId);
            _isInitialized = true;
        }
    }

    internal async Task AddMarkerAsync(MarkerModel marker)
    {
        if (marker is null)
        {
            return;
        }
        await JsInterop.AddMarkerAsync(marker.Latitude, marker.Longitude);
        marker.SetAdded();
    }

    internal async Task SetMarkerIcon(MarkerModel marker, string iconName)
    {
        if (marker is null)
        {
            return;
        }
        await JsInterop.SetMarkerIconAsync(marker.Latitude, marker.Longitude, iconName);
    }

    internal async Task FitAllMarkersInViewAsync()
    {
        await JsInterop.FitAllMarkersInViewAsync();
    }

    internal async Task RemoveMarkerAsync(MarkerModel marker)
    {
        if (marker is null)
        {
            return;
        }
        await JsInterop.RemoveMarkerAsync(marker.Latitude, marker.Longitude);
    }
}