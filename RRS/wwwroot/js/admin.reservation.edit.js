$(() => {

    $("#dateControl").on('change', (e) => getSitting(
        e.target.value).then(
            ()=> highlightStart($("#idInput").val())
        )
    );

    getSitting($("#dateControl").val()).then(
        ()=> highlightStart($("#idInput").val())
    );


    $("#sittingsTBody").on('click', 'tr', function (e) {
        // working? I hope
        $('#sittingsTBody').find('.bg-secondary').attr('role', 'button');
        $('#sittingsTBody').find('.bg-secondary').removeClass('bg-secondary');
        $('#sittingsTBody').find('.text-white').removeClass('text-white');
        $(this).addClass('bg-secondary');
        $(this).addClass('text-white');
        $(this).removeAttr('role');

        $("#idInput").val(e.currentTarget.children[0].innerHTML)

        console.log($("#dateControl").val())

        $('#startTime').datepicker('setDate', new Date());
        //$('#startTime').val(new Date);
        $('#startDate')
        console.log($('#startTime'))
    });



});

function resTimesToList() {

}


function highlightStart(id){
    $('#sittingsTBody').find(`#STB${id}`).addClass('bg-secondary');
    $('#sittingsTBody').find(`#STB${id}`).addClass('text-white');
    $('#sittingsTBody').find(`#STB${id}`).removeAttr('role');
}

async function getSitting(newDate) {


    //Sittings by selected day
    await $.get(`https://localhost:7271/api/Sittings/any/${newDate}`, null, function (data) {

        $("#sittingsTBody").empty();

        data.forEach((item) => {

            $("#sittingsTBody").append(

                `<tr 
                    id="STB${item.id}"
                    role="button"
                    data-reservation-start="${item.start}"
                    data-reservation-duration="${item.duration}"
                >
                    <td>${item.id}</td>
                    <td>${formatTime(item.start)}</td>
                    <td>${formatTime(item.start,item.duration)}</td>
                    <td>${item.totalGuests}/${item.capacity}</td>
                    <td>${item.isOpen}</td>
                    <td>${item.sittingTypeDescription}</td>
                </tr>`
            );
        })

    });
}

function formatTime(dateString, addMins) {
    let date = new Date(dateString)
    if (addMins) {
        date.setMinutes(date.getMinutes() + addMins);
    }
    let hours = date.getHours() % 12 || 12;
    let mins = date.getMinutes();
    let ampm = date.getHours() < 12 ? "AM" : "PM";
    return `${hours}:${mins<=9?'0'+mins:mins} ${ampm}`;
}
