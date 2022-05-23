$(() => {
    toggleIconCarouselControls();

    $(".list-group-item").click((e) => {
        $('#past-res-container').find('.past-item-card-body').attr('hidden', 'true');
        let cardBody = e.currentTarget.children[0].id;
        $(`#${cardBody}`).removeAttr('hidden');
    });
});

function toggleIconCarouselControls() {
    $("#profile-icon-container").on({
        mouseover: () => {
            $(`.carousel-control-prev`).removeAttr('hidden');
            $(`.carousel-control-next`).removeAttr('hidden');
        },
        mouseleave: () => {
            $(`.carousel-control-prev`).attr('hidden', true);
            $(`.carousel-control-next`).attr('hidden', true);
        }
    });
}

//function toggleDisplayById(hide, show) {
//    $(`#${hide}`).attr('hidden', true);
//    $(`#${show}`).removeAttr('hidden');
//}

////    $(".form-btn").on("click", (e) => {
////        let bttn = e.target.name;
////        if (bttn == "ChangePassword") {
////            $("#change-password-form").attr("action", `${bttn}`);
////        }
////        else if (bttn == "Delete") {
////            if (confirm("Are you sure you want to delete the selected sitting?")) {
////                $("#change-password-form").attr("action", `${bttn}`);
////            }
////            else {
////                e.preventDefault();
////            }
////        }
////        else {
////            e.preventDefault();
////        }
////    });