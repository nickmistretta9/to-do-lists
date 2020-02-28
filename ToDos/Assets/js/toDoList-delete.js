"use strict";

$('.delete-list').click(function (e) {
    let list = $(this).parents('.to-do-list');
    let toDoData = {
        id: parseInt(list.data('id'))
    };

    $.ajax({
        url: '/api/lists/delete',
        data: JSON.stringify(toDoData),
        type: 'POST',
        contentType: 'application/json',
        success: function (data) {
            $(list).remove();
        }
    });
});