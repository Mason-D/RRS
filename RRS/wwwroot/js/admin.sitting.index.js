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
});

function populateSittingsTable(newDate) {
    //Sittings by selected day
    $.get(`https://localhost:7271/api/Sittings/any/${newDate}`, null, function (data) {

        $("#sittingsTBody").empty();

        data.forEach((item, index) => {
            
            let formattedStart = new Date(item.start).toLocaleTimeString("en-US");

            $("#sittingsTBody").append(
                `<tr>
                    <td>${item.id}</td>
                    <td>${formattedStart}</td>
                    <td>${item.duration}</td>
                    <td>${item.capacity}</td>
                    <td>${item.isOpen}</td>
                    <td>${item.sittingTypeDescription}</td>
                    <td>(Not yet in entity)</td>
                    <td>
                        <input
                            type="checkbox"
                            data-sitting-id="${item.id}"
                            data-sitting-start="${item.start}"
                            data-sitting-duration="${item.duration}"
                            data-sitting-capacity="${item.capacity}"
                            data-sitting-is-open="${item.isOpen}"
                            data-sitting-type-id="${item.sittingTypeId}"
                            /*data-sitting-type-description="${item.sittingTypeDescription}"*/
                            class="radio select-sitting-cb "
                            value="${index}" 
                            id="type${index}" 
                            name="type${index}" />
                    </td>
                </tr>`
            );
            /*$("#sittingsTBody").find('.select-sitting-cb').click((e) => {});*/
        })

    });

    $("#sittingsTBody").on('change', "input[type='checkbox']", function (e) {

        $("#sittingsTBody input[type='checkbox']").not(e.target).prop('checked', false);

        //Posted
        $("#hiddenIdInput").val(`${$(e.target).data('sitting-id')}`);
        $("#hiddenTypeIdInput").val(`${$(e.target).data('sitting-type-id')}`);
        $("#startInput").val(`${$(e.target).data('sitting-start')}`);
        $("#durationInput").val(`${$(e.target).data('sitting-duration')}`);
        $("#capacityInput").val(`${$(e.target).data('sitting-capacity')}`);
        $("#typeSelectList").val(`${$(e.target).data('sitting-type-id')}`);
        // Match checkbox state to selected sitting isOpen value
        let open = true == $(e.target).data('sitting-is-open'); //String to bool
        $("#isOpenInput").prop('checked', open);
        $("#isOpenInput").val(`${open}`);
        //Posted End

        //Purely Visual
        $("#idInput").val(`${$(e.target).data('sitting-id')}`);
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

