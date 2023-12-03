let map;
let markers = [];
const defaultIcon = createIcon("place", "blue");

export function initMap() {
  map = L.map("map").setView([51.505, -0.09], 13);
  L.tileLayer("https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png", {
    maxZoom: 19,
    attribution:
      'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors',
  }).addTo(map);
}

export function addMarker(lat, lng) {
  const marker = L.marker([lat, lng], { icon: defaultIcon }).addTo(map);
  map.setView([lat, lng], 13)
  markers.push(marker);
}

export function fitAllMarkersInView() {
  const group = new L.featureGroup(markers);
  map.fitBounds(group.getBounds());
}

export function changeMarkerIcon(lat, lng, iconName, color) {
  const icon = createIcon(iconName, color);
  const marker = findMarker(lat, lng);
  marker.setIcon(icon);
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

function createIcon(iconName, color) {
  return L.divIcon({
    iconSize: [30, 30],
    iconAnchor: [15, 15],
    popUpAnchor: [0, -15],
    className: "material-icons",
    html: `<i class="material-icons" style="color: ${color}; font-size: 30px !important;">${iconName}</i>`,
  });
}
