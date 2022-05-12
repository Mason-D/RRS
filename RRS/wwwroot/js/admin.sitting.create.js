    var ShowReapeatDays = false;
    var ShowReapeatWeeks = false;




$(() => {

    $('#day-of-week-container').find('.btn-check').change(e => {

        console.log('selected days')
        for (let cb of $('#day-of-week-container').find(':checked')) {
            console.log($(cb).data('day'));
        }
      

    }); 

    //Show and Hide Toggle for new Sitting Type

    $("#NewSittingArea").hide();
    $("#RepeatWeeksContainer").hide();
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
   

    //Show Repeat Weeks
    $("#RepeatSittingBtnWeeks").click(function () {
        if (ShowReapeatDays) {
            $("#RepeatDaysInput").val(null);
            $("#RepeatDaysContainer").hide();
            ShowReapeatDays = false
        }
        if (!ShowReapeatWeeks) {
            $("#RepeatWeeksContainer").show();
            ShowReapeatWeeks = true;
            $("#Group").val("Weeks");
        }
        else if (ShowReapeatWeeks) {
            $("#RepeatWeeksContainer").hide();
            ShowReapeatWeeks = false;
            $("#Group").val(null);
        }
    });

    //Show Repeat Days
    $("#RepeatSittingBtnDays").click(function () {
        if (ShowReapeatWeeks) {
            $("#RepeatWeeksInput").val(null);
            $("#RepeatWeeksContainer").hide();
            ShowReapeatWeeks = false;
        }
        if (!ShowReapeatDays) {
            $("#RepeatDaysContainer").show();
            ShowReapeatDays = true
            $("#Group").val("Days");
        }
        else if (ShowReapeatDays) {
            $("#RepeatDaysContainer").hide();
            ShowReapeatDays = false
            $("#Group").val(null);
        }
    });


    $("#RepeatDaysInput").change(function (e) {
        $("#DaysToRepeat").val(e.target.value);
    });

    $

    $("#RepeatWeeksInput").change(function (e) {
        $("#WeeksToRepeat").val(e.target.value);
    });





    $('#StartTime').change(function (e) {

        let startDate = new Date(e.target.value)
        console.log(startDate)

    });


    $("#btn-check-Sunday").click(function (e) {
        console.log(e.target.value)
    });



});
