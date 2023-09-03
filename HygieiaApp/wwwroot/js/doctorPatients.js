var tables;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    tables = $('#myTable').DataTable({
        destroy: true,
        lengthMenu: [5, 10, 15, 20, 50, 100, 200, 300],
        "ajax": {
            url: "/Doctor/Doctor/GetMyPatients"
        },
        "columns": [
            {data: "oib", "width": "15%"},
            {data: "mbo", "width": "15%"},
            {data: "firstName", "width": "15%"},
            {data: "lastName", "width": "15%"},
            {
                data: "id",
                "render": function (data) {
                    return `
                    <div class="w-75 btn-group" role="group">
                        <a href="/Doctor/Doctor/PatientInfo?id=${data}"
                        class="btn btn-primary mx-2"> <i class="bi bi-info-circle"></i> </a>
                        <a href="/Doctor/Doctor/Remove/${data}"
                        class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> </a>
					</div>
                        `
                },
                "width": "15%"
            }
        ]

    });

}