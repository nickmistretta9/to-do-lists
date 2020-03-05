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
        title: $('.new-to-do-list-description').val(),
        userID: 1
    };

    console.log(toDoListData);

    $.ajax({
        type: 'POST',
        url: '/api/lists/create',
        contentType: 'application/json',
        data: JSON.stringify(toDoListData),
        success: function (data) {
            common.functions.closeListModal();
            appendNewToDoList(data);
        },
        error: function (data) {
            alert(`Error Adding To Do: ${data}`);
        }
    });
});

function appendNewToDoList(toDoList) {
    const htmlElement = `<div class="to-do-list" data-id="${toDoList['id']}">
                            <div class="list-title">
                                <div class="actions">
                                    <a href="javascript:void('')" class="edit-list"><i class="far fa-edit"></i></a>
                                    <a href="javascript:void('')" class="delete-list"><i class="far fa-trash-alt"></i></a>
                                </div>
                                <p class="title">${toDoList['title']}</p>
                            </div>
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