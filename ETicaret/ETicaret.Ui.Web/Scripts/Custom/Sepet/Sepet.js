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
     $('#total_price').empty();
     $('#total_price').append('₺ ' + response.ToplamTutar);
 }