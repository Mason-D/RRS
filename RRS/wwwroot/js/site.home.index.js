var resToggle = false;
$(() => {


    $("#site-res-btn-container-text").on('click', (e) => {

        resToggle = true;

        $(document).ready(function () {
            $('#SPA-container').css('pointer-events', 'all');
            $('#SPA-container').css('top', '200px');
            $('#SPA-container').css('width', '90%');
            $('#SPA-container').css('opacity', '1');
            $('#SPA-container').css('max-height', '1000px');
            //glass-container
            $('#glass-container').css('opacity', '0');
            $('#glass-container').css('pointer-events', 'none');
            $('.site-main-header').css('font-size', '100px');
        });
    });


    $("#close-icon").on('click', (e) => {

        resToggle = false;

        $(document).ready(function () {
            $('#SPA-container').css('pointer-events', 'none');
            $('#SPA-container').css('top', '1000px');
            $('#SPA-container').css('width', '268px');
            $('#SPA-container').css('opacity', '0');
            $('#SPA-container').css('max-height', '0px');
            //glass-container
            $('#glass-container').css('opacity', '1');
            $('#glass-container').css('pointer-events', 'all');
            $('.site-main-header').css('font-size', '200px');
        });
    });

    $("#contact-us-link").on(load)

});