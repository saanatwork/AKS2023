﻿function OrderChanged() {
    var myCtrl = $(OrderChanged.caller.arguments[0].target);
    var myRow = $(myCtrl.closest('tr'));
    var prowid = myRow.attr('id');
    var itemcateCtrl = myRow.find('.ordcat');
    var qtyCtrl = myRow.find('.ordqty');
    var remCtrl = myRow.find('.ordrem');
    var docno = myCtrl.val();
    var sBodyM = 'mvTBody1';
    var dBodyM = 'mvTBody2';
    var sBodyD = 'dvTBody1';
    var dBodyD = 'dvTBody2';
    var sBodyS = 'svTBody1';
    var dBodyS = 'svTBody2';
    var MVCtrlID = 'cMetalVariant';
    var MWCtrlID = 'cMetalWt';
    var DVCtrlID = 'cDiamondVariant';
    var DWCtrlID = 'cDiamondWt';
    var SVCtrlID = 'cStoneVariant';
    var SWCtrlID = 'cStoneWt';
    if (prowid > 0) {
        sBodyM = 'mvTBody1-' + prowid;
        dBodyM = 'mvTBody2-' + prowid;
        sBodyD = 'dvTBody1-' + prowid;
        dBodyD = 'dvTBody2-' + prowid;
        sBodyS = 'svTBody1-' + prowid;
        dBodyS = 'svTBody2-' + prowid;
        MVCtrlID = 'cMetalVariant-' + prowid;
        MWCtrlID = 'cMetalWt-' + prowid;
        DVCtrlID = 'cDiamondVariant-' + prowid;
        DWCtrlID = 'cDiamondWt-' + prowid;
        SVCtrlID = 'cStoneVariant-' + prowid;
        SWCtrlID = 'cStoneWt-' + prowid;
    }
    itemcateCtrl.val('').isInvalid();//itemcateCtrl.removeAttr('disabled');
    qtyCtrl.val('').isInvalid(); //qtyCtrl.removeAttr('disabled');
    remCtrl.val('').isInvalid(); //remCtrl.removeAttr('disabled');
    $('#' + dBodyM).empty();
    $('#' + dBodyD).empty();
    $('#' + dBodyS).empty();
    $('#0_' + MVCtrlID).val('').isInvalid();
    $('#0_' + MWCtrlID).val('').isInvalid();
    $('#0_' + DVCtrlID).val('').removeClass('is-valid is-invalid');
    $('#0_' + DWCtrlID).val('').isInvalid();
    $('#0_' + SVCtrlID).val('').removeClass('is-valid is-invalid');
    $('#0_' + SWCtrlID).val('').isInvalid();
    if (docno == '') {
        myCtrl.removeClass('is-valid is-invalid');
        
    }
    else {
        myCtrl.isValid();
        //itemcateCtrl.attr('disabled', 'disabled');
        //qtyCtrl.attr('disabled', 'disabled');
        //remCtrl.attr('disabled', 'disabled');
        //Get Order Details and plot
        var url = '/Inventory/GetOrderDetails?DocumentNumber=' + docno;
        GetDataFromAjax(url).done(function (data) {
            $(data.AppStockList).each(function (index,item) {
                itemcateCtrl.val(item.ItemCatCode).isValid();
                qtyCtrl.val(item.Qty).isValid();
                remCtrl.val(item.Remarks).isValid();
                $(item.MetalVariants).each(function (mindex, mitem) {
                    if (mindex > 0) {
                        var rowid = CloneRowChildTableReturningID(sBodyM, dBodyM, true, false);
                        $('#' + rowid + '_' + MVCtrlID).val(mitem.VariantID).isValid();
                        $('#' + rowid + '_' + MWCtrlID).val(mitem.Weight).isValid();                        
                    }
                    else {
                        $('#0_' + MVCtrlID).val(mitem.VariantID).isValid();
                        $('#0_' + MWCtrlID).val(mitem.Weight).isValid();
                    }
                });
                $(item.DiamondVariants).each(function (mindex, mitem) {
                    if (mindex > 0) {
                        var rowid = CloneRowChildTableReturningID(sBodyD, dBodyD, true, false);
                        $('#' + rowid + '_' + DVCtrlID).val(mitem.VariantID).isValid();
                        $('#' + rowid + '_' + DWCtrlID).val(mitem.Weight).isValid();
                    }
                    else {
                        $('#0_' + DVCtrlID).val(mitem.VariantID).isValid();
                        $('#0_' + DWCtrlID).val(mitem.Weight).isValid();
                    }
                });
                $(item.StoneVariants).each(function (mindex, mitem) {
                    if (mindex > 0) {
                        var rowid = CloneRowChildTableReturningID(sBodyS, dBodyS, true, false);
                        $('#' + rowid + '_' + SVCtrlID).val(mitem.VariantID).isValid();
                        $('#' + rowid + '_' + SWCtrlID).val(mitem.Weight).isValid();
                    }
                    else {
                        $('#0_' + SVCtrlID).val(mitem.VariantID).isValid();
                        $('#0_' + SWCtrlID).val(mitem.Weight).isValid();
                    }
                });
            })
            SaveBtnStatus();
        });
    }
    SaveBtnStatus();
};
function OrderIDBtnClicked() {
    var myRow = $(OrderIDBtnClicked.caller.arguments[0].target.closest('tr'));
    var rowid = myRow.attr('id');
    var oderno = '';
    if (rowid == 0) {
        oderno = $('#cOrderID_0').val();
    } else { oderno = $('#cOrderID_0-' + rowid).val();}
    if (oderno != '') {
        var url = '/Order/ViewOrder?DocumentNumber=' + oderno;
        window.open(url);
    } else {
        Swal.fire({
            title: 'Error!',
            text: 'Select Order Number To View Details.',
            icon: 'error',
            customClass: 'swal-wide',
            buttons: {
                confirm: 'Ok'
            },
            confirmButtonColor: '#2527a2',
        });
    }
};
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
    var docFilename = $('#DocumentFileName').val();
    var schrecords = GetAppStockRecords('tblDataList');
    var x = '{"VendorID":"' + vendor
        + '","DocumentFileName":"' + docFilename
        + '","DocNo":"' + docNumber
        + '","DocDate":"' + docDate
        + '","AppStockList":' + schrecords + '}';
    $.ajax({
        method: 'POST',
        url: '/Inventory/SetAppStock',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: x,
        success: function (data) {
            $(data).each(function (index, item) {
                if (item.bResponseBool == true) {
                    Swal.fire({
                        title: 'Success',
                        text: 'Approval Stock Entry Saved Successfully.',
                        icon: 'success',
                        customClass: 'swal-wide',
                        buttons: {
                            confirm: 'Ok'
                        },
                        confirmButtonColor: '#2527a2',
                    }).then(callback);
                    function callback(result) {
                        if (result.value) {
                            window.location.href = "/Inventory/StockOnApproval";
                        }
                    }
                }
                else {
                    Swal.fire({
                        title: 'Error!',
                        text: 'Failed To Save Approval Stock Entry.',
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
function ValidateModalControl() {
    var myCtrl = $(ValidateModalControl.caller.arguments[0].target);
    var isvalid = validatectrl(myCtrl.attr('id'), myCtrl.val(), 1);
    if (isvalid) { myCtrl.isValid(); } else { myCtrl.isInvalid(); }
    SaveVendorBtnStatus();
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
        case "cVendorName":
        case "cVendorAddress":
        case "cCategoryLongText":
            isvalid = IsAlphaNumericWithSpace(value);
            break;
        case "cQty":
            if (IsValidInteger(value)) {
                if (value > 0) { isvalid = true; }
            }
            break;
        case "cRemarks":
            if (value != '') { isvalid = true; }
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
        case"cVendorGSTIN":
            if (value != '') {
                isvalid = true;
            }
            break;
        case "cMetalWt":
        case "cDiamondWt":
        case "cStoneWt":
            isvalid = IsValidIntegerOrDecimal(value);
            break;
        case "cVendorContact":
            isvalid = IsValidContact(value);
            break;
        case "cVendorEmailID":
            isvalid = IsValidEmail(value);
            break;
    }
    return isvalid;
};
function SaveBtnStatus() {
    //alert($('.is-invalid').length);
    var btnSubmitCtrl = $('#btnSubmit');
    if (GetDivInvalidCount('HdrDIV') > 0) {
        btnSubmitCtrl.makeDisable();
    }
    else {
        btnSubmitCtrl.makeEnabled();
    }
};
function SaveVendorBtnStatus() {
    //alert($('.is-invalid').length);
    var btnSubmitCtrl = $('#btnVendorSave');
    if (GetDivInvalidCount('VendorModal') > 0) {
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
    SaveBtnStatus();
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
    SaveBtnStatus();
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
    SaveBtnStatus();
};
function RemoveMVChildClicked() {
    var row = RemoveMVChildClicked.caller.arguments[0].target.closest('tr');
    removeBtnClickFromChildTableCloneRow(row, 'mvTBody2');
    SaveBtnStatus();
};
function RemoveDVChildClicked() {
    var row = RemoveDVChildClicked.caller.arguments[0].target.closest('tr');
    removeBtnClickFromChildTableCloneRow(row, 'dvTBody2');
    SaveBtnStatus();
};
function RemoveSVChildClicked() {
    var row = RemoveSVChildClicked.caller.arguments[0].target.closest('tr');
    removeBtnClickFromChildTableCloneRow(row, 'svTBody2');
    SaveBtnStatus();
};
function ParentCloneRowAddClicked() {
    var rowid = CloneRowParentTableReturningID('tbody1', 'tbody2', true, true);
    SaveBtnStatus();
};
function ParentCloneRowRemoveClicked() {
    var row = ParentCloneRowRemoveClicked.caller.arguments[0].target.closest('tr');
    removeBtnClickFromParentTableCloneRow(row, 'tbody2');
    SaveBtnStatus();
};
function AddVendorClicked() {
    var modalDiv = $('#VendorModal');
    modalDiv.modal('show');
};
function RefreshVendorDropDown() {
    var DropdownCtrl = $('#cVendors');
    $.ajax({
        url: '/Inventory/GetVendors',
        method: 'GET',
        dataType: 'json',
        success: function (data) {
            DropdownCtrl.empty();
            DropdownCtrl.append($('<option/>', {
                value: "", text: "Select Vendor" }));
            $(data).each(function (index, item) {
                DropdownCtrl.append($('<option/>', { value: item.PartyCode, text: item.PartyName }));
            });
        }
    });
};
function VendorSaveBtnClicked() {    
    var vName = $('#cVendorName');
    var vAddress = $('#cVendorAddress');
    var vContact = $('#cVendorContact');
    var vEmail = $('#cVendorEmailID');
    var vGSTIN = $('#cVendorGSTIN');
    var x = '{"PartyName":"' + vName.val()
        + '","PartyAddress":"' + vAddress.val()
        + '","GSTIN":"' + vGSTIN.val()
        + '","ContactNo":"' + vContact.val()
        + '","EmailID":"' + vEmail.val() + '"}';
    $.ajax({
        method: 'POST',
        url: '/Inventory/SetVendor',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: x,
        success: function (data) {
            $(data).each(function (index, item) {
                if (item.bResponseBool == true) {
                    RefreshVendorDropDown();
                    vName.val('').isInvalid();
                    vAddress.val('').isInvalid();
                    vContact.val('').isInvalid();
                    vEmail.val('').isInvalid();
                    vGSTIN.val('').isInvalid();
                    Swal.fire({
                        title: 'Success',
                        text: 'New Vendor Created Successfully.',
                        icon: 'success',
                        customClass: 'swal-wide',
                        buttons: {
                            confirm: 'Ok'
                        },
                        confirmButtonColor: '#2527a2',
                    });
                }
                else {
                    Swal.fire({
                        title: 'Error!',
                        text: 'Failed To Create A New Vendor. Error : ' + item.sResponseString,
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
