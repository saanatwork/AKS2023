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
function CustomerSearChanged() {
    var myCtrl = $(CustomerSearChanged.caller.arguments[0].target);
    var DropdownCtrl = $('#cCustomer');
    if (myCtrl.val() != '' && myCtrl.val().length > 2) {
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
    }    
};
function ItemCategoryChanged() {
    var myCtrl = $(ItemCategoryChanged.caller.arguments[0].target);
    var myCtrlID = myCtrl.attr('id');
    var DropdownCtrlID = 'cItem';
    if (myCtrlID.indexOf('-') > 0)
    { DropdownCtrlID = 'cItem-' + myCtrlID.split('-')[1]; }
    var DropdownCtrl = $('#' + DropdownCtrlID);
    if (myCtrl.val() != '') {
        myCtrl.isValid();
        $.ajax({
            url: '/Inventory/GetItemOfCategory?CategoryCode=' + myCtrl.val(),
            method: 'GET',
            dataType: 'json',
            success: function (data) {
                $(data).each(function (index, item) {
                    DropdownCtrl.empty();
                    DropdownCtrl.append($('<option/>', { value: "", text: "Select Item" }));
                    $(data).each(function (index, item) {
                        DropdownCtrl.append($('<option/>', { value: item.ID, text: item.DisplayText }));
                    });
                });
                DropdownCtrl.isInvalid();
            }
        });
    } else { myCtrl.isInvalid(); }
    SaveBtnStatus();
};
function ItemChanged() {
    var myCtrl = $(ItemChanged.caller.arguments[0].target);
    var myCtrlID = myCtrl.attr('id');
    var sBodyM = 'mvTBody1';
    var dBodyM = 'mvTBody2';
    var sBodyD = 'dvTBody1';
    var dBodyD = 'dvTBody2';
    var sBodyS = 'svTBody1';
    var dBodyS = 'svTBody2';
    var MVCtrlID = 'cMetalVariant';
    var MWCtrlID = 'cMetalWt';
    var MRCtrlID = 'cMetalRate';
    var MACtrlID = 'cMetalAmount';
    var DVCtrlID = 'cDiamondVariant';
    var DWCtrlID = 'cDiamondWt';
    var DRCtrlID = 'cDiamondRate';
    var DGACtrlID = 'cDiamondGA';
    var DDCtrlID = 'cDiamondDis';
    var DDACtrlID = 'cDiamondDisAmount';
    var DACtrlID = 'cDiamondAmount';
    var SVCtrlID = 'cStoneVariant';
    var SWCtrlID = 'cStoneWt';
    var SRCtrlID = 'cStoneRate';
    var SACtrlID = 'cStoneAmount';
    var MCWCtrlID = 'cMCWt';
    var MCRCtrlID = 'cMCRate';
    var MCACtrlID = 'cMCAmount';
    var GrossAmtID = 'cGrossAmount';
    var QtyID = 'cQty';
    var HallMarkID = 'cHallMark';
    var OtherChargeID = 'cOtherCharges';
    var NetAmtID = 'cNetAmount';
    var DisID = 'cDiscountPer';
    var DisAmt = 'cDiscountAmt';
    var NetAfterDis = 'cNetAfterDiscount';
    if (myCtrlID.indexOf('-') > 0) {
        var prowid = myCtrlID.split('-')[1];
        sBodyM = 'mvTBody1-' + prowid;
        dBodyM = 'mvTBody2-' + prowid;
        sBodyD = 'dvTBody1-' + prowid;
        dBodyD = 'dvTBody2-' + prowid;
        sBodyS = 'svTBody1-' + prowid;
        dBodyS = 'svTBody2-' + prowid;
        MVCtrlID = 'cMetalVariant-' + prowid;
        MWCtrlID = 'cMetalWt-' + prowid;
        MRCtrlID = 'cMetalRate-' + prowid;
        MACtrlID = 'cMetalAmount-' + prowid;
        DVCtrlID = 'cDiamondVariant-' + prowid;
        DWCtrlID = 'cDiamondWt-' + prowid;
        DRCtrlID = 'cDiamondRate-' + prowid;
        DGACtrlID = 'cDiamondGA-' + prowid;
        DDCtrlID = 'cDiamondDis-' + prowid;
        DDACtrlID = 'cDiamondDisAmount-' + prowid;
        DACtrlID = 'cDiamondAmount-' + prowid;
        SVCtrlID = 'cStoneVariant-' + prowid;
        SWCtrlID = 'cStoneWt-' + prowid;
        SRCtrlID = 'cStoneRate-' + prowid;
        SACtrlID = 'cStoneAmount-' + prowid;
        MCWCtrlID = 'cMCWt-' + prowid;
        MCRCtrlID = 'cMCRate-' + prowid;
        MCACtrlID = 'cMCAmount-' + prowid;
        GrossAmtID = 'cGrossAmount-' + prowid;
        QtyID = 'cQty-' + prowid;
        HallMarkID = 'cHallMark-' + prowid;
        OtherChargeID = 'cOtherCharges-' + prowid;
        var NetAmtID = 'cNetAmount-' + prowid;
        var DisID = 'cDiscountPer-' + prowid;
        var DisAmt = 'cDiscountAmt-' + prowid;
        var NetAfterDis = 'cNetAfterDiscount-' + prowid;
    }
    if (myCtrl.val() != '') {
        $('#' + dBodyM).html('');
        $('#' + dBodyD).html('');
        $('#' + dBodyS).html('');
        $('#0_' + MVCtrlID).val('');
        $('#0_' + MWCtrlID).val(0);
        $('#0_' + MRCtrlID).val(0);
        $('#0_' + MACtrlID).val(0);
        $('#0_' + DVCtrlID).val('');
        $('#0_' + DWCtrlID).val(0);
        $('#0_' + DRCtrlID).val(0);
        $('#0_' + DGACtrlID).val(0);
        $('#0_' + DDCtrlID).val(0);
        $('#0_' + DDACtrlID).val(0);
        $('#0_' + DACtrlID).val(0);
        $('#0_' + SVCtrlID).val('');
        $('#0_' + SWCtrlID).val(0);
        $('#0_' + SRCtrlID).val(0);
        $('#0_' + SACtrlID).val(0);
        $('#' + MCWCtrlID).val(0);
        $('#' + MCRCtrlID).val(0);
        $('#' + MCACtrlID).val(0);
        myCtrl.isValid();
        $.ajax({
            url: '/Inventory/GetItemVariantsForSale?ItemID=' + myCtrl.val(),
            method: 'GET',
            dataType: 'json',
            success: function (data) {
                var gamt = 0;
                $.each(data.MetalVariants, function (index, item) {
                    if (index > 0) {
                        var rowid = CloneRowChildTableReturningID(sBodyM, dBodyM, true, false);
                        $('#' + rowid + '_' + MVCtrlID).val(item.VariantDescription);
                        $('#' + rowid + '_' + MWCtrlID).val(item.VariantWt).isValid();
                        $('#' + rowid + '_' + MRCtrlID).val(item.RatePerUnit);
                        $('#' + rowid + '_' + MACtrlID).val(item.Amount);
                    }
                    else {
                        $('#0_' + MVCtrlID).val(item.VariantDescription);
                        $('#0_' + MWCtrlID).val(item.VariantWt).isValid();
                        $('#0_' + MRCtrlID).val(item.RatePerUnit);
                        $('#0_' + MACtrlID).val(item.Amount);
                    }
                    gamt = gamt + item.Amount;
                });
                $.each(data.DiamondVariants, function (index, item) {
                    if (index > 0) {
                        var rowid = CloneRowChildTableReturningID(sBodyD, dBodyD, true, false);
                        $('#' + rowid + '_' + DVCtrlID).val(item.VariantDescription);
                        $('#' + rowid + '_' + DWCtrlID).val(item.VariantWt).isValid();
                        $('#' + rowid + '_' + DRCtrlID).val(item.RatePerUnit);
                        $('#' + rowid + '_' + DGACtrlID).val(item.GrossAmount);
                        $('#' + rowid + '_' + DDCtrlID).val(item.DiamondDiscount);
                        $('#' + rowid + '_' + DDACtrlID).val(item.DiDiscountAmount);
                        $('#' + rowid + '_' + DACtrlID).val(item.Amount);
                    }
                    else {
                        $('#0_' + DVCtrlID).val(item.VariantDescription);
                        $('#0_' + DWCtrlID).val(item.VariantWt).isValid();
                        $('#0_' + DRCtrlID).val(item.RatePerUnit);
                        $('#0_' + DGACtrlID).val(item.GrossAmount);
                        $('#0_' + DDCtrlID).val(item.DiamondDiscount);
                        $('#0_' + DDACtrlID).val(item.DiDiscountAmount);
                        $('#0_' + DACtrlID).val(item.Amount);
                    }
                    gamt = gamt + item.Amount;
                });
                $.each(data.StoneVariants, function (index, item) {
                    if (index > 0) {
                        var rowid = CloneRowChildTableReturningID(sBodyS, dBodyS, true, false);
                        $('#' + rowid + '_' + SVCtrlID).val(item.VariantDescription);
                        $('#' + rowid + '_' + SWCtrlID).val(item.VariantWt).isValid();
                        $('#' + rowid + '_' + SRCtrlID).val(item.RatePerUnit);
                        $('#' + rowid + '_' + SACtrlID).val(item.Amount);
                    }
                    else {
                        $('#0_' + SVCtrlID).val(item.VariantDescription);
                        $('#0_' + SWCtrlID).val(item.VariantWt).isValid();
                        $('#0_' + SRCtrlID).val(item.RatePerUnit);
                        $('#0_' + SACtrlID).val(item.Amount);
                    }
                    gamt = gamt + item.Amount;
                });
                $.each(data.MCInfo, function (index, item) {
                    $('#' + MCWCtrlID).val(item.VariantWt);
                    $('#' + MCRCtrlID).val(item.MakingCharge).isValid();
                    $('#' + MCACtrlID).val(item.Amount);
                    gamt = gamt + item.Amount;
                });
                $('#' + GrossAmtID).val(gamt);
                $('#' + QtyID).val(1);
                $('#' + HallMarkID).val(0);
                $('#' + OtherChargeID).val(0);
                $('#' + NetAmtID).val(gamt);
                $('#' + DisID).val(0);
                $('#' + DisAmt).val(0);
                $('#' + NetAfterDis).val(gamt);
                CalculateItemTotal();
                CalculateNetPayable();
            }
        });
    } else { myCtrl.isInvalid(); }
    SaveBtnStatus();
};
function QtyChanged() {
    var myCtrl = $(QtyChanged.caller.arguments[0].target);
    if (myCtrl.val() >0) { myCtrl.isValid(); } else { myCtrl.isInvalid(); }
    var myCtrlID = myCtrl.attr('id');
    var prowid = 0;
    if (myCtrlID.indexOf('-') > 0) { prowid = myCtrlID.split('-')[1]; }
    CalculateItemTotalOfaRow(prowid);
    CalculateItemTotal();
    CalculateNetPayable();
    SaveBtnStatus();
};
function VariantWtChanged() {
    var myCtrl = $(VariantWtChanged.caller.arguments[0].target);
    var myChildRow = $(VariantWtChanged.caller.arguments[0].target.closest('tr'));
    var myvariant = myChildRow.find('.xvariant').val().trim();
    if (myvariant != '') {
        if (myCtrl.val() * 1 > 0) {
            
            myCtrl.isValid();
        } else {
            myCtrl.isInvalid();
        }
    } else { myCtrl.val(0).isValid(); }
    
    var myCtrlID = myCtrl.attr('id');
    var prowid = 0;
    if (myCtrlID.indexOf('-') > 0) {prowid = myCtrlID.split('-')[1];}
    var myRate = myChildRow.find('.mrate').val() * 1;
    myChildRow.find('.iamt').val(Math.round(myRate * myCtrl.val()));
    CalculateMakingChargeOfaRow(prowid);
    CalculateItemTotalOfaRow(prowid);
    CalculateItemTotal();
    CalculateNetPayable();
    SaveBtnStatus();
};
function DVariantWtChanged() {
    var myCtrl = $(DVariantWtChanged.caller.arguments[0].target);
    var myChildRow = $(DVariantWtChanged.caller.arguments[0].target.closest('tr'));
    var myvariant = myChildRow.find('.xvariant').val().trim();
    if (myvariant != '') {
        if (myCtrl.val() * 1 > 0) {

            myCtrl.isValid();
        } else {
            myCtrl.isInvalid();
        }
    } else { myCtrl.val(0).isValid(); }

    var myCtrlID = myCtrl.attr('id');
    var prowid = 0;
    if (myCtrlID.indexOf('-') > 0) { prowid = myCtrlID.split('-')[1]; }
    var myRate = myChildRow.find('.mrate').val() * 1;
    var myAmt = Math.round(myRate * myCtrl.val());
    myChildRow.find('.igamt').val(myAmt);
    var myDisp = myChildRow.find('.ddis').val() * 1;
    var myDisAmt = Math.round(myAmt * myDisp / 100);
    myChildRow.find('.ddisamt').val(myDisAmt);
    myChildRow.find('.iamt').val(myAmt - myDisAmt);
    CalculateMakingChargeOfaRow(prowid);
    CalculateItemTotalOfaRow(prowid);
    CalculateItemTotal();
    CalculateNetPayable();
    SaveBtnStatus();
};



function CalculateItemTotal() {
    var netamt = 0;
    $('.inetafterdis').each(function () {
        netamt = netamt + $(this).val() * 1;
    });
    $('#cItemTotal').val(netamt);
};
function CalculateNetPayable() {
    var itemtotal = $('#cItemTotal').val() * 1;
    var tradediscount = $('#cTradeDiscount').val() * 1;
    var taxableAmt = itemtotal - tradediscount;
    var gst = $('#cGST').val() * 1;
    var gstamt = 0;
    if (gst > 0) { gstamt = Math.round(taxableAmt * gst / 100); }
    var netpayable = taxableAmt + gstamt;
    
    $('#cTaxableAmount').val(taxableAmt);
    $('#cGSTAmount').val(gstamt);
    $('#cNetPayable').val(netpayable);
};
function CalculateItemTotalOfaRow(rowid) {
    var myRow = $('#' + rowid);
    var qty = myRow.find('.iqty').val() * 1;
    var amount = 0;
    myRow.find('.iamt').each(function () {
        amount = amount + $(this).val() * 1;
    });
    var netamount = amount * qty;
    myRow.find('.igrossamt').val(amount);
    myRow.find('.inetamt').val(netamount);
    var discount = myRow.find('.idisamt').val() * 1;
    myRow.find('.inetafterdis').val(netamount - discount);
};
function CalculateMakingChargeOfaRow(rowid) {
    var myRow = $('#' + rowid);
    var wt = 0;
    var mwt = 0;
    myRow.find('.wtg').each(function () {
        wt = wt + $(this).val() * 1;
    });
    myRow.find('.wtk').each(function () {
        mwt = $(this).val() * 1;
        wt = wt + mwt/5;
    });
    myRow.find('.mcwt').val(wt.toFixed(3));
    var mcrate = myRow.find('.mcrate').val() * 1;
    myRow.find('.mcamt').val(Math.round(mcrate * wt));
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

function ValidateControl() {
    var myCtrl = $(ValidateControl.caller.arguments[0].target);
    var isvalid = validatectrl(myCtrl.attr('id'), myCtrl.val(), 1);
    if (isvalid) { myCtrl.isValid(); } else { myCtrl.isInvalid(); }
    SaveBtnStatus();
};
function validatectrl(targetid, value, spltag) {
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