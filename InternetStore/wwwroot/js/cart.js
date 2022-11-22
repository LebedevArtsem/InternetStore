$(document).ready(function () {
    $("#button_clear_cart").click(function () {
        $.ajax({
            type: "DELETE",
            url: '/Cart/ClearCart',
            success: function () {
                window.location.reload()
            },
            error: function (response) {
                console.log(response)
                alert("Error")
            }
        })
    })
});

$(document).ready(function () {
    $("#button_delete").click(function () {
        $.ajax({
            type: "DELETE",
            url: '/Cart/RemoveFromCart',
            data: {
                Id: $("#product_id").val()
            },
            success: function () {
                window.location.reload()
            },
            error: function (response) {
                console.log(response)
                alert("Error")
            }
        })
    })
});