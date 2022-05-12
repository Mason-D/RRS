$(() => {
    $("#dateControl").on("click", (e) => {
                
        $(this).changed(() => {

            const newDate = e.target.value;

            //Sittings by selected day
            $.get(`https://localhost:7271/api/Sittings/any/${newDate}/${newDate}`, null, function (data) {

                $("#sittingsTBody").empty();
                //$("#selectTypes").empty();

                data.forEach((item, index) => {

                    $("#sittingsTBody").append(
                        `<tr>
                            <td>${item.id}</td>
                            <td>${item.capacity}</td>
                            <td>${item.isOpen}</td>
                            <td>${item.sittingTypeDescription}</td>
                            <td>(Not yet in entity)</td>
                            <td><input type="checkbox" class="radio" value="${index}" id="type${index}" name="type${index}" /></td>
                            <td><button class="selectSittingBttn">Select</button></td>
                        </tr>`
                    );

                    //$("#selectTypes").append(
                    //    //value should be id so no conflict possibility, e.g., what if same day had multiple of 'x' type sittings
                    //    `<option value="${item.sittingTypeDescription}">${item.sittingTypeDescription}</option>`
                    //);

                })

            });
        });
    });

    $(".selectSittingBttn").click((e) => {
        let temp = e.target.value
        debugger;
    });

    //$(".selectSittingBttn").on("click", (e) => {
    //    let temp = e.target.value
    //    debugger;
    //});

    $("#sittingsTBody").on('change',"input[type='checkbox']",function (e) {
        let temp = e.target.value;
        $(`#type${temp}.radio`).prop("checked", true);
    });

    //$("#updateBttn").on("click", (e) => {
    //    e.preventDefault();
    //    debugger;             
        //AJAX Post doesn't hit action
        //jqXHR (jQuery XMLHttpRequest)
        //$.post("https://localhost:7271/Admin/Sitting/Edit?id=81", 81)               
        //    .done((response, status, jqxhr) => {
        //        debugger;
        //    })
        //    .fail((jqxhr, status, response) => {
        //        debugger;
        //    });
    //});
})