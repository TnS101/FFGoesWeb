$(".game-button").click(function () {
    $('html, body').animate({
        scrollTop: $("#Game").offset().top - 60
    }, 1000);
});

$(".social-button").click(function () {
    $('html, body').animate({
        scrollTop: $("#Social").offset().top - 60
    }, 1500);
});

$(".rules-button").click(function () {
    $('html, body').animate({
        scrollTop: $("#Rules").offset().top - 60
    }, 150);
});

$(".rewards-button").click(function () {
    $('html, body').animate({
        scrollTop: $("#Rewards").offset().top - 60
    }, 1500);
});

$(".spells-button").click(function () {
    $('html, body').animate({
        scrollTop: $("#Spells").offset().top - 60
    }, 1500);
});

$(".classes-button").click(function () {
    $('html, body').animate({
        scrollTop: $("#Classes").offset().top - 60
    }, 1500);
});

$(".items-button").click(function () {
    $('html, body').animate({
        scrollTop: $("#Items").offset().top - 60
    }, 1800);
});

$(".crafting-button").click(function () {
    $('html, body').animate({
        scrollTop: $("#Crafting").offset().top - 60
    }, 2000);
});

$(".professions-button").click(function () {
    $('html, body').animate({
        scrollTop: $("#Professions").offset().top - 60
    }, 2100);
});

$(".pvp-button").click(function () {
    $('html, body').animate({
        scrollTop: $("#PvP").offset().top - 60
    }, 2200);
});

$(".shops-button").click(function () {
    $('html, body').animate({
        scrollTop: $("#Shops").offset().top - 60
    }, 1500);
});

function show(id) {
    const clicked = document.getElementById(`${id}`).querySelectorAll('i')[1];
    const section = document.getElementById(`${id}`).getElementsByClassName('about-section')[0];

    section.style.display = 'inline-block';

    $('html, body').animate({scrollTop: $(`#${id}`).offset().top - 60}, 800);

    clicked.className = 'fas fa-caret-square-up light-font-color clickable';

    clicked.onclick = function () {
        return false;
    };

    clicked.onclick = function hide(e) {
        e.preventDefault();
        section.style.display = 'none';
        clicked.className = 'fas fa-caret-square-down main-font-color clickable';

        clicked.onclick = function () {
            return show(id);
        };
    };
}
