document.getElementById("entrada").addEventListener("input", function () {
    this.value = this.value.replace(/[^()]/g, '');
});
function parenteses() {
    let valorEntrada = document.getElementById("entrada").value;

    $.ajax({
        type: "POST",
        url: "/api/parenteses",
        contentType: "application/json",
        data: JSON.stringify({ valor: valorEntrada }),
        success: function (data) {
            document.getElementById("saida").value = data;
        },
        error: function (xhr, status, error) {
            console.log("Erro:", xhr.responseText);
            document.getElementById("saida").value = "Erro ao processar!";
        }
    });
}