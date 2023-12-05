
//#region check boix selection
//select suign suppoorted class ,
function getValueUsingClass(classholder) {
    /* declare an checkbox array */
    var chkArray = [];

    /* look for all checkboes that have a class 'classholder' attached to it and check if it was checked */
    $("." + classholder + ":checked").each(function () {
        chkArray.push($(this).val());
    });

    /* we join the array separated by the comma */
    var selected;
    selected = chkArray.join(',') + ",";

    return selected;

}

//using parent , select all check boxes in a parent control 
function getValueUsingParentTag(parentholder) {
    var chkArray = [];

    /* look for all checkboes that have a parent id called parentholder attached to it and check if it was checked */
    $("#" + parentholder + " input:checked").each(function () {
        chkArray.push($(this).val());
    });

    /* we join the array separated by the comma */
    var selected;
    selected = chkArray.join(',') + ",";

    return selected;
    /* check if there is selected checkboxes, by default the length is 1 as it contains one single comma */
    //if(selected.length > 1){
    //    alert("You have selected " + selected);
    //}else{
    //    alert("Please at least one of the checkbox");
    //}
}

$(document).on('change', '#CheckAll', function () {
    $('[id^="Check_"').prop('checked', $(this).prop('checked'));
});
//#endregion


//#region customized java validations

//#region greater than validator 
//jQuery.validator("greaterThan",
//    function (value, element, params) {

//        if (!/Invalid|NaN/.test(new Date(value))) {
//            return new Date(value) > new Date($(params).val());
//        }

//        return isNaN(value) && isNaN($(params).val())
//            || (Number(value) > Number($(params).val()));
//    }, 'Must be greater than {0}.');
//#endregion
//#endregion

//#region transalate lookup 
//#region tag helper switch language
function appendLanguageSwitcherCookie(cookieName, code) {
    {

        var cookieValue = cookieName + '=c=' + code + '|uic=' + code;
        alert(cookieValue);
        document.cookie = cookieValue;
        // window.location = window.location.href.split('?')[0];
        //   document.cookie = '{0}=c=' + code + '|uic=' + code;
        window.location.reload();
        //$.ajax({
        //    type: "POST",
        //    contentType: "application/json; charset=utf-8",
        //    url: "/Localization/Localization/SetLanguage", //will generate erro t ochange it to search table name
        //    data: JSON.stringify({"culture": code, "returnUrl": window.location }),
        //    dataType: "json",
        //    success: function (data) {
        //        window.location.reload();
        //    },
        //    error: function (err) {
        //        alert("Couldn't Change culture : " + err.responseText);
        //    }
        //});
    }
}

//#endregion
//#endregion