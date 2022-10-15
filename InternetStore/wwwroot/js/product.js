$(document).ready(function () {
    $("#button_add_to_cart").click(function () {
        $.ajax({
            type: "POST",
            url: '/Home/AddToCart',
            data: {
                
                Image: $("#product_image").attr('src'),
                Title: $("#product_name").text(),
                Price: $("#product_price").text(),
                Size: $("input[name=product_radio]:checked").val(),
                Quantity: 1,
            },
            success: function (response) {
                alert("Success")
                console.log(response)
            },
            error: function (response) {
                console.log(response)
                alert("Error")
            }
        })
    })
});