﻿function BtnReportClicked() {
    var fromdate = $('#cFromDate').val();
    var asondate = $('#cAsOnDate').val();
    var iDiv = $('#PartialViewDiv');
    var myUrl = '/Accounts/TrialBalancePartialView?FromDate=' + fromdate + '&AsOnDate=' + asondate;
    $.ajax({
        url: myUrl,
        contentType: 'application/html; charset=utf-8',
        type: 'GET',
        dataType: 'html',
        success: function (result) {
            iDiv.html(result);
        },
        error: function (xhr, status, error) {
            iDiv.html(xhr.responseText);
            //iDiv.html("No Data Found");
        }
    });
    var aUrl = '/Common/GeneratePdfForTrialBalance?FromDate=' + fromdate + '&AsOnDate=' + asondate + '&PdfFileName=TB' + asondate ;

    $('#PrintAnchor').attr('href', aUrl);
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
        case "cACD":
        case "cAsOnDate":
        case "cFromDate":
            if (value != '') { isvalid = true; }
            break;

    }
    return isvalid;
};
function SaveBtnStatus() {
    //alert($('.is-invalid').length);
    var btnSubmitCtrl = $('#btnReport');
    if (GetDivInvalidCount('HdrDIV') > 0) {
        btnSubmitCtrl.makeDisable();
    }
    else {
        btnSubmitCtrl.makeEnabled();
    }
};