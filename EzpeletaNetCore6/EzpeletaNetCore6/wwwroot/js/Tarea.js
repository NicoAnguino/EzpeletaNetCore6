function CompletarTabla() {
    VaciarFormulario();
    $.ajax({
        type: "POST",
        url: '../../Tareas/BuscarTareas',
        data: { ArticuloID: 0 },
        success: function (listadoTaras) {
            $("#tbody-tareas").empty();
            $("#tbody-tareas-imprimir").empty();
            $.each(listadoTaras, function (index, tarea) {

                let claseEliminado = '';
                let realizada = "REALIZADA";
                let botones = '';

                if (!tarea.realizada) { 
                    realizada = "PENDIENTE";              
                    botones += 
                    '<button type="button" onclick="BuscarTarea(' + tarea.tareaID + ')" class="btn btn-primary btn-sm" style="margin-right:10px">...</button>' +
                    '<button type="button" onclick="MarcarRealizada(' + tarea.tareaID + ')" class="btn btn-success btn-sm" style="margin-right:10px">~</button>';
                }
                else{
                    claseEliminado = 'table-success';
                }

                botones += '<button type="button" onclick="EliminarTarea(' + tarea.tareaID + ')"  class="btn btn-danger btn-sm">X</button>';
             
                $("#tbody-tareas").append('<tr class=' + claseEliminado + '>' +
                    '<td class="text-center">' + tarea.fechaString + '</td>' +
                    '<td>' + tarea.descripcion + '</td>' +
                    '<td class="text-center">' + tarea.prioridadString + '</td>' +
                    '<td class="text-center">' + realizada + '</td>' +
                    '<td class="text-center">' +
                    botones +
                    '</td>' +
                    '</tr>');

                    $("#tbody-tareas-imprimir").append('<tr>' +
                    '<td>' + tarea.fechaString + '</td>' +
                    '<td>' + tarea.descripcion + '</td>' +
                    '<td>' + tarea.prioridadString + '</td>' +
                    '<td>' + realizada + '</td>' +
                    '</tr>');
            });
        },
        error: function (data) {
        }
    });
}


function AbrirModal() {
    $("#Titulo-Modal-Tarea").text("Nueva Tarea");
    $("#TareaID").val(0);
    $("#exampleModal").modal("show");
}

function CerrarModal() {
    VaciarFormulario();
    $("#exampleModal").modal("hide");
}

function VaciarFormulario() {
    $("#TareaID").val(0);
    $("#Descripcion").val('');
    $("#Error-Descripcion").text("");
    $("#Error-Fecha").text("");
 }

function Guardar() {
    $("#Error-Descripcion").text("");
    $("#Error-Fecha").text("");
    let tareaID = $("#TareaID").val();
    let descripcion = $("#Descripcion").val();
    let fecha = $("#Fecha").val();
    let prioridad = $("#Prioridad").val();

    let guardar = true;
    if (descripcion == "" || descripcion == null) {
        guardar = false;
        $("#Error-Descripcion").text("Debe ingresar una Descripcion.");
    }
    if (guardar) {

      
        $.ajax({
            type: "POST",
            url: '../../Tareas/GuardarTarea',
            data: {
                TareaID: tareaID, Fecha:fecha, 
                Descripcion: descripcion, Prioridad: prioridad
            },
         
          
            success: function (resultado) {
                if (resultado == 0) {
                    $("#exampleModal").modal("hide");
                    CompletarTabla();
                }
            },
            error: function (data) {
            }
        });
    }
   
}

 function BuscarTarea(tareaID) {
     $("#Titulo-Modal-Tarea").text("Editar Tarea");
     $("#TareaID").val(tareaID);
     $.ajax({
         type: "POST",
         url: '../../Tareas/BuscarTareas',
         data: { TareaID: tareaID },
         success: function (tareas) {

            if(tareas.length > 0){
                var tarea = tareas[0];
                $("#Descripcion").val(tarea.descripcion);
                $("#Fecha").val(tarea.fechaStringInput);
             
              
              
                $("#Priridad").val(tarea.prioridad);
                $("#exampleModal").modal("show");
            }
            
         },
         error: function (data) {
         }
     });
}


function MarcarRealizada(tareaID) {
    $.ajax({
        type: "POST",
        url: '../../Tareas/MarcarRealizada',
        data: { TareaID: tareaID },
        success: function (resultado) {
            CompletarTabla();
        },
        error: function (data) {
        }
    });
}

 function EliminarTarea(tareaID) {
     $.ajax({
         type: "POST",
         url: '../../Tareas/EliminarTarea',
         data: { TareaID: tareaID },
         success: function (resultado) {
             CompletarTabla();
         },
         error: function (data) {
         }
     });
 }