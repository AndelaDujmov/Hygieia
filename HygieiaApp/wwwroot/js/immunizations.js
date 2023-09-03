$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#immunizations').DataTable({
        destroy: true,
        lengthMenu: [5, 10, 15, 20, 50, 100, 200, 300],
        "ajax": {
            url:"/Admin/Immunization/GetImmunizations"
        },
        "columns": [
            { data: "type", "width": "15%" },
            { data: "usedFor", "width": "15%" },
            {
                data: "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                        <a href="/Admin/Immunization/Edit?id=${data}"
                        class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Edit</a>
     
                        <a href="/Admin/Immunization/Delete/${data}"
                        class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
					</div>
                        `
                },
                "width": "15%"
            }
        ]
    });
}