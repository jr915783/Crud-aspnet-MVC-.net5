// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    getDatatable('#table-contatos');
    getDatatable('#table-usuarios');

    $('.btn-total-contatos').click(function () {
        var usuarioId = $(this).attr('usuario-id');
        var colaboradorId = $(this).attr('unidade-id');

        $.ajax({
            type: 'GET',
            url: '/Unidade/ListarColaboradorPorUnidade/' + colaboradorId,
            success: function (result) {
                $("#listaContatosUsuario").html(result);
                $('#modalContatosUsuario').modal();
                getDatatable('#table-contatos-usuario');
            }
        });
    });


    $('.btn-delete-colaborador').click(function () {       
        var colaboradorId = $(this).attr('colaborador-id');

        $.ajax({
            type: 'GET',
            url: '/Colaborador/ModalApagarColaborador/' + colaboradorId,
            success: function (result) {
                $("#colaborador").html(result);
                $('#modalApagarColaborador').modal();               
            }
        });
    });

    $('.btn-delete-unidade').click(function () {        
        var unidadeId = $(this).attr('unidade-id');

        $.ajax({
            type: 'GET',
            url: '/Unidade/ModalApagarUnidade/' + unidadeId,
            success: function (result) {
                $("#unidade").html(result);
                $('#modalApagarUnidade').modal();
            }
        });
    });

    $('.btn-delete-usuario').click(function () {
        var usuarioId = $(this).attr('usuario-id');

        $.ajax({
            type: 'GET',
            url: '/Usuario/ModalApagarUsuario/' + usuarioId,
            success: function (result) {
                $("#usuario").html(result);
                $('#modalApagarUsuario').modal();
            }
        });
    });
})

function getDatatable(id) {
    $(id).DataTable({
        "ordering": true,
        "paging": true,
        "searching": true,
        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": "Mostrar _START_ at&eacute; _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrar 0 at&eacute; 0 de 0 Registros",
            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Mostrar _MENU_ registros por página",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Proximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Ultimo"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    });
}


$('.close-alert').click(function() {
    $(".alert").hide('hide');
});