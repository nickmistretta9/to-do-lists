"use strict";

$('.close > a').click(function (e) {
    e.preventDefault();
    functions.closeModal();
    functions.closeListModal();
});

$('.btn-cancel').click(function (e) {
    e.preventDefault();
    functions.closeModal();
    functions.closeListModal();
});

const functions = {
    closeModal: () => {
        $('.new-item-modal').addClass('out-of-view');
    },
    showModal: () => {
        $('.new-item-modal').removeClass('out-of-view');
    },
    showListModal: () => {
        $('.new-list-modal').removeClass('out-of-view');
    },
    closeListModal: () => {
        $('.new-list-modal').addClass('out-of-view');
    }
};

module.exports = {
    functions
}