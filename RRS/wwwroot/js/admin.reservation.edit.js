$(() => {


    $("#dateControl").on('change', (e) => getSitting(e.target.value));
    getSitting($("#dateControl").val()); 


    $("#sittingsTBody").on('change', "input[type='checkbox']", function (e) {

        $("#sittingsTBody input[type='checkbox']").not(e.target).prop('checked', false);

        $("#idInput").val(`${$(e.target).data('sitting-id')}`)
    });

});


function getSitting(newDate) {


    //Sittings by selected day
    $.get(`https://localhost:7271/api/Sittings/any/${newDate}`, null, function (data) {

        $("#sittingsTBody").empty();

        data.forEach((item, index) => {

            $("#sittingsTBody").append(

                `<tr>
                            <td>${item.id}</td>
                            <td>${formatTime(item.start)}</td>
                            <td>${formatTime(item.start,item.duration)}</td>
                            <td>${item.capacity}</td>
                            <td>${item.isOpen}</td>
                            <td>${item.sittingTypeDescription}</td>
                            <td>
                                <input
                                    type="checkbox"
                                    data-sitting-id="${item.id}"    
                                    class="radio select-sitting-cb "
                                    value="${index}" 
                                    id="type${index}" 
                                    name="type${index}" />
                            </td>
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
