
$(document).ready(function () {
    loadGrid();
});

function loadGrid(){
    var docElem = document.documentElement;
    var kanban = document.querySelector('.task-demo');
    var board = kanban.querySelector('.board');
    var itemContainers = Array.prototype.slice.call(kanban.querySelectorAll('.board-column-content'));
    var columnGrids = [];
    var dragCounter = 0;
    var boardGrid;

    itemContainers.forEach(function (container) {

        var muuri = new Muuri(container, {
            items: '.board-item',
            layoutDuration: 400,
            layoutEasing: 'ease',
            dragEnabled: true,
            dragSortInterval: 0,
            dragSortGroup: 'column',
            dragSortWith: 'column',
            dragContainer: document.body,
            dragReleaseDuration: 400,
            dragReleaseEasing: 'ease'
        })
        .on('dragStart', function (item) {
            ++dragCounter;
            docElem.classList.add('dragging');
            item.getElement().style.width = item.getWidth() + 'px';
            item.getElement().style.height = item.getHeight() + 'px';
        })
        .on('dragEnd', function (item) {
            if (--dragCounter < 1) {
                docElem.classList.remove('dragging');
            }
        })
        .on('dragReleaseEnd', function (item) {
            item.getElement().style.width = '';
            item.getElement().style.height = '';
            columnGrids.forEach(function (muuri) {
                muuri.refreshItems();
            });
        })
        .on('layoutStart', function () {
            boardGrid.refreshItems().layout();
        })
        .on('receive', function (data) {
            console.log(data.item);
            console.log(data.fromGrid);
            console.log(data.toGrid);
            console.log(data.fromIndex);
            console.log(data.toIndex);
        });

        columnGrids.push(muuri);

    });

    boardGrid = new Muuri(board, {
        layoutDuration: 400,
        layoutEasing: 'ease',
        dragEnabled: true,
        dragSortInterval: 0,
        dragStartPredicate: {
            handle: '.board-column-header'
        },
        dragReleaseDuration: 400,
        dragReleaseEasing: 'ease'
    });
}

function removeTask(taskManageId) {
    if (taskManageId == 0 || taskManageId == undefined){
        return;
    }

    $.ajax({
        url: relativeRoot + 'TaskManage/Delete',
        type: 'GET',
        cache: false,
        data: { 'id': taskManageId },
        success: function (result) {
            document.location = relativeRoot + 'TaskManage/Index';
        }
    });
}