"use strict";

$('.close > a').click(function (e) {
    e.preventDefault();
    functions.closeModal();
});

$('.btn-cancel').click(function (e) {
    e.preventDefault();
    functions.closeModal();
});

const functions = {
    closeModal: () => {
        $('.new-item-modal').addClass('out-of-view');
    },
    showModal: () => {
        $('.new-item-modal').removeClass('out-of-view');
    }
};

module.exports = {
    functions
}