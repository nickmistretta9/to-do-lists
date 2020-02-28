"use strict";

const initialize = () => {
    const common = require('./common');

    // To Do List Items
    const itemUpdate = require('./toDoListItem-Update');
    const itemDelete = require('./toDoListItem-delete');
    const itemAdd = require('./toDoListItem-add');
    const toDoListItems = require('./toDoListItems');
    toDoListItems.init();

    // To Do Lists
    const listAdd = require('./toDoList-add');
    const listUpdate = require('./toDoList-update');
    const listDelete = require('./toDoList-delete');
};

$(document).ready(initialize);