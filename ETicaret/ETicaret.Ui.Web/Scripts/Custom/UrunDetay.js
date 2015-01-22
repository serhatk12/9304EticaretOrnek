$('#frmSepeteEkle').submit(function (event) {
    /*Yapılacak işlemleri iptal eder..!*/
    event.preventDefault();

    var adet = $('#adet');    
    if(isNaN(adet.val()) || adet.val() < 1)
    {
        adet.addClass('invalid');
        return false;
    }
   
        adet.removeClass('invalid');
    

    var cart = {
        'UrunId': $('#urunId').val(),
        'Adet': $('#adet').val(),
    };

    $.ajax({
        url: $(this).attr('action'),
        type:$(this).attr('method'),
        data: cart,
        success: function (response) {
            $('#frmSepeteEkle').trigger('reset');
            SepetDetayEkle(response);
        }

    });

});