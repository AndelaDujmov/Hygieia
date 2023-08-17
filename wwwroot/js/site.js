// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this pr
$(document).ready(function(){
    loadDataTable();
})

var loadDataTable = () => {
    dataTable = $('#myTable').DataTable( {
        ajax: '/Admin/Immunization/GetImmunizations'
    } );
}

