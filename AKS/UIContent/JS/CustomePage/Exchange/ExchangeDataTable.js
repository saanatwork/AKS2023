﻿function FnEditNote(ctrl) {
    var primarykey = $(ctrl).attr('data-dt');
    window.location.href = "/Exchange/EditAppStock?DocumentNumber=" + primarykey;
};
function FnDeleteNote(ctrl) {
    var primarykey = $(ctrl).attr('data-dt');
    window.location.href = "/Inventory/ViewAppStock?IsDelete=1&DocumentNumber=" + primarykey;
};
function FnViewNote(ctrl) {
    var primarykey = $(ctrl).attr('id');
    window.location.href = "/Exchange/ViewExchangeNote?DocumentNumber=" + primarykey;
};
$(document).ready(function () {
    var dtinstance = $('#tblDataList').DataTable({
        columns: [
            { 'data': 'CustomerName' },
            { 'data': 'RefDocumentNumber' },
            { 'data': 'InvoiceDateStr' },
            { 'data': 'InvoiceAmount' },
            { 'data': 'DocumentNumber' },
            { 'data': 'EntryDateStr' },
            { 'data': 'ExchangeValue' },
            {
                'data': 'DocumentNumber', render: function (data, type, row, meta) {
                    var viewBtn = '<button type="button" id="' + row.DocumentNumber + '" onclick="FnViewNote(this)" class="btn primaryLink" data-toggle="tooltip" data-placement="top" title="Details"> <svg xmlns=http://www.w3.org/2000/svg width=24 height=24 viewBox="0 0 24 24" fill=none stroke=currentColor stroke-width=2 stroke-linecap=round stroke-linejoin=round class="feather feather-eye"><path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z"></path><circle cx=12 cy=12 r=3></circle></svg></button>';
                    var editBtn = '<button type="button" id="D_' + row.DocumentNumber + '" data-dt="' + row.DocumentNumber + '" onclick="FnEditNote(this)" class="btn secondaryLink" data-toggle="tooltip" data-placement="top" title="Edit" data-placement="top" title="" data-bs-original-title="Edit"><svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-edit"><path d="M11 4H4a2 2 0 0 0-2 2v14a2 2 0 0 0 2 2h14a2 2 0 0 0 2-2v-7"></path><path d="M18.5 2.5a2.121 2.121 0 0 1 3 3L12 15l-4 1 1-4 9.5-9.5z"></path></svg></button>';
                    var mbtns = '<span class="actionBtn d-block">';
                    mbtns = mbtns + viewBtn;
                    if (!row.IsApproved) { mbtns = mbtns ; }
                    mbtns = mbtns + '</span>';
                    return type === 'display' ? mbtns : data;
                }
            },
        ],
        bServerSide: true,
        sAjaxSource: '/Exchange/GetExchangeExistingHistory',
        "pagingType": "input",
    });

});