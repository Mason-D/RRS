    var ShowReapeatWeeks = false;

$(() => {


    //check which days of the week are selected and return to controller
    $('#day-of-week-container').find('.btn-check').change(e => {
        let selectedDays = []

        for (let cb of $('#day-of-week-container').find(':checked')) {
            selectedDays.push($(cb).data('day'));
        }
        $("#SelectedDays").val(selectedDays);
        console.log("test")

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
        console.log(e.target.value)

    });




    //select the repeate sitting buttons and toggle for the selected day 

    $('#StartTime').change(function (e) {
        let startDate = new Date(e.target.value)
        
        let selectedDay = startDate.toLocaleDateString('en-us', {weekday: 'long'})
        $("#day-of-week-container").find(`:checked`).prop("checked", false);
        $("#day-of-week-container").find(`#cb-day-${selectedDay}`).prop("checked", "checked");

        //add display in a better way like duration 

    });


    //create a display that show the duration in a more readable way 

    $("#Duration").change(function (e) { 

        // console.log($("#StartTime").val());

        if($("#StartTime").val() != "")
        {   
           console.log(e.target.value)
        }
        
    });


});


DisplayDuration = () => {
    console.log("yeet");
}