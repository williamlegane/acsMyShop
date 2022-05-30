


function requestTeminals(mechantNumber) {
    var url = "Terminals/GetTerminals/" + mechantNumber;
    var method = "get";
    var data = {};
    AjaxRequest(url, method, requestTeminals, data);
}

function renderTeminalsResponse(response) {
    $("#terminals").html(response);
}