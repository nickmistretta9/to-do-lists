"use strict";

const common = require('./common');

$('.to-do-item.add-new > a').click(function (e) {
    e.preventDefault();
    $('.new-to-do-description').val('');
    let listID = $(this).parentsUntil('.to-do-list').parent().data('id');
    common.functions.showModal();
    $('.new-item-modal .list-value').html(listID);
});

$('.save-to-do').click(function (e) {
    e.preventDefault();
    let toDoData = {
        toDoListID: parseInt($('.list-value').html()),
        content: $('.new-to-do-description').val()
    };

    $.ajax({
        type: 'POST',
        url: '/api/items/new',
        contentType: 'application/json',
        data: JSON.stringify(toDoData),
        success: function (data) {
            appendNewToDo(data);
            common.functions.closeModal();
        },
        error: function (data) {
            alert(`Error Adding To Do: ${data}`);
        }
    });
});

function appendNewToDo(toDoItem) {
    const htmlElement = `<div class="to-do-item">
                            <div class="actions">
                                <a class="edit-item" href="javascript:void('')"><i class="far fa-edit"></i></a>
                                <a class="delete-item" href="javascript:void('')"><i class="far fa-trash-alt"></i></a>
                            </div>
                            <div class="item-info">
                                <input class="item-complete" type="checkbox" data-item-id="${toDoItem['id']}" data-complete="False" />
                                <div class="item-title">${toDoItem['content']}</div>
                            </div>
                        </div>`;

    $(`.to-do-list[data-id="${toDoItem['toDoListID']}"] .items-list`).prepend(htmlElement);
}