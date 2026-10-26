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
