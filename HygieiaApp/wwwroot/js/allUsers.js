var tables;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    tables = $('#myTable').DataTable({
        destroy: true,
        lengthMenu: [5, 10, 15, 20, 50, 100, 200, 300],
        "ajax": {
            url:"/Admin/User/GetAll"
        },
        "columns": [
            { data: "oib", "width": "15%" },
            { data: "firstName", "width": "15%" },
            { data: "lastName", "width": "15%" },
            {
                data: "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                        <a href="/Admin/User/Edit?id=${data}"
                        class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Edit</a>
                        <a href="/Admin/User/Info?id=${data}"
                        class="btn btn-primary mx-2"> <i class="bi bi-info-circle"></i> Info</a>
                        <a href="/Admin/User/Delete/${data}"
                        class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
					</div>
                        `
                },
                "width": "15%"
            }

        ]
    });
}

function loadDataTable2() {
    tables = $('#table').DataTable({
        destroy: true,
        "ajax": {
            url:"/Admin/User/GetAllDeleted"
        },
        "columns": [
            { data: "oib", "width": "15%" },
            { data: "firstName", "width": "15%" },
            { data: "lastName", "width": "15%" }
        ]
    });

}