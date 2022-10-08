$("body").on("click", "i.fa-floppy-disk", function () {

    var id = $(this).attr("data-id");
    var model = BindModel(id);

    Swal.fire({
        title:'Emin misiniz?',
        html: model.Name + ' ülkesine ait bilgileri kaydetmek istediğinize emin misiniz?',
        showDenyButton: true,
        confirmButtonText: 'Kaydet',
        denyButtonText: `Vazgeç`,
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: "/Home/CountryInfoAddAsync",
                type: "POST",
                async: true,
                data: JSON.stringify(model),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (res) {
                    if (res.success) {
                        Swal.fire({
                            icon: 'success',
                            title: 'Başarılı!',
                            text: model.Name + ' ülkesine ait bilgiler, başarılı bir şekilde kaydedildi.',
                        })
                        $(".tr-" + model.ShortName).remove();
                        $("#CountryList option[value='" + model.ShortName + "']").remove();
                        $("#CountryList").val(0);
                        $("#DbCountryInfoBody").append(
                            '<tr>' +
                            '<td>' + model.Name + '</td>' +
                            '<td>' + model.CapitalCity + '</td> ' +
                            '<td>' + model.ShortName + '</td> ' +
                            '<td>' + model.CountryCurrency + '</td> ' +
                            '</tr>');

                    } else {
                        Swal.fire({
                            icon: 'error',
                            title: 'Hata!',
                            text: res.message,
                        })
                    }
                }
            });
        }
    })
});


function BindModel(id) {
    var data = [];
    $('.tr-' + id).each(function (index, tr) {
        var rowValues = $("td", this).map(function () {
            return this.innerText;
        }).get();
        data.push(rowValues);
    });

    return model = {
        'Name': data[0][0],
        'CapitalCity': data[0][1],
        'ShortName': data[0][2],
        'CountryCurrency': data[0][3]
    }
}


function BodyScrollDown() {
    var n = $(document).height();
    $('.country-info-tbl, #CountryInfoBody').animate({ scrollTop: n }, 250);
    $('.db-country-info-tbl, #DbCountryInfoBody').animate({ scrollTop: n }, 250);
}