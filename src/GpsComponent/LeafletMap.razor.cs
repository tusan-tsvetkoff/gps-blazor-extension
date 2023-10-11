using GpsComponent.Models;

using Microsoft.AspNetCore.Components;

namespace GpsComponent;

public partial class LeafletMap : ComponentBase
{
    private bool _isInitialized = false;
    protected const string MapId = "map";
    private MarkerModel _lastAddedMarker = MarkerModel.Create(string.Empty, 0, 0);
    private List<MarkerModel> _markers = new();

    [Parameter]
    public List<MarkerModel>? Markers { get; set; }
    [Parameter]
    public EventCallback<List<MarkerModel>> MarkersChanged { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _isInitialized = true;
    }

    protected override async Task OnParametersSetAsync()
    {
        if(!_isInitialized)
        {
            return;
        }
        _lastAddedMarker = Markers?.LastOrDefault();
        await AddMarkerAsync();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JsInterop.InitializeMapAsync(MapId);
        }
    }

    public async Task AddMarkerAsync()
    {
        await JsInterop.AddMarkerAsync(_lastAddedMarker.Latitude, _lastAddedMarker.Longitude);
    }
}