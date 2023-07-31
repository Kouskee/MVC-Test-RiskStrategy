function refreshTable(parameters) {
    var tableContainer = document.getElementById(parameters[0]);
    var tbody = tableContainer.querySelector('tbody');

    if (tableContainer.id == SelectedContainerName) {
        clearDataSelection();
    }

    if (tbody) {
        tbody.outerHTML = '';
    }

    createTableBody(...parameters);
}

function editEmpl() {
    if (SelectedContainerName == "employees" && SelectedId) {
        fillFormEmployee(SelectedId);
    }
}

function deleteEmpl(paramsArr) {
    if (SelectedContainerName == "employees" && SelectedId) {
        var url = paramsArr[1] + SelectedId;
        deleteEnity(paramsArr[0], url).then(() => {
            clearForm(paramsArr[2]);
        }).catch(error => {
            console.error(error);
        });
    }
}

function deleteNote(paramsArr) {
    if (SelectedContainerName == "notes" && SelectedId) {
        var url = paramsArr[1] + SelectedId;
        deleteEnity(paramsArr[0], url).catch(error => {
            console.error(error);
        });
    }
}

function deleteEnity(parameters, url) {
    return fetch(url, {
        method: 'DELETE'
    }).then(response => {
        if (response.ok) {
            refreshTable(parameters);
        } else {
            throw new Error('Error when deleting an object');
        }
    }).catch(error => {
        throw new Error(`Error server: ${error}`);
    });
}

function clearForm(idForm) {
    var form = document.getElementById(idForm);
    form.reset();
}
