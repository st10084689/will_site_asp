var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "Events/GetAll"
        },
        "columns": [
            { "data": "title", "width": "15%" },
            { "data": "description", "width": "15%" },
            { "data": "images", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                    <div class="w-75 btn-group" role="group">
                        <a href="Events/Upsert?id=${data}">
                         <i class="bi bi-pencil-square"></i> edit</a>
                        <a class="btn btn-danger" onClick=Delete('/Events/Delete/${data}')> <i class=" bi bi-x-circle"></i> Delete</a>
                </div>
                    `
                },
                "width": "15%"
            },

        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }

                    else {
                        toastr.error(data.message)
                    }
                }
            })
        }
    })
}