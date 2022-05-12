$(() => {

                
    $("#dateControl").on('change',(e) => {

            const newDate = e.target.value;

            //Sittings by selected day
            $.get(`https://localhost:7271/api/Sittings/any/${newDate}/${newDate}`, null, function (data) {

                $("#sittingsTBody").empty();

                data.forEach((item, index) => {

                    $("#sittingsTBody").append(
                        `<tr>
                            <td>${item.id}</td>
                            <td>${item.capacity}</td>
                            <td>${item.isOpen}</td>
                            <td>${item.sittingTypeDescription}</td>
                            <td>(Not yet in entity)</td>
                            <td><input type="checkbox" data-sitting-id="${item.id}" class="radio select-sitting-cb " value="${index}" id="type${index}" name="type${index}" /></td>
                            <td><button class="selectSittingBttn">Select</button></td>
                        </tr>`
                    );
                    $("#sittingsTBody").find('.select-sitting-cb').click((e) => {
                        let x = $(e.target).data('sitting-id');

                    });


                })

            });
        });
    });

