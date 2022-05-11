

$(function () {

    //Show and Hide Toggle for new Sitting Type

    $("#NewSittingArea").hide();
    $("#RepeatDaysContainer").hide();


    //Show and Hide Toggle for new Sitting Type
    $("#NewSittingBtn").click(function () {

        $("#NewSittingArea").show();
        $("#SittingTypeSelect").hide();

    });
    $("#OldSittingBtn").click(function () {
        $("#NewSittingAreaInput").val(null);
        $("#NewSittingArea").hide();
        $("#SittingTypeSelect").show();
    });
    //Show Repeat Days 
    $("#RepeatSittingBtn").click(function () {
        $("#RepeatDaysContainer").show();
    });

    $('#StartTime').change(function (e) {

        let startDate = new Date(e.target.value)
               

    });



});
