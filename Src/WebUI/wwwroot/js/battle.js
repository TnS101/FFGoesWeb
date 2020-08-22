var battleAction = $('#action');

var hero = $('#hero');
var enemy = $('#enemy');

$("select.command").change(function () {
    var battleOption = $('select option:selected');
    var background = $('#button');

    if (battleOption.val() === 'Spell') {
        $('#spells').removeAttr('hidden');
        background.removeClass();
        background.addClass('spell-option-gradient');
    }
    else if (battleAction.val() === 'Attack') {
        background.removeClass();

        background.addClass('attack-option-gradient');
        $('#spellId').val(0);

        $('#spells').attr('hidden', true);
    }
    else{
        background.removeClass();
        background.addClass('defend-option-gradient');
        $('#spellId').val(0);

        $('#spells').attr('hidden', true);
    }


    battleAction.click(function () {

        if (battleOption === 'Attack') {
            hero.toggleClass('roll-in-bottom');
            enemy.toggleClass('jello enemy-hit');
        }
    });
});
