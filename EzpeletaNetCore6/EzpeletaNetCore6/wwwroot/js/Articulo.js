function CompletarTablaArticulos() {
    VaciarFormulario();
    $.ajax({
        type: "POST",
        url: '../../Articulos/BuscarArticulos',
        data: {},
        success: function (listadoArticulos) {
            $("#tbody-articulos").empty();
            $.each(listadoArticulos, function (index, articulo) {

                let claseEliminado = '';
                let botones = '<button type="button" onclick="BuscarArticulo(' + articulo.articuloID + ')" class="btn btn-primary btn-sm" style="margin-right:5px">Editar</button>' +
                    '<button type="button" onclick="EliminarArticulo(' + articulo.articuloID + ',1)" class="btn btn-danger btn-sm">Eliminar</button>';

                if (articulo.eliminado) {
                    claseEliminado = 'table-danger';
                    botones = '<button type="button" onclick="EliminarArticulo(' + articulo.articuloID + ',0)" class="btn btn-warning btn-sm">Activar</button>';
                }

                $("#tbody-articulos").append('<tr class=' + claseEliminado + '>' +
                    '<td>' + articulo.descripcion + '</td>' +
                    '<td>' + articulo.rubroNombre + '</td>' +
                    '<td>' + articulo.subrubroNombre + '</td>' +
                    '<td class="text-center">' + articulo.ultActString + '</td>' +
                    '<td class="text-right">$' + articulo.precioCosto.toFixed(2) + '</td>' +
                    '<td class="text-right">' + articulo.porcentajeGanancia.toFixed(2) + '%</td>' +
                    '<td class="text-right">$' + articulo.precioVenta.toFixed(2) + '</td>' +
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
    $("#Titulo-Modal-Articulo").text("Nuevo Articulo");
    $("#ArticuloID").val(0);
    $("#exampleModal").modal("show");
}

function VaciarFormulario() {
    $("#ArticuloID").val(0);
    $("#ArticuloNombre").val('');
    $("#Error-ArticuloNombre").text("");
    $("#Error-SubrubroID").text("");
    $("#RubroID").val(0);
    $("#SubrubroID").val(0);
    $("#PrecioCosto").val(0);
    $("#PorcentajeGanancia").val(0);
    $("#PrecioVenta").val(0);
 
}


function CalcularImportes(origen) {
    let costo = $("#PrecioCosto").val();
    costo = costo.replace(/\,/g, "");
    costo = parseFloat(costo);

    let ganancia = $("#PorcentajeGanancia").val();
    ganancia = ganancia.replace(/\,/g, "");
    ganancia = parseFloat(ganancia);

    let venta = $("#PrecioVenta").val();
    venta = venta.replace(/\,/g, "");
    venta = parseFloat(venta);

    //SI MODIFICA PRECIO DE COSTO O EL PORCENTAJE DE GANANCIA
    if (origen == 1 || origen == 2) {
        //CALCULAR SOLO EL PRECIO DE VENTA
        venta = costo + (costo * (ganancia / 100));
        $("#PrecioVenta").val(venta.toFixed(2));
    }

    //SI MODIFICA PRECIO DE VENTA
    if (origen == 3) {
        //calcular ganancia
        ganancia = venta * 100 / costo - 100;
        $("#PorcentajeGanancia").val(ganancia.toFixed(2));
    }
}

$("#RubroID").change(function () {
    BuscarSubRubros();
});

function BuscarSubRubros() {
    //Se limpia el contenido del dropdownlist
    $("#SubrubroID").empty();
    let rubroID = $("#RubroID").val();
    $.ajax({
        type: 'POST',
        //Llamado al metodo en el controlador
        url: "../../Subrubros/ComboSubRubro",
        dataType: 'json',
        //Parametros que se envian al metodo del controlador
        data: { id: rubroID },
        //En caso de resultado exitoso
        success: function (subRubros) {

            if (rubroID == 0) {
                $("#SubrubroID").append('<option value="' + "0" + '">' + "[SELECCIONE UN RUBRO]" + '</option>');
            }
            else {
                if (subRubros.length == 0) {
                    $("#SubrubroID").append('<option value="' + "0" + '">' + "[NO EXISTEN SUBRUBROS]" + '</option>');
                }
                else {
                    $.each(subRubros, function (i, subRubro) {
                        $("#SubrubroID").append('<option value="' + subRubro.value + '">' +
                            subRubro.text + '</option>');
                    });
                }
            }   
        },
        ////Mensaje de error en caso de fallo
        error: function (ex) {
        }
    });
    return false;
}

function GuardarArticulo() {
    $("#Error-ArticuloNombre").text("");
    $("#Error-SubrubroID").text("");
    let articuloID = $("#ArticuloID").val();
    let articuloNombre = $("#ArticuloNombre").val().trim();
    let subrubroID = $("#SubrubroID").val();
    let costo = $("#PrecioCosto").val();
    let ganancia = $("#PorcentajeGanancia").val();
    let venta = $("#PrecioVenta").val();

    let guardar = true;
    if (articuloNombre == "" || articuloNombre == null) {
        guardar = false;
        $("#Error-ArticuloNombre").text("Debe ingresar un Nombre.");
    }
    if (subrubroID == 0) {
        guardar = false;
        $("#Error-SubrubroID").text("Debe seleccionar un Subrubro.");
    }
    if (guardar) {
        $.ajax({
            type: "POST",
            url: '../../Articulos/GuardarArticulo',
            data: {
                ArticuloID: articuloID, Descripcion: articuloNombre,
                SubrubroID: subrubroID, Costo: costo,
                Ganancia: ganancia, Venta: venta
            },
            success: function (resultado) {
                if (resultado == 0) {
                    $("#exampleModal").modal("hide");
                    CompletarTablaArticulos();
                }
            },
            error: function (data) {
            }
        });
    }
   
}

function BuscarArticulo(articuloID) {
    $("#Titulo-Modal-Articulo").text("Editar Articulo");
    $("#ArticuloID").val(articuloID);
    $.ajax({
        type: "POST",
        url: '../../Articulos/BuscarArticulo',
        data: { ArticuloID: articuloID },
        success: function (articulo) {
            $("#ArticuloNombre").val(articulo.descripcion);
            $("#RubroID").val(articulo.rubroID);
            BuscarSubRubros();
           
            $("#PrecioCosto").val(articulo.precioCosto.toFixed(2));
            $("#PorcentajeGanancia").val(articulo.porcentajeGanancia.toFixed(2));
            $("#PrecioVenta").val(articulo.precioVenta.toFixed(2));
            $("#SubrubroID").val(articulo.subrubroID);
            $("#exampleModal").modal("show");
        },
        error: function (data) {
        }
    });
}