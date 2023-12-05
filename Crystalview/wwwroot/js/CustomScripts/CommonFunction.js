//start of file ,to prevent an error
//nothing
//#region modal popup for CRUD opearations
$(function () {
    $.ajaxSetup({ cache: false });
    $("a[data-modal]").on("click", function (e) {
        $('#myModalContent').load(this.href, function () {
            $('#myModal').modal({
                keyboard: true
            }, 'show');
            bindForm(this);
        });
        return false;
    });
});

function bindForm(dialog) {
    console.log('calling form');
    $('form', dialog).submit(function () {
        // alert('dddd');

        console.log('calling mopdal');
        $('#progress').show();
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (result) {
                if (result.success) {
                    $('#myModal').modal('hide');
                    $('#progress').hide();
                    location.reload();
                } else {
                    $('#progress').hide();
                    $('#myModalContent').html(result);
                    bindForm();
                }
            }
        });
        return false;
    });
}
//#endregion

//#region start up stuff fdor all options
$(document).ready(function () {
    //#region short cut keys
    //short cut keys
    $(document).on('keydown', function (e) {
        if (e.altKey) {
            $('[class*="alt-"]:not([data-alt])').each(function (idx, item) {
                var Key = $(item).prop('class').substr($(item).prop('class').indexOf('alt-') + 5, 1).toUpperCase();
                $(item).attr("data-alt", Key);
                $(item).append('<div class="tooltip fade top in tooltip-alt alter-info" role="tooltip" style="margin-top: -61px; display: block; visibility: visible;"><div class="tooltip-arrow" style="left: 49.5935%;"></div><div class="tooltip-inner"> ALT + ' + Key + '</div></div>')
            });
        }

        //not working so no action from here
        //if (e.ctrlKey && e.which !== 17) {
        //    var Key = String.fromCharCode(e.which).toLowerCase();
        //    if ($('.ctrl-' + Key).length === 1) {
        //        e.preventDefault();
        //        //if (!$('#divLoader').is(":visible"))
        //        $('.ctrl-' + Key).click();
        //        console.log("You pressed ctrl + " + Key);
        //    }
        //}
    });

    $(document).on('keyup', function (e) {
        if (!e.ctrlKey) {
            $('[class*="ctrl-"]').removeAttr("data-ctrl");
            $(".tooltip-ctrl").remove();
        }
    });
    //#endregion

    // $("#menu").menu();
    $(".chosen-select").select2();
    //resolve the isue that some times chosen is not shown correct
    //$('.chosen-select').select2({ width: '100%' });
    $('.select2').select2();
    $("#tabs").tabs();

    // Summernote
    $('.summernote').summernote({ height: 200 });
    //$('.SearchlistBox').listbox({ 'searchbar': true });

    // activate jquery tool tip plug in for the sirte
    $(document).tooltip({ tooltipClass: "slick-tooltip" });

    //#region set the doamin so we can call reports directly
    var dd = window.location.hostname.slice(window.location.hostname.indexOf('.') + 1);
    document.domain = (dd.length < 3 ? 'LocalHost' : dd);//'datatech-eg.com';
    //console.log(document.domain);

    //#endregion

    //#region get current uiser local part
    //is not working always return os language not cultureUI
    //var l_lang;
    //if (navigator.userLanguage) // Explorer
    //    l_lang = navigator.userLanguage;
    //else if (navigator.language) // FF
    //    l_lang = navigator.language;
    ////else
    ////    l_lang = "en";
    //alert(l_lang);
    //var CurrentDateFormat = 'MM/DD/YYYY';
    //if (l_lang != 'en-US')
    //    CurrentDateFormat = 'DD/MM/YYYY';
    ////alert(CurrentDateFormat);

    //#endregion

    //#region date time picker stufff
    //get current culture format for date
    //cannot be doen here ,must be done in html page to get culture UI ,
    // now it is jspartial and working here fine
    //var CurrentDateFormat = @System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
    //alert(moment.locale());
    //alert(moment.defaultFormat);
    //alert('in the js '+CurrentDateFormat);
    //usef for tabulator grid date class
    $('.datepicker').datepicker($.datepicker.regional['en-us']);
    //$('.date-picker').datetimepicker({
    $('.date-picker').datepicker({
        dateFormat: CurrentDateFormat,
        //rtl : true ,
        //locale: 'ru',
        //format: 'L',
        showClose: true,
        showClear: true,
        toolbarPlacement: 'top'
    });
    // $('.time-picker').timepicker();
    $('.time-picker').datetimepicker({
        format: 'HH:mm'
    });
    //date picker with history only today is max
    $('.date-picker-Max-Today').datetimepicker({
        format: CurrentDateFormat,
        //format: 'L',
        showClose: true,
        showClear: true,
        maxDate: DateTime.now(),
        toolbarPlacement: 'top'
    });
    //date picker with future only today is max
    $('.date-picker-Min-Today').datetimepicker({
        format: CurrentDateFormat,
        //format: 'L',
        showClose: true,
        showClear: true,
        minDate: DateTime.now(),
        toolbarPlacement: 'top'
    });

    //date picker with credit card with MM/YYYY from current and up
    $('.CC-picker').datetimepicker({
        format: 'MM/YYYY',
        showClose: true,
        showClear: true,
        minDate: DateTime.now(),
        toolbarPlacement: 'top'
    });

    //date picker with credit card with MM/YYYY
    $('.MM-picker').datetimepicker({
        format: 'MM/YYYY',
        showClose: true,
        showClear: true,

        toolbarPlacement: 'top'
    });

    //date picker with Year only
    $('.YY-picker').datetimepicker({
        viewMode: 'years',
        format: 'YYYY',
        showClose: true,
        showClear: true,

        toolbarPlacement: 'top'
    });

    //date picker with week days by Name
    $('.WD-picker').datetimepicker({
        //viewMode: 'years',
        format: 'dddd',
        showClose: true,
        showClear: true,

        toolbarPlacement: 'top'
    });

    //time list picker , list of avaiable times in ddl like control

    $('.DDLTimePicker').timepicker({
        'scrollDefault': 'now',
        'timeFormat': 'H:i',
        'step': 15
    });
    //#endregion
    //$.sidebarMenu("#menu");

    //#region file upload validation process
    //usage need to add some attributes to file upload
    // data-max-size='1m' (can be in K,M,G) data-type='image'
    //<input type="file" asp-for="AvatarFileName" name="AvatarFile" accept=".jpg" data-max-size='1m' data-type='image' />
    //$("input[type=file]").fileValidator({
    //    //onValidation: function (files) { ... },
    //    onInvalid: function (type, file) {
    //        alert("Invalid file uploaded");
    //        //$("#FileUploadValidator").val("Invalid file uploaded , max size is 1 MB and only Jpg is alowed")
    //        $(this).val(null);//clear selection
    //    },

    //});
    //#endregion

    //#region preapre progfewess to be modal for long process
    $('#progress').dialog({
        modal: true,
        autoOpen: false
    });
    //#endregion
});

//#endregion

//#region checkboxes part
//#region make chaeck box readonly if ti has the read only attrib as it is not working by details
$('input[type="checkbox"]').on('click keyup keypress keydown', function (event) {
    if ($(this).is('[readonly]')) { return false; }
});
//#endregion

//#region mutula exclusive check box
///usage
//code ==> $(".radio").click(enforeMutualExcludedCheckBox(".radio"));
//code ==> $("[class=radio]").mutuallyExcludedCheckBoxes();
//html ==>  <input asp-for="UserHourRate" type="checkbox" class="radio"/>
$.fn.mutuallyExcludedCheckBoxes = function () {
    var $checkboxes = this; // refers to selected checkboxes

    $checkboxes.click(function () {
        var $this = $(this),
            isChecked = $this.prop("checked");

        $checkboxes.prop("checked", false);
        $this.prop("checked", isChecked);
    });
};

//#endregion

//#endregion

//#region diable button

$(':submit').click(function () {
    var $button = this;
    var oldValue = $button.value;
    var oldHtml = $button.innerHTML;
    setTimeout(function () {
        $button.disabled = true;
        if (oldValue) {
            $button.value = 'One moment...';
        }
        if (oldHtml) {
            $button.innerHTML = 'One moment...';
        }
        setTimeout(function () {
            $button.disabled = false;
            if (oldValue) {
                $button.value = oldValue;
            }
            if (oldHtml) {
                $button.innerHTML = oldHtml;
            }
        }, 5000);
    }, 0);
});

// non button usingf anchor and bootstrap format

$('.btn-primary').click(function () {
    var $button = this;
    var oldValue = $button.value;
    var oldHtml = $button.innerHTML;
    setTimeout(function () {
        $button.disabled = true;
        if (oldValue) {
            $button.value = 'One moment...';
        }
        if (oldHtml) {
            $button.innerHTML = 'One moment...';
        }
        setTimeout(function () {
            $button.disabled = false;
            if (oldValue) {
                $button.value = oldValue;
            }
            if (oldHtml) {
                $button.innerHTML = oldHtml;
            }
        }, 8000);
    }, 0);
});

//delete confirmation for delete without page
function useDeleteConfirmation() {
    $('.btn-delete').on("click", function (e) {
        e.preventDefault();

        var choice = confirm("Are you sure you want to delete?");

        if (choice) {
            window.location.href = $(this).attr('href');
        }
    });
}
//#endregion

//region General Utils

//#region date time utils
// fill in array of time slots
function getTimeStlots(start, end) {
    var startTime = DateTime.fromISO(start, 'HH:mm');
    var endTime = DateTime.fromISO(end, 'HH:mm');

    if (endTime.isBefore(startTime)) {
        endTime.add(1, 'day');
    }

    var timeStops = [];

    while (startTime <= endTime) {
        timeStops.push(new DateTime.fromISO(startTime).format('HH:mm'));
        startTime.add(15, 'minutes');
    }
    return timeStops;
}

//#endregion

//#region fill in arrays
function fillInSelect(select, dataSource, addBlank) {
    var index, len, newOption;
    if (addBlank) { select.appendChild(new Option('', '')); }
    console.log('inside poputale');
    $.each(dataSource, function (value, text) {
        //console.log('text is ' + text);
        newOption = new Option(text, value);
        select.appendChild(newOption);
    });
}

//#endregion

//#region string manipluation
//get a part of string after a specified character.
// a : get till this char , from start to
// b : get from this char ,from this char till end
function subStrAfterChars(str, char, pos) {
    if ((pos === 'b') && (str.indexOf(char) > 0))
        return str.substring(str.indexOf(char) + 1);
    else if ((pos === 'a') && (str.indexOf(char) > 0))
        return str.substring(0, str.indexOf(char));
    else
        return str;
}

//#endregion

//#region ajazx short hands
// calling ajax general function to reduce code
/// var contentType = "application/json; charset=utf-8";
//var url = "/Club/clpaPaymentInH/ActionVoided";
//var Senddata = @Model.ID;

//callAjaxshort(url, contentType, Senddata, '@Localizer["VoidSuccess"]', '@Localizer["FailToVoid"]')
function callAjaxshort(url, contentType, Senddata, Successmsg, Failmsg) {
    var result = false;
    $.ajax({
        type: "POST",
        contentType: contentType,
        accepts: "application/json",
        url: url,
        //traditional: true,   //must be tru for arrray to be send
        data: Senddata,
        dataType: "json",
        success: function (results) {
            result = true;
            // here comes your response after calling the server
            alert(Successmsg);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            result = false;
            alert(Failmsg);
            //alert("error : " + jQuery.parseJSON(jqXHR.responseText));
            //alert("error : " + errorThrown);
            console.log(textStatus);
            console.log(errorThrown);
        }
    });
    return result;
}

//#region call ajax in short row

//CallAjax(parentId, "/Dental/mdPrices/AddAllServices", "@Localizer["ConfirmDelete"]", "@Localizer["DeleteSuccess"]", "@Localizer["DeleteFail"]", true);
function CallAjax(ID, URL, ConfirmMsg, SuccessMsg, FailMsg, PageReload) {
    if (confirm(ConfirmMsg + ID)) {
        var id = ID;
        console.log(id);
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: URL,
            data: JSON.stringify(id), //JSON.stringify({ "ids": SelectedIds }),
            dataType: "json",
            traditional: true,
            success: function (data) {
                alert(SuccessMsg);
                if (PageReload)
                    window.location.reload();
            },
            error: function (err) {
                alert("error : " + err);
            }
        });
    }
};

//#endregion

function getQueryVariable(variable) {
    var query = window.location.search.substring(1);
    var vars = query.split("&");
    for (var i = 0; i < vars.length; i++) {
        var pair = vars[i].split("=");
        if (pair[0] === variable) { return pair[1]; }
    }
    return (false);
}

//function GetQueryStringParams(sParam)
//{
//    var sPageURL = window.location.search.substring(1);
//    var sURLVariables = sPageURL.split('&');
//    for (var i = 0; i < sURLVariables.length; i++)
//    {
//        var sParameterName = sURLVariables[i].split('=');
//        if (sParameterName[0] == sParam)
//        {
//            return sParameterName[1];
//        }
//    }
//}​

function getParameterByName(name) {
    //name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    //var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
    //    results = regex.exec(url);
    //return results == null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));

    var match = RegExp('[?&]' + name + '=([^&]*)')
        .exec(window.location.search);

    return match ?
        decodeURIComponent(match[1].replace(/\+/g, ' '))
        : null;
    //return null;
}

function getCoreid() {
    var val = getParameterByName('id');
    // if URL has query string style
    // xxx?id=56
    if (val !== null)
        return val;
    else
        // if core style
        // Edit/123
        return subStrAfterChars(getLastPartofURL(), '?', 'a');
}

function getLastPartofURL() {
    return window.location.href.substr(window.location.href.lastIndexOf('/') + 1);
}

var getAbsoluteUrl = (function () {
    var a;
    return function (url) {
        if (!a) a = document.createElement('a');
        a.href = url;
        alert(a.href);
        return a.href;
    };
})();

function CorrectHindiNumerals(value) {
    console.log('inside indi function');
    var yas = value;
    console.log(yas);
    yas = yas.replace(/[٠١٢٣٤٥٦٧٨٩]/g, function (d) { return d.charCodeAt(0) - 1632; })
        .replace(/[۰۱۲۳۴۵۶۷۸۹]/g, function (d) { return d.charCodeAt(0) - 1776; });
    console.log(yas);
    return yas === null ? value : yas;
}

//// show bootstrap tool tips for all pages and controls
//$(function () {
//    //alert('holeeee');
//    $(document).tooltip();
//    $('.mvc-grid').mvcgrid();
//});

//#endregion

//#region cascadign drop down
function CascadingDropDown(ddlParent, ddlChild, strMethod) {
    $(ddlChild).empty();

    var statesProgress = $("#states-loading-progress");
    statesProgress.show();
    $.ajax({
        type: 'POST',
        //url: '@Url.Action("GetGroupMeals")', // we are calling json method
        //url: strMethod ,
        url: "/TripsEmployees/GetAllTripDrivers",
        dataType: 'json',
        data: { id: $(ddlParent).val() },
        success: function (childs) {
            //alert('got enough meals ??' + meals.Value);
            // states contains the JSON formatted list
            // of states passed from the controller
            $.each(childs, function (i, child) {
                $(ddlChild).append('<option value="' + child.Value + '">' + meal.child + '</option>');
                statesProgress.hide();
            }); // here we are adding option for States
        },
        error: function (ex) {
            alert('Failed to retrieve children.' + ex);
            statesProgress.hide();
        }
    });
    return false;
}

/// activate a specic tab in  bootstrap
//usage activaTab('bbb');
function activaTab(tab) {
    $('.nav-tabs a[href="#' + tab + '"]').tab('show');
};
//#endregion

//#region common functions for delete

//#region deleted all selected

function DeleteSelected(gridName, URL, ConfirmMsg, SuccessMsg, FailMsg, PageReload) {
    if (confirm(ConfirmMsg)) {
        var selectedData = [];
        var selectedIndexes;

        selectedIndexes = gridName.getSelectedData();
        //console.log(selectedIndexes);

        jQuery.each(selectedIndexes, function (index, value) {
            selectedData.push(selectedIndexes[index].id);
        });
        //console.log(selectedData);

        var SelectedIds = JSON.stringify(selectedData);
        //console.log(SelectedIds);

        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: URL,
            data: SelectedIds, //JSON.stringify({ "ids": SelectedIds }),
            dataType: "json",
            traditional: true,
            success: function (data) {
                if (data.success) {
                    alert(SuccessMsg);
                    if (PageReload)
                        window.location.reload();
                    //clpaPaymentInMemberGrid.setData();
                }
                else {
                    alert(data.responseText);
                }
            },
            error: function (err) {
                alert("error : " + err + FailMsg);
            }
        });
    }
};

//#endregion
//#endregion

//#region cokie manipulations
function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}

function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

function checkCookie() {
    var user = getCookie("username");
    if (user != "") {
        alert("Welcome again " + user);
    } else {
        user = prompt("Please enter your name:", "");
        if (user != "" && user != null) {
            setCookie("username", user, 365);
        }
    }
}
//#endregion