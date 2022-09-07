function CompletarTablaSubrubros() {
    VaciarFormulario();
    $.ajax({
        type: "POST",
        url: '../../Subrubros/BuscarSubrubros',
        data: {},
        success: function (listadoSubrubros) {
            $("#tbody-subrubros").empty();
            $.each(listadoSubrubros, function (index, subrubro) {

                let claseEliminado = '';
                let botones = '<button type="button" onclick="BuscarSubRubro(' + subrubro.subrubroID + ')" class="btn btn-primary btn-sm" style="margin-right:5px">Editar</button>' +
                    '<button type="button" onclick="EliminarSubrubro(' + subrubro.subrubroID + ',1)" class="btn btn-danger btn-sm">Eliminar</button>';

                if (subrubro.eliminado) {
                    claseEliminado = 'table-danger';
                    botones = '<button type="button" onclick="EliminarSubrubro(' + subrubro.subrubroID + ',0)" class="btn btn-warning btn-sm">Activar</button>';
                }

                $("#tbody-subrubros").append('<tr class=' + claseEliminado + '>' +
                    '<td>' + subrubro.descripcion + '</td>' +
                    '<td>' + subrubro.rubroNombre + '</td>' +
                    '<td class="text-center">' +
                    botones +
                    '</td>' +
                    '</tr>');
            });
        },
        error: function (data) {
        }
    });
}

function AbrirModal() {
    $("#Titulo-Modal-Subrubro").text("Nuevo Subrubro");
    $("#SubrubroID").val(0);
    $("#exampleModal").modal("show");
}

function VaciarFormulario() {
    $("#SubrubroID").val(0);
    $("#SubrubroNombre").val('');
    $("#Error-SubrubroNombre").text("");
}


function GuardarSubrubro() {
    $("#Error-SubrubroNombre").text("");
    let subrubroID = $("#SubrubroID").val();
    let rubroID = $("#RubroID").val();
    let subrubroNombre = $("#SubrubroNombre").val().trim();

    if (subrubroNombre != "" && subrubroNombre != null) {
        $.ajax({
            type: "POST",
            url: '../../Subrubros/GuardarSubrubro',
            data: { SubrubroID: subrubroID, Descripcion: subrubroNombre, RubroID: rubroID },
            success: function (resultado) {
                if (resultado == 0) {
                    $("#exampleModal").modal("hide");
                    CompletarTablaSubrubros();
                }
                if (resultado == 2) {
                    $("#Error-SubrubroNombre").text("El Subrubro ingresado ya existe.");
                }
            },
            error: function (data) {
            }
        });
    }
    else {
        $("#Error-SubrubroNombre").text("Debe ingresar un Nombre.");
    }
}

function BuscarSubRubro(subRubroID) {
    $("#Titulo-Modal-Subrubro").text("Editar Subrubro");
    $("#SubrubroID").val(subRubroID);
    $.ajax({
        type: "POST",
        url: '../../Subrubros/BuscarSubrubro',
        data: { SubrubroID: subRubroID },
        success: function (subrubro) {
            $("#SubrubroNombre").val(subrubro.descripcion);
            $("#RubroID").val(subrubro.rubroID);
            $("#exampleModal").modal("show");
        },
        error: function (data) {
        }
    });
}

function EliminarSubrubro(subrubroID, elimina) {
    $.ajax({
        type: "POST",
        url: '../../Subrubros/EliminarSubrubro',
        data: { SubrubroID: subrubroID, Elimina: elimina },
        success: function (resultado) {
            if (resultado == 0) {
                CompletarTablaSubrubros();
            }
            else {
                alert("No se puede eliminar porque contiene artículos activos.");
            }
        },
        error: function (data) {
        }
    });
}