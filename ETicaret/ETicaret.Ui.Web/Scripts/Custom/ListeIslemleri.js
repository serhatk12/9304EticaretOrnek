function DeleteFromList(deleteAdress, id)
{
  
    var result = confirm('Bu kaydı silmek istediğinize emin misiniz?');
   
    if (result == true)
    {
        var fullAdress = deleteAdress + id;
        $.get(fullAdress, function (response) {

            if (response.BasariliMi == true) {
                $('#tableRow-' + id).fadeOut(1000);

            }
            else {
                alert(response.Mesaj);
            }

        });

    }

}