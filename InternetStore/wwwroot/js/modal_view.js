function get_modal_view(id) {
    var element = document.getElementById(`${id.id} modal`)
    element.classList.add('modal_view_active')
}

function close_modal_view(id) {
    var modal_id = id.id.split(" ")[0];
    var element = document.getElementById(`${modal_id} modal`)
    element.classList.remove('modal_view_active')
}