"use strict";

const common = require('./common');
const init = () => {
    let checkBoxes = $('.item-complete');
    for (let box of checkBoxes) {
        checkBox(box);
    }
};

$('.to-do-item').click(function (e) {
    if ($(e.target).is('svg')) {
        return;
    }

    e.preventDefault();
    let box = $(this).children('.item-info').children('.item-complete');
    let complete = $(box).data('complete') === 'True' ? 'False' : 'True';    

    $(box).data('complete', complete);
    checkBox(box);
});

function checkBox(selector) {
    let complete = $(selector).data('complete');
    if (complete === 'True') {
        $(selector).attr('checked', 'checked');
        $(selector).siblings('.item-title').addClass('strike');
    } else {
        $(selector).removeAttr('checked');
        $(selector).siblings('.item-title').removeClass('strike');
    }
}

module.exports = {
    init
};