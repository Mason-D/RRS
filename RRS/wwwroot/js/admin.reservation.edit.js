$(() => {

    $("#dateControl").on('change', (e) => {
        getSitting(e.target.value).then(() => highlightStart($("#idInput").val()));

    });

    getSitting($("#dateControl").val()).then(
        () => highlightStart($("#idInput").val()).then(
            () => resDateTimeToList($("#idInput").val())
        )
    );


    $("#sittingsTBody").on('click', 'tr', function (e) {
        $('#sittingsTBody').find('.bg-secondary').attr('role', 'button');
        $('#sittingsTBody').find('.bg-secondary').removeClass('bg-secondary');
        $('#sittingsTBody').find('.text-white').removeClass('text-white');
        $(this).addClass('bg-secondary');
        $(this).addClass('text-white');
        $(this).removeAttr('role');

        $("#idInput").val(e.currentTarget.children[0].innerHTML)
        resDateTimeToList($("#idInput").val());
        $("#sittingDate").val($("#dateControl").val());
        toggleDisplayById("table-view", "resForm-col");
    });

    $(".formBtn").on("click", (e) => {
        let bttn = e.target.value;
        if (bttn == "Change Sitting") {
            toggleDisplayById("resForm-col", "table-view");
        }
        else if (bttn == "Delete") {
            if (confirm("Are you sure you want to delete the selected sitting?")) {
                $("#form").attr("action", `${bttn}`);
            }
            else {
                e.preventDefault();
            }
        }
        else if (bttn == "Update") {
            $(".field-validation-error").empty();
            toggleDisplayById("form", "sittingsT");
        }
        else {
            e.preventDefault();
        }

        //HACK: Refer to: Mason-D/RRS/issues/11
        if (window.history.replaceState) {
            window.history.replaceState(null, null, window.location.href);
        }
    });
});

function toggleDisplayById(hide, show) {
    $(`#${hide}`).attr('hidden', true);
    $(`#${show}`).removeAttr('hidden');
}

function resDateTimeToList(id) {
    let selectedStart = new Date($("#startDateTime").val()).getTime();
    let tr = $("#sittingsTBody").find(`#STB${id}`)
    let startDT = new Date(tr.data('sitting-start')).getTime();
    let duration = tr.data('sitting-duration') * 60000;
    let interval = tr.data('sitting-interval') * 60000;
    let cutoff = tr.data('sitting-cutoff') * 60000;
    let endDT = duration + startDT

    console.log(selectedStart)

    $("#startTime").empty();

    for (let i = startDT; i <= endDT-cutoff; i += interval){
        let dateOption = new Date(i);
        $("#startTime").append(`<option ${selectedStart==i?"selected":""} value="${dateOption.toJSON()}">${formatTime(dateOption)}</option>`)
    }
}

async function highlightStart(id) {
    let sTB = $('#sittingsTBody').find(`#STB${id}`) 
    sTB.addClass('bg-secondary');
    sTB.addClass('text-white');
    sTB.removeAttr('role');
}

async function getSitting(newDate) {


    //Sittings by selected day
    await $.get(`https://localhost:7271/api/Sittings/any/${newDate}`, null, function (data) {

        $("#sittingsTBody").empty();

        data.forEach((item) => {
            if (item.isOpen) {
                $("#sittingsTBody").append(

                    `<tr 
                        id="STB${item.id}"
                        role="button"
                        data-sitting-start="${item.start}"
                        data-sitting-duration="${item.duration}"
                        data-sitting-interval="${item.interval}"
                        data-sitting-cutoff="${item.cutoff}"
                    >
                        <td>${item.id}</td>
                        <td>${formatTime(item.start)}</td>
                        <td>${formatTime(item.start,item.duration)}</td>
                        <td>${item.totalGuests}/${item.capacity}</td>
                        <td>${item.sittingTypeDescription}</td>
                    </tr>`
                );
            }
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
