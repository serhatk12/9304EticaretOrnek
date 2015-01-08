$(document).ready(function () {
    $('.ajaxform').ajaxForm({
        beforeSubmit: setLoading,
        success: setResponse,
    });
});

function setLoading() {
    //TODO Loading gif göster..
    console.log("İşlem başladı");
};

function setResponse(response) {
    //TODO Gelen sonucu işle
    console.log(response);
}