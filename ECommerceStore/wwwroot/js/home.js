$(document).ready(() => {

    $('.addCartForm').submit((e) => {
        e.preventDefault();

        var inputButton = $(e.target).children('button')[0];
        var inputId = $(e.target).children('input')[0].value;
        var inputReturnUrl = $(e.target).children('input')[1].value;

        var actionUrl = e.currentTarget.action;
        var data = { 'id': inputId, 'returnUrl': inputReturnUrl, 'preventRedirect': true };

        inputButton.disabled = true;

        $.ajax({
            type: "POST",
            url: actionUrl,
            data: data,
            success: (data) => {
                var cartAmount = parseInt($("#cartAmount").html());
                $("#cartAmount").html(cartAmount + 1);
                
                setTimeout(() => {
                    inputButton.disabled = false;
                }, 1000);
            },
            error: (err) => {
                console.error(err);
                inputButton.disabled = false;
            }
        });
    });

});