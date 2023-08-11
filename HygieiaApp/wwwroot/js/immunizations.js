

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#myTable').DataTable({
        "ajax": {
            url:"/Admin/Immunization/GetImmunizations"
        },
        "columns": [
            { data: "type", "width": "15%" },
            { data: "usedFor", "width": "15%" }
        ]
    });
}