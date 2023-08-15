var tables;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    tables = $('#myTable').DataTable({
        destroy: true,
        lengthMenu: [5, 10, 15, 20, 50, 100, 200, 300],
        "ajax": {
            url:"/Admin/Medication/GetAllDeleted"
        },
        "columns": [
            { data: "class", "width": "15%" },
            { data: "name", "width": "15%" },
            {
                data: "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                        <a href="/Admin/Medication/UndoMedication?id=${data}"
                        class="btn btn-primary mx-2">  <i class="bi bi-arrow-counterclockwise"></i></i> Undo</a>
                     
					</div>
                        `
                },
                "width": "15%"
            }
        ]

    });

}