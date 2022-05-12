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
                            <td>
                                <input
                                    type="checkbox"
                                    data-sitting-id="${item.id}"
                                    data-sitting-capacity="${item.capacity}"
                                    data-sitting-isOpen="${item.isOpen}"
                                    data-sitting-typeDescription="${item.sittingTypeDescription}"
                                    class="radio select-sitting-cb "
                                    value="${index}" 
                                    id="type${index}" 
                                    name="type${index}" />
                            </td>
                        </tr>`
                    );
                    $("#sittingsTBody").find('.select-sitting-cb').click((e) => {
                        //let x = $(e.target).data('sitting-id');
                        //$("#idInput").val(`${item.id}`)
                        //$("#startInput").val(`${item.start}`)
                        //$("#durationInput").val(`${item.isOpen}`)
                        //$("#capacityInput").val(`${item.sittingTypeDescription}`)
                    });


                })

            });

            $("#sittingsTBody").on('change', "input[type='checkbox']", function (e) {
                let id = $(e.target).data('sittingId');
                let capacity = $(e.target).data('sittingCapacity');
                let isOpen = $(e.target).data('sittingIsOpen');
                let typeDescription = $(e.target).data('sittingTypeDescription');
            });
        });
    });

