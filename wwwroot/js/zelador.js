function calcularViagens() {
    let objetivoInput = document.getElementById("pesos").value;
    let pesos = objetivoInput.split(',').map(n => parseFloat(n.trim())).filter(n => !isNaN(n));

    if (pesos.length === 0) {
        alert("Por favor, insira valores válidos.");
        return;
    }

    $.ajax({
        type: "POST",
        url: "/api/zelador",
        contentType: "application/json",
        data: JSON.stringify({ pesos: pesos }),
        success: function (data) {
            document.getElementById("saida").value = "[" + data.join(",") + "]";
        },
        error: function (xhr, status, error) {
            console.log("Erro:", xhr.responseText);
            document.getElementById("saida").value = "Erro ao processar!";
        }
    });
}