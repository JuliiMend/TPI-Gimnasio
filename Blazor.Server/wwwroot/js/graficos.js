// Funciones que llaman los reportes de Blazor (JS interop) para dibujar con Chart.js.
// Cada gráfico se identifica por el id del <canvas>; si ya existía se destruye y se vuelve a crear.
window.graficos = {
    _instancias: {},

    _crear: function (idCanvas, config) {
        const anterior = this._instancias[idCanvas];
        if (anterior) {
            anterior.destroy();
        }

        const canvas = document.getElementById(idCanvas);
        if (!canvas) {
            return;
        }

        this._instancias[idCanvas] = new Chart(canvas, config);
    },

    // series: [{ nombre, valores, color }]
    barras: function (idCanvas, etiquetas, series, titulo) {
        this._crear(idCanvas, {
            type: 'bar',
            data: {
                labels: etiquetas,
                datasets: series.map(s => ({
                    label: s.nombre,
                    data: s.valores,
                    backgroundColor: s.color
                }))
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
                plugins: { title: { display: true, text: titulo } },
                scales: { y: { beginAtZero: true, ticks: { precision: 0 } } }
            }
        });
    },

    torta: function (idCanvas, etiquetas, valores, colores, titulo) {
        this._crear(idCanvas, {
            type: 'pie',
            data: {
                labels: etiquetas,
                datasets: [{ data: valores, backgroundColor: colores }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
                plugins: {
                    title: { display: true, text: titulo },
                    legend: { position: 'right' }
                }
            }
        });
    }
};
