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
    var resultDiv = $('#result');
    if (response.BasariliMi == true)
    {
        if(resultDiv.hasClass('insertResult'))
        {
            $('form').trigger('reset');
        }
    }
    var html = '<div class="' + response.CssClass + '">' + response.Mesaj + "</div>";
   
    resultDiv.fadeOut(0, function () {
        resultDiv.append(html);
    });
    resultDiv.fadeIn(2000, function () {
        resultDiv.fadeOut(5000, function () {
            resultDiv.empty();
        });

    });
 
}