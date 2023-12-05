//#region generalutils

//#region fill in selectr lookup array for the grid to use

function arraytoFillhandleData(arraytoFill, responseData) {
    var expecting = responseData.length;
    responseData.forEach(function (entry, index) {
        arraytoFill[entry.value] = entry.text;
    });
}

//callAjaxshort(url, contentType, Senddata, '@Localizer["VoidSuccess"]', '@Localizer["FailToVoid"]')
function fillArraryfromAjax(arraytoFill, url, contentType, Senddata, isAsync, dataType, Failmsg) {
    var result = false;

    $.ajax({
        type: "GET",
        contentType: contentType,
        accepts: "application/json",
        url: url,
        //traditional: true,   //must be tru for arrray to be send
        data: Senddata,
        dataType: dataType,
        async: isAsync,
        success: function (responseData) {
            arraytoFillhandleData(arraytoFill, responseData);
            result = true;
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

    //if (Senddata !== null) {
    //    $.ajax({
    //        type: "GET",
    //        contentType: contentType,
    //        accepts: "application/json",
    //        url: url,
    //        //traditional: true,   //must be tru for arrray to be send
    //        data: Senddata,
    //        dataType: dataType,
    //        async: isAsync,
    //        success: function (responseData) {
    //            arraytoFillhandleData(arraytoFill, responseData);
    //            result = true;
    //        },
    //        error: function (jqXHR, textStatus, errorThrown) {
    //            result = false;
    //            alert(Failmsg);
    //            //alert("error : " + jQuery.parseJSON(jqXHR.responseText));
    //            //alert("error : " + errorThrown);
    //            console.log(textStatus);
    //            console.log(errorThrown);
    //        }
    //    });
    //}
    //else {
    //    $.ajax({
    //        type: "GET",
    //        contentType: contentType,
    //        accepts: "application/json",
    //        url: url,
    //        //traditional: true,   //must be tru for arrray to be send
    //        //data: Senddata,
    //        dataType: dataType,
    //        async: isAsync,
    //        success: function (responseData) {
    //            arraytoFillhandleData(arraytoFill, responseData);
    //            result = true;
    //        },
    //        error: function (jqXHR, textStatus, errorThrown) {
    //            result = false;
    //            alert(Failmsg);
    //            //alert("error : " + jQuery.parseJSON(jqXHR.responseText));
    //            //alert("error : " + errorThrown);
    //            console.log(textStatus);
    //            console.log(errorThrown);
    //        }
    //    });
    //}
    return result;
}

//#endregion

//#region delete row
function DeleteRow(rowID, URL, ConfirmMsg, SuccessMsg, FailMsg, PageReload) {
    if (confirm(ConfirmMsg + rowID)) {
        var id = rowID;
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

//#region cancel Edit of row
function CancelEdit(cell, ConfirmMsg) {
    if (confirm(ConfirmMsg)) {
        // console.log(cell);
        cell.getRow().getCells().forEach(function (cell) {
            var oldVal = cell.getOldValue();

            if (oldVal !== null) {
                cell.restoreOldValue();
            }
        });
    }
};

//#endregion

//#region tool tip
function GetToolTip(column) {
    //column - column component
    var tooltip = column.getDefinition().title;
    if (column.getDefinition().headerToolTip !== null)
        tooltip = column.getDefinition().headerToolTip;
    //function should return a string for the header tooltip of false to hide the tooltip

    return tooltip;
};
//#endregion

//#region add row using + key

Tabulator.prototype.extendModule("keybindings", "actions", {
    "addNewRow": function () {
        var id = Math.floor((Math.random() * 10000) + 1) * -1;
        this.table.addRow({ iD: id });
    }
});
//#endregion

//#endregion

//#region save settings part

//if (document.getElementById("GridConfig") !== null)
//    document.getElementById("GridConfig").addEventListener("click", function () {
//        console.log('clicked');
//        var popwindow = this.getElementById("columnsconfig");
//        console.log(popwindow.style.display);
//        if (popwindow.style.display === "none") {
//            popwindow.style.display = "block";
//        } else {
//            popwindow.style.display = "none";
//        }
//    });

function hideColumn(grid, columnid) {
    //console.log(columnid);
    grid.toggleColumn(columnid);
};

function fillInColumns(grid, gridName) {
    //console.log(grid);
    // find table object for table with id of example-table
    //var table = Tabulator.prototype.findTable(gridName)[0];
    var chekcName = 'checkBundle' + gridName.replace("Grid", "");
    var ul = document.getElementById(chekcName);
    for (var i = 0; i < grid.columnManager.columns.length; i++) {
        var columndef = grid.columnManager.columns[i].definition;
        //console.log(columndef);
        var title = columndef.title;
        var field = columndef.field;
        if (field !== undefined) {
            var label = document.createElement('label');
            var t = document.createTextNode('  ' + title);

            var input = document.createElement('input');
            input.setAttribute("type", "checkbox");
            input.setAttribute("name", title);
            input.setAttribute("id", i);
            input.setAttribute("columnid", i);
            input.setAttribute("parent", grid);

            input.setAttribute('onclick', "hideColumn(" + gridName + ",'" + field + "') ;");

            label.setAttribute("class", "mvc-grid-column");
            if (columndef.visible === true)
                input.setAttribute("checked", "true");

            label.appendChild(input);
            label.appendChild(t);

            ul.appendChild(label);
        }
    };
    //ul.style.display = "none";
};
//#endregion

//#region validation summery messages
var validationFailed = (cell, value, validators) => {
    for (let i in validators) {
        if (!validators.hasOwnProperty(i)) continue;
        const validator = validators[i];
        $("#lblErrorMessage").text("Invalid input");
    }
};
//#endregion

//#region button formatters for columns
//custom formatter definition
var printIcon = function (cell, formatterParams, onRendered) { //plain text value
    return "<i class='fa fa-print fa-lg'></i>";
};

//custom formatter definition
var EditIcon = function (cell, formatterParams, onRendered) { //plain text value
    return "<i class='fa fa-pencil-square-o fa-lg'></i>";
};

//custom formatter definition
var DeleteIcon = function (cell, formatterParams, onRendered) { //plain text value
    //return "<i class='far fa-trash  fa-lg'></i>";
    //<i class="far fa-trash"></i>
    //<i class="fas fa-trash"></i>
    return "<img  src='/images/Iconmaterial-delete.svg' />";
};

//custom formatter definition
var CancelIcon = function (cell, formatterParams, onRendered) { //plain text value
    return "<i class='fa fa-times fa-lg'></i>";
};
//#endregion

//#region header menu to hide a column
//define row context menu
var headerMenu = [
    {
        label: "<i class='fas fa-eye-slash'></i> Hide Column",
        action: function (e, column) {
            column.hide();
        }
    },
    //{
    //    label: "<i class='fas fa-arrows-alt'></i> Move Column",
    //    action: function (e, column) {
    //        column.move("col");
    //    }
    //}
]
//#endregion

//#region date editors

//Create Date Editor
var dateEditor2 = function (cell, onRendered, success, cancel) {
    //cell - the cell component for the editable cell
    //onRendered - function to call when the editor has been rendered
    //success - function to call to pass the successfuly updated value to Tabulator
    //cancel - function to call to abort the edit and return to a normal cell

    //create and style input
    var cellValue = moment(cell.getValue(), "MM/DD/YYYY").format("YYYY-MM-DD"),
        input = document.createElement("input");

    //console.log('console');
    //console.log(cellValue);
    input.setAttribute("type", "date");

    input.style.padding = "4px";
    input.style.width = "100%";
    input.style.boxSizing = "border-box";

    input.value = cellValue;

    onRendered(function () {
        input.focus();
        input.style.height = "100%";
    });

    function onChange() {
        if (input.value !== cellValue) {
            success(moment(input.value, "MM-DD-YYYY").format("DD/MM/YYYY"));
        } else {
            cancel();
        }
    }

    //submit new value on blur or change
    input.addEventListener("change", onChange);
    input.addEventListener("blur", onChange);

    //submit new value on enter
    input.addEventListener("keydown", function (e) {
        if (e.keyCode === 13) {
            onChange();
        }

        if (e.keyCode === 27) {
            cancel();
        }
    });

    return input;
};

//usage as below
//in your column definition for the column
//{ title: "Birthday", field: "dob", editor: dateEditor }}
var dateEditor = function (cell, onRendered, success, cancel, editorParams) {
    //cell - the cell component for the editable cell
    //onRendered - function to call when the editor has been rendered
    //success - function to call to pass the successfuly updated value to Tabulator
    //cancel - function to call to abort the edit and return to a normal cell
    //editorParams - params object passed into the editorParams column definition property

    //testing part
    //console.log('date editor part');
    //console.log(cell);
    //console.log(cell.getValue());

    //create and style editor
    var editor = document.createElement("input");

    editor.setAttribute("type", "date");
    editor.setAttribute("class", "datepicker");
    //create and style input
    editor.style.padding = "3px";
    editor.style.width = "100%";
    editor.style.boxSizing = "border-box";

    //Set value of editor to the current value of the cell
    var FormattedDate = moment(cell.getValue(), "YYYY-MM-DD").format("YYYY-MM-DD");
    editor.value = FormattedDate;
    //editor.value = moment(cell.getValue(), "MM/DD/YYYY").format("YYYY-MM-DD")

    // console.log('FormattedDate');
    // console.log(cell.getValue());
    // console.log(FormattedDate);

    //set focus on the select box when the editor is selected (timeout allows for editor to be added to DOM)
    onRendered(function () {
        editor.focus();
        editor.style.css = "100%";
    });

    //when the value has been set, trigger the cell to update
    function successFunc() {
        success(moment(editor.value, "YYYY-MM-DD").format("YYYY/MM/DD"));
        //success(moment(editor.value, "YYYY-MM-DD").format("MM/DD/YYYY"));
    }

    editor.addEventListener("change", successFunc);
    editor.addEventListener("blur", successFunc);

    //return the editor element
    return editor;
};
//#endregion

//#region time editors

//usage as below
//in your column definition for the column
//{ title: "StartTime", field: "startTime", editor: timeEditor }}
var timeEditor = function (cell, onRendered, success, cancel, editorParams) {
    //cell - the cell component for the editable cell
    //onRendered - function to call when the editor has been rendered
    //success - function to call to pass the successfuly updated value to Tabulator
    //cancel - function to call to abort the edit and return to a normal cell
    //editorParams - params object passed into the editorParams column definition property

    //create and style editor
    var editor = document.createElement("input");

    editor.setAttribute("type", "time");
    editor.setAttribute("class", "time-picker");

    //editor.datetimepicker({ format: 'HH:mm' });

    //create and style input
    editor.style.padding = "3px";
    editor.style.width = "100%";
    editor.style.boxSizing = "border-box";

    //Set value of editor to the current value of the cell
    editor.value = moment(cell.getValue(), "HH:mm").format("HH:mm");

    //set focus on the select box when the editor is selected (timeout allows for editor to be added to DOM)
    onRendered(function () {
        editor.focus();
        editor.style.css = "100%";
    });

    //when the value has been set, trigger the cell to update
    function successFunc() {
        success(moment(editor.value, "HH:mm").format("HH:mm"));
    }

    editor.addEventListener("change", successFunc);
    editor.addEventListener("blur", successFunc);

    //return the editor element
    return editor;
};
//#endregion

//#region select2 editror
//editr oto use select2 for the select column type not built in select
//create custom editor
//usage as below
//in your column definition for the column
//{ title: "Select2", field: "lucky_no", align: "center", width: 300, editor: select2Editor , editorParams: { values: InvoiceToCustomerSelect } },
var select2Editort = function (cell, onRendered, success, cancel, editorParams) {
    //create input element to hold select
    var editor = document.createElement("select");
    PopulateSelect(editor, editorParams.values, true);

    onRendered(function () {
        var select_2 = $(editor);
        select_2.select2({
            placeholder: '-',
            allowClear: true
        });
        select_2.focus().select();
        //select_2.select2({
        //    theme: "classic",
        //    placeholder: 'Select',
        //    data: editorParams.values,
        //    minimumResultsForSearch: Infinity,
        //    width: 300,
        //    minimumInputLength: 0,
        //    allowClear: true
        //});

        select_2.on('change', function (e) {
            success(select_2.val());
            console.log('change');
        });

        select_2.on('blur', function (e) {
            cancel();
            console.log('change');
        });
    });

    //add editor to cell
    return editor;
};
//#endregion