$(() => {


    $("#dateControl").on('change', (e) => {
        populateSittingsTable(e.target.value);
        clearForm();
        toggleViewIfFormDateChange();
    });

    populateSittingsTable($("#dateControl").val()); //ONLOAD 
    

    let s = $("#lastSelectedSitting");
    if (s.val() != "") {
        restoreInvalidForm(s);
    }

    $(".formBtn").on("click", (e) => {
        let bttn = e.target.value;
        if (bttn == "Edit") {
            $("#form").attr("action", `${bttn}`);
        }
        else if (bttn == "Delete") {
            if (confirm("Are you sure you want to delete the selected sitting?")) {
                $("#form").attr("action", `${bttn}`);
            }
            else {
                e.preventDefault();
            }
        }
        else if (bttn == "Back") {
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

    $("#sittingsTBody").on('dblclick', 'tr', function (e) {

        onRowSelect(this);

        //Posted
        $("#hiddenIdInput").val(`${$(e.currentTarget).data('sitting-id')}`);
        $("#hiddenTypeIdInput").val(`${$(e.currentTarget).data('sitting-type-id')}`);
        $("#startInput").val(`${$(e.currentTarget).data('sitting-start')}`);
        $("#durationInput").val(`${$(e.currentTarget).data('sitting-duration')}`);
        $("#capacityInput").val(`${$(e.currentTarget).data('sitting-capacity')}`);
        $("#intervalInput").val(`${$(e.currentTarget).data('sitting-interval')}`);
        $("#cutoffInput").val(`${$(e.currentTarget).data('sitting-cutoff')}`);
        $("#typeSelectList").val(`${$(e.currentTarget).data('sitting-type-id')}`);
        // Match checkbox state to selected sitting isOpen value
        let open = true == $(e.currentTarget).data('sitting-is-open');
        $("#isOpenInput").val(`${open}`);
        //Posted End

        //Purely Visual
        $("#idInput").val(`${$(e.currentTarget).data('sitting-id')}`);
    });
});

function populateSittingsTable(newDate) {
    //Sittings by selected day
    $.get(`https://localhost:7271/api/Sittings/any/${newDate}`, null, function (data) {

        $("#sittingsTBody").empty();

        if (data.length == 0) {
            validateTable();
            return;
        }

        data.forEach((item, index) => {

            let formattedStart = new Date(item.start).toLocaleTimeString("en-US");
            let buttonHtml = item.isOpen == true ? "Open" : "Closed";
            let bttnBootstrap = item.isOpen == true ? "btn btn-success" : "btn btn-danger";
            let bttnTitle = item.isOpen == true ? "close sitting" : "open sitting";

            $("#sittingsTBody").append(
                `<tr
                    role="button"
                    data-sitting-id="${item.id}"
                    data-sitting-start="${item.start}"
                    data-sitting-duration="${item.duration}"
                    data-sitting-capacity="${item.capacity}"
                    data-sitting-interval="${item.interval}"
                    data-sitting-cutoff="${item.cutoff}"
                    data-sitting-is-open="${item.isOpen}"
                    data-sitting-type-id="${item.sittingTypeId}"
                    data-sitting-type-description="${item.sittingTypeDescription}"
                    class="sittingsTBody-row"
                    value="${index}" 
                    id="sittingsTBody-row-${index}"
                    name="sittingsTBody-row-${index}">
                        <td>${item.id}</td>
                        <td>${formattedStart}</td>
                        <td>${item.duration}</td>
                        <td>${item.totalGuests}/${item.capacity}</td>
                        <td>${item.interval}</td>
                        <td>${item.cutoff}</td>
                        <td>${item.sittingTypeDescription}</td>
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

                setUserFeedback(`Sitting: ${sittingId} is now '${buttonHtml}'`);
            });
        });
    });
};

function clearForm() {
    $("#hiddenIdInput").val("");
    $("#hiddenTypeIdInput").val("");
    $("#startInput").val("");
    $("#durationInput").val("");
    $("#capacityInput").val("");
    $("#intervalInput").val("");
    $("#cutoffInput").val("");
    $("#isOpenInput").val("");
    $("#idInput").val("");
}

function onRowSelect(row) {
    toggleDisplayById("sittingsT", "form");
    //Row hover cursor icon changes
    $('#sittingsTBody').find('.bg-secondary').attr('role', 'button');
    //Deselect any highlighted rows
    $('#sittingsTBody').find('.bg-secondary').removeClass('bg-secondary');
    $('#sittingsTBody').find('.text-white').removeClass('text-white');
    //Highlight selected row
    $(row).addClass('bg-secondary');
    $(row).addClass('text-white');
    $(row).removeAttr('role');
}

function toggleDisplayById(hide, show) {
    $(`#${hide}`).attr('hidden', true);
    $(`#${show}`).removeAttr('hidden');
}

function validateTable() {
    let columnCount = $("#sittingsT th").length; // Validation msg spans entire table
    $("#sittingsTBody").append(
        `<tr>
            <td colspan="${columnCount}">No sittings exist on this day...</td>
        </tr>`
    );
}

function toggleViewIfFormDateChange() {
    let tableHiddenStatus = $("sittingsT").attr("hidden");
    if (tableHiddenStatus == undefined || tableHiddenStatus == true) {
        toggleDisplayById("form", "sittingsT")
    }
}

function restoreInvalidForm(s) {
    toggleDisplayById("sittingsT", "form");
    //Posted
    $("#hiddenIdInput").val(`${s.data('sitting-id')}`);
    $("#hiddenTypeIdInput").val(`${s.data('sitting-type-id')}`);
    $("#startInput").val(`${s.data('sitting-start')}`);
    $("#durationInput").val(`${s.data('sitting-duration')}`);
    $("#capacityInput").val(`${s.data('sitting-capacity')}`);
    $("#intervalInput").val(`${s.data('sitting-interval')}`);
    $("#cutoffInput").val(`${s.data('sitting-cutoff')}`);
    $("#typeSelectList").val(`${s.data('sitting-type-id')}`);
    // Match checkbox state to selected sitting isOpen value
    let open = true == s.data('sitting-is-open');
    $("#isOpenInput").val(`${open}`);
    //Posted End

    //Purely Visual
    $("#idInput").val(`${s.data('sitting-id')}`);
}

function setUserFeedback(msg) {
    let index = $("#user-feedback p").length;
    $("#user-feedback").append(`<p id="user-feedback-item-${index}" class="alert alert-danger mb-0 p-1 border-top-0">${msg}</p>`);
    setTimeout(() => {
        $(`#user-feedback-item-${index}`).remove();
    }, 5000);
}

