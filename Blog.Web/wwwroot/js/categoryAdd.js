$(document).ready(function () {
    $("#btnSave").click(function (e) {
        e.preventDefault();
        var addUrl = app.Urls.categoryAddUrl;
        var redirectUrl = app.Urls.articleAddUrl;
        var categoryAddDto = {
            Name: $("input[id=categoryName]").val()
        }
        var jsonData = JSON.stringify(categoryAddDto);
        console.log(jsonData);
        $.ajax({
            url: addUrl,
            method: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: jsonData,
            success: function (data) {
                setTimeout(function () {
                    window.location.href = redirectUrl;
                },1500)
            },
            error: function () {
                toastr.error("Something went wrong!", "Error");
            }
        })
    })
})