function ValidateModalControl() {
    var myCtrl = $(ValidateModalControl.caller.arguments[0].target);
    var isvalid = validatectrl(myCtrl.attr('id'), myCtrl.val(), 1);
    if (isvalid) { myCtrl.isValid(); } else { myCtrl.isInvalid(); }
    SaveVendorBtnStatus();
};
function validatectrl(targetid, value, spltag) {
    var isvalid = false;
    switch (targetid) {
        case "cVendorName":
        case "cVendorAddress":
            isvalid = IsAlphaNumericWithSpace(value);
            break;
        case "cVendorGSTIN":
            if (value != '') {
                isvalid = true;
            }
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
function CustomerSearChanged() {
    var myCtrl = $(CustomerSearChanged.caller.arguments[0].target);
    var DropdownCtrl = $('#cCustomer');
    if (myCtrl.val() != '' && myCtrl.val().length > 0) {
        $.ajax({
            url: '/POS/SearchParty?SearchText=' + myCtrl.val(),
            method: 'GET',
            dataType: 'json',
            success: function (data) {
                $(data).each(function (index, item) {
                    DropdownCtrl.empty();
                    DropdownCtrl.append($('<option/>', { value: "", text: "Select Customer" }));
                    $(data).each(function (index, item) {
                        DropdownCtrl.append($('<option/>', { value: item.ID, text: item.DisplayText }));
                    });
                });
            }
        });
        DropdownCtrl.isInvalid();
    }
};
function CustomerClicked() {
    var myCtrl = $(CustomerClicked.caller.arguments[0].target);
    if (myCtrl.val() != '') {
        myCtrl.isValid();
        $.ajax({
            url: '/Admin/GetParty?PartyCode=' + myCtrl.val(),
            method: 'GET',
            dataType: 'json',
            success: function (data) {
                $(data).each(function (index, item) {
                    $('#cAddress').html(item.PartyAddress);
                    $('#cContact').html(item.ContactNo);
                    //$('#cEmail').html(item.ContactNo);
                    $('#cEmail').html(item.EmailID);
                });
            }
        });
    } else { myCtrl.isInvalid(); }
    SaveBtnStatus();
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
function AddVendorClicked() {
    var modalDiv = $('#VendorModal');
    modalDiv.modal('show');
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
        url: '/POS/SetCostomer',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: x,
        success: function (data) {
            $(data).each(function (index, item) {
                if (item.bResponseBool == true) {
                    RefreshVendorDropDown(vName.val());
                    vName.val('').isInvalid();
                    vAddress.val('').isInvalid();
                    vContact.val('').isInvalid();
                    vEmail.val('').isInvalid();
                    vGSTIN.val('').isInvalid();
                    Swal.fire({
                        title: 'Success',
                        text: 'New Customer Created Successfully.',
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
                        text: 'Failed To Create A New Customer. Error : ' + item.sResponseString,
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
function ItemCategoryChanged() {
    var myCtrl = $(ItemCategoryChanged.caller.arguments[0].target);
    if (myCtrl.val() != '') { myCtrl.isValid(); } else { myCtrl.isInvalid(); }
};
function ItemCodeChanged() {
    var myCtrl = $(ItemCodeChanged.caller.arguments[0].target);
    if (myCtrl.val() != '') { myCtrl.isValid(); } else { myCtrl.isInvalid(); }

};
function QtyChanged() {
    var myCtrl = $(QtyChanged.caller.arguments[0].target);
    if (myCtrl.val() >0) { myCtrl.isValid(); } else { myCtrl.isInvalid(); }

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

function MetalVariantChanged() {
    var myCtrl = $(MetalVariantChanged.caller.arguments[0].target);    
    myCtrlID = myCtrl.attr('id');
    var childRowID = myCtrlID.split('_')[0];
    var parentRowID = 0;
    if (myCtrlID.indexOf('-') >= 0) { parentRowID = myCtrlID.split('-')[1]; }
    var rateCtrlid = childRowID + '_cMetalRate';
    var wtCtrlid = childRowID + '_cMetalWt';
    if (parentRowID > 0) {
        rateCtrlid = rateCtrlid + '-' + parentRowID;
        wtCtrlid = wtCtrlid + '-' + parentRowID;
    }
    myRateCtrl = $('#' + rateCtrlid);
    myWtCtrl = $('#' + wtCtrlid);    
    if (myCtrl.val() != '') {
        myCtrl.isValid();
        var purity = $('#' + myCtrlID + ' option:selected').attr('data-purity');
        $.ajax({
            url: '/Order/GetGoldRates?GoldKarate=' + purity,
            method: 'GET',
            dataType: 'json',
            success: function (data) {
                myRateCtrl.val(data);
                calculateMetalAmount(childRowID, parentRowID, myWtCtrl.val());
            }
        });
    } else { myCtrl.isInvalid(); }    
};
function MetalWeightChanged() {
    var myCtrl = $(MetalWeightChanged.caller.arguments[0].target);
    myCtrlID = myCtrl.attr('id');    
    if (myCtrl.val() > 0) {
        myCtrl.isValid();
        calculateMetalAmount(GetChildRowID(myCtrlID), GetParentRowID(myCtrlID), myCtrl.val());
    } else { myCtrl.isInvalid(); }    
};
function calculateMetalAmount(childRowID, parentRowID,Wt) {
    var rateCtrlid = childRowID+'_cMetalRate';
    var wtCtrlid = childRowID+'_cMetalWt';
    var amtCtrlid = childRowID+'_cMetalAmount';
    if (parentRowID > 0) {
        rateCtrlid = rateCtrlid + '-' + parentRowID;
        wtCtrlid = wtCtrlid + '-' + parentRowID;
        amtCtrlid = amtCtrlid + '-' + parentRowID;
    }
    var rate = $('#' + rateCtrlid).val();
    var amount = Wt * rate;
    $('#' + amtCtrlid).val(amount);
    $('#' + wtCtrlid).val(Wt);
    if (Wt > 0) { $('#' + wtCtrlid).isValid(); } else { $('#' + wtCtrlid).isInvalid(); }
};
function GetParentRowID(myCtrlID) {
    var parentRowID = 0;
    if (myCtrlID.indexOf('-') >= 0) { parentRowID = myCtrlID.split('-')[1]; }
    return parentRowID
};
function GetChildRowID(myCtrlID) {
    var childRowID = 0;
    if (myCtrlID.indexOf('_') >= 0) { childRowID = myCtrlID.split('_')[0]; }
    return childRowID
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