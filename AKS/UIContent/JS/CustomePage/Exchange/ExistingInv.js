function InvoceNumberChanged(){
    var invnoCtrl = $('#InvoiceNumberCtrl');
    var btnGetInvDtl = $('#btnGetInvDtl');
    if (invnoCtrl.val() != '' && invnoCtrl.val().length>=8) {
        btnGetInvDtl.makeEnabled();
    }
    else {
        btnGetInvDtl.makeDisable();
    }
}
function GetInvoiceDetails() {
    var invno = $('#InvoiceNumberCtrl').val();
    var url = '/Exchange/GetInvoiceDetails?InvoiceNumber=' + invno
    GetDataFromAjax(url).done(function (data) {
        debugger;
        if (data.IsSuccess) {
            FillHeaderData(data.invoiceDtl)
        }
        else {
            MyAlert(3, data.Message, false);
        }
    });
}
function FillHeaderData(data) {
    $('#cInvDate').html(data.InvoiceDateStr);
    $('#cCustomer').html(data.CustomerID + ' - ' + data.CustomerName + '(' + data.CustomerContactNo+')');   
}