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

$(document).on('click', function (event) {
    var btn_id = event.target.id;
    if (btn_id.split(' ')[0] == "button_delete") {
        var product_id = btn_id.split(' ')[1]
        var product_size = btn_id.split(' ')[2]
        $.ajax(
            console.log(product_id,product_size)
            , {
            
            type: "DELETE",
            url: `/Cart/RemoveFromCart/${product_id}/${product_size}`,
            success: function () {
                window.location.reload()
            },
            error: function (response) {
                console.log(response)
                alert("Error")
            }
        })
    }

});