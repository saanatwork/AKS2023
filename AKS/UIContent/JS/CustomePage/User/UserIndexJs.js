function ValidateControl() {
    var myCtrl = $(ValidateControl.caller.arguments[0].target);
    var isvalid = validatectrl(myCtrl.attr('id'), myCtrl.val(), 1);
    if (isvalid) { myCtrl.isValid(); } else { myCtrl.isInvalid(); }
    SaveBtnStatus();
};
function validatectrl(targetid, value, spltag) {
    var isvalid = false;
    switch (targetid) {
        case "cCategory":
            if (value != '') { isvalid = true; }
            break;

        case "cDocumentNumber":
            isvalid = IsAlphaNumeric(value);
            break;
        
    }
    return isvalid;
};

function CategoryClicked() {
    var myCtrl = $(CategoryClicked.caller.arguments[0].target);
    if (myCtrl.val() != '') {
        GetDropDownData('cItem', 'Select Item', '/Inventory/GetItemOfCategory?CategoryCode=' + myCtrl.val())
        myCtrl.isValid();
    }
    else { myCtrl.isInvalid(); }
};
function ItemClicked() {
    var myCtrl = $(ItemClicked.caller.arguments[0].target);
    if (myCtrl.val() != '') {        
        myCtrl.isValid();
        var myBody = $('#VariantBody');
        var myBodyContent = '';
        dataSourceURL = '/Inventory/GetItemVariantsForSale?ItemID=' + myCtrl.val();
        $.ajax({
            url: dataSourceURL,
            method: 'GET',
            dataType: 'json',
            success: function (data) {
                var totItem = 0;
                $.each(data.MetalVariants, function (index, item) {                    
                    myBodyContent = myBodyContent + '<tr>'
                        + '<td>' + item.VariantDescription + '</td>'
                        + '<td>' + item.VariantWt + 'G</td>'
                        + '<td style="text-align:right">' + item.RatePerUnit + '</td><td></td>'
                        + '<td style="text-align:right">' + item.Amount + '</td>'
                        + '</tr>';
                    totItem = totItem + item.Amount;
                });
                $.each(data.DiamondVariants, function (index, item) {
                    myBodyContent = myBodyContent + '<tr>'
                        + '<td>' + item.VariantDescription + '</td>'
                        + '<td>' + item.VariantWt + 'K</td>'
                        + '<td style="text-align:right">' + item.RatePerUnit + '</td>'
                        + '<td style="text-align:right">' + item.DiDiscountAmount + '</td>'
                        + '<td style="text-align:right">' + item.Amount + '</td>'
                        + '</tr>';
                    totItem = totItem + item.Amount;
                });
                $.each(data.StoneVariants, function (index, item) {
                    myBodyContent = myBodyContent + '<tr>'
                        + '<td>' + item.VariantDescription + '</td>'
                        + '<td>' + item.VariantWt + 'K</td>'
                        + '<td style="text-align:right">' + item.RatePerUnit + '</td><td></td>'
                        + '<td style="text-align:right">' + item.Amount + '</td>'
                        + '</tr>';
                    totItem = totItem + item.Amount;
                });
                $.each(data.MCInfo, function (index, item) {
                    myBodyContent = myBodyContent + '<tr>'
                        + '<td>Making Charges : </td>'
                        + '<td>' + item.VariantWt + 'G</td>'
                        + '<td style="text-align:right">' + item.MakingCharge + '</td><td></td>'
                        + '<td style="text-align:right">' + item.Amount + '</td>'
                        + '</tr>';
                    totItem = totItem + item.Amount;
                });
                myBodyContent = myBodyContent + '<tr>'
                    + '<td colspan="4"><b>Total Amount : </b></td>'                    
                    + '<td style="text-align:right"><b>' + totItem + '</b></td>'
                    + '</tr>'
                
                myBody.html(myBodyContent);
            }
        });
    }
    else { myCtrl.isInvalid(); }
};