$(() => {
    toggleIconCarouselControls();

    $(".list-group-item").click((e) => {
        let itemBody = e.currentTarget.children[0].id;
        //let type = $(`#${itemBody}`).data("type");
        let type = $(`#${itemBody}`).data("type");
        let id = type == "upcoming" ? e.currentTarget.children[0].dataset.upcomingLiId : e.currentTarget.children[0].dataset.pastLiId;
        let isHidden = $(`#${type}-item-body-${id}`).is(":hidden");
        if (isHidden) {
            $(`#${itemBody}`).removeAttr('hidden');
        }
        else {
            $(`#${itemBody}`).attr('hidden', 'true');
        }
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