function BtnDeleteClicked() {
    var docNo = $('#DocumentNumber').val();
    var url = '/Order/RemoveOrder';
    Swal.fire({
        title: 'Confirmation',
        text: "Are You Sure Want to Delete Order Having Number " + docNo + " ?",
        icon: 'question',
        customClass: 'swal-wide',
        confirmButtonText: "Yes",
        cancelButtonText: "No",
        cancelButtonClass: 'btn-cancel',
        confirmButtonColor: '#2527a2',
        showCancelButton: true,
    }).then(callback);
    function callback(result) {
        if (result.value) {
            var x = '{"DocumentNumber":"' + docNo + '"}';
            $.ajax({
                method: 'POST',
                url: url,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: x,
                success: function (data) {
                    $(data).each(function (index, item) {
                        if (item.bResponseBool == true) {
                            Swal.fire({
                                title: 'Success',
                                text: 'Order Having Number ' + docNo + ' Removed Successfully.',
                                icon: 'success',
                                customClass: 'swal-wide',
                                buttons: {
                                    confirm: 'Ok'
                                },
                                confirmButtonColor: '#2527a2',
                            }).then(callback);
                            function callback(result) {
                                if (result.value) {
                                    window.location.href = "/Order/Index";
                                }
                            }
                        }
                        else {
                            Swal.fire({
                                title: 'Error!',
                                text: 'Failed To Remove Order Having Number ' + docNo,
                                icon: 'error',
                                customClass: 'swal-wide',
                                buttons: {
                                    confirm: 'Ok'
                                },
                                confirmButtonColor: '#2527a2',
                            });
                        }
                    });
                },
            });
        }
    }
};
function BtnCancelClicked() {
    var docNo = $('#DocumentNumber').val();
    var url = '/Order/CancelOrder';
    Swal.fire({
        title: 'Confirmation',
        text: "Are You Sure Want to Cancel Order Having Number " + docNo + " ?",
        icon: 'question',
        customClass: 'swal-wide',
        confirmButtonText: "Yes",
        cancelButtonText: "No",
        cancelButtonClass: 'btn-cancel',
        confirmButtonColor: '#2527a2',
        showCancelButton: true,
    }).then(callback);
    function callback(result) {
        if (result.value) {
            var x = '{"DocumentNumber":"' + docNo + '"}';
            $.ajax({
                method: 'POST',
                url: url,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: x,
                success: function (data) {
                    $(data).each(function (index, item) {
                        if (item.bResponseBool == true) {
                            Swal.fire({
                                title: 'Success',
                                text: 'Order Having Number ' + docNo + ' Cancelled Successfully.',
                                icon: 'success',
                                customClass: 'swal-wide',
                                buttons: {
                                    confirm: 'Ok'
                                },
                                confirmButtonColor: '#2527a2',
                            }).then(callback);
                            function callback(result) {
                                if (result.value) {
                                    window.location.href = "/Order/Index";
                                }
                            }
                        }
                        else {
                            Swal.fire({
                                title: 'Error!',
                                text: 'Failed To Cancel Order Having Number ' + docNo,
                                icon: 'error',
                                customClass: 'swal-wide',
                                buttons: {
                                    confirm: 'Ok'
                                },
                                confirmButtonColor: '#2527a2',
                            });
                        }
                    });
                },
            });
        }
    }
};