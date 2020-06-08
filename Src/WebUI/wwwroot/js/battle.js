let playerHealth = document.getElementById("playerHealth");
let enemyHealth = document.getElementById("enemyHealth");
let playerDamage = document.getElementById("playerDamage");
let enemyDamage = document.getElementById("enemyDamage");
playerHealth.value -= enemyDamage.value;
enemyHealth.value -= playerDamage.value;


var battleAction = $('#action');

var hero = $('#hero');
var enemy = $('#enemy');

$("select.command").change(function () {
    var battleOption = $(this).children('option:selected').val();

    if (battleOption === 'Spell') {
        $('#spells').removeAttr('hidden');

    } else {
        $('#spells').attr('hidden', true);
    }

    battleAction.click(function () {

        if (battleOption === 'Attack') {
            hero.toggleClass('roll-in-bottom');
            enemy.toggleClass('jello enemy-hit');
        }
    });
});
