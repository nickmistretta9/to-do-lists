"use strict";

$('.delete-item').click(function (e) {
    let item = $(this).parents('.to-do-item');
    let toDoData = {
        id: parseInt(item.data('item-id')),
        toDoListID: parseInt(item.parents('.to-do-list').data('id'))
    };

    $.ajax({
        url: '/api/items/delete',
        data: JSON.stringify(toDoData),
        type: 'POST',
        contentType: 'application/json',
        success: function (data) {
            $(item).remove();
        }
    });
});