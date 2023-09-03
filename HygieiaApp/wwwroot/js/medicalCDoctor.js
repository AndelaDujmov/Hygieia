var tables;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    tables = $('#myTable').DataTable({
        destroy: true,
        lengthMenu: [5, 10, 15, 20, 50, 100, 200, 300],
        "ajax": {
            url: "/Admin/MedicalCondition/GetAll"
        },
        "columns": [
            {data: "type", "width": "15%"},
            {data: "nameOfDiagnosis", "width": "15%"},
            {
                data: "id",
                "render": function (data) {
                    return ` 
                        <div class="w-25 btn-group" role="group">
                      
                        <a href="/Admin/MedicalCondition/Info?id=${data}"
                        class="btn btn-primary mx-2" style="width: 22px"> <i class="bi bi-info-circle"></i> Info</a>
                        
					</div>
                        `
                },
                "width": "15%"
            }
        ]

    });
}
