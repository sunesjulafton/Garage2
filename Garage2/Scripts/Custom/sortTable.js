$(document).ready(function () {
    $('#sortTable').DataTable({
        "order": [],
        "columnDefs": [{
            "targets": 'no-sort',
            "orderable": false,
        }]
    });
});

