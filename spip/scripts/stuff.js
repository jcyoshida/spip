

    $(".click-row").click(function () {
        window.document.location = $(this).data("href");
    });
    $("#goals").change(function () {
        $("#objectives").load("getObj.php?choice=" + $("#goals").val());
    });
    $("#objectives").change(function () {
        $("#strategies").load("getStrat.php?ochoice=" + $("#objectives").val());
    });
