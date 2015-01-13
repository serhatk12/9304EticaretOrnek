$(document).ready(function () {
    var options = {
        update: function (event, ui) {

            onUpdate(ui);
        },
        activate: function (event, ui) {
            onActive(ui);
        },
        deactivate: function (event, ui) {
            onDeactive(ui);
        }
    };

    $('.sortable').sortable(options);
    $('.subsortable').sortable(options);
});
function onUpdate(ui) {
    var sorted = ui.item.parent();
    var sortedIDs = sorted.sortable("toArray");
    var ids = [];
    $.each(sortedIDs, function (index, value) {
        ids.push(value);
    });


    $.ajax({
        url: '/Yonetim/Kategori/SiraDuzenle',
        method: 'POST',
        data: { 'item': ids },
        success: function (response) {
            setResponse(response);
        }
    });

}
var oldSource = "";
function onActive(ui) {
    var image = ui.item.find('img');
    oldSource = $(image).attr('src');
    $(image).attr('src', '/Content/images/movest.png');
}

function onDeactive(ui) {
    var image = ui.item.find('img');
    $(image).attr('src', oldSource);
}