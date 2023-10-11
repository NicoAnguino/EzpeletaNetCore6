
window.onload = CompletarGrafico();

var myLineChart; // Declara una variable global para el gráfico
var myPieChart;

$("#TipoEjercicioFisicoID, #MesActividadBuscar, #AnioActividadBuscar").change(function () {
    myLineChart.destroy();
    myPieChart.destroy();
    CompletarGrafico();
});

function CompletarGrafico() {
    let tipoEjercicioFisicoID = $("#TipoEjercicioFisicoID").val();
    let mesBuscar = $("#MesActividadBuscar").val();
    let anioActividadBuscar = $("#AnioActividadBuscar").val();
    $.ajax({
        type: "POST",
        url: '../../EjerciciosFisicos/BuscarEjerciciosFisicos2',
        data: { Mes: mesBuscar, Anio: anioActividadBuscar, TipoEjercicioFisicoID: tipoEjercicioFisicoID },
        success: function (vistaSumaEjercicioFisico) {



            // var totalidadMinutos = 0;
            // var diasConEjercicios = 0;
            // var diasSinEjercicios = 0;
            var labels = [];
            var data = [];
            $.each(vistaSumaEjercicioFisico.diasEjercicios, function (index, ejercicio) {
                //totalidadMinutos += ejercicio.cantidadMinutos;
                labels.push(ejercicio.mes + " " + ejercicio.dia);
                data.push(ejercicio.cantidadMinutos);
                // if(ejercicio.cantidadMinutos == 0){
                //     diasSinEjercicios += 1;
                // }
                // else{
                //     diasConEjercicios += 1;
                // }
            });


            $("#texto-card-total-ejercicios").text("Totalidad de Actividad Física: " + vistaSumaEjercicioFisico.totalidadMinutos + " Minutos en " + vistaSumaEjercicioFisico.totalidadDiasConEjercicio + " Días");
            $("#texto-card-sin-ejercicios").text("Sin Actividad Física: " + vistaSumaEjercicioFisico.totalidadDiasSinEjercicio + " Días.");

            // Set new default font family and font color to mimic Bootstrap's default styling
            Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
            Chart.defaults.global.defaultFontColor = '#292b2c';

            // Area Chart Example
            var ctx = document.getElementById("myAreaChart");
            //myLineChart.destroy();
            myLineChart = new Chart(ctx, {
                type: 'line',
                data: {
                    labels: labels,
                    datasets: [{
                        label: "Sessions",
                        lineTension: 0.3,
                        backgroundColor: "rgba(2,117,216,0.2)",
                        borderColor: "rgba(2,117,216,1)",
                        pointRadius: 5,
                        pointBackgroundColor: "rgba(2,117,216,1)",
                        pointBorderColor: "rgba(255,255,255,0.8)",
                        pointHoverRadius: 5,
                        pointHoverBackgroundColor: "rgba(2,117,216,1)",
                        pointHitRadius: 50,
                        pointBorderWidth: 2,
                        data: data,
                    }],
                },
                options: {
                    scales: {
                        xAxes: [{
                            time: {
                                unit: 'date'
                            },
                            gridLines: {
                                display: false
                            },
                            ticks: {
                                maxTicksLimit: 7
                            }
                        }],
                        yAxes: [{
                            ticks: {
                                min: 0,
                                //max: 40000,
                                maxTicksLimit: 5
                            },
                            gridLines: {
                                color: "rgba(0, 0, 0, .125)",
                            }
                        }],
                    },
                    legend: {
                        display: false
                    }
                }
            });

         
            GraficoTorta();
        },
        error: function (data) {
        }
    });
}

function aleatorio(inferior, superior) {
    let numPosibilidades = superior - inferior;
    let aleatorio = Math.random() * numPosibilidades;
    aleatorio = Math.floor(aleatorio);
    return parseInt(inferior) + aleatorio;
}

function colorAleatorio() {
    let hexadecimal = new Array("0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F")
    let color_aleatorio = "#";
    for (i = 0; i < 6; i++) {
      let posarray = aleatorio(0, hexadecimal.length)
      color_aleatorio += hexadecimal[posarray]
    }
    return color_aleatorio
}

function GraficoTorta(){

    let mesBuscar = $("#MesActividadBuscar").val();
    let anioActividadBuscar = $("#AnioActividadBuscar").val();
    $.ajax({
        type: "POST",
        url: '../../EjerciciosFisicos/GraficoTortaTipoActividades',
        data: {Mes: mesBuscar, Anio: anioActividadBuscar},
        success: function (vistaTipoEjercicioFisico) {
           
            var labels = [];
            var data = [];
            var fondo = [];
            $.each(vistaTipoEjercicioFisico, function (index, tipoEjercicio) {

                labels.push(tipoEjercicio.descripcion);
                var color = colorAleatorio();
                fondo.push(color);
                data.push(tipoEjercicio.cantidadMinutos);

            });


            var ctxPie = document.getElementById("myPieChart");
            myPieChart = new Chart(ctxPie, {
                type: 'pie',
                data: {
                    labels: labels,
                    datasets: [{
                        data: data,
                        backgroundColor: fondo,
                    }],
                },
            });
        },
        error: function (data) {
        }
    });
    
   

  
}


