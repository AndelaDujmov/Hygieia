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
           
        ]
    });
}