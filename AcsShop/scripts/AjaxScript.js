

function AjaxRequest(url, method, callbackMethod,data) {
    $.ajax({
        data: JSON.stringify(data),
        url: url,
        method: method,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            callbackMethod("modied" + response);
            console.log("success", response);
        },
        error: function (errorMessage) {
            alert("Something went wrong when making a request");
            console.log("error",errorMessage);
        }
    });
}

