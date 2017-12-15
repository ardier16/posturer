$("#sendBtn").click(function () {
    blockButton();
    postRequest();
});

function blockButton() {
    $("button").addClass("disabled");
    $("#sendBtn")[0].innerText = "Sending request...";
}

function postRequest() {
    $.ajax({
        url: 'http://posturer.azurewebsites.net/api/posturelevel',
        type: 'POST',
        data: {
            'UserId': '74b43350-8275-42ae-91b3-152ae1944328',
            'Level': getPostureLevel()
        },
        success: function(data){ 
            unblockButton();
            setAlert("success");
        },
        error: function(data) {
            unblockButton();            
            setAlert("error"); 
        }
    });
}

function unblockButton() {
    $("button").removeClass("disabled");
    $("#sendBtn")[0].innerText = "Send To Server";
}

function setAlert(status) {
    var alertField = $(".alertField")[0];

    if (status == "success") {
        alertField.innerHTML = generateAlertDiv("alert-success", "Success!", "Request was sent");
    }
    else {
        alertField.innerHTML = generateAlertDiv("alert-danger", "Error!", "Request was not sent");        
    }
}

function generateAlertDiv(className, title, data) {
    return '<div class="alert alert-dismissible fade show text-left '+ className + '" role="alert">' +
        '<strong>' + title + '</strong> ' + data +
        '<button type="button" class="close" data-dismiss="alert" aria-label="Close">' +
        '<span aria-hidden="true">&times;</span>' +
        '</button></div>'
}