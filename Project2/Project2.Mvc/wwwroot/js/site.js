var createModal = function(url) {
    $('#modalContent').load(url);
    $('#ModalPopUp').modal('show');
}

var clearModal = function (url) {
    $('#modalContent').empty();
    $('#ModalPopUp').modal('toggle');
}

var sendForm = function() {
    $("#form").submit();
}