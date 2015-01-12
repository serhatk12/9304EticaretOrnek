$(document).ready(function () {
    $('#kategoriForm').ajaxForm({
        beforeSubmit: setLoading,
        success:function(response)
        {
            setResponse(response);
            if(response.BasariliMi==true)
            {
                var kayit = response.Kayit;
                if(typeof(kayit) == 'object' && response.Kayit.UstKategori==null)
                {
                    $('#UstKategori').append(
                        "<option value='" + kayit.Id + "'>" + kayit.Ad
                        +"</option>");
                }
            }

        }
    });
});