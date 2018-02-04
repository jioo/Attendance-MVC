$(document).ready(function () {

    /*
     * DataTable Functions
    **/
    $('#DefaultDataTable').DataTable({
        responsive: true,
        "order": [],
        columnDefs: [
            { orderable: false, targets: -1 }
        ],
        "sPaginationType": "full_numbers",
        "language": {
            "lengthMenu": "Show _MENU_ items per page",
            "zeroRecords": "Nothing found. Please change your search term",
            "info": "Showing _START_ to _END_ of _TOTAL_ entries",
            "infoEmpty": "No results",
            "infoFiltered": "(filtered out of _MAX_)",
            "search": "Search:",
            "paginate": {
                "first": "First",
                "last": "Last",
                "next": "&raquo;",
                "previous": "&laquo;"
            }
        },
        dom: "<'row'<'col-sm-6 col-xs-12'l><'col-sm-6 col-xs-10'f>>" +
         "<'row'<'col-sm-5'i><'col-sm-7'p>>" +
         "<'row'<'col-sm-12'tr>>" +
         "<'row'<'col-sm-5'i><'col-sm-7'p>>"
    });
});

function ShowPreview(input) {
    if (input.files && input.files[0]) {

        var reader = new FileReader();
        reader.onload = function (e) {
            $("#EmployeePicture").attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}

function ResetPicture() {
    $("input[type='hidden'][name='Picture']").val('user.png');
    $("#EmployeePicture").attr('src', "/Images/user.png");
    
}

function DisplayModal() {
    $('#Modal').modal({
        backdrop: 'static',
        keyboard: false
    });
}

$.ajaxSetup({
    beforeSend: AjaxBeforeSend,
    complete: AjaxComplete
});

function AjaxBeforeSend() {
    NProgress.start();
}
function AjaxComplete() {
    NProgress.done();
}

function AjaxDataTable(tableId, ajaxSource) {
    var oTable = $(tableId)
        .DataTable({
            responsive: true,
            "order": [],
            columnDefs: [
                { orderable: false, targets: -1 }
            ],
            ajax: {
                url: ajaxSource,
                dataFilter: function (data) {
                    var json = jQuery.parseJSON(data);
                    json.recordsTotal = json.total;
                    json.recordsFiltered = json.total;
                    json.data = json.list;
                    return JSON.stringify(json); // return JSON string
                },
                beforeSend: function () {
                    NProgress.start();
                },
                complete: function () {
                    NProgress.done();
                },
                error: function (xhr, e) {
                    console.log(xhr.responseText);
                }
            },
            "sPaginationType": "full_numbers",
            "language": {
                "lengthMenu": "Show _MENU_ items per page",
                "zeroRecords": "Nothing found. Please change your search term",
                "info": "Showing _START_ to _END_ of _TOTAL_ entries",
                "infoEmpty": "No results",
                "infoFiltered": "(filtered out of _MAX_)",
                "search": "Search:",
                "paginate": {
                    "first": "First",
                    "last": "Last",
                    "next": "&raquo;",
                    "previous": "&laquo;"
                }
            },
            dom: "<'row'<'col-sm-6 col-xs-12'l><'col-sm-6 col-xs-10'f>>" +
             "<'row'<'col-sm-5'i><'col-sm-7'p>>" +
             "<'row'<'col-sm-12'tr>>" +
             "<'row'<'col-sm-5'i><'col-sm-7'p>>"
        });

    return oTable;
}