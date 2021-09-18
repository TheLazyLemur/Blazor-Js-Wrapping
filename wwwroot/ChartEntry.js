import "https://cdnjs.cloudflare.com/ajax/libs/Chart.js/3.5.1/chart.min.js"

export function renderLineChart(element, config) {
    config.options.plugins.tooltip.callbacks = {
        labelTextColor: function (context) {
            return '#000000';
        },
    }

    let myChart = new Chart(
        element,
        config
    );
    
    
    return myChart;
}