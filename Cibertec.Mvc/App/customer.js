﻿(function (customer) {
    customer.pages = 1;
    customer.rowSize = 25;
    customer.hub = {};
    customer.ids = [];
    customer.recordInUse = false;

    customer.success = successReload;
    customer.addCustomer = addCustomerId;
    customer.removeCustomer = removeCustomerId;
    customer.validate = validate;

    $(function () {
        connectToHub();
        init();
    });    

    return customer;

    function successReload(option) {
        //console.log('successreload');
        //alert(option);
        cibertec.closeModal(option);
    }

    function init() {
        $.get('Customer/Count/' + customer.rowSize,
            function (data) {
                customer.pages = data;
                $('.pagination').bootpag({
                    total: customer.pages,
                    page: 1,
                    maxVisible: 5,
                    leaps: true,
                    firstLastUse: true,
                    first: '←',
                    last: '→',
                    wrapClass: 'pagination',
                    activeClass: 'active',
                    disabledClass: 'disabled',
                    nextClass: 'next',
                    prevClass: 'prev',
                    lastClass: 'last',
                    firstClass: 'first'
                }).on('page', function (event, num) {
                    getCustomers(num);
                    });
                getCustomers(1);
            });
    }

    function getCustomers(num) {
        var url = '/customer/List/' + num + '/' + customer.rowSize;
        $.get(url, function (data) {
            $('.content').html(data);
        });
    }

    function addCustomerId(id) {
        customer.hub.server.addCustomerId(id);
    }

    function removeCustomerId(id) {
        customer.hub.server.removeCustomerId(id);
    }

    function connectToHub() {
        customer.hub = $.connection.customerHub;
        customer.hub.client.customerStatus = customerStatus;
    }

    function customerStatus(customerIds) {
        console.log(customerIds);
        customer.ids = customerIds;
    }

    function validate(id) {
        customer.recordInUse = (customer.ids.indexOf(id) > -1);
        if (customer.recordInUse) {
            $('#inUse').removeClass('hidden');
        }
    }

})(window.customer = window.customer || {});    