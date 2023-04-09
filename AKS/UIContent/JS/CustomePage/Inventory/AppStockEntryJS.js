function GetAppStockRecords(tableName) {
    //The fields should have an attribute "data-name", Which is the property name of the MVC object
    var MVariant = '';
    var DVariant = '';
    var SVariant = '';
    var schrecords = '';
    var dataname;
    var datavalue;
    var mrecord = '';
    $('#' + tableName + ' .Ptbody').each(function () {
        mRow = $(this);
        mRow.find('[data-name]').each(function () {
            that = $(this);
            dataname = that.attr('data-name');
            if (that.hasClass('htmlVal')) {
                datavalue = that.html();
            }
            else { datavalue = that.val(); }
            mrecord = mrecord + '"' + dataname + '":"' + datavalue + '",';
        });
        mRow.find('[data-name-text]').each(function () {
            that = $(this);
            dataname = that.attr('data-name-text');
            thatid = that.attr('id');
            datavalue = $('#' + thatid + ' option:selected').toArray().map(item => item.text).join();
            mrecord = mrecord + '"' + dataname + '":"' + datavalue + '",';
        });
        //mrecord = mrecord.replace(/,\s*$/, "");
        MVariant = GetRecordsFromChildTableBody(mRow, 'MVTable');
        DVariant = GetRecordsFromChildTableBody(mRow, 'DVTable');
        SVariant = GetRecordsFromChildTableBody(mRow, 'SVTable');
        mrecord = mrecord+ '"MetalVariants":' + MVariant
            + ',"DiamondVariants":' + DVariant
            + ',"StoneVariants":' + SVariant
        schrecords = schrecords + '{' + mrecord + '},';
        mrecord = '';
        MVariant = '';
        DVariant = '';
        SVariant = '';
    });
    schrecords = schrecords.replace(/,\s*$/, "");
    schrecords = '[' + schrecords+']';
    return schrecords;
};
function SubmitBtnClicked() {
    var vendor = $('#cVendors').val();
    var docNumber = $('#cDocumentNumber').val();
    var docDate = $('#cDocumentDate').val();
    var schrecords = GetAppStockRecords('tblDataList');
    var x = '{"VendorID":"' + vendor
        + '","DocNo":"' + docNumber
        + '","DocDate":"' + docDate
        + '","AppStockList":' + schrecords + '}';
    alert(x);
    $.ajax({
        method: 'POST',
        url: '/Inventory/SetAppStock',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: x,
        success: function (data) {
            $(data).each(function (index, item) {
                if (item.bResponseBool == true) {
                    $('#cCategoryCode').val('').isInvalid();
                    $('#cCategoryLongText').val('').isInvalid();
                    $('#cHSNCode').val('').isInvalid();
                    $('#cIsActive').val('').isInvalid();

                    $('#btnSave').makeDisable();
                    Swal.fire({
                        title: 'Success',
                        text: 'Category Information Saved Successfully.',
                        icon: 'success',
                        customClass: 'swal-wide',
                        buttons: {
                            confirm: 'Ok'
                        },
                        confirmButtonColor: '#2527a2',
                    });
                    dtinstance.ajax.reload();
                }
                else {
                    Swal.fire({
                        title: 'Error!',
                        text: 'Failed To Save Category Information.',
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
};
function ValidateChildCloneRowControl() {
    var myCtrl = $(ValidateChildCloneRowControl.caller.arguments[0].target);
    var myCtrlId = myCtrl.attr('id');
    var myRowid = 0;
    if (myCtrlId.indexOf('_') >= 0) {
        myCtrlId = myCtrl.attr('id').split('_')[1];
        myRowid = myCtrl.attr('id').split('_')[0]
    }
    if (myCtrlId.indexOf('-') >= 0) {
        myCtrlId = myCtrlId.split('-')[0];
    }    
    var isvalid = validatectrl(myCtrlId, myCtrl.val(), myRowid);
    if (isvalid) { myCtrl.isValid(); } else { myCtrl.isInvalid(); }
    SaveBtnStatus();
};
function ValidateCloneRowControl() {
    var myCtrl = $(ValidateCloneRowControl.caller.arguments[0].target);
    var myCtrlId = myCtrl.attr('id');
    if (myCtrlId.indexOf('_') >= 0) { myCtrlId = myCtrl.attr('id').split('_')[0]; }
    var isvalid = validatectrl(myCtrlId, myCtrl.val(),1);
    if (isvalid) { myCtrl.isValid(); } else { myCtrl.isInvalid(); }
    SaveBtnStatus();
};
function ValidateControl() {
    var myCtrl = $(ValidateControl.caller.arguments[0].target);
    var isvalid = validatectrl(myCtrl.attr('id'), myCtrl.val(),1);
    if (isvalid) { myCtrl.isValid(); } else { myCtrl.isInvalid(); }
    SaveBtnStatus();
};
function validatectrl(targetid, value,spltag) {
    var isvalid = false;
    switch (targetid) {
        case "cDocumentNumber":
            isvalid = IsAlphaNumeric(value);
            break;
        case "cCategoryLongText":
            isvalid = IsAlphaNumericWithSpace(value);
            break;
        case "cQty":
            if (IsValidInteger(value)) {
                if (value > 0) { isvalid = true; }
            }
            break;
        case "cRemarks":
            isvalid = IsAlphaNumericWithSpace(value);
            break;
        case "cDiamondVariant":
        case "cStoneVariant":
            if (spltag == 0) {
                isvalid = true;
            }
            else if (value != '') {
                isvalid = true;
            }
            break;
        case "cVendors":
        case "cDocumentDate":
        case "cItemCategory":
        case "cMetalVariant":        
            if (value != '') { isvalid = true; }
            break;
        case "cMetalWt":
        case "cDiamondWt":
        case "cStoneWt":
            isvalid = IsValidIntegerOrDecimal(value);
            break;
    }
    return isvalid;
};
function SaveBtnStatus() {
    //alert($('.is-invalid').length);
    var btnSubmitCtrl = $('#btnSubmit');
    if ($('.is-invalid').length > 0) {
        btnSubmitCtrl.makeDisable();
    }
    else {
        btnSubmitCtrl.makeEnabled();
    }
};
function AddMVClicked() {
    var row = $(AddMVClicked.caller.arguments[0].target.closest('tbody'));
    var sBody = 'mvTBody1';
    var dBody = 'mvTBody2';
    if (row.attr('id').indexOf('-') >= 0) {
        var rowid = row.attr('id').split('-')[1];
        sBody = 'mvTBody1-' + rowid;
        dBody = 'mvTBody2-' + rowid;
    }    
    var rowid = CloneRowChildTableReturningID(sBody, dBody, true, false);
};
function AddDVClicked() {
    var row = $(AddDVClicked.caller.arguments[0].target.closest('tbody'));
    var sBody = 'dvTBody1';
    var dBody = 'dvTBody2';
    if (row.attr('id').indexOf('-') >= 0) {
        var rowid = row.attr('id').split('-')[1];
        sBody = 'dvTBody1-' + rowid;
        dBody = 'dvTBody2-' + rowid;
    }
    var rowid = CloneRowChildTableReturningID(sBody, dBody, true, false);
};
function AddSVClicked() {
    var row = $(AddSVClicked.caller.arguments[0].target.closest('tbody'));
    var sBody = 'svTBody1';
    var dBody = 'svTBody2';
    if (row.attr('id').indexOf('-') >= 0) {
        var rowid = row.attr('id').split('-')[1];
        sBody = 'svTBody1-' + rowid;
        dBody = 'svTBody2-' + rowid;
    }
    var rowid = CloneRowChildTableReturningID(sBody, dBody, true, false);
};
function RemoveMVChildClicked() {
    var row = RemoveMVChildClicked.caller.arguments[0].target.closest('tr');
    removeBtnClickFromChildTableCloneRow(row, 'mvTBody2');
};
function RemoveDVChildClicked() {
    var row = RemoveDVChildClicked.caller.arguments[0].target.closest('tr');
    removeBtnClickFromChildTableCloneRow(row, 'dvTBody2');
};
function RemoveSVChildClicked() {
    var row = RemoveSVChildClicked.caller.arguments[0].target.closest('tr');
    removeBtnClickFromChildTableCloneRow(row, 'svTBody2');
};
function ParentCloneRowAddClicked() {
    var rowid = CloneRowParentTableReturningID('tbody1', 'tbody2', true, true);
};
function ParentCloneRowRemoveClicked() {
    var row = ParentCloneRowRemoveClicked.caller.arguments[0].target.closest('tr');
    removeBtnClickFromParentTableCloneRow(row, 'tbody2');
};


$(document).ready(function () {
    $('.cloneBtn').hover(function () {
        $(this).closest('tr').css('background-color', '#FFC0CB');
    }, function () {
        $(this).closest('tr').css('background-color', '#fff');
    });
    $('.CloneBtn').hover(function () {
        $(this).closest('tr').css('background-color', '#FFC0CB');
    }, function () {
        $(this).closest('tr').css('background-color', '#fff');
    });
});
