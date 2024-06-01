function InvoceNumberChanged(){
    var invnoCtrl = $('#InvoiceNumberCtrl');
    var btnGetInvDtl = $('#btnGetInvDtl');  
    var btnSubmit = $('#btnSubmit');
    if (invnoCtrl.val() != '' && invnoCtrl.val().length>=8) {
        btnGetInvDtl.makeEnabled();        
    }
    else {
        btnGetInvDtl.makeDisable();
    }
    btnSubmit.makeDisable();
    ClearData();
}
function ClearData(){
    $('#cInvDate').html('');
    $('#cCustomer').html('');

    $('#VariantBody').html('');

    $('.cattext').html('');
    $('.itemtext').html('');
    $('#billmc').html(''); 

    $('#billtaxable').html('');
    $('#billgst').html('');
    $('#billamt').html('');
    $('#revamt').html('');
    $('#InputwtDiscount').val(0);
    $('#InputExchangeValue').val(0);
};
function GetInvoiceDetails() {
    var btnSubmit = $('#btnSubmit');
    var invno = $('#InvoiceNumberCtrl').val();
    var url = '/Exchange/GetInvoiceDetails?InvoiceNumber=' + invno
    GetDataFromAjax(url).done(function (data) {
        
        if (data.IsSuccess) {
            FillHeaderData(data.invoiceDtl); 
            $.each(data.invoiceDtl.Items, function (index, item) {
                FillDetailData(item);
            });
            btnSubmit.makeEnabled();
        }
        else {
            MyAlert(3, data.Message, false);
            btnSubmit.makeDisable();
        }
    });
}
function FillHeaderData(data) {
    $('#cInvDate').html(data.InvoiceDateStr);
    $('#cCustomer').html(data.CustomerID + ' - ' + data.CustomerName + '(' + data.CustomerContactNo+')');   
     
    $('#billtaxable').html(data.TaxableAmount);
    $('#billgst').html(data.GSTAmount);
    $('#billamt').html(data.NetPayableAmount);
}
function FillDetailData(dataitem) {
    $('.cattext').html(dataitem.CategoryLongText);
    $('.itemtext').html(dataitem.UItemCode);
    $('#billmc').html(dataitem.MCAmount); 
    $.each(dataitem.MetalVariants, function (index, item) {
        FillVariantDetailData(item,0);
    });
    $.each(dataitem.DiamondVariants, function (index, item) {
        FillVariantDetailData(item,10);
    });
    $.each(dataitem.StoneVariants, function (index, item) {
        FillVariantDetailData(item,0);
    });

    calculateExchangeValue();
}
function FillVariantDetailData(varianttem, revisedrateincrease) {
    var rr = varianttem.RevisedRate * 1;
    if (revisedrateincrease > 0) {
        rr = (rr*1) + (rr * revisedrateincrease / 100).toFixed(0)*1;
    }
    var rrAmount = (varianttem.Weight * rr).toFixed(0);
    var newRow = $("<tr>").append(
        $("<td>").text(varianttem.VariantText),
        $("<td>").text(varianttem.Weight),
        $("<td>").text(varianttem.Rate),
        $("<td>").text(varianttem.DDisAmount),
        $("<td>").text(varianttem.Amount),
        $("<td>").text(rr),
        $("<td class='rrAmt bggreen'>").text(rrAmount)
    );
    $('#VariantBody').append(newRow);
}
function calculateExchangeValue() {
    var totalRRAmount = 0;
    debugger;
    $('#VariantBody .rrAmt').each(function () {
        // Extract the text from the element and convert it to a number
        var rrAmtValue = parseFloat($(this).html());

        // Check if the value is a valid number
        if (!isNaN(rrAmtValue)) {
            // Add the value to the totalRRAmount
            totalRRAmount += rrAmtValue;
        }
    });
    $('#revamt').html(totalRRAmount);
    $('#InputwtDiscount').val(0);
    $('#InputExchangeValue').val(totalRRAmount);
};
function InputwtDiscountChanged() {
    var ramt = $('#revamt').html() * 1;
    var dis = 0;
    if ($('#InputwtDiscount').val() != '') {
        dis = $('#InputwtDiscount').val() * 1;
    }
    $('#InputExchangeValue').val(ramt - dis);
};
function enableSubmitBtn() {
    var btn = $('#btnSubmit');
};
$(document).ready(function () {
    // Attach keydown event listener to the textbox
    $('#InputwtDiscount').on('keydown', function (event) {
        // Allow: backspace, delete, tab, escape, enter, and . -
        if ($.inArray(event.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            // Allow: Ctrl+A, Command+A
            (event.keyCode == 65 && (event.ctrlKey === true || event.metaKey === true)) ||
            // Allow: Ctrl+C, Command+C
            (event.keyCode == 67 && (event.ctrlKey === true || event.metaKey === true)) ||
            // Allow: Ctrl+V, Command+V
            (event.keyCode == 86 && (event.ctrlKey === true || event.metaKey === true)) ||
            // Allow: Ctrl+X, Command+X
            (event.keyCode == 88 && (event.ctrlKey === true || event.metaKey === true)) ||
            // Allow: home, end, left, right
            (event.keyCode >= 35 && event.keyCode <= 39)) {
            // let it happen, don't do anything
            return;
        }
        // Ensure that it is a number and stop the keypress
        if ((event.shiftKey || (event.keyCode < 48 || event.keyCode > 57)) && (event.keyCode < 96 || event.keyCode > 105)) {
            event.preventDefault();
        }
    });
});

