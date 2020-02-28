"use strict";

const common = require('./common');

$('.add-new-list').click(function (e) {
    e.preventDefault();
    common.functions.showListModal();
    $('.new-to-do-list-description').val('');
});

$('.save-to-do-list').click(function (e) {
    e.preventDefault();
    let toDoListData = {
        content: $('.new-to-do-list-description').val()
    };

    $.ajax({
        type: 'POST',
        url: '/api/lists/create',
        contentType: 'application/json',
        data: JSON.stringify(toDoListData),
        success: function (data) {
            appendNewToDoList(data);
            common.functions.closeListModal();
        },
        error: function (data) {
            alert(`Error Adding To Do: ${data}`);
        }
    });
});

function appendNewToDoList(toDoList) {
    const htmlElement = `<div class="to-do-list" data-id="${toDoList['id']}">
                            <div class="list-title">${toDoList['title']}</div>
                            <div class="items-list"></div>
                            <div class="to-do-item add-new">
                                <a href="javascript:void('')">
                                    <i class="fas fa-plus-square"></i>
                                    <div class="item-title">Add New To Do List Item</div>
                                </a>
                            </div>
                        </div>`;

    $('.to-do-wrapper > .flex').append(htmlElement);
}