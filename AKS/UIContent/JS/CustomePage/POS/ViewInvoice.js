function ConvertToTaxInvoice(){
    var invoiceNumber = $('#InvoiceNumber').val();
    if (invoiceNumber != '') {
        GetDataFromAjax('/POS/ConvertToTaxInvoice?DocumentNumber=' + invoiceNumber).done(function (data) {
            if (data.IsSuccess) {
                var msg = 'Provisional Bill ' + invoiceNumber + ' Is Successfully Converted To Tax Invoice Having Number ' + data.NewIDStr;
                var redirectUrl = '/POS/ViewInvoice?InvoiceNumber=' + data.NewIDStr +'&CBUID='+$('#CBUID').val();
                MyAlertWithRedirection(1, msg, redirectUrl,false);
            }
            else {
                MyAlert(3, 'Failed To Convert Provisional Bill To Tax Invoice', false);
            }
        });
    }
}