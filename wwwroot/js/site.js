$(document).ready(function () {
    getDatatable('#table-medico');
    getDatatable('#table-paciente');
    getDatatable('#table-consulta');

    //Modal
    $('.btn-total-medicos').click(function () {
        var medicoId = $(this).attr('medico-id');
        $.ajax({
            type: 'GET',
            url: '/Medico/ListarConsultasPorMedicoId/' + medicoId,
            success: function (result) {
                $('#listaConsultaMedico').html(result);
                $('#modalConsultaMedico').modal('show');
                getDatatable('#table-consulta-medico');
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
            "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Mostrar _MENU_ registros por pagina",
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
$(function () {
    $('.dropdown-toggle').dropdown();
});
$('.close-alert').click(function () {
    $('.alert').hide('hide');
});

