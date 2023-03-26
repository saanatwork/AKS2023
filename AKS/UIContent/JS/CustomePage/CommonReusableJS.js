﻿$.fn.isInvalid = function () {
    var that = this;
    that.addClass('is-invalid valid').removeClass('is-valid');
};
$.fn.isValid = function () {
    var that = this;
    that.addClass('is-valid valid').removeClass('is-invalid');
};
$.fn.makeEnabled = function () {
    var that = this;
    that.removeAttr('disabled');
};
$.fn.makeDisable = function () {
    var that = this;
    that.attr('disabled', 'disabled');
};
function IsValidEmail(valuestring) {
    var result = false;
    if (valuestring != '') {
        var emailRegex = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
        result = emailRegex.test(valuestring);
    }    
    return result;
};
function IsValidContact(valuestring) {
    var result = false;
    if (valuestring != '') {
        var phoneRegex = /^\d{10}$/;
        result = phoneRegex.test(valuestring);
    }    
    return result;
};
function IsValidEmailorContact(valuestring) {
    var result = false;    
    if (valuestring != '') {
        var emailRegex = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
        var phoneRegex = /^\d{10}$/;
        if (!emailRegex.test(valuestring)) {
            if (!phoneRegex.test(valuestring)) {
                result = false;
            } else { result = true; }
        } else { result = true; }
    }    
    return result;
};
function IsAlphaNumeric(valuestring) {
    var result = false;
    if (valuestring != '') {
        var alphanumericRegex = /^[a-zA-Z0-9]+$/;
        result = alphanumericRegex.test(valuestring);
    }
    return result;
};
function IsAlphaNumericWithSpace(valuestring) {
    var result = false;
    if (valuestring != '') {
        var alphanumericRegex = /^[a-zA-Z0-9\s]+$/;
        result = alphanumericRegex.test(valuestring);
    }
    return result;
};

function GetRecordsFromTableV3(tableName) {
    //The fields should have an attribute "data-name", Which is the property name of the MVC object
    var schrecords = '';
    var dataname;
    var datavalue;
    var mrecord = '';
    $('#' + tableName + ' tbody tr').each(function () {
        mRow = $(this);
        mRow.find('[data-name]').each(function () {
            that = $(this);
            dataname = that.attr('data-name');
            if (that.hasClass('htmlVal')) {
                datavalue = that.html();
            }
            else { datavalue = that.val(); }
            mrecord = mrecord + '"' + dataname + '":"' + datavalue + '",';
        });
        mRow.find('[data-name-text]').each(function () {
            that = $(this);
            dataname = that.attr('data-name-text');
            thatid = that.attr('id');
            datavalue = $('#' + thatid + ' option:selected').toArray().map(item => item.text).join();
            mrecord = mrecord + '"' + dataname + '":"' + datavalue + '",';
        });
        mrecord = mrecord.replace(/,\s*$/, "");
        schrecords = schrecords + '{' + mrecord + '},';
        mrecord = '';
    });
    schrecords = schrecords.replace(/,\s*$/, "");
    schrecords = '[' + schrecords + ']';
    //alert(schrecords);
    return schrecords;
};
function GetRecordsFromTableHeader(tableName) {
    //The fields should have an attribute "data-name", Which is the property name of the MVC object
    //tr id must be 'PickHdrData'
    var schrecords = '';
    var dataname;
    var datavalue;
    var mrecord = '';
    $('#' + tableName + ' thead tr').each(function () {
        mRow = $(this);
        if (mRow.attr('id') == 'PickHdrData') {
            mRow.find('[data-name]').each(function () {
                that = $(this);
                dataname = that.attr('data-name');
                if (that.hasClass('htmlVal')) {
                    datavalue = that.html();
                }
                else { datavalue = that.val(); }
                mrecord = mrecord + '"' + dataname + '":"' + datavalue + '",';
            });
            mRow.find('[data-name-text]').each(function () {
                that = $(this);
                dataname = that.attr('data-name-text');
                thatid = that.attr('id');
                datavalue = $('#' + thatid + ' option:selected').toArray().map(item => item.text).join();
                mrecord = mrecord + '"' + dataname + '":"' + datavalue + '",';
            });
            mrecord = mrecord.replace(/,\s*$/, "");
            schrecords = schrecords + '{' + mrecord + '},';
            mrecord = '';
        }        
    });
    schrecords = schrecords.replace(/,\s*$/, "");
    schrecords = '[' + schrecords + ']';
    //alert(schrecords);
    return schrecords;
};