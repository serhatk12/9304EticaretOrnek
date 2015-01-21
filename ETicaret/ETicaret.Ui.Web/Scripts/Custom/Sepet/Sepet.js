 function SepeteEkle(id,count)
 {
     var cart = {
         'UrunId': id,
         'Adet':count,
     };

     $.ajax({
         type: 'POST',
         url: '/Layout/SepeteEkle',   
         data:cart,
         success:function(response)
         {
             SepetDetayEkle(response);
         }
     });
 }

 function SepetDetayEkle(response)
 {
    
     $('#sepet_detaylari').empty();
     $.each(response.SepetIcerik, function (index, value) {
         var html = '<tr><td>'+value.Adet+'</td><td>'+value.UrunAdi+'</td><td> ₺'+value.BirimFiyat+'</td></tr>';
         $('#sepet_detaylari').append(html);
     });
     $('#total_price').empty();
     $('#total_price').append('₺ ' + response.ToplamTutar);
     $('html, body').animate({
         scrollTop: $("#cart_menu").offset().top
     }, 1000);
     $('#cart_menu').find('a').trigger('hover');
    
 }