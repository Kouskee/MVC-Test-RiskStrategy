function startInitializer() {

    createContainer('history', [
        { func: 'refreshTable', params: paramsHist, icon: 'refresh' }
    ]);
    createContainer('notes', [
        { icon: 'plus' },
        { func: 'refreshTable', params: paramsNote, icon: 'refresh' },
        { func: 'deleteNote', params: [paramsNote, "/Note/Delete/"], icon: 'delete' }
    ]);
    createContainer('employees', [
        { func: 'clearForm', params: employeeForm, icon: 'plus' },
        { func: 'refreshTable', params: paramsEmpl, icon: 'refresh' },
        { func: 'editEmpl', icon: 'pencil' }
    ]);

    createContainer('employeeEdit', [
        { func: 'editEmpl', icon: 'accept' },
        { func: 'deleteEmpl', params: [paramsEmpl, "/Employee/Delete/", employeeForm], icon: 'delete' }
    ], true);
    createContainer('info', [{ func: '', icon: 'accept' }]);

    createTableHead(paramsHist[0], paramsHist[2]);
    createTableHead(paramsNote[0], paramsNote[2]);
    createTableHead(paramsEmpl[0], paramsEmpl[2]);

}
document.addEventListener('DOMContentLoaded', function () {
    createTableBody(...paramsHist);
    createTableBody(...paramsNote);
    createTableBody(...paramsEmpl);
});