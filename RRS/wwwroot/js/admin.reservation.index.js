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
            //let statusClass;
            //switch (item.reservationStatusId) {
            //    case 1:
            //        statusClass = "btn-warning"
            //        break;
            //    case 2:
            //        statusClass = "btn-success"
            //        break;
            //    case 3:
            //        statusClass = "btn-danger"
            //        break;
            //    case 4:
            //        statusClass = "btn-info"
            //        break;
            //    case 5:
            //        statusClass = "btn-primary"
            //        break;
            //}

            let selectStatusList = statusList.reduce((p, c) => p + `<option value='${c.id}' ${item.reservationStatusId == c.id ? 'selected' : ''}>${c.status}</option> `, '')

            $("#reservationsTBody").append(

                `<tr class="res-row" data-reference-no=${item.referenceNo}>
                    <td>${formatTime(item.startTime)}</td>
                    <td>${item.resType}</td>
                    <td>${(item.firstName+' '+item.lastName).length < 25 ? item.firstName+' '+item.lastName : item.firstName.length < 25 ? item.firstName+'...' : shortenText(item.firstName)}</td>
                    <td>${item.phoneNumber}</td>
                    <td>${item.noOfGuests}</td>
                    <td>    
                    <select id="selectStatus-${item.referenceNo}" class="select-list-btn form-select" aria-label="Default select example">
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