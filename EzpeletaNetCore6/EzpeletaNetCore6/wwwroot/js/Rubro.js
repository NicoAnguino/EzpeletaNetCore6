

function CompletarTablaRubros() {
    VaciarFormulario();
    $.ajax({
        type: "POST",
        url: '../../Rubros/BuscarRubros',
        data: {},
        success: function (listadoRubros) {
            $("#tbody-rubros").empty();
            $.each(listadoRubros, function (index, rubro) {

                let claseEliminado = '';
                let botones = '<button type="button" onclick="BuscarRubro(' + rubro.rubroID + ')" class="btn btn-primary btn-sm" style="margin-right:5px">Editar</button>' +
                    '<button type="button" onclick="EliminarRubro(' + rubro.rubroID + ',1)" class="btn btn-danger btn-sm">Eliminar</button>';

                if (rubro.eliminado) {
                    claseEliminado = 'table-danger';
                    botones = '<button type="button" onclick="EliminarRubro(' + rubro.rubroID + ',0)" class="btn btn-warning btn-sm">Activar</button>';
                }

                $("#tbody-rubros").append('<tr class=' + claseEliminado + '>' +
                    '<td>' + rubro.descripcion + '</td>' +
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
    $("#Titulo-Modal-Rubro").text("Nuevo Rubro");
    $("#RubroID").val(0);
    $("#exampleModal").modal("show");
}

function GuardarRubro() {
    $("#Error-RubroNombre").text("");

    let url = "../../Rubros/GuardarRubro";
    var parametros = new FormData($("#frmFormulario")[0]);

    let rubroNombre = $("#RubroNombre").val().trim();

    if (rubroNombre != "" && rubroNombre != null) {
        $.ajax({
            type: "POST",
            url: url,
            data: parametros,
            contentType: false, //importante enviar este parametro en false
            processData: false, //importante enviar este parametro en false
            success: function (resultado) {
                if (resultado == 0) {
                    $("#exampleModal").modal("hide");
                    CompletarTablaRubros();
                }
                if (resultado == 2) {
                    $("#Error-RubroNombre").text("El Rubro ingresado ya existe.");
                }
            },
            error: function (r) {

                alert("Error del servidor");
            }
        });
    }
    else {
        $("#Error-RubroNombre").text("Debe ingresar un Nombre.");
    }
}


function BuscarRubro(rubroID) {
    $("#Titulo-Modal-Rubro").text("Editar Rubro");
    $("#RubroID").val(rubroID);
    $.ajax({
        type: "POST",
        url: '../../Rubros/BuscarRubro',
        data: { RubroID: rubroID },
        success: function (rubro) {
            $("#RubroNombre").val(rubro.descripcion);
            $("#exampleModal").modal("show");
        },
        error: function (data) {
        }
    });
}

function VaciarFormulario() {
    $("#RubroID").val(0);
    $("#RubroNombre").val('');
    $("#Error-RubroNombre").text("");
}

function EliminarRubro(rubroID,elimina) {
    $.ajax({
        type: "POST",
        url: '../../Rubros/EliminarRubro',
        data: { RubroID: rubroID, Elimina: elimina },
        success: function (resultado) {          
            if (resultado == 0) {
                CompletarTablaRubros();
            }
            else {
                alert("No se puede eliminar porque contiene subrubros activos.");
            }
        },
        error: function (data) {
        }
    });
}
