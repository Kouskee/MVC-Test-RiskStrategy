var SelectedId = null;
var SelectedContainerName = null;

function selectRow(containerId, Id, row) {
    clearSelection();

    row.classList.add("selected");

    SelectedContainerName = containerId;
    SelectedId = Id;
}

function clearSelection() {
    if (SelectedContainerName) {
        const previousTable = document.getElementById(SelectedContainerName);
        const previousRow = previousTable.querySelector('.selected');
        previousRow.classList.remove("selected");
    }
}

function clearDataSelection() {
    SelectedId = null;
    SelectedContainerName = null;
}