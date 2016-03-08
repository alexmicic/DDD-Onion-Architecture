$(document).ready(function () {
    clickHandler();
});

// callAPI function
var callAPI = function (params, url, type, tableId) {
    $.ajax({
        url: url,
        cache: false,
        type: type,
        data: params,
        dataType: 'json',
        async: true,
        success: function (data) {
            //console.log(data);
            populateTable(data, tableId);
        },
        error: function (jqXHR, exception) {
            ajaxErrorHandler(jqXHR, exception);
        }
    });
};


var populateTable = function (data, tableId) {
    var table = $('#' + tableId);
    var tableBody = $('#' + tableId + ' tbody').html('');
    $.each(data, function () {
        var tr = '<tr><td>' + this["ClientID"] + '</td><td>' + (this["Ime"]) + '</td><td>' + this["Prezime"] + '</td></tr>';
        $(tr).appendTo(tableBody);
    });
    table.slideDown('fast');
};

var ajaxErrorHandler = function (jqXHR, exception) {
    if (jqXHR.status === 0) {
        return;
    } else if (jqXHR.status === 404) {
        console.log('Requested page not found. [404]');
    } else if (jqXHR.status === 500) {
        console.log('Internal Server Error [500].');
    } else if (exception === 'parsererror') {
        console.log('There was an error loading your content. Please try again in a few minutes');
    } else if (exception === 'timeout') {
        console.log('There was an error loading your content. Please try again in a few minutes');
    } else if (exception === 'abort') {
        console.log('There was an error loading your content. Please try again in a few minutes');
    } else {
        console.log('There was an error loading your content. Please try again in a few minutes');
    }
};

var clickHandler = function () {
    var btns = $('.loadData');
    if (btns.length > 0) {
        btns.each(function () {
            var item = $(this);
            var url = item.attr('data-url');
            var params = {
                action: item.attr('data-params')
            };
            var tableId = item.attr('data-table');
            item.on('click', function () {
                callAPI(params, url, 'GET', tableId);
                item.off();
                return false;
            });
        });
    }
};