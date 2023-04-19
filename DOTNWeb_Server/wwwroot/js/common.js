/*type je vrsta poruke - greška, uspješno...*/
window.ShowToastr = (type, message) => {
    if (type === "success") {
        /*poruka, podnaslov, timeout*/
        toastr.success(message, "Operation Successful", { timeOut: 5000 });
    }
    if (type === "error") {
        toastr.error(message, "Operation Failed", { timeOut: 5000 });
    }
}

function ShowDeleteConfirmationModel() {
    $('#deleteConfirmationModal').modal('show');
}

function HideDeleteConfirmationModel() {
    $('#deleteConfirmationModal').modal('hide');
}