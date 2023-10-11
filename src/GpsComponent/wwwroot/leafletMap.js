let map;
let markers = [];

export function initMap() {
  map = L.map("map").setView([51.505, -0.09], 13);
  L.tileLayer("https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png", {
    maxZoom: 19,
    attribution:
      'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors',
  }).addTo(map);
}

export function addMarker(lat, lng) {
  const marker = L.marker([lat, lng]).addTo(map);
  markers.push(marker);
}

export function deleteMarker(lat, lng) {
  console.log("deleteMarker", lat, lng);
  const marker = findMarker(lat, lng);
  if (marker) {
    map.removeLayer(marker);
    const index = markers.indexOf(marker);
    if (index > -1) {
      markers.splice(index, 1);
    }
  }
}

function findMarker(lat, lng) {
  return markers.find((marker) => marker.getLatLng().equals([lat, lng]));
}
