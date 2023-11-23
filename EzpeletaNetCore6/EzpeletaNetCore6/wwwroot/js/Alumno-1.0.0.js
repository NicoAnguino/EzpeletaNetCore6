

function CompletarTabla() {
    VaciarFormulario();
    $.ajax({
        type: "POST",
        url: '../../Alumnos/BuscarAlumnos',
        data: {},
        success: function (listadoAlumnos) {
            $("#tbody-alumnos").empty();
            $.each(listadoAlumnos, function (index, alumno) {

                let claseEliminado = '';
                let botones = '<button type="button" onclick="BuscarAlumno(' + alumno.alumnoID + ')" class="btn btn-primary btn-sm" style="margin-right:5px">Editar</button>' +
                    '<button type="button" onclick="EliminarAsignatura(' + alumno.alumnoID + ')" class="btn btn-danger btn-sm">Desactivar</button>';

                $("#tbody-alumnos").append('<tr class=' + claseEliminado + '>' +
                    '<td>' + alumno.nombre + '</td>' +
                    '<td>' + alumno.nombreCarrera + '</td>' +
                    '<td>' + alumno.dni + '</td>' +
                    '<td>' + alumno.email + '</td>' +
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
    $("#Titulo-Modal").text("Nuevo Alumno");
    $("#AlumnoID").val(0);
    $("#CarreraID").val(0);
    $("#ModalAltaModificacion").modal("show");
}

function CerrarModal() {
    VaciarFormulario();
    $("#ModalAltaModificacion").modal("hide");
}

function GuardarRegistro() {
    $("#Error-Nombre").text("");

    let url = "../../Alumnos/GuardarAlumno";
   
    let carreraID = $("#CarreraID").val();
    let alumnoNombre = $("#AlumnoNombre").val().trim();
    let nacimiento = $("#Nacimiento").val();
    let direccion = $("#Direccion").val().trim();
    let email = $("#Email").val().trim();
    let dNI = $("#DNI").val();
    let alumnoID = $("#AlumnoID").val();

    let registrar = true;
    if (alumnoNombre == ""){
        $("#Error-Nombre").text("Debe ingresar un Nombre.");
        registrar = false;
    }
    if (dNI == 0){
        $("#Error-DNI").text("Debe ingresar un DNI.");
        registrar = false;
    }

    if (registrar) {
        $.ajax({
            type: "POST",
            url: url,
            data: { AlumnoID:alumnoID, Nombre: alumnoNombre, FechaNacimiento: nacimiento,CarreraID: carreraID,
                Email: email, DNI: dNI, Direccion: direccion},
            success: function (resultado) {
                if (resultado) {
                    $("#ModalAltaModificacion").modal("hide");
                    CompletarTabla();
                }
                else {
                    $("#Error-Nombre").text("El alumno ingresado ya existe.");
                }
            },
            error: function (r) {

                alert("Error del servidor");
            }
        });
    }
}


function BuscarAlumno(alumnoID) {
    $("#Titulo-Modal").text("Editar Alumno");
    $("#AlumnoID").val(alumnoID);
    $.ajax({
        type: "POST",
        url: '../../Alumnos/BuscarAlumnos',
        data: { AlumnoID: alumnoID },
        success: function (alumnos) {
            let alumno = alumnos[0];
            $("#AlumnoNombre").val(alumno.nombre);
           
            $("#Nacimiento").val(alumno.fechaNacimientoStringInput);
            $("#Direccion").val(alumno.direccion);
            $("#Email").val(alumno.email);
            $("#DNI").val(alumno.dni);
            $("#CarreraID").val(alumno.carreraID);
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
