var tables;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    tables = $('#myTable').DataTable({
        destroy: true,
        lengthMenu: [5, 10, 15, 20, 50, 100, 200, 300],
        "ajax": {
            url:"/Admin/Medication/GetAll"
        },
        "columns": [
            { data: "class", "width": "15%" },
            { data: "name", "width": "15%" },
            {
                data: "id",
                "render": function (data) {
                    return `
                        <a href="/Admin/Medication/Info?id=${data}"
                        class="btn btn-primary mx-2"> <i class="bi bi-info-circle"></i> Info</a>
					</div>
                        `
                },
                "width": "15%"
            }
        ]

    });

}