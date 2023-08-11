
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    tables = $('#myTable').DataTable({
        "ajax": {
            url:"/Admin/MedicalCondition/GetAll"
        },
        "columns": [
            { data: "type", "width": "15%" },
            { data: "nameOfDiagnosis", "width": "15%" }
        ]
    });
}