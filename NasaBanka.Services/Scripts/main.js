$(document).ready(function () {
    /* jQueryUI tabs widget */
    $("#tabs").tabs({
        heightStyle: "content"
    });

    /* jQueryUI dialog widget */
    $("#dialog").dialog({
        autoOpen: false,
        closeText: "Zatvori",
        width: 500,
        modal: true,
        draggable: false,
        show: {
            effect: "fade",
            duration: 400
        },
        hide: {
            effect: "fade",
            duration: 400
        }
    });

    $('.box a').on('click', function () {
        $("#dialog").dialog('open');
        return false;
    });

    /* Custom widget */
    var calculator = $('#tab-5');
    calculator.loan({
        price: 1000,
        participation: 100,
        deadline: 12
    });

    // call public method and set creditType value
    $('select[name="creditType"]').on('change', function () {
        var value = $(this).val();
        calculator.loan('creditType', value);
        $('input[name="yearlyRate"]').val(value);
    });

    // call public method calculate();
    $('form[name="calculate"]').on('submit', function () {
        calculator.loan({
            price: $('input[name="price"]').val(),
            participation: $('input[name="participation"]').val(),
            deadline: $('select[name="deadline"]').val()
        });
        var calculation = calculator.loan('calculate');
        $('input[name="montlyPrice"]').val(calculation);
        return false;
    });

    // simple ajax call
    simpleAjaxCall();

    // on button click ajax call
    $('#addList').on('click', function () {
        simpleAjaxCall('add');
        return false;
    });


});

// custom widget 
$.widget('custom.loan', {
    options: {
        price: 0,
        participation: 0,
        deadline: 0,
        creditType: 0
    },
    _create: function () {
        if (typeof this.options.price === 'number') {
            this.options.price = parseFloat(this.options.price);
        } else {
            this.options.price = 0;
        }
        if (typeof this.options.price === 'number') {
            this.options.participation = parseFloat(this.options.participation);
        } else {
            this.options.participation = 0;
        }
        if (typeof this.options.price === 'number') {
            this.options.deadline = parseFloat(this.options.deadline);
        } else {
            this.options.deadline = 0;
        }
    },
    refresh: function () {
        // revert options to initial values
        this.options.price = 0;
        this.options.participation = 0;
        this.options.deadline = 0;
        this.options.creditType = 0;
    },
    _setOption: function (key, value) {
        if (key === "value") {
            value = this._constrain(value);
        }
        this._super(key, value);
    },
    _setOptions: function (options) {
        this._super(options);
    },

    // public method
    creditType: function (creditType) {
        // no value passed, act as a getter
        if (creditType === undefined) {
            return this.options.creditType;
        }

        // set creditType in options
        this.options.creditType = this._constrain(parseFloat(creditType));
    },

    // private method
    _constrain: function (creditType) {
        if (typeof creditType === 'number') {
            return creditType;
        }
        else {
            return 0;
        }
    },

    calculate: function () {
        var calculation = 0;

        var price = this.options.price;
        var participation = this.options.participation;
        var deadline = this.options.deadline;
        var creditType = this.options.creditType;

        if (creditType == 0) {
            calculation = (price - participation) / deadline;
        } else {
            calculation = ((price - participation) + ((price - participation) * (0.01 * creditType))) / deadline;
        }

        return calculation.toFixed(2);
    }
});

// ajax call
var simpleAjaxCall = function (action) {
    if (typeof action !== 'undefined') {
        var params = {};
    } else {
        var params = {
            base: "EUR",
            symbols: "USD,GBP,JPY,CHF,CAD,RUB"
        };
    }

    $.ajax({
        url: 'http://api.fixer.io/latest',
        cache: false,
        type: 'get',
        data: params,
        dataType: 'json',
        async: true,
        success: function (data) {
            populateTable(data);
        },
        error: function (jqXHR, exception) {
            ajaxErrorHandler(jqXHR, exception);
        }
    });
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

var populateTable = function (data) {
    $('#base').text(data.base);
    $('#date').text(data.date);
    var table = $('#currencyList tbody').html('');
    $.each(data.rates, function (key, value) {
        var tr = '<tr><td>' + key + '</td><td>' + value + '</td></tr>';
        $(tr).appendTo(table);
    });
};

