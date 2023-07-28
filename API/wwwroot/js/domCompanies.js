async function loadGridData() {
    const response = await fetch('/Company/GetData');
    const data = await response.json();

    const columns = ['City', 'State', 'Phone'];

    const tbody = document.getElementById('companyTBody');

    data.forEach(item => {
        const row = document.createElement('tr');
        const tdLink = document.createElement('td');

        const link = document.createElement('a')

        link.textContent = item['Company name'];
        link.href = `/Company/Edit/${item['Id']}`;
        link.classList.add("text-decoration-none", "text-dark");
        tdLink.appendChild(link);

        row.appendChild(tdLink);

        columns.forEach(column => {
            const td = document.createElement('td');
            td.textContent = item[column];
            row.appendChild(td);
        });

        tbody.appendChild(row);
    });
}

window.addEventListener('load', loadGridData);