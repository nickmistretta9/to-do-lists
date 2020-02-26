"use strict";

const common = require('./common');

$('.edit-item').click(function (e) {
    e.preventDefault();
    common.functions.showModal();

    $('.save-to-do').data('btn-type', 'edit');

    let listID = $(this).parentsUntil('.to-do-list').parent().data('id');
    $('.new-item-modal .list-value').html(listID);
    let itemID = $(this).parents('.to-do-item').data('item-id');
    const promise = getToDoItem(itemID).then((itemResponse) => {
        $('.new-to-do-description').val(itemResponse['title']);
    });
});

async function getToDoItem(itemID) {
    const url = `/api/items/${itemID}`;
    const response = await fetch(url);
    return await response.json();
}

$('.save-to-do').click(function (e) {
    e.preventDefault();
    let toDoData = {
        toDoListID: parseInt($('.list-value').html()),
        content: $('.new-to-do-description').val()
    };

    $.ajax({
        type: 'POST',
        url: '/api/items/update',
        contentType: 'application/json',
        data: JSON.stringify(toDoData),
        success: function (data) {
            updateToDo(data);
            common.functions.closeModal();
        },
        error: function (data) {
            alert(`Error Adding To Do: ${data}`);
        }
    });
});

function updateToDo(toDo) {
    $(`.to-do-list[data-id="${toDo['toDoListID']}"] .to-do-item[data-item="${toDo['id']}"] .item-title`).val(toDo['title']);
}