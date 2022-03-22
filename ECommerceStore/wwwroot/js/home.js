$(document).ready(() => {

    $('.addCartForm').submit((e) => {
        e.preventDefault();

        var inputButton = $(e.target).children('button')[0];

        var inputId = $(e.target).children('input')[0].value;
        //console.log(inputId);

        var inputReturnUrl = $(e.target).children('input')[1].value;
        //console.log(inputReturnUrl);

        var actionUrl = e.currentTarget.action;
        var data = { 'id': inputId, 'returnUrl': inputReturnUrl, 'preventRedirect': true };

        $.ajax({
            type: "POST",
            url: actionUrl,
            data: data,
            success: (data) => {
                // TODO: update cart count
                //alert("Id: " + inputId + ", returnUrl: " + inputReturnUrl + ", data: " + data); // show response from the php script.
                inputButton.disabled = true;
                setTimeout(() => {
                    inputButton.disabled = false;
                }, 1000);
            },
            error: (err) => {
                console.error(err);
            }
        });
    });

});