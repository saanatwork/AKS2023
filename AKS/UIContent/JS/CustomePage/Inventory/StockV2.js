function FnViewCatStockDetails(ctrl) {
    var primarykey = $(ctrl).attr('id');
    window.location.href = "/Inventory/StockItemDetails?ItemCatCode=" + primarykey;
};
$(document).ready(function () {
    var dtinstance = $('#tblCatStockList').DataTable({
        columns: [
            { 'data': 'ItemCatCode' },
            { 'data': 'ItemCatLongText' },
            { 'data': 'AppQty' },
            { 'data': 'PurQty' },
            { 'data': 'TotalQty' },
            {
                'data': 'ItemCatCode', render: function (data, type, row, meta) {
                    var viewBtn = '<button type="button" id="' + row.ItemCatCode + '" onclick="FnViewCatStockDetails(this)" class="btn primaryLink" data-toggle="tooltip" data-placement="top" title="Details"> <svg xmlns=http://www.w3.org/2000/svg width=24 height=24 viewBox="0 0 24 24" fill=none stroke=currentColor stroke-width=2 stroke-linecap=round stroke-linejoin=round class="feather feather-eye"><path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z"></path><circle cx=12 cy=12 r=3></circle></svg></button>';
                    var mbtns = '<span class="actionBtn d-block">';
                    mbtns = mbtns + viewBtn;
                    //if (!row.IsApproved) { mbtns = mbtns + editBtn; }
                    mbtns = mbtns + '</span>';
                    return type === 'display' ? mbtns : data;
                }
            },
        ],
        bServerSide: true,
        sAjaxSource: '/Inventory/GetStockListV2',
    });

});