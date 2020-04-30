var show = $('#show');
var statuses = $('#statuses');
var friends = $('#friends');
var statusMenu = $('#menu');
var feedbackButton = $('.feedback-button');
var feedbackPanel = $('#feedback-panel');

feedbackButton.click(function () {
    feedbackPanel.show();
    $('html, body').animate({ scrollTop: feedbackButton.offset().top - 10 }, 'slow');
})

show.on("mouseenter", function () {
    statuses.show();
    friends.hide();
});

statusMenu.on("mouseleave", function () {
    statuses.hide();
    friends.show();
})