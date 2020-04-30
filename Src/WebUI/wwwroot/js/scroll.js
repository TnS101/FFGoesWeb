var scrollTop = $('#scroll-top');

$(window).scroll(function () {
    if ($(window).scrollTop() > 1200) {
        scrollTop.removeClass('fade-out');
        scrollTop.show();
    } else {
        scrollTop.addClass('fade-out');
    }
});

scrollTop.click(function () {
    $('html, body').animate({
        scrollTop: $("#top").offset().top
    }, 1200);
});