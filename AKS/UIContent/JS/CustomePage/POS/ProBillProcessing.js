function ChangeProvisionalBill() {
    var PBillCtrl = $('#cProvisionalBill');
    PBillNo = PBillCtrl.val();
    if (PBillNo == '') {
        PBillCtrl.isInvalid();
    } else {
        PBillCtrl.isValid();
        GetDataFromAjax('/POS/GetInvoiceDetails?DocumentNumber=' + PBillNo).done(function (data) {
            $('#billDateDiv').html(data.InvoiceDateStr);
            $('#CustomerDiv').html(data.CustomerName + ' (' + data.CustomerContactNo+')');
            $('#CustomerAddressDiv').html(data.CustomerAddress);
        });
    }
};
function SubmitBtnClicked() {

};