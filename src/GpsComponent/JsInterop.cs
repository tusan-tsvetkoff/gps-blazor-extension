using Microsoft.JSInterop;

namespace GpsComponent;

public class JsInterop : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    public JsInterop(IJSRuntime jsRuntime)
    {
        _moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/GpsComponent/leafletMap.js").AsTask());
    }

    public async Task InitializeMapAsync(string mapId)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("initMap", mapId);
    }

    public async Task AddMarkerAsync(double lat, double lang)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("addMarker", lat, lang);
    }

    public async ValueTask DisposeAsync()
    {
        if (_moduleTask.IsValueCreated)
        {
            var module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}
