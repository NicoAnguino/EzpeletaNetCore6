

function CompletarTabla() {
    VaciarFormulario();
    $.ajax({
        type: "POST",
        url: '../../Profesores/BuscarProfesores',
        data: {},
        success: function (listadoProfesores) {
            $("#tbody-profesores").empty();
            $.each(listadoProfesores, function (index, profesor) {

                let claseEliminado = '';
                let botones = '<button type="button" onclick="BuscarAlumno(' + profesor.profesorID + ')" class="btn btn-primary btn-sm" style="margin-right:5px">Editar</button>' +
                    '<button type="button" onclick="EliminarAlumno(' + profesor.profesorID + ')" class="btn btn-danger btn-sm">Desactivar</button>';

                $("#tbody-profesores").append('<tr class=' + claseEliminado + '>' +
                    '<td>' + profesor.nombre + '</td>' +
                    '<td>' + profesor.fechaNacimientoString + '</td>' +
                    '<td>' + profesor.dni + '</td>' +
                    '<td>' + profesor.email + '</td>' +
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
    $("#Titulo-Modal").text("Nuevo Profesor");
    $("#ProfesorID").val(0);
    $("#CarreraID").val(0);
    $("#ModalAltaModificacion").modal("show");
}

function CerrarModal() {
    VaciarFormulario();
    $("#ModalAltaModificacion").modal("hide");
}

function GuardarRegistro() {
    $("#Error-Nombre").text("");

    let url = "../../Profesores/GuardarProfesor";
   
    let profesorID = $("#ProfesorID").val();
    let profesorNombre = $("#ProfesorNombre").val().trim();
    let nacimiento = $("#Nacimiento").val();
    let direccion = $("#Direccion").val().trim();
    let email = $("#Email").val().trim();
    let dNI = $("#DNI").val();

    let registrar = true;
    if (profesorNombre == ""){
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
            data: { ProfesorID:profesorID, Nombre: profesorNombre, FechaNacimiento: nacimiento,
                Email: email, DNI: dNI, Direccion: direccion},
            success: function (resultado) {
                if (resultado) {
                    $("#ModalAltaModificacion").modal("hide");
                    CompletarTabla();
                }
                else {
                    $("#Error-Nombre").text("El profesor ingresado ya existe.");
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

function EliminarAlumno(alumnoID) {
    $.ajax({
        type: "POST",
        url: '../../Alumnos/EliminarAlumno',
        data: { AlumnoID: alumnoID },
        success: function (resultado) {          
            if (resultado) {
                CompletarTabla();
            }
            else {
                alert("No se puede eliminar porque contiene datos relacionados.");
            }
        },
        error: function (data) {
        }
    });
}
