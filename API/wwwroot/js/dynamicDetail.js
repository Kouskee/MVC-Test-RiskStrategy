function createContainer(id, iconCollection, isNoname, isNoTable) {
    const mainContainer = document.getElementById(id);

    const divContainer = document.createElement('div');

    divContainer.classList.add("row", "mb-3");

    const divName = document.createElement('div');
    if (!isNoname) {
        const name = id.charAt(0).toUpperCase() + id.slice(1);
        divName.innerHTML = `<h5>${name}</h5>`;
    }

    divName.classList.add("col-md-6");

    const divIcons = document.createElement('div');
    divIcons.classList.add("col-md-6", "d-flex", "justify-content-end");

    for (const item of iconCollection) {
        var iconClass;
        if (item.icon == "accept") {
            iconClass = document.createElement('button');
            iconClass.classList.add("icon-button");
            iconClass.type = "submit";
        }
        else {
            iconClass = document.createElement('a');
            iconClass.classList.add("text-decoration-none", "text-black", "mx-1");
        }

        if (item.func) {
            const fn = window[item.func];
            iconClass.onclick = () => { fn(item.params); };
        }

        const svgCode = getSvgCode(item.icon);
        iconClass.innerHTML = svgCode;

        divIcons.appendChild(iconClass);
    }

    divContainer.appendChild(divName);
    divContainer.appendChild(divIcons);

    mainContainer.appendChild(divContainer);
    
}

function createTableHead(idContainer, columns) {
    const mainContainer = document.getElementById(idContainer);

    const table = document.createElement('table');
    table.id = idContainer + 'form';
    table.classList.add("table", "table-hover", "table-bordered");

    const thead = document.createElement('thead');
    thead.classList.add("text-muted");
    const headerRow = document.createElement('tr');

    columns.forEach(column => {
        const th = document.createElement('th');
        th.textContent = column;
        headerRow.appendChild(th);
    });

    thead.appendChild(headerRow);
    table.appendChild(thead);

    mainContainer.appendChild(table);
}

async function createTableBody(idContainer, url, columns, isClickable) {

    const response = await fetch(url);
    const data = await response.json();

    const table = document.getElementById(idContainer + 'form');
    const tbody = document.createElement('tbody');

    data.forEach(item => {
        const bodyRow = document.createElement('tr');
        columns.forEach(column => {
            const td = document.createElement('td');
            td.textContent = item[column];
            bodyRow.appendChild(td);
        });

        if (isClickable) {
            bodyRow.onclick = () => {
                SelectedId = item['Id'];
                ContainerName = idContainer;
            };
        }

        tbody.appendChild(bodyRow);
    });

    table.appendChild(tbody);
}


