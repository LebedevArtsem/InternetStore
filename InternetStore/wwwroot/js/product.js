$(document).ready(function () {
    $("#button_add_to_cart").click(function () {
        $.ajax({
            type: "POST",
            url: '/Cart/AddToCart',
            data: {
                Id: $("#product_id").val(),
                Image: $("#product_image").attr('src'),
                Title: $("#product_name").text(),
                Price: $("#product_price").text(),
                Size: $("input[name=product_radio]:checked").val(),
                Quantity: 1,
            },
            success: function () {
                window.location.reload()
            },
            error: function (response) {
                alert("Error")
            }
        })
    })
});