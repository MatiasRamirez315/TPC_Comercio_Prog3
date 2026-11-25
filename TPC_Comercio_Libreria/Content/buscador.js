document.addEventListener('DOMContentLoaded', function () {
    var input = document.getElementById('txtBuscar');
    if (!input) return;

    input.addEventListener('keyup', function () {
        var filtro = this.value.toLowerCase().trim();
        var filas = document.querySelectorAll('table tbody tr');

        filas.forEach(function (fila) {
            var texto = fila.innerText.toLowerCase();
            fila.style.display = (filtro === '' || texto.indexOf(filtro) !== -1) ? '' : 'none';
        });
    });
});