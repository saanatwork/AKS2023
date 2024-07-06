function GetItemVariantRecords(tableName) {
    var schrecords = '';
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
        mrecord = mrecord.replace(/,\s*$/, "");
        schrecords = schrecords + '{' + mrecord + '},';
        mrecord = '';
    });
    schrecords = schrecords.replace(/,\s*$/, "");
    schrecords = '[' + schrecords + ']';
    return schrecords;
};
function SubmitBtnClicked() {
    var invoiceNumber = $('#InvoiceNumberCtrl').val();
    var itemCode = $('#InputItemCode').val();
    var revisedAmount = $('#revamt').html();
    var wtDiscount = $('#InputwtDiscount').val();
    var exchangeValue = $('#InputExchangeValue').val();
    var mc = $('#billmc').html();
    var taxableAmt = $('#billtaxable').html();
    var oldgst = $('#billgst').html();
    var billAmt = $('#billamt').html();
    var gstOnExchange = $('#gstOnExchange').html();
    var netExchangeValue=$('#netExchange').html();
    var schrecords = GetItemVariantRecords('tblItemVariant');
    var x = '{"InvoiceNumber":"' + invoiceNumber
        + '","ItemCode":"' + itemCode
        + '","RevisedAmount":"' + revisedAmount
        + '","WearnTearDiscount":"' + wtDiscount
        + '","ExchangeValue":"' + exchangeValue
        + '","MakingCharge":"' + mc
        + '","TaxableAmount":"' + taxableAmt
        + '","OldGST":"' + oldgst
        + '","InvoiceAmount":"' + billAmt
        + '","GSTOnExchange":"' + gstOnExchange
        + '","NetExchangeAmount":"' + netExchangeValue
        + '","VariantDetails":' + schrecords + '}';
    
    $.ajax({
        method: 'POST',
        url: '/Exchange/AddExistingExchange',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: x,
        success: function (data) {
            $(data).each(function (index, item) {
                if (item.bResponseBool == true) {
                    Swal.fire({
                        title: 'Success',
                        text: 'Exchange Entry Saved Successfully.',
                        icon: 'success',
                        customClass: 'swal-wide',
                        buttons: {
                            confirm: 'Ok'
                        },
                        confirmButtonColor: '#2527a2',
                    }).then(callback);
                    function callback(result) {
                        if (result.value) {
                            window.location.href = "/Exchange/Index";
                        }
                    }
                }
                else {
                    Swal.fire({
                        title: 'Error!',
                        text: 'Failed To Save Exchange Entry.',
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
function InvoceNumberChanged() {
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
    $('#InputItemCode').val(dataitem.ItemCode);
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
    var newRow = $("<tr class='Ptbody'>").append(
        $("<td class='htmlVal' data-name='VariantID'>").text(varianttem.VariantID),
        $("<td class='htmlVal' data-name='VariantText'>").text(varianttem.VariantText),
        $("<td class='htmlVal' data-name='VariantWt'>").text(varianttem.Weight),
        $("<td>").text(varianttem.Rate),
        $("<td>").text(varianttem.DDisAmount),
        $("<td>").text(varianttem.Amount),
        $("<td class='htmlVal' data-name='RevisedRate'>").text(rr),
        $("<td class='rrAmt bggreen htmlVal' data-name='RevisedAmount'>").text(rrAmount)
    );
    $('#VariantBody').append(newRow);
}
function calculateExchangeValue() {
    var totalRRAmount = 0;    
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
    var gst = Math.round(totalRRAmount * .03);
    $('#gstOnExchange').html(gst);
    $('#netExchange').html(totalRRAmount+gst);
};
function InputwtDiscountChanged() {
    var ramt = $('#revamt').html() * 1;
    var dis = 0;
    if ($('#InputwtDiscount').val() != '') {
        dis = $('#InputwtDiscount').val() * 1;
    }
    $('#InputExchangeValue').val(ramt - dis);
    var gst = Math.round(totalRRAmount * .03);
    $('#gstOnExchange').html(gst);
    $('#netExchange').html(totalRRAmount + gst);
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

