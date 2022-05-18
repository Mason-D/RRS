$(() => {
    $("#dateControl").on('change', (e) => {
        populateSittingsTable(e.target.value);
        clearForm();
    });
    populateSittingsTable($("#dateControl").val()); //ONLOAD  

    $("input[type='submit']").on("click", (e) => {
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
    });

    $("#sittingsTBody").on('click', 'tr', function (e) {

        onRowSelect(this);

        //Posted
        $("#hiddenIdInput").val(`${$(e.currentTarget).data('sitting-id')}`);
        $("#hiddenTypeIdInput").val(`${$(e.currentTarget).data('sitting-type-id')}`);
        $("#startInput").val(`${$(e.currentTarget).data('sitting-start')}`);
        $("#durationInput").val(`${$(e.currentTarget).data('sitting-duration')}`);
        $("#capacityInput").val(`${$(e.currentTarget).data('sitting-capacity')}`);
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

            $("#sittingsTBody").append(
                `<tr    
                    data-sitting-id="${item.id}"
                    data-sitting-start="${item.start}"
                    data-sitting-duration="${item.duration}"
                    data-sitting-capacity="${item.capacity}"
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
                        <td>${item.capacity}</td>
                        <td>${item.sittingTypeDescription}</td>
                        <td>(Not yet in entity)</td>
                        <td><button class="sittingsTBody-row-bttn ${bttnBootstrap}" id="sittingsTBody-row-bttn-${index}">${buttonHtml}</button></td>
                </tr>`
            );
        });


        $(".sittingsTBody-row-bttn").click((e) => {
            let index = e.currentTarget.id.split("-")[3];
            let sittingId = $(`#sittingsTBody-row-${index}`).data("sitting-id");
            
            $.get(`https://localhost:7271/api/Sittings/toggle-availability/${sittingId}`, null, function (data) {
                let buttonHtml = data.isOpen == true ? "Open" : "Closed";
                $(`#sittingsTBody-row-bttn-${index}`).html(buttonHtml);
                $(`#sittingsTBody-row-bttn-${index}`).removeClass(data.isOpen == true ? "btn-danger" : "btn-success");
                $(`#sittingsTBody-row-bttn-${index}`).addClass(data.isOpen == true ? "btn-success" : "btn-danger");
                $("#isOpenInput").val(`${data.isOpen}`);
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
    $("#isOpenInput").val("");
    $("#idInput").val("");
}

function onRowSelect(row) {
    //Deselect any highlighted rows
    $('#sittingsTBody').find('.bg-secondary').removeClass('bg-secondary');
    $('#sittingsTBody').find('.text-white').removeClass('text-white');
    //Highlight selected row
    $(row).addClass('bg-secondary');
    $(row).addClass('text-white');
}

function validateTable() {
    let columnCount = $("#sittingsT th").length; // Validation msg spans entire table
    $("#sittingsTBody").append(
        `<tr>
            <td colspan="${columnCount}">No sittings exist on this day...</td>
        </tr>`
    );
}

