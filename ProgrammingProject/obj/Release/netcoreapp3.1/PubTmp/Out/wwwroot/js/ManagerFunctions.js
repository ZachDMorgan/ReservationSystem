function confirmDelete(uniqueId, isDeleteClicked) {
    var deleteSpan = 'deleteSpan_' + uniqueId;
    var confirmDeleteSpan = 'confirmDeleteSpan_' + uniqueId;

    if (isDeleteClicked) {
        $('#' + deleteSpan).hide();
        $('#' + confirmDeleteSpan).show();
    } else {
        $('#' + deleteSpan).show();
        $('#' + confirmDeleteSpan).hide();
    }
}

$(() => {

    $(".btn-manager").click((e) => {

        var userId = $(e.currentTarget).data('user'); 
        var action = $(e.currentTarget).data('action'); 

        fetch(`/api/roles/${action}/${userId}/manager`, { method: 'POST' })
            .then(response => {

                if (response.status == '200') {

                    if (action == 'add') {
                        $(e.currentTarget).data('action', 'remove');
                        $(e.currentTarget).removeClass('btn-success');
                        $(e.currentTarget).addClass('btn-danger');
                        $(e.currentTarget).val('Remove');

                        location.reload();
                    }
                    else {
                        $(e.currentTarget).data('action', 'add');
                        $(e.currentTarget).removeClass('btn-danger');
                        $(e.currentTarget).addClass('btn-success');
                        $(e.currentTarget).val('Add');

                        location.reload();
                    }
                }
                else {
                    alert('oops, something went wrong :('); 
                }
            })
    });
})