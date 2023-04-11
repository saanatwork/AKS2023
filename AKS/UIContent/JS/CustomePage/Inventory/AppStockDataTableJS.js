$(document).ready(function () {
    var dtinstance = $('#tblDataList').DataTable({
        columns: [
            { 'data': 'DocumentNumber' },
            { 'data': 'EntryDate' },
            { 'data': 'Vendor' },
            { 'data': 'VendorDocNumber' },
            { 'data': 'VendorDocumentDate' },
            { 'data': 'ItemCount' },
            { 'data': 'QtyCount' },
            {
                'data': 'DocumentNumber', render: function (data, type, row, meta) {
                    var viewBtn = '<button type="button" id="' + row.DocumentNumber + '" onclick="FnViewNote(this)" class="btn primaryLink" data-toggle="tooltip" data-placement="top" title="Details"> <svg xmlns=http://www.w3.org/2000/svg width=24 height=24 viewBox="0 0 24 24" fill=none stroke=currentColor stroke-width=2 stroke-linecap=round stroke-linejoin=round class="feather feather-eye"><path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z"></path><circle cx=12 cy=12 r=3></circle></svg></button>';
                    var deleteBtn = '<button type="button" id="D_' + row.DocumentNumber + '" data-dt="' + row.DocumentNumber + '" onclick="FnDeleteNote(this)" class="btn secondaryLink" data-toggle="tooltip" data-placement="top" title="Remove" data-placement="top" title="" data-bs-original-title="Pending"><svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-trash-2"><polyline points="3 6 5 6 21 6"></polyline><path d="M19 6v14a2 2 0 0 1-2 2H7a2 2 0 0 1-2-2V6m3 0V4a2 2 0 0 1 2-2h4a2 2 0 0 1 2 2v2"></path><line x1="10" y1="11" x2="10" y2="17"></line><line x1="14" y1="11" x2="14" y2="17"></line></svg></button>';
                    var mbtns = '<span class="actionBtn d-block">';
                    mbtns = mbtns + viewBtn;
                    if (!row.IsApproved) { mbtns = mbtns + deleteBtn; }
                    mbtns = mbtns + '</span>';
                    return type === 'display' ? mbtns : data;
                }
            },
        ],
        bServerSide: true,
        sAjaxSource: '/Inventory/GetAppStockDocList',
        "pagingType": "input",
    });
    
});