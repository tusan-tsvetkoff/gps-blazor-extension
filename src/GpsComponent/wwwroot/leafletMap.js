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
  console.log("addMarker");
  const marker = L.marker([lat, lng]).addTo(map);
  markers.push(marker);
}


