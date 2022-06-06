    var ShowReapeatWeeks = false;
    var selectedDays = [];

$(() => {


    //check which days of the week are selected and return to controller
    $('#day-of-week-container').find('.btn-check').change(e => {

        for (let cb of $('#day-of-week-container').find(':checked')) {
            selectedDays.push($(cb).data('day'));
        }
        $("#SelectedDays").val(selectedDays);

    }); 

    //Show and Hide Toggle for new Sitting Type
    $("#NewSittingBtn").click(function (e) {
        let btnValue = e.target.value
        if(btnValue === "New")
        {
            $("#NewSittingArea").show();
            $("#SittingTypeSelect").hide();
            e.target.value = 'Back'
        }else{
            $("#NewSittingArea").hide();
            $("#SittingTypeSelect").show();
            $("#NewSittingAreaInput").val("");
            e.target.value = 'New'
        }
    });

    //Toggle Show Repeat Weeks
    $("#RepeatSittingBtnWeeks").click(function () {
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

    $("#EndDateInput").change(function (e) {
        $("#EndDate").val(e.target.value);

    });
    //select the repeate sitting buttons and toggle for the selected day 

    $('#StartTime').change(function (e) {
        let startDate = new Date(e.target.value)
        
        let selectedDay = startDate.toLocaleDateString('en-us', {weekday: 'long'})
        $("#day-of-week-container").find(`:checked`).prop("checked", false);
        $("#day-of-week-container").find(`#cb-day-${selectedDay}`).prop("checked", "checked");
        selectedDays = [selectedDay];
        $("#SelectedDays").val(selectedDays);


        //console.log($('#Duration').val());
        if($('#Duration').val() != "")
        {
            let start = new Date(e.target.value)
            let duration = $('#Duration').val();
            DisplayDuration(start, duration);
        }

    });


    $("#Hours").change(function (e) { 
        let hours = e.target.value
        let minutes = $("#Minutes").val();
        $("#Duration").val(CalculateDuration(hours, minutes)).trigger("change");
    });


    $("#Minutes").change(function (e) { 
        let minutes = e.target.value
        let hours = $("#Hours").val();
        $("#Duration").val(CalculateDuration(hours, minutes)).trigger("change");
    });

    //create a display that show the duration in a more readable way 

    $("#Duration").change(function (e) { 

        if($("#StartTime").val() != "")
        {   
            let duration = e.target.value;
            let start = new Date($('#StartTime').val());
            DisplayDuration(start, duration);
        }
        
    });


});



CalculateDuration = (hours, minutes) =>{
    return Number((hours * 60)) + Number(minutes)
}

DisplayDuration = (start, duration ) => {
    let end = new Date(start.getTime() + duration * 60000)


    let endTime = end.toLocaleTimeString()
    let endDate = end.toLocaleDateString("en-au");

    //console.log(end);
    $('#time-container-end').html(`End Time ${endDate} : ${endTime}`);
    $('#display-time-container').show();
}

