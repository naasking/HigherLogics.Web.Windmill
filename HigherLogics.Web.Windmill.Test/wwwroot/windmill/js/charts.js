// setup all charts on the page
//FIXME: will need a hook for dynamically rendered content
document.addEventListener('DOMContentLoaded', function () {
    var charts = document.querySelectorAll("canvas[data-chart]");
    for (var i = 0; i < charts.length; ++i) {
        var attr = charts[i].getAttribute("data-chart");
        var cfg = JSON.parse(attr);
        window['chart-' + i] = new Chart(charts[i], cfg);
    }
});