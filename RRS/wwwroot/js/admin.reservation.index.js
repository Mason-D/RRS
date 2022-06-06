$(() => {

    $("#dateControl").on('change', (e) => getReservation(e.target.value));
    getReservation($("#dateControl").val());


    $("#reservationsTBody").on('click', 'tr', (e) => {
        if (e.target.className.includes("form-select")) {
            return;
        }
        let id = e.currentTarget.dataset.referenceNo;
        window.location.href = `https://localhost:7271/Admin/Reservation/Edit/${id}`;
    });
});



function getStatusList() {
    let newList = [];
    $.get(`https://localhost:7271/api/reservations/getList`, null, function (data) {
        data.forEach((item) => {
            newList.push({ id: item.id, status: item.description })
        })

    })
    return newList;
}

function setStatusColor(id) {
    id = +id;
    switch (id) {
        case 1:
            return "btn-warning";
        case 2:
            return "btn-success";
        case 3:
            return "btn-danger";
        case 4:
            return "btn-info";
        case 5:
            return "btn-primary";
        default:
            return "";
    }
}

function getReservation(newDate) {

    var statusList = getStatusList();

    //Reservations by selected day
    $.get(`https://localhost:7271/api/reservations/any/${newDate}`, null, function (data) {

        $("#reservationsTBody").empty();

        if (data.length == 0) {
            validateTable();
            return;
        }


        data.forEach((item) => {

            let selectStatusList = statusList.reduce((p, c) => p + `<option class="bg-light text-dark" value='${c.id}' ${item.reservationStatusId == c.id ? 'selected' : ''}>${c.status}</option> `, '')

            $("#reservationsTBody").append(

                `<tr class="res-row" data-reference-no=${item.referenceNo}>
                    <td>${formatTime(item.startTime)}</td>
                    <td>${item.resType}</td>
                    <td>${(item.firstName+' '+item.lastName).length < 25 ? item.firstName+' '+item.lastName : item.firstName.length < 25 ? item.firstName+'...' : shortenText(item.firstName)}</td>
                    <td>${item.phoneNumber}</td>
                    <td>${item.noOfGuests}</td>
                    <td>    
                    <select id="selectStatus-${item.referenceNo}" class="select-list-btn form-select ${setStatusColor(item.reservationStatusId)}" aria-label="Default select example">
                        ${selectStatusList}
                    </select>
                    </td>
                    <td>${shortenText(item.customerNotes)}</td>
                    <td>
                        <a type="button" class="btn btn-success" href="/Admin/Reservation/Details/${item.referenceNo}">Details</a>
                    </td>
                </tr>`
            );
        })

        $(".select-list-btn").on('change', (e) => {
            let resId = e.currentTarget.id.split("-")[1];
            let statusId = e.currentTarget.value;
            $.get(`https://localhost:7271/api/Reservations/updateReservationStatus/${resId}/${statusId}`)
            $(`#selectStatus-${resId}`).removeClass("btn-warning btn-success btn-danger btn-info btn-primary").addClass(setStatusColor(statusId));
        });

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

function validateTable() {
    let columnCount = $("#sittingsT th").length; // Validation msg spans entire table
    $("#sittingsTBody").append(
        `<tr>
            <td colspan="${columnCount}">No current reservations exist on this day...</td>
        </tr>`
    );
}

function shortenText(text) {
    let shortText = String(text);
    return shortText.length <= 25 ? shortText : `${shortText.slice(0,25).trim()}...`
}