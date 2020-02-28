"use strict";

const common = require('./common');

$('.edit-list').click(function (e) {
    e.preventDefault();
    common.functions.showListModal();

    let listID = $(this).parents('.to-do-list').data('id');
    $('.new-list-modal .list-id').html(listID);
    const promise = getToDoList(listID).then((listResponse) => {
        $('.new-to-do-list-description').val(listResponse['title']);
    });
});

async function getToDoList(listID) {
    const url = `/api/lists/${listID}`;
    const response = await fetch(url);
    return await response.json();
}

$('.save-to-do-list').click(function (e) {
    e.preventDefault();
    let toDoData = {
        title: $('.new-to-do-list-description').val(),
        id: parseInt($('.new-list-modal .list-id').html())
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
    $(`.to-do-list[data-id="${toDo['id']}"] .title`).html(toDo['title']);
}