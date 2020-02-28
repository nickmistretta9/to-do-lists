"use strict";

const common = require('./common');

$('.edit-list').click(function (e) {
    e.preventDefault();
    common.functions.showListModal();

    let listID = $(this).parents('.to-do-list').data('id');
    const promise = getToDoItem(listID).then((listResponse) => {
        $('.new-to-do-list-description').val(listResponse['title']);
    });
});

async function getToDoItem(listID) {
    const url = `/api/lists/${listID}`;
    const response = await fetch(url);
    return await response.json();
}

$('.save-to-do-list').click(function (e) {
    e.preventDefault();
    let toDoData = {
        content: $('.new-to-do-list-description').val()
    };

    $.ajax({
        type: 'POST',
        url: '/api/lists/update',
        contentType: 'application/json',
        data: JSON.stringify(toDoData),
        success: function (data) {
            updateToDo(data);
            common.functions.closeListModal();
        },
        error: function (data) {
            alert(`Error Adding To Do: ${data}`);
        }
    });
});

function updateToDo(toDo) {
    $(`.to-do-list[data-id="${toDo['id']}"]"] .list-title > p`).val(toDo['title']);
}