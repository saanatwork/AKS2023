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
});
