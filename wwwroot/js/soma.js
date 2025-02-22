function calcularViagens() {
    let numeroInput = document.getElementById("numero").value;
    let objetivoInput = document.getElementById("objetivo").value;

    let pesos = numeroInput.split(',').map(n => parseFloat(n.trim())).filter(n => !isNaN(n));
    let objetivo = parseFloat(objetivoInput);

    if (pesos.length === 0 || isNaN(objetivo)) {
        alert("Por favor, insira valores válidos.");
        return;
    }

    $.ajax({
        type: "POST",
        url: "/api/viagens",
        contentType: "application/json",
        data: JSON.stringify({ pesos: pesos, objetivo: objetivo }),
        success: function (data) {
            document.getElementById("saida").value = data;
        },
        error: function (xhr, status, error) {
            console.log("Erro:", xhr.responseText);
            document.getElementById("saida").value = "Soma não encontrada!";
        }
    });
}
