$(function () {
    var qtdEmails = $("#div-emails .row").length;

    $("#btn-add-email").click(function (e) {
        e.preventDefault();

        var blocoEmail = '<div class="row">' +
            '    <div class="col-md-2"></div>' +
'    <div class="col-md-6">' +
'        <input type="email" name="Emails[' + qtdEmails + '].EnderecoEmail" placeholder="E-mail válido" class="form-control txt-email" size="150" />' +
'    </div>' +
'    <div class="col-md-3">' +
'        <select name="Emails[' + qtdEmails + '].Tipo" class="form-control sel-tipoEmail">' +
'            <option value="0">Particular</option>' +
'            <option value="1">Comercial</option>' +
'        </select>' +
'    </div>' +
'    <div class="col-md-1">' +
'        <button class="btn btn-danger btn-remover-email">' +
'            <span class="glyphicon glyphicon-trash"></span>' +
'        </button>' +
'    </div>' +
'</div>';

        $("#div-emails").append(blocoEmail);

        qtdEmails++;
    });

    $("#div-emails").on("click", ".btn-remover-email", function (e) {
        e.preventDefault();

        var id = $(this).attr("data-id");

        if (id)
            $.post("/Contatos/RemoverEmail?id=" + id);

        $(this).parent().parent().remove();

        qtdEmails--;

        $("#div-emails .row").each(function (indice, elemento) {
            $(elemento).find(".txt-email").attr("name", "Emails[" + indice + "].EnderecoEmail");
            $(elemento).find(".sel-tipoEmail").attr("name", "Emails[" + indice + "].Tipo");
        });
    });
});