InventoryAction = (data) => {
    if (data.status === 200) {
        var id = data.responseJSON.result.itemId !== undefined ? id = data.responseJSON.result.itemId : id = data.responseJSON.result;
        var element = $(`#${id}`);
        var count = Number(element.children()[1].textContent.split(' x ')[1]);
        var name = element.children()[1].textContent.split(' x ')[0];

        if (count > 1) {
            $(`#${id}`).children()[1].textContent = `${name} x ${count - 1}`;
        } else {
            element.remove();
        }

        if ($('#items').children().length === 0) {
            $('#title').text('No items in this section');
        }

    } else {
        window.location.href = '/Error/Default';
    }
};