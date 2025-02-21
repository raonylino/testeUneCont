function verificarPalindromo() {
    let palavraInput = document.getElementById("palavra").value;

    if (!/^[a-zA-Z]+$/.test(palavraInput)) {
        alert("Por favor, insira apenas letras.");
        return;
    }

    $.ajax({
        type: "POST",
        url: "/api/palindroma",
        contentType: "application/json",
        data: JSON.stringify(palavraInput),
        success: function (data) {

            document.getElementById("saida").value = data ? "É um palíndromo!" : "Não é um palíndromo.";
        },
        error: function (xhr, status, error) {
            console.log("Erro:", xhr.responseText);
            document.getElementById("saida").value = "Erro ao processar!";
        }
    });
}
