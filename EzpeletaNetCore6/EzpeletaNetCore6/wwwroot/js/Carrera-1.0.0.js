

function CompletarTabla() {
    VaciarFormulario();
    $.ajax({
        type: "POST",
        url: '../../Carreras/BuscarCarreras',
        data: {},
        success: function (listadoCarreras) {
            $("#tbody-carreras").empty();
            $.each(listadoCarreras, function (index, carrera) {

                let claseEliminado = '';
                let botones = '<button type="button" onclick="BuscarCarrera(' + carrera.carreraID + ')" class="btn btn-primary btn-sm" style="margin-right:5px">Editar</button>' +
                    '<button type="button" onclick="EliminarCarrera(' + carrera.carreraID + ')" class="btn btn-danger btn-sm">Desactivar</button>';

                $("#tbody-carreras").append('<tr class=' + claseEliminado + '>' +
                    '<td>' + carrera.nombre + '</td>' +
                    '<td>' + carrera.duracionCarrera + '</td>' +
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
    $("#Titulo-Modal-Carrera").text("Nueva Carrera");
    $("#CarreraID").val(0);
    $("#ModalAltaModificacion").modal("show");
}

function CerrarModal() {
    VaciarFormulario();
    $("#ModalAltaModificacion").modal("hide");
}

function GuardarRegistro() {
    $("#Error-Nombre").text("");

    let url = "../../Carreras/GuardarCarrera";
   
    let carreraID = $("#CarreraID").val();
    let carreraNombre = $("#CarreraNombre").val().trim();
    let duracion = $("#Duracion").val().trim();

    let registrar = true;
    if (carreraNombre == ""){
        $("#Error-Nombre").text("Debe ingresar una Carrera.");
        registrar = false;
    }
    if (duracion == ""){
        $("#Error-Duracion").text("Debe ingresar la duración de la carrera.");
        registrar = false;
    }

    if (registrar) {
        $.ajax({
            type: "POST",
            url: url,
            data: { CarreraID: carreraID, Nombre: carreraNombre, Duracion:duracion },
            success: function (resultado) {
                if (resultado) {
                    $("#ModalAltaModificacion").modal("hide");
                    CompletarTabla();
                }
                else {
                    $("#Error-Nombre").text("La carrera ingresada ya existe.");
                }
            },
            error: function (r) {

                alert("Error del servidor");
            }
        });
    }
}


function BuscarCarrera(carreraID) {
    $("#Titulo-Modal-Carrera").text("Editar Carrera");
    $("#CarreraID").val(carreraID);
    $.ajax({
        type: "POST",
        url: '../../Carreras/BuscarCarreras',
        data: { CarreraID: carreraID },
        success: function (carreras) {
            let carrera = carreras[0];
            $("#CarreraNombre").val(carrera.nombre);
            $("#Duracion").val(carrera.duracionCarrera);
            $("#ModalAltaModificacion").modal("show");
        },
        error: function (data) {
        }
    });
}

function VaciarFormulario() {
    $("#CarreraID").val(0);
    $("#CarreraNombre").val('');
    $("#Duracion").val('');
    $("#Error-Nombre").text("");
    $("#Error-Duracion").text("");
}

function EliminarCarrera(carreraID,elimina) {
    $.ajax({
        type: "POST",
        url: '../../Carreras/EliminarCarrera',
        data: { CarreraID: carreraID },
        success: function (resultado) {          
            if (resultado) {
                CompletarTabla();
            }
            else {
                alert("No se puede eliminar porque contiene asignaturas o alumnos relacionados.");
            }
        },
        error: function (data) {
        }
    });
}
