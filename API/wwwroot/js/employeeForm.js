document.getElementById('employeeForm').addEventListener('submit', function (event) {
    event.preventDefault();
    createOrEditEmploye();
});

function fillFormEmployee(employeeId) {
    fetch(`/Employee/Details/${employeeId}`)
        .then(response => response.json())
        .then(data => {
            document.getElementById('id').value = data.id;
            document.getElementById('firstName').value = data.firstName;
            document.getElementById('lastName').value = data.lastName;
            document.getElementById('title').value = data.title;
            document.getElementById('birthDate').value = data.birthDate;
            document.getElementById('position').value = data.position;
            document.getElementById('companyId').value = data.companyId;
        });
}

function createOrEditEmploye() {
    var id = document.getElementById('id').value;
    var firstName = document.getElementById('firstName').value;
    var lastName = document.getElementById('lastName').value;
    var title = document.getElementById('title').value;
    var birthDate = document.getElementById('birthDate').value;
    var position = document.getElementById('position').value;
    var companyId = document.getElementById('companyId').value;

    var employee = {
        Id: parseInt(id),
        FirstName: firstName,
        LastName: lastName,
        Title: title,
        BirthDate: birthDate,
        Position: parseInt(position),
        CompanyId: parseInt(companyId)
    };

    fetch(id != 0 ? '/Employee/Edit' : '/Employee/Create', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(employee)
    }).then(response => {
        if (response.ok) {
            clearForm(employeeForm);
            refreshTable(paramsEmpl);
        } else {
            alert('Failed to save employee.');
        }
    });
}