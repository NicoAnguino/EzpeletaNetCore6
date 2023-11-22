

function CompletarTabla() {
    VaciarFormulario();
    $.ajax({
        type: "POST",
        url: '../../Asignaturas/BuscarAsignaturas',
        data: {},
        success: function (listadoAsignaturas) {
            $("#tbody-asignaturas").empty();
            $.each(listadoAsignaturas, function (index, asignatura) {

                let claseEliminado = '';
                let botones = '<button type="button" onclick="BuscarAsignatura(' + asignatura.asignaturaID + ')" class="btn btn-primary btn-sm" style="margin-right:5px">Editar</button>' +
                    '<button type="button" onclick="EliminarAsignatura(' + asignatura.asignaturaID + ')" class="btn btn-danger btn-sm">Desactivar</button>';

                $("#tbody-asignaturas").append('<tr class=' + claseEliminado + '>' +
                    '<td>' + asignatura.nombreAsignatura + '</td>' +
                    '<td>' + asignatura.nombreCarrera + '</td>' +
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
    $("#Titulo-Modal-Asignatura").text("Nueva Asignatura");
    $("#AsignaturaID").val(0);
    $("#CarreraID").val(0);
    $("#ModalAltaModificacion").modal("show");
}

function CerrarModal() {
    VaciarFormulario();
    $("#ModalAltaModificacion").modal("hide");
}

function GuardarRegistro() {
    $("#Error-Nombre").text("");

    let url = "../../Asignaturas/GuardarAsignatura";
   
    let carreraID = $("#CarreraID").val();
    let asignaturaNombre = $("#AsignaturaNombre").val().trim();
    let asignaturaID = $("#AsignaturaID").val().trim();

    let registrar = true;
    if (asignaturaNombre == ""){
        $("#Error-Nombre").text("Debe ingresar una Carrera.");
        registrar = false;
    }
    if (carreraID == 0){
        $("#Error-Duracion").text("Debe ingresar la duración de la carrera.");
        registrar = false;
    }

    if (registrar) {
        $.ajax({
            type: "POST",
            url: url,
            data: { AsignaturaID:asignaturaID, CarreraID: carreraID, Nombre: asignaturaNombre },
            success: function (resultado) {
                if (resultado) {
                    $("#ModalAltaModificacion").modal("hide");
                    CompletarTabla();
                }
                else {
                    $("#Error-Nombre").text("La asignatura ingresada ya existe.");
                }
            },
            error: function (r) {

                alert("Error del servidor");
            }
        });
    }
}


function BuscarAsignatura(asignaturaID) {
    $("#Titulo-Modal-Asignatura").text("Editar Asignatura");
    $("#AsignaturaID").val(asignaturaID);
    $.ajax({
        type: "POST",
        url: '../../Asignaturas/BuscarAsignaturas',
        data: { AsignaturaID: asignaturaID },
        success: function (asignaturas) {
            let asignatura = asignaturas[0];
            $("#AsignaturaNombre").val(asignatura.nombreAsignatura);
            $("#CarreraID").val(asignatura.carreraID);
            $("#ModalAltaModificacion").modal("show");
        },
        error: function (data) {
        }
    });
}

function VaciarFormulario() {
    $("#CarreraID").val(0);
    $("#AsignaturaNombre").val('');
    $("#AsignaturaID").val(0);
    $("#Error-Nombre").text("");
}

function EliminarAsignatura(asignaturaID) {
    $.ajax({
        type: "POST",
        url: '../../Asignaturas/EliminarAsignatura',
        data: { AsignaturaID: asignaturaID },
        success: function (resultado) {          
            if (resultado) {
                CompletarTabla();
            }
            else {
                alert("No se puede eliminar porque contiene profesores relacionados.");
            }
        },
        error: function (data) {
        }
    });
}
