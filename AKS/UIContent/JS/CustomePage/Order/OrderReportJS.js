function GetReport1() {
    var fromdate = $('#cFromDate').val();
    var todate = $('#cToDate').val();
    var url = '/Order/GetReport1?FromDate=' + fromdate + '&ToDate=' + todate;
    GetDataFromAjax(url).done(function (data) {
        $('#OPtd').html(data.NoOfOrdersRegister);
        $('#OCtd').html(data.NoOfOrdersCompleted);
        $('#ODtd').html(data.NoOfOrdersDelivered);
    });
};
function OrderListViewBtnClicked(ststus) {
    var fromdate = $('#cFromDate').val();
    var todate = $('#cToDate').val();
    var tblody = $('#ReportDtlBody');
    var rpthdr = $('#ReportDtlHdr');
    var mbody = '';
    var url = '/Order/GetReport2?FromDate=' + fromdate + '&ToDate=' + todate + '&Status=' + ststus;
    GetDataFromAjax(url).done(function (data) {
        var sl = 1;
        var bcolor = '';
        $(data).each(function (index, item) {
            var viewBtn = '<button type="button" id="' + item.DocumentNumber + '" onclick="FnViewOrder(this)" class="btn primaryLink" data-toggle="tooltip" data-placement="top" title="Details"> <svg xmlns=http://www.w3.org/2000/svg width=24 height=24 viewBox="0 0 24 24" fill=none stroke=currentColor stroke-width=2 stroke-linecap=round stroke-linejoin=round class="feather feather-eye"><path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z"></path><circle cx=12 cy=12 r=3></circle></svg></button>';
            if (item.OrdStatus == 2) { bcolor = 'blue'; }
            else if (item.OrdStatus == 4) { bcolor = 'green'; }
            else if (item.OrdStatus == 9) { bcolor = 'red'; }
            else { bcolor = ''; }
            mbody = mbody + '<tr>';
            mbody = mbody + '<td style="border:1px solid green;background-color:' + bcolor + '"></td>';
            mbody = mbody + '<td style="border:1px solid green;text-align:center">' + sl +'</td><td style="border:1px solid green;text-align: center">';
            mbody = mbody + item.DocumentNumber;
            mbody = mbody + '</td>';
            mbody = mbody + '<td style="border:1px solid green;text-align: center">';
            mbody = mbody + item.EntryDateStr;
            mbody = mbody + '</td>';
            mbody = mbody + '<td style="border:1px solid green;text-align: center">';
            mbody = mbody + (item.StockDocumentnumber == null ? '' : item.StockDocumentnumber) + '<br/>' + item.StockEntryDateStr;
            mbody = mbody + '</td>';
            mbody = mbody + '<td style="border:1px solid green;text-align: center">';
            mbody = mbody + (item.POSDocumentnumber == null ? '' : item.POSDocumentnumber) + '<br/>' + item.DeliverDateStr;
            mbody = mbody + '</td>';
            mbody = mbody + '<td style="border:1px solid green;text-align:center"> ';
            mbody = mbody + viewBtn;
            mbody = mbody +'</td>';
            mbody = mbody + '</tr>';
            sl = sl + 1;
        });
        tblody.html(mbody);
    });
    /// Generating Report Header
    if (ststus == 0) {
        rpthdr.html('Details Of Order Placed From <strong>' + ChangeDateFormat(fromdate) + '</strong> To <strong>' + ChangeDateFormat(todate) +'</strong>');
    }
    else if (ststus == 2) {
        rpthdr.html('Details Of Order Completed From <strong>' + ChangeDateFormat(fromdate) + '</strong> To <strong>' + ChangeDateFormat(todate) +'</strong>');
    }
    else if (ststus == 4) {
        rpthdr.html('Details Of Order Delivered From <strong>' + ChangeDateFormat(fromdate) + '</strong> To <strong>' + ChangeDateFormat(todate) +'</strong>');
    }
};
function FnViewOrder(myCtrl) {
    var docnumber = $(myCtrl).attr('id');
    window.location.href = "/Order/ViewOrder?DocumentNumber=" + docnumber;
};
function OrderViewBtnClicked(myCtrl) {
    var docnumber = $(myCtrl).attr('id').split('_')[1];
    window.location.href = "/Order/ViewOrder?DocumentNumber=" + docnumber;
};
