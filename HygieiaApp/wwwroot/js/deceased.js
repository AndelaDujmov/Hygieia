var tables;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    tables = $('#myTable').DataTable({
        destroy: true,
        lengthMenu: [5, 10, 15, 20, 50, 100, 200, 300],
        "ajax": {
            url: "/Doctor/Doctor/Deceased/"
        },
        "columns": [
            {data: "firstName", "width": "15%"},
            {data: "lastName", "width": "15%"},
            {data: "dateOfBirth", "width": "15%"},
        ]

    });

}