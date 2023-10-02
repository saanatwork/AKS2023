function SubmitBtnClicked() {
    Swal.fire({
        title: 'Confirmation',
        text: "Are You Sure Want To Update A Return Document With The Selected Items?",
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
            var vendor = $('#cVendors').val();
            var schrecords = GetSelectedItemQty();
            var x = '{"VendorID":"' + vendor                
                + '","Items":' + schrecords + '}';
            $.ajax({
                method: 'POST',
                url: '/Inventory/ReturnAppStock',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: x,
                success: function (data) {
                    $(data).each(function (index, item) {
                        if (item.bResponseBool == true) {
                            Swal.fire({
                                title: 'Success',
                                text: item.sResponseString,
                                icon: 'success',
                                customClass: 'swal-wide',
                                buttons: {
                                    confirm: 'Ok'
                                },
                                confirmButtonColor: '#2527a2',
                            }).then(callback);
                            function callback(result) {
                                if (result.value) {
                                    window.location.href = "/Inventory/ReturnAppIndex";
                                }
                            }
                        }
                        else {
                            Swal.fire({
                                title: 'Error!',
                                text: 'Failed To Place Order Due To: ' + item.sResponseString,
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
function GetSelectedItemQty() {
    var result = '';
    $('.itemselected').each(function () {
        var that = $(this);
        var itemcode = that.attr('id');
        var qty = that.find('.mQty').val();
        result = result+'{"ItemCode":"' + itemcode + '","Qty":"' + qty+'"},';
    });
    result = result.replace(/,\s*$/, "");
    result = '[' + result + ']';
    return result;
};
function SelectionChanged() {
    var myCtrl = $(SelectionChanged.caller.arguments[0].target);
    var isChecked = myCtrl.prop("checked");
    var mRow = myCtrl.closest('tr');
    if (isChecked) {
        mRow.addClass('itemselected');
    }
    else {
        mRow.removeClass('itemselected');
    }
    EnableSaveBtn();
};
function QtyChanged() {
    var myCtrl = $(QtyChanged.caller.arguments[0].target);
    if (myCtrl.val() > 0) {
        myCtrl.isValid();
    } else {
        myCtrl.isInvalid();
    }
    EnableSaveBtn();
};
function EnableSaveBtn() {
    var myBtn = $('#btnSubmit');
    var errorcount = $('.is-invalid').length;
    var selectioncount = $('.itemselected').length
    if (errorcount == 0 && selectioncount>0) {        
        myBtn.makeEnabled();
    }
    else {
        myBtn.makeDisable();
    }
    //alert(GetSelectedItemQty());
};
function VendorChanged() {
    var myCtrl = $('#cVendors');
    var destinationContainer = $('#tbody1');
    var vendorid = myCtrl.val();
    if (vendorid != '') {
        myCtrl.isValid();
        var url = '/Inventory/GetLiveItemsOfaVendor?VendorID=' + vendorid;
        GetDataFromAjax(url).done(function (data) {            
            var htmlValue = '';
            var sl = 1;
            $(data).each(function (index,item) {
                htmlValue = htmlValue + '<tr id="' + item.ItemCode+'">';
                htmlValue = htmlValue + '<td>' + sl + '</td>';
                htmlValue = htmlValue + '<td>' + item.UserRemarks + '</td>';
                htmlValue = htmlValue + '<td>' + item.ItemCatCode + ' - ' + item.ItemCatLongText+'</td>';
                htmlValue = htmlValue + '<td>' + item.ItemDescription + '</td>';
                htmlValue = htmlValue + '<td>';
                htmlValue = htmlValue + '<input type="text" onkeyup = "QtyChanged()" class="form-control mQty" value = "' + item.Qty+'">';
                htmlValue = htmlValue + '</td>';
                htmlValue = htmlValue + '<td>';
                htmlValue = htmlValue + '<input type="checkbox" name="checkbox" onchange="SelectionChanged()" class="mcheck" value="checked">';
                htmlValue = htmlValue + '</td>';
                htmlValue = htmlValue + '</tr>';
                sl = sl + 1;
            });
            destinationContainer.html(htmlValue);
        });
    }
    else {
        myCtrl.isInvalid(); destinationContainer.html('');
    }
    
};