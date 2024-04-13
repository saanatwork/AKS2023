function PBIllChanged() {
    var myCtrl = $(PBIllChanged.caller.arguments[0].target);
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
    var MRCtrlID = 'cMetalRate';
    var MACtrlID = 'cMetalAmount';
    var DVCtrlID = 'cDiamondVariant';
    var DWCtrlID = 'cDiamondWt';
    var DRCtrlID = 'cDiamondRate';
    var DACtrlID = 'cDiamondAmount';
    var SVCtrlID = 'cStoneVariant';
    var SWCtrlID = 'cStoneWt';
    var SRCtrlID = 'cStoneRate';
    var SACtrlID = 'cStoneAmount';
    var MCWCtrlID = 'cMCWt';
    var MCRCtrlID = 'cMCRate';
    var MCACtrlID = 'cMCAmount';
    var HallMarkID = 'cHallMark_0';
    var OtherChargeID = 'cOtherCharges_0';
    var DisID = 'cDiscount_0';
    var GrossAmtID = 'cGrossAmount_0';
    var NetAmtID = 'cNet_0';
    if (prowid > 0) {
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
        DACtrlID = 'cDiamondAmount-' + prowid;
        SVCtrlID = 'cStoneVariant-' + prowid;
        SWCtrlID = 'cStoneWt-' + prowid;
        SRCtrlID = 'cStoneRate-' + prowid;
        SACtrlID = 'cStoneAmount-' + prowid;
        MCWCtrlID = 'cMCWt-' + prowid;
        MCRCtrlID = 'cMCRate-' + prowid;
        MCACtrlID = 'cMCAmount-' + prowid;

        HallMarkID = 'cHallMark_0-' + prowid;
        OtherChargeID = 'cOtherCharges_0-' + prowid;
        DisID = 'cDiscount_0-' + prowid;
        GrossAmtID = 'cGrossAmount_0-' + prowid;
        NetAmtID = 'cNet_0-' + prowid;
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

    $('#0_' + MRCtrlID).val('').isInvalid();
    $('#0_' + DRCtrlID).val('').isInvalid();
    $('#0_' + SRCtrlID).val('').isInvalid();
    $('#0_' + MACtrlID).val(0).removeClass('is-valid is-invalid');
    $('#0_' + DACtrlID).val(0).removeClass('is-valid is-invalid');
    $('#0_' + SACtrlID).val(0).removeClass('is-valid is-invalid');
    $('#' + MCWCtrlID).val(0).removeClass('is-valid is-invalid');
    $('#' + MCRCtrlID).val(0).removeClass('is-valid is-invalid');
    $('#' + MCACtrlID).val(0).removeClass('is-valid is-invalid');

    $('#' + HallMarkID).val(0).removeClass('is-valid is-invalid');
    $('#' + OtherChargeID).val(0).removeClass('is-valid is-invalid');
    $('#' + DisID).val(0).removeClass('is-valid is-invalid');
    $('#' + GrossAmtID).val(0).removeClass('is-valid is-invalid');
    $('#' + NetAmtID).val(0).removeClass('is-valid is-invalid');
    CalculateNetPayable();
    if (docno == '') {
        myCtrl.removeClass('is-valid is-invalid');
    }
    else {
        myCtrl.isValid();
        //itemcateCtrl.attr('disabled', 'disabled');
        //qtyCtrl.attr('disabled', 'disabled');
        //remCtrl.attr('disabled', 'disabled');
        //Get Order Details and plot
        var url = '/POS/GetInvoiceDetails?DocumentNumber=' + docno;
        GetDataFromAjax(url).done(function (data) {
            $(data.Items).each(function (index, item) {
                itemcateCtrl.val(item.ItemCatCode).isValid();
                qtyCtrl.val(item.Qty).isValid();
                remCtrl.val(item.UItemCode).isValid();
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
            MCWeightCalculation(prowid);
            SaveBtnStatus();
        });
    }
    SaveBtnStatus();
};
function PBILLBtnClicked() {
    var myRow = $(PBILLBtnClicked.caller.arguments[0].target.closest('tr'));
    var rowid = myRow.attr('id');
    var oderno = '';
    if (rowid == 0) {
        oderno = $('#cPBILL_0').val();
    } else { oderno = $('#cPBILL_0-' + rowid).val(); }
    if (oderno != '') {
        var url = '/POS/ViewInvoice?InvoiceNumber=' + oderno;
        window.open(url);
    } else {
        Swal.fire({
            title: 'Error!',
            text: 'Select Provisional Bill To View Details.',
            icon: 'error',
            customClass: 'swal-wide',
            buttons: {
                confirm: 'Ok'
            },
            confirmButtonColor: '#2527a2',
        });
    }
};
function OrderChanged() {
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
    var MRCtrlID = 'cMetalRate';
    var MACtrlID = 'cMetalAmount';
    var DVCtrlID = 'cDiamondVariant';
    var DWCtrlID = 'cDiamondWt';
    var DRCtrlID = 'cDiamondRate'; 
    var DACtrlID = 'cDiamondAmount';
    var SVCtrlID = 'cStoneVariant';
    var SWCtrlID = 'cStoneWt';
    var SRCtrlID = 'cStoneRate';
    var SACtrlID = 'cStoneAmount';
    var MCWCtrlID = 'cMCWt';
    var MCRCtrlID = 'cMCRate';
    var MCACtrlID = 'cMCAmount';    
    var HallMarkID = 'cHallMark_0';
    var OtherChargeID = 'cOtherCharges_0';
    var DisID = 'cDiscount_0';
    var GrossAmtID = 'cGrossAmount_0';
    var NetAmtID = 'cNet_0';
    if (prowid > 0) {
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
        DACtrlID = 'cDiamondAmount-' + prowid;
        SVCtrlID = 'cStoneVariant-' + prowid;
        SWCtrlID = 'cStoneWt-' + prowid;
        SRCtrlID = 'cStoneRate-' + prowid;
        SACtrlID = 'cStoneAmount-' + prowid;
        MCWCtrlID = 'cMCWt-' + prowid;
        MCRCtrlID = 'cMCRate-' + prowid;
        MCACtrlID = 'cMCAmount-' + prowid;

        HallMarkID = 'cHallMark_0-' + prowid;
        OtherChargeID = 'cOtherCharges_0-' + prowid;
        DisID = 'cDiscount_0-' + prowid;
        GrossAmtID = 'cGrossAmount_0-' + prowid;
        NetAmtID = 'cNet_0-' + prowid;
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

    $('#0_' + MRCtrlID).val('').isInvalid();
    $('#0_' + DRCtrlID).val('').isInvalid();
    $('#0_' + SRCtrlID).val('').isInvalid();
    $('#0_' + MACtrlID).val(0).removeClass('is-valid is-invalid');
    $('#0_' + DACtrlID).val(0).removeClass('is-valid is-invalid');
    $('#0_' + SACtrlID).val(0).removeClass('is-valid is-invalid');
    $('#' + MCWCtrlID).val(0).removeClass('is-valid is-invalid');
    $('#' + MCRCtrlID).val(0).removeClass('is-valid is-invalid');
    $('#' + MCACtrlID).val(0).removeClass('is-valid is-invalid');

    $('#' + HallMarkID).val(0).removeClass('is-valid is-invalid');
    $('#' + OtherChargeID).val(0).removeClass('is-valid is-invalid');
    $('#' + DisID).val(0).removeClass('is-valid is-invalid');
    $('#' + GrossAmtID).val(0).removeClass('is-valid is-invalid');
    $('#' + NetAmtID).val(0).removeClass('is-valid is-invalid');
    CalculateNetPayable();
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
            $(data.AppStockList).each(function (index, item) {
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
            MCWeightCalculation(prowid);
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
    } else { oderno = $('#cOrderID_0-' + rowid).val(); }
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
function SubmitBtnClicked() {
    var vendor = $('#cVendors').val();
    var docNumber = $('#cDocumentNumber').val();
    var docDate = $('#cDocumentDate').val();
    var docFilename = $('#DocumentFileName').val();    
    var itemtotal = $('#cItemTotal').val();
    var tradediscount = $('#cTradeDiscount').val();
    var taxableamt = $('#cTaxableAmount').val();    
    var gst = $('#cGST').val();    
    var gstamount = $('#cGSTAmount').val();
    var netpayable = $('#cNetPayable').val();
    var schrecords = GetAppStockRecords('tblDataList');
    var x = '{"VendorID":"' + vendor
        + '","DocumentFileName":"' + docFilename
        + '","DocNo":"' + docNumber
        + '","DocDate":"' + docDate
        + '","ItemTotal":"' + itemtotal
        + '","TradeDiscount":"' + tradediscount
        + '","TaxableAmount":"' + taxableamt
        + '","GST":"' + gst
        + '","GSTAmount":"' + gstamount
        + '","NetPayableAmount":"' + netpayable
        + '","AppStockList":' + schrecords + '}';
    $.ajax({
        method: 'POST',
        url: '/Inventory/SetPurchase',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: x,
        success: function (data) {
            $(data).each(function (index, item) {
                if (item.bResponseBool == true) {
                    Swal.fire({
                        title: 'Success',
                        text: 'Purchase Entry Saved Successfully.',
                        icon: 'success',
                        customClass: 'swal-wide',
                        buttons: {
                            confirm: 'Ok'
                        },
                        confirmButtonColor: '#2527a2',
                    }).then(callback);
                    function callback(result) {
                        if (result.value) {
                            window.location.href = "/Inventory/Purchase";
                        }
                    }
                }
                else {
                    Swal.fire({
                        title: 'Error!',
                        text: 'Failed To Save Purchase Entry.',
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
        mrecord = mrecord + '"MetalVariants":' + MVariant
            + ',"DiamondVariants":' + DVariant
            + ',"StoneVariants":' + SVariant
        schrecords = schrecords + '{' + mrecord + '},';
        mrecord = '';
        MVariant = '';
        DVariant = '';
        SVariant = '';
    });
    schrecords = schrecords.replace(/,\s*$/, "");
    schrecords = '[' + schrecords + ']';
    return schrecords;
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
                value: "", text: "Select Vendor"
            }));
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
                        text: 'Failed To Create A New Vendor. Error : '+item.sResponseString,
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
function ValidateTradeDiscount() {
    var myCtrl = $('#cTradeDiscount');
    var discount = myCtrl.val()*1;
    var itemtotal = $('#cItemTotal').val() * 1;
    if (myCtrl.val() != '' && IsValidIntegerOrDecimal(myCtrl.val())) {
        myCtrl.isValid();
    }
    else { myCtrl.isInvalid(); }
    $('#cTaxableAmount').val(itemtotal - discount);
    ValidateGST();
};
function ValidateGST() {
    var myCtrl = $('#cGST');
    var gst = myCtrl.val() * 1;
    var taxableamt = $('#cTaxableAmount').val() * 1;
    var gstamount = 0;
    if (myCtrl.val() != '' && IsValidIntegerOrDecimal(myCtrl.val())) {
        myCtrl.isValid();
    }
    else { myCtrl.isInvalid(); }
    if (gst > 0 && taxableamt > 0) {
        gstamount = Math.round(taxableamt * gst / 100);
    }
    $('#cGSTAmount').val(gstamount);
    $('#cNetPayable').val(taxableamt + gstamount);
    SaveBtnStatus();
};
function CalculateNetPayable() {
    var amt = 0;
    var discount = $('#cTradeDiscount').val() * 1;
    $('.Rnetamount').each(function () {
        var x = $(this).val() * 1;
        if (IsValidIntegerOrDecimal(x)) {
            amt = amt + x;
        }
    });
    $('#cItemTotal').val(amt);

    var taxableamt = amt - discount;
    $('#cTaxableAmount').val(taxableamt);

    var gst = $('#cGST').val() * 1;
    var gstamount=0
    if (gst > 0) { gstamount = Math.round(taxableamt * gst / 100); }
    
    $('#cGSTAmount').val(gstamount);
    $('#cNetPayable').val(taxableamt + gstamount);
    SaveBtnStatus();
};
function ValidateCtrlWithNumberOrDecimal(myCtrl) {
    if (myCtrl.val() != '' && IsValidIntegerOrDecimal(myCtrl.val())) {
        myCtrl.isValid();
    }
    else { myCtrl.isInvalid(); }
    GrossNetAmountCalculation(ReturnParentRowID(myCtrl));
};
function ItemQtyChanged() { 
    var myCtrl = $(ItemQtyChanged.caller.arguments[0].target);
    ValidateCtrlWithNumberOrDecimal(myCtrl);    
};
function ValidateMcRate() {
    var myChildRow = $(ValidateMcRate.caller.arguments[0].target.closest('tr'));
    var myCtrl = $(ValidateMcRate.caller.arguments[0].target);
    
    var mcWt = myChildRow.find('.mcwt').val() * 1;
    myChildRow.find('.mcamt').val(Math.round(mcWt * (myCtrl.val() * 1)));
    ValidateCtrlWithNumberOrDecimal(myCtrl);
};
function MCWtChanged() {
    var myChildRow = $(MCWtChanged.caller.arguments[0].target.closest('tr'));
    var myCtrl = $(MCWtChanged.caller.arguments[0].target);

    var mcWt = myChildRow.find('.mcrate').val() * 1;
    myChildRow.find('.mcamt').val(Math.round(mcWt * (myCtrl.val() * 1)));
    ValidateCtrlWithNumberOrDecimal(myCtrl);
};
function ValidateMetalAmount() {
    var myChildRow = $(ValidateMetalAmount.caller.arguments[0].target.closest('tr'));
    var myCtrl = $(ValidateMetalAmount.caller.arguments[0].target);
    
    MetalRateCalculator(myChildRow);
    ValidateCtrlWithNumberOrDecimal(myCtrl);
};
function ValidateMetalWt() {
    var myChildRow = $(ValidateMetalWt.caller.arguments[0].target.closest('tr'));
    var myCtrl = $(ValidateMetalWt.caller.arguments[0].target);
    
    MetalAmountCalculator(myChildRow);
    var myParentRowID = ReturnParentRowID(myCtrl);
    MCWeightCalculation(myParentRowID);
    ValidateCtrlWithNumberOrDecimal(myCtrl);
};
function MCWeightCalculation(ParrentRowID) {
    var parrentRow = $('#' + ParrentRowID);
    var mcwt = 0;
    var mcrate = parrentRow.find('.mcrate').val() * 1;
    parrentRow.find('.mwtk').each(function () {
        var y = $(this).val() * 1;
        if (IsValidIntegerOrDecimal(y)) {
            y = (y/5);
            mcwt = mcwt + y;
        }
    });
    parrentRow.find('.mwtg').each(function () {
        var x = $(this).val() * 1;
        if (IsValidIntegerOrDecimal(x)) {
            mcwt = mcwt + x;
        }
    });
    parrentRow.find('.mcwt').val(mcwt);
    parrentRow.find('.mcamt').val(Math.round(mcwt * mcrate));
};
function GrossNetAmountCalculation(ParrentRowID) {
    var parrentRow = $('#' + ParrentRowID);
    var amt = 0;
    var qty = parrentRow.find('.Rqty').val() * 1;
    parrentRow.find('.grossamt').each(function () {
        var x = $(this).val() * 1;
        if (IsValidIntegerOrDecimal(x)) {
            amt = amt + x;
        }
    });
    parrentRow.find('.Ngrossamt').each(function () {
        var x = $(this).val() * 1;
        if (IsValidIntegerOrDecimal(x)) {
            amt = amt - x;
        }
    });
    parrentRow.find('.Rgrossamt').val(Math.round(amt));
    parrentRow.find('.Rnetamount').val(Math.round(amt * qty));
    CalculateNetPayable();
};
function MetalAmountCalculator(myRow) {
    var metalWt = myRow.find('.mwt').val() * 1;
    var metalRate = myRow.find('.mrate').val() * 1;
    myRow.find('.mamt').val(metalWt * metalRate);
};
function MetalRateCalculator(myRow) {
    var metalWt = myRow.find('.mwt').val() * 1;
    var metalAmount = myRow.find('.mamt').val() * 1;
    myRow.find('.mrate').val((metalAmount / metalWt).toFixed(2));
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
    var isvalid = validatectrl(myCtrlId, myCtrl.val(), 1);
    if (isvalid) { myCtrl.isValid(); } else { myCtrl.isInvalid(); }
    SaveBtnStatus();
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

function RemoveMVChildClicked() {
    var row = RemoveMVChildClicked.caller.arguments[0].target.closest('tr');
    var ParrentRowID = ReturnParentRowID($(row));
    removeBtnClickFromChildTableCloneRow(row, 'mvTBody2');
    
    GrossNetAmountCalculation(ParrentRowID);
    MCWeightCalculation(ParrentRowID);
    SaveBtnStatus();
};
function RemoveDVChildClicked() {
    var row = RemoveDVChildClicked.caller.arguments[0].target.closest('tr');
    var ParrentRowID = ReturnParentRowID($(row));
    removeBtnClickFromChildTableCloneRow(row, 'dvTBody2');
    
    GrossNetAmountCalculation(ParrentRowID);
    MCWeightCalculation(ParrentRowID);
    SaveBtnStatus();
};
function RemoveSVChildClicked() {
    var row = RemoveSVChildClicked.caller.arguments[0].target.closest('tr');
    var ParrentRowID = ReturnParentRowID($(row));
    removeBtnClickFromChildTableCloneRow(row, 'svTBody2');
    GrossNetAmountCalculation(ParrentRowID);
    MCWeightCalculation(ParrentRowID);
    SaveBtnStatus();
    
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
function ParentCloneRowAddClicked() {
    var rowid = CloneRowParentTableReturningID('tbody1', 'tbody2', true, true);
    SaveBtnStatus();
};
function ParentCloneRowRemoveClicked() {
    var row = ParentCloneRowRemoveClicked.caller.arguments[0].target.closest('tr');
    removeBtnClickFromParentTableCloneRow(row, 'tbody2');
    SaveBtnStatus();
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