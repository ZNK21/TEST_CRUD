$(function () {

    numeral.locale('es');

    $("#crear").click(function () {
    //    $("#newModal").modal("show");



        $.ajax({
            url: "/Games/NuevoDrop",
            async: true,
            success: function (res) {

                $("<div class='modal fade' id='modalGames'></div>").prependTo(".container");
                $("#modalGames").modal("show").html(res);
                cargaCategorias();
                cargaPlataforms();

                $("#cancelar").click(function () {
                    $("#modalGames").remove();
                    $(".modal-backdrop").removeClass("show").addClass("hide");
                    $(".modal-backdrop").remove();
                })
            },
            error: function () {

            }
        })
    });
    $("#cancelar").click(function () {
        $("#newModal").modal("hide");
    });
    $("#guardar").click(function () {

        var _name = $("#name").val();
        var _date = $("#date").val();
        var _genre = $("#genre").val();
        var _price = parseFloat($("#price").val());

        var _games = {
            gameName: _name,
            launchDate: _date,
            genre: _genre,
            price: _price
        }

        $.ajax({
            type: "POST", //Metodo
            url: "/Games/Nuevo", // --> Controlador/acción
            cache: false,
            data: _games, //datos a enviar
            success: function (res) {
                if (res.status) {
                    alert("Juego registrado correctamente.");

                    setTimeout(() => {
                        location.href = "/Games/"
                    }, 1500)


                } else {
                    if ($("#name").val() === "" || null) { $("#name").addClass("red_border"); alert("El nombre es obligatorio")}
                    if ($("#price").val() === "" || null) { $("#price").addClass("red_border"); alert("El precio es obligatorio") }

                }


            },
            error: function () {
            }
        })

    });

    $("[id^=editar_]").click(function () {

        var id = $(this).attr("id").replace("editar_", "");

        $.ajax({
            type: "POST",
            url: "/Games/Editar",
            data: { gameID: id },
            async: true,
            success: function (result) {

                $("<div class='modal fade' id='modalEditar'></div>").prependTo(".container");
                $("#modalEditar").modal("show").html(result);

                $("#cancelaredit").click(function () {
                    $("#modalEditar").remove();
                    $(".modal-backdrop").removeClass("show").addClass("hide");
                    $(".modal-backdrop").remove();


                })

            },
            error: function (result) {

            }
        })

    });

    $("[id^=eliminar_]").click(function () {

        var id = $(this).attr("id").replace("eliminar_", "");
        if (confirm("¿Esta seguro de querer eliminar este registro?")) {
            $.ajax({
                type: "POST",
                url: "/Games/Eliminar",
                data: { gameId: id },
                async: true,
                success: function (res) {
                    if (res.status) {
                        alert("Registro eliminado correctamente");

                        setTimeout(() => {
                            location.href = "/Games/"
                        }, 1500)

                    }
                },
                error: function () {

                }
            })
        }

    });

    $("[id^=fecha_]").each(function () {
        var id = $(this).attr("id").replace("fecha_", "");
        var fecha = ($("#fecha_" + id).data("valor"))
        $("#fecha_" + id).text(moment(fecha, "YYYY-MM-DD HH:mm:ss:sss").format("DD-MM-YYYY"))
    });

    $("[id^=moneda_]").each(function () {

        var id = $(this).attr("id").replace("moneda_", "");
        var moneda = $("#moneda_" + id).data("valor");
        $("#moneda_" + id).text(numeral(moneda).format('0,0'));

    })
})

function cargaCategorias() {

    $.ajax({
        type: "GET",
        url: "/Games/GetCategorias",
        async: true,
        success: function (res) {
            var combo = $("#dropdown");
            $.each(res, function (index, data) {
                $("<option value='" + data.genreID + "'>" + data.genre + "</option>").appendTo(combo);
            })

        },
        error: function (){


        }
    })
}

function cargaPlataforms() {

    $.ajax({
        type: "GET",
        url: "/Games/GetPlatforms",
        async: true,
        success: function (res) {
            var combo2 = $("#dropdown2");
            $.each(res, function (index, data) {
                $("<option value='" + data.platformID + "'>" + data.platform + "</option>").appendTo(combo2);
            })

        },
        error: function () {


        }
    })
}