$('select.slot').change(function () {

    var slotOption = $(this).children('option:selected').val();

    if (slotOption === 'Weapon') {
        $('#requiresKey').hide();
        $('#armor').hide();
        $('#resistance').hide();
        $('#rewardAmplifier').hide();
        $('#boxType').hide();
        $('#fuel').hide();
        $('#materials').hide();
        $('#refineable').hide();
        $('#disolveable').hide();
        $('#durability').hide();
        $('#craftable').hide();
        $('#material-type').hide();
        $('#none').hide();

        $('#name').show();
        $('#level').show();
        $('#class-type').show();
        $('#stamina').show();
        $('#strength').show();
        $('#agility').show();
        $('#intellect').show();
        $('#spirit').show();
        $('#attack').show();
        $('#buy').show();
        $('#sell').show();
    }
    else if (slotOption === 'Armor') {
        $('#requiresKey').hide();
        $('#attack').hide();
        $('#rewardAmplifier').hide();
        $('#boxType').hide();
        $('#fuel').hide();
        $('#materials').hide();
        $('#refineable').hide();
        $('#disolveable').hide();
        $('#durability').hide();
        $('#craftable').hide();
        $('#material-type').hide();
        $('#none').hide();

        $('#name').show();
        $('#level').show();
        $('#class-type').show();
        $('#stamina').show();
        $('#strength').show();
        $('#agility').show();
        $('#intellect').show();
        $('#spirit').show();
        $('#armor').show();
        $('#resistance').show();
        $('#buy').show();
        $('#sell').show();
    }
    else if (slotOption === 'Trinket') {
        $('#requiresKey').hide();
        $('#attack').hide();
        $('#armor').hide();
        $('#resistance').hide();
        $('#rewardAmplifier').hide();
        $('#boxType').hide();
        $('#fuel').hide();
        $('#materials').hide();
        $('#refineable').hide();
        $('#disolveable').hide();
        $('#durability').hide();
        $('#craftable').hide();
        $('#material-type').hide();
        $('#none').hide();

        $('#name').show();
        $('#level').show();
        $('#stamina').show();
        $('#strength').show();
        $('#agility').show();
        $('#intellect').show();
        $('#spirit').show();
        $('#buy').show();
        $('#sell').show();
    }
    else if (slotOption === 'Treasure') {
        $('#attack').hide();
        $('#armor').hide();
        $('#resistance').hide();
        $('#boxType').hide();
        $('#fuel').hide();
        $('#materials').hide();
        $('#refineable').hide();
        $('#disolveable').hide();
        $('#durability').hide();
        $('#craftable').hide();
        $('#level').hide();
        $('#stamina').hide();
        $('#strength').hide();
        $('#agility').hide();
        $('#intellect').hide();
        $('#spirit').hide();
        $('#buy').hide();
        $('#sell').hide();
        $('#class-type').hide();
        $('#material-type').hide();
        $('#none').hide();

        $('#name').show();
        $('#rewardAmplifier').show();
        $('#boxType').show();
        $('#requiresKey').show();
    }
    else if (slotOption === 'Treasure Key') {
        $('#requiresKey').hide();
        $('#boxType').hide();
        $('#attack').hide();
        $('#armor').hide();
        $('#resistance').hide();
        $('#boxType').hide();
        $('#fuel').hide();
        $('#materials').hide();
        $('#refineable').hide();
        $('#disolveable').hide();
        $('#durability').hide();
        $('#craftable').hide();
        $('#level').hide();
        $('#stamina').hide();
        $('#strength').hide();
        $('#agility').hide();
        $('#intellect').hide();
        $('#spirit').hide();
        $('#buy').hide();
        $('#sell').hide();
        $('#class-type').hide();
        $('#material-type').hide();
        $('#none').hide();

        $('#name').show();
        $('#boxType').show();
    }
    else if (slotOption === 'Material') {
        $('#requiresKey').hide();
        $('#boxType').hide();
        $('#attack').hide();
        $('#armor').hide();
        $('#resistance').hide();
        $('#rewardAmplifier').hide();
        $('#boxType').hide();
        $('#materials').hide();
        $('#refineable').hide();
        $('#disolveable').hide();
        $('#durability').hide();
        $('#craftable').hide();
        $('#level').hide();
        $('#stamina').hide();
        $('#strength').hide();
        $('#agility').hide();
        $('#intellect').hide();
        $('#spirit').hide();
        $('#buy').hide();
        $('#sell').hide();
        $('#class-type').hide();

        $('#name').show();
        $('#material-type').show();
        $('#fuel').show();
        $('#none').show();
        $('#refineable').show();
        $('#disolveable').show();
        $('#craftable').show();

        $('input:radio[name="materialDiversity"]').change(function () {
            if ($(this).is(':checked') && $(this).val() === 'craftable' || $(this).val() === 'refineable' || $(this).val() === 'disolveable') {
                $('#materials').show();
                $('#tools').show();
            } else {
                $('#materials').hide();
                $('#tools').hide();
            }
        });
    }
    else if (slotOption === 'Tool') {
        $('#requiresKey').hide();
        $('#boxType').hide();
        $('#attack').hide();
        $('#armor').hide();
        $('#resistance').hide();
        $('#rewardAmplifier').hide();
        $('#boxType').hide();
        $('#refineable').hide();
        $('#disolveable').hide();
        $('#materials').hide();

        $('#craftable').hide();
        $('#level').hide();
        $('#stamina').hide();
        $('#strength').hide();
        $('#agility').hide();
        $('#intellect').hide();
        $('#spirit').hide();
        $('#sell').hide();
        $('#class-type').hide();

        $('#name').show();
        $('#craftable').show();
        $('#buy').show();
        $('#durability').show();
    }
});
