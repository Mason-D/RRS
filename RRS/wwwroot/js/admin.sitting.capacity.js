$(() => {

    populateSittingsTable(); //ONLOAD 
    
});


function populateSittingsTable(newDate) {
    //Sittings by selected day
    $.get(`https://localhost:7271/api/Sittings/capacity-warnings`, null, function (data) {

        $("#sittingsTBody").empty();

        if (data.length == 0) {
            validateTable();
            return;
        }

        data.forEach((item, index) => {

            let formattedStart = new Date(item.start).toLocaleDateString("en-US");
            let EndDateTime = new Date(item.start);
            EndDateTime.setMinutes(EndDateTime.getMinutes() + item.duration)
            let formattedEnd = new Date(EndDateTime).toLocaleDateString("en-US");
            let buttonHtml = item.isOpen == true ? "Open" : "Closed";
            let bttnBootstrap = item.isOpen == true ? "btn btn-success" : "btn btn-danger";
            let bttnTitle = item.isOpen == true ? "close sitting" : "open sitting";

            $("#sittingsTBody").append(
                `<tr
                    data-sitting-id="${item.id}"
                    data-sitting-start="${item.start}"
                    data-sitting-duration="${item.duration}"
                    data-sitting-capacity="${item.capacity}"
                    data-sitting-interval="${item.interval}"
                    data-sitting-cutoff="${item.cutoff}"
                    data-sitting-is-open="${item.isOpen}"
                    data-sitting-type-id="${item.sittingTypeId}"
                    data-sitting-type-description="${item.sittingTypeDescription}"
                    data-sitting-group-id="${item.groupId}"
                    class="sittingsTBody-row"
                    value="${index}" 
                    id="sittingsTBody-row-${index}"
                    name="sittingsTBody-row-${index}">
                        <td>${item.id}</td>
                        <td>${formattedStart}</td>
                        <td>${formatTime(item.start)}</td>
                        <td>${formattedEnd}</td>
                        <td>${formatTime(item.start, item.duration)}</td>
                        <td>${item.sittingTypeDescription}</td>
                        <td class="${capacityWarningLevel(item.totalGuests, item.capacity)}" >${item.totalGuests}/${item.capacity}</td>
                        <td>
                            <button class="sittingsTBody-row-bttn ${bttnBootstrap}" id="sittingsTBody-row-bttn-${index}" title="${bttnTitle}">
                                ${buttonHtml}
                            </button>
                        </td>
                </tr>`
            );
        });


        $(".sittingsTBody-row-bttn").click((e) => {
            let index = e.currentTarget.id.split("-")[3];
            let sittingId = $(`#sittingsTBody-row-${index}`).data("sitting-id");
            
            $.get(`https://localhost:7271/api/Sittings/toggle-availability/${sittingId}`, null, function (data) {
                let buttonHtml = data.isOpen == true ? "Open" : "Closed";
                $(`#sittingsTBody-row-bttn-${index}`).html(buttonHtml);

                let bttnTitle = data.isOpen == true ? "close sitting" : "open sitting";
                $(`#sittingsTBody-row-bttn-${index}`).attr("title", `${bttnTitle}`)

                $(`#sittingsTBody-row-bttn-${index}`).removeClass(data.isOpen == true ? "btn-danger" : "btn-success");
                $(`#sittingsTBody-row-bttn-${index}`).addClass(data.isOpen == true ? "btn-success" : "btn-danger");

                $("#isOpenInput").val(`${data.isOpen}`);

                setUserFeedback(`Sitting: ${sittingId} is now '${buttonHtml}'`, 5000);
            });
        });
    });
};

function capacityWarningLevel(total, capacity) {
    let capPer = total / capacity
    if (capPer <= 0.95) {
        return "warning1";
    }
    else if (capPer <= 1) {
        return "warning2";
    }
    else if (capPer <= 1.05) {
        return "warning3";
    }
    else if (capPer <= 1.1) {
        return "warning4";
    }
    else if (capPer <= 1.15) {
        return "warning5";
    }
    else if (capPer <= 1.2) {
        return "warning6";
    }
    else{
        return "warning7";
    }
}

function formatTime(dateString, addMins) {
    let date = new Date(dateString)
    if (addMins) {
        date.setMinutes(date.getMinutes() + addMins);
    }
    let hours = date.getHours() % 12 || 12;
    let mins = date.getMinutes();
    let ampm = date.getHours() < 12 ? "AM" : "PM";
    return `${hours}:${mins <= 9 ? '0' + mins : mins} ${ampm}`;
}


function validateTable() {
    let columnCount = $("#sittingsT th").length; // Validation msg spans entire table
    $("#sittingsTBody").append(
        `<tr>
            <td colspan="${columnCount}">No Sittings have capacity warnings...</td>
        </tr>`
    );
}


function setUserFeedback(msg, delay) {
    let index = $("#user-feedback p").length;
    $("#user-feedback").append(`<p id="user-feedback-item-${index}" class="alert alert-danger mb-0 p-1 border-top-0">${msg}</p>`);
    setTimeout(() => {
        $(`#user-feedback-item-${index}`).remove();
    }, delay);
}

