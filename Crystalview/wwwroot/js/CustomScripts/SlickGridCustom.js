//#region slick grid stuff

//#region validators
// validator , make it required
function requiredFieldValidator(value) {
    if (value === null || value === undefined || !value.length) {
        return { valid: false, msg: "This is a required field" };
    } else {
        return { valid: true, msg: null };
    }
}

//#endregion


//#region formatters
//formatters

// Capitalize number of chars defined by user
// neeed NumOfChar = xxx in the column definition
function CustomUpperFormatter(row, cell, value, columnDef, dataContext) {
    //console.debug(columnDef.NumOfChar);
    var nbChar = columnDef.NumOfChar;
    var output = value.substring(0, nbChar).toUpperCase() + value.substring(nbChar);

    return value ? output : '';
}

// Capitalize first char of each word
function TitleCaseFormatter(row, cell, value, columnDef, dataContext) {
    var output = value.replace(/\w\S*/g, function (txt) { return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase(); });

    return value ? output : '';
}

//date one 
function DateFormatter(rowIndex, cell, value, columnDef, grid, dataProvider) {
    if (value === null || value === "") { return "-"; }
    return moment.utc(value).format('ddd, D MMM YYYY');
}

function formatter(row, cell, value, columnDef, dataContext) {
    return value;
}

function FloatFormatter(row, cell, value, columnDef, dataContext) {

    var nDecimals = 2;

    if (typeof columnDef.editorFixedDecimalPlaces === 'number') {
        nDecimals = columnDef.editorFixedDecimalPlaces;
    }

    return Number(value).toFixed(nDecimals);
}


//Now define your buttonFormatter function
function buttonFormatter(row, cell, value, columnDef, dataContext) {
    //var key = Object.keys(dataContext)[0];
    if (dataContext === undefined)
        return;
    var id = Object.values(dataContext)[0];
    var button = "<button title='" + columnDef.toolTip + "' class='grid-button btn btn-primary btn-xs' type='button' id='" + id + "' >" + columnDef.title + "</button>";
    //the id is so that you can identify the row when the particular button is clicked
    return button || '';
    //Now the row will display your button
}

// buttonFormatter to show button i na column
//use title as text 
// use tool tip as tool tip
function buttonConditionFormatter(row, cell, value, columnDef, dataContext) {
    //var key = Object.keys(dataContext)[0];

    if (dataContext === undefined)
        return;
    var id = Object.values(dataContext)[0];

    //console.log(id + '|' + columnDef.toolTip + '|' + columnDef.Condition);
    if (columnDef.Condition)
        var button = "<button title='" + columnDef.toolTip + "' class='grid-button btn btn-primary btn-xs' type='button' id='" + id + "' >" + columnDef.title + "</button>";
    //the id is so that you can identify the row when the particular button is clicked
    return button || '';
    //Now the row will display your button
}


/// button to be shows on a speciifc conditions only
// need the use same as button 
// extra part condition = xxxx
// then we compare value to xxxx and only show 
// button if compoare is true 
function buttonTrueFormatter(row, cell, value, columnDef, dataContext) {
    //var key = Object.keys(dataContext)[0];
    //console.log(value);
    if (dataContext === undefined)
        return;
    var id = Object.values(dataContext)[0];

    //console.log(id + '|' + columnDef.toolTip + '|' + columnDef.Condition);
    if (value === columnDef.Condition)
        var button = "<button title='" + columnDef.toolTip + "' class='grid-button btn btn-primary btn-xs' type='button' id='" + id + "'  >" + columnDef.title + "</button>";
    //the id is so that you can identify the row when the particular button is clicked
    return button || '';
    //Now the row will display your button
}


// show url in column
//need a Target option to decide target
// use TargetURL to define path of url
// use title to show text

/// usage sample
// { id: "Prices", name: "@Localizer["Prices"]", toolTip: "Prices" ,title : "@Localizer["Show Prices"]", Target : "_self",   formatter : URLFormatter , TargetURL : "/Club/clacTrainingGroups/Edit/"   ,cssClass: "cell-title", sortable: false},
function URLFormatter(row, cell, value, columnDef, dataContext) {

    if (dataContext === undefined)
        return;
    console.log(dataContext);
    console.log(Object.values(dataContext)[0]);
    var Target = columnDef.Target;
    if (Target === undefined)
        Target = "_blank";
    var id = Object.values(dataContext)[0];
    s = "<a data-modal='' title='" + columnDef.toolTip + "' data-id='" + id + "' href='" + columnDef.TargetURL + "/" + id + "' target=" + Target + ">" + columnDef.title + "</a>";
    return s;
};


function CurrencyFormatter(row, cell, value, columnDef, dataContext) {

    if (value === null || value === '' || !(value > 0)) {

        return '' + Number();

    } else {

        return '' + Number(value).toFixed(2);

    }

}

/// foramt the dsate as dd/mm/yyyy
function ukDateFormatter(row, cell, value, columnDef, dataContext) {
    return (value.getDate()) + "/" + value.getMonth() + "/" + value.getFullYear();
}

// show other column value in this column
//used t oshow name in a column of ID
//usage 
//     field: "busID"
//    , formatter: NameColumnFormatter
//    , NameColumn: "busIDName"  -- will show column busidname not busid in this one 
// must have an array of values in the foramt (id , name)

function NameColumnFormatter(row, cell, value, columnDef, dataContext) {

    var NameValue;
    if (dataContext !== undefined)
        NameValue = dataContext[columnDef.NameColumn]; //Object.values(dataContext)[index];
    return NameValue || '------';
    //}
}

function Select2Formatter(row, cell, value, columnDef, dataContext) {
    // console.log(dataContext);
    //  console.log(columnDef);
    return columnDef.dataSource[value] || '------';
}

// take an ajax function and get the name from thois function
// use NameURL to get data ,send id and get name 
// server function must have id as parameter 
// must have NameURL: "/Inventory/ivItemDetails/GetItemsName"

function getNamebyIDFormatter(row, cell, value, columnDef, dataContext) {


    var returnValue;
    if (value !== "") {

        var SendData = { id: value };
        $.ajax({
            type: "GET",
            url: columnDef.NameURL,
            data: SendData,
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            success: function (responseData) {
                returnValue = responseData;
            }
        });

        return returnValue || '======';
    }


    return returnValue || '------';
}


//#endregion

//#region editors

//#region select editor
function PopulateSelect(select, dataSource, addBlank) {
    var index, len, newOption;
    if (addBlank) { select.appendChild(new Option('', '')); }
    console.log('inside poputale');
    $.each(dataSource, function (value, text) {
        //console.log('text is ' + text);
        newOption = new Option(text, value);
        select.appendChild(newOption);
    });
}

function Select2Editor(args) {
    var $input;
    var defaultValue;
    var scope = this;
    var calendarOpen = false;

    this.keyCaptureList = [Slick.keyCode.UP, Slick.keyCode.DOWN, Slick.keyCode.ENTER];

    this.init = function () {
        $input = $('<select class="control-in-grid" ></select>');
        $input.width(args.container.clientWidth + 3);
        PopulateSelect($input[0], args.column.dataSource, true);

        $input.appendTo(args.container);
        $input.focus().select();

        $input.select2({
            placeholder: '-',
            allowClear: true
        });
    };

    this.destroy = function () {
        $input.select2('destroy');
        $input.remove();
    };

    this.show = function () {
    };

    this.hide = function () {
        $input.select2('results_hide');
    };

    this.position = function (position) {
    };

    this.focus = function () {
        $input.select2('input_focus');
    };

    this.loadValue = function (item) {
        defaultValue = item[args.column.field];
        $input.val(defaultValue);
        $input[0].defaultValue = defaultValue;
        $input.trigger("change.select2");
    };

    this.serializeValue = function () {
        return $input.val();
    };

    this.applyValue = function (item, state) {
        item[args.column.field] = state;
    };

    this.isValueChanged = function () {
        return ((!($input.val() === "" && defaultValue === null)) && ($input.val() !== defaultValue));
    };

    this.validate = function () {
        return {
            valid: true,
            msg: null
        };
    };

    this.getInputEl = function () {
        return $input;
    };

    this.init();
}


//#endregion


//#region multi select editor using checkboxes

/*
   * An example of a "Multi-Select Dropdown" editor.
   * The UI is added onto document BODY and .position(), .show() and .hide() are implemented.
   * KeyDown events are also handled to provide handling for Tab, Shift-Tab, Esc and Ctrl-Enter.
   */
function MultiSelectDropdownEditor(args) {
    var $input, $wrapper, $checkBoxInput, selectedchkBoxArray = [];
    var defaultValue;
    var scope = this;
    // check scope get this value

    var chkBoxListData = getChkBoxDataList(args);
    var chkBoxAllValues = chkBoxListData.AllValues;
    chkBoxAllValues.sort();
    var selectedchkBox = chkBoxListData.SelectedValues;
    if (!(selectedchkBox === undefined || selectedchkBox === '')) {
        if (selectedchkBox.length > 0) selectedchkBoxArray = selectedchkBox.split(";");
    }
    this.init = function () {

        if (chkBoxAllValues.length !== 0) {
            var $container = $("body");
            $wrapper = $("<DIV style='z-index:10000;position:absolute;background:white;padding:5px;border:3px solid gray; -moz-border-radius:10px; border-radius:10px;'/>")
                .appendTo($container);

            for (var i = 0; i < chkBoxAllValues.length; i++) {
                if (!(selectedchkBoxArray === undefined || selectedchkBoxArray === '')) {
                    if (selectedchkBoxArray.length > 0 && selectedchkBoxArray.indexOf(chkBoxAllValues[i]) > -1) {
                        $checkBoxInput = $("<input class='chkBox' type='checkbox' name='" + chkBoxAllValues[i] + "' id='chkBox_" + i + "' checked='checked'/>" + chkBoxAllValues[i] + "<br />");
                    }
                    else
                        $checkBoxInput = $("<input class='chkBox' type='checkbox' name='" + chkBoxAllValues[i] + "' id='chkBox_" + i + "'/>" + chkBoxAllValues[i] + "<br />");
                }
                else
                    $checkBoxInput = $("<input class='chkBox' type='checkbox' name='" + chkBoxAllValues[i] + "' id='chkBox_" + i + "'/>" + chkBoxAllValues[i] + "<br />");
                $wrapper.append($checkBoxInput);
            }
            $wrapper.append("<br/><br/>");
            $input = $("<TEXTAREA style='display:none;' hidefocus rows=25 style='background:white;width:150px;height:100px;border:1px solid;outline:0'>")
                .appendTo($wrapper);
            $("<DIV style='text-align:right'><BUTTON>Save</BUTTON><BUTTON>Cancel</BUTTON></DIV>")
                .appendTo($wrapper);
            $wrapper.find("button:first").on("click", this.save);
            $wrapper.find("button:last").on("click", this.cancel);
            $input.on("keydown", this.handleKeyDown);
        }
        else {

            alert("Dropdown list is empty. Kindly provide data for this dropdown list");
        }
        scope.position(args.position);
        $input.focus().select();
        $('input[type="checkbox"]').change(function () {
            var name = $(this).prop('name');
            var chkboxId = $(this).prop('id');
            var check = $(this).prop('checked');
            var currentValue = $input.val();
            var allSelectedValues = '';
            if (check) {

                $('input[type="checkbox"]').each(function () {
                    var isChecked = $(this).prop('checked');
                    var name = $(this).prop('name');
                    var currentChekBoxId = $(this).prop('id');
                    if (isChecked) {
                        if (allSelectedValues.length === 0) allSelectedValues = name;
                        else allSelectedValues = allSelectedValues + ";" + name;
                    }
                });
                $input.val('');
                $input.val(allSelectedValues);
            }
            else {

                $('input[type="checkbox"]').each(function () {
                    var isChecked = $(this).prop('checked');

                    var name = $(this).prop('name');
                    var currentChekBoxId = $(this).prop('id');
                    if (isChecked) {
                        if (allSelectedValues.length === 0) allSelectedValues = name;
                        else allSelectedValues = allSelectedValues + ";" + name;
                    }
                });
                $input.val('');
                $input.val(allSelectedValues);
            }
        });
        var allSelValues = '';
        $('input[type="checkbox"]').each(function () {
            var isChecked = $(this).prop('checked');

            var name = $(this).prop('name');
            var currentChekBoxId = $(this).prop('id');
            if (isChecked) {
                if (allSelValues.length === 0) allSelValues = name;
                else allSelValues = allSelValues + ";" + name;
            }
        });
        $input.val('');
        $input.val(allSelValues);
    };
    this.handleKeyDown = function (e) {
        if (e.which === $.ui.keyCode.ENTER && e.ctrlKey) {
            scope.save();
        } else if (e.which === $.ui.keyCode.ESCAPE) {
            e.preventDefault();
            scope.cancel();
        } else if (e.which === $.ui.keyCode.TAB && e.shiftKey) {
            e.preventDefault();
            args.grid.navigatePrev();
        } else if (e.which === $.ui.keyCode.TAB) {
            e.preventDefault();
            args.grid.navigateNext();
        }
    };
    this.save = function () {
        args.commitChanges();
        $wrapper.hide();
    };
    this.cancel = function () {
        $input.val(defaultValue);
        args.cancelChanges();
    };
    this.hide = function () {
        $wrapper.hide();
    };
    this.show = function () {
        $wrapper.show();
    };
    this.position = function (position) {
        $wrapper
            .css("top", position.top - 5)
            .css("left", position.left - 5)
    };
    this.destroy = function () {
        $wrapper.remove();
    };
    this.focus = function () {
        $input.focus();
    };
    this.loadValue = function (item) {
        $input.val(defaultValue = item[args.column.field]);
    };
    this.serializeValue = function () {
        return $input.val();
    };
    this.applyValue = function (item, state) {
        item[args.column.field] = state;
    };
    this.isValueChanged = function () {
        return (!($input.val() === "" && defaultValue === null)) && ($input.val() !== defaultValue);
    };
    this.validate = function () {
        if (args.column.validator) {
            var validationResults = args.column.validator($input.val());
            if (!validationResults.valid) {
                return validationResults;
            }
        }
        return {
            valid: true,
            msg: null
        };
    };
    this.init();
}

//how to use it 
/*
    * An example of a "Multi-Select Dropdown" editor.
    * "DropdownListData" is an array to store all the checkbox options required for the dropdowwn multi-select field.
    */
var DropdownListData = ["Afghanistan", "Bangladesh", "Canada", "China", "England", "India", "Japan", "United Kingdom", "United States", "France"];
function getChkBoxDataList(args) {
    var countryLeadsData = [];
    // here 'country' is column id
    if (args.column.id === 'country') {
        var countryData =
        {
            "AllValues": DropdownListData,
            "SelectedValues": args.item.country
            /*
             * args.item.country is used to read the value of the field "country" of a particular row.
             * This "SelectedValues" array generates prepopulated data if you want to retrieve data from your data base.
             * Lets for emxample for row no 1 : you have 2 countries, this field captures the name of these countries(should be seprated by semicolon) and mark the checkboxes of those country as checked.
             */
        }
        return countryData;
    }
}

//#endregion


//#region static options editor
//setup option in the column difinition ands use in select
//usage as below
// {id:"color", name:"Color", field:"Color",  
//options: "Red,Green,Blue,Black,White", editor: OptionsCellEditor},
function OptionCellEditor(args) {
    var selects;
    var $select;
    var d;
    var divend;
    var defaultValue;
    var scope = this;

    this.init = function () {
        console.log(args.column.options);
        if (args.column.options) {
            opt_values = args.column.options.split(',');
        } else {
            opt_values = "yes,no".split(',');
        }
        option_str = ""

        $.each(opt_values, function (index, value) {
            option_str += "<OPTION value='" + value + "'>" + value + "</OPTION>";
        });
        // d = "<div class='select-editable'>";
        // divend = "<input type='text' name='format' value='' />";
        selects = "<SELECT id='Mobility' tabIndex='0' class='editor-select'>" + option_str + "</SELECT>";
        //$select = $(d + divend + selects)
        $select = $(selects)
        $select.appendTo(args.container);
        $select.focus();
        document.getElementById("Mobility").selectedIndex = 2;
    };

    this.destroy = function () {
        $select.remove();
    };

    this.focus = function () {
        $select.focus();
    };

    this.loadValue = function (item) {
        defaultValue = item[args.column.field];
        $select.val(defaultValue);
    };

    this.serializeValue = function () {
        if (args.column.options) {
            return $select.val();
        } else {
            return ($select.val() === "yes");
        }
    };

    this.applyValue = function (item, state) {
        item[args.column.field] = state;
    };

    this.isValueChanged = function () {
        return ($select.val() !== defaultValue);
    };

    this.validate = function () {
        return {
            valid: true,
            msg: null
        };
    };
    this.init();
}
//#endregion

//#region dynamic slelection based on other column value

// a select option that get the dropdown filled based on otehr column
//usage 
///, editor: DynamicSelectCellEditor
// , URL: "/FleetControl/fcTripSchedule/getfcBusTripSelect"
// , ParentColumn: "tripID"
// and in controller 
// the funtion parameter m,ust be named id 
//public JsonResult getfcBusTripSelect(int tripID)
function DynamicSelectCellEditor(args) {

    // 2: if data needs to be fetched from the server
    var editor = new Select2Editor(args),
        $select = editor.getInputEl();

    $select.html("<option>Loading...</option>");
    var parentid = args.item[args.column.ParentColumn];
    //var ParentColumn = args.column.ParentColumn;
    //cannot get the parameter name here ,so must use
    // static name for now 
    var SendData = { id: parentid };
    $.ajax({
        type: "GET",
        url: args.column.URL,
        data: SendData,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (responseData) {
            var DirectionSelect = {};
            var option_str = "<option>----</option>";
            responseData.forEach(function (entry, index) {
                //DirectionSelect[entry.value] = entry.text;
                option_str += "<OPTION value='" + entry.value + "'>" + entry.text + "</OPTION>";
            });
            $select.html(option_str);
            // PopulateSelect(editor.select2, responseData, true);
        }
    });

    return editor;
}



//#endregion

//#region numeric editor
/***
 * Contains Numeric(Decimal) SlickGrid editors.
 * @module Editors
 * @namespace Slick
 */

(function ($) {
    // register namespace
    $.extend(true, window, {
        "Slick": {
            "Editors": {
                "Numeric": NumericEditor
            }
        }
    });

    function NumericEditor(args) {
        var $input;
        var defaultValue = "";
        var scope = this;
        var lang = "";
        var numberInputCount = 0;

        this.getLang = function () {
            try {
                return (navigator.browserLanguage || navigator.language || navigator.userLanguage).substr(0, 2)
            } catch (e) {
                return undefined;
            }
        }

        this.init = function () {
            numberInputCount = 0;
            lang = this.getLang();

            $input = $("<INPUT type='text' class='editor-text' />")
                .appendTo(args.container)
                .bind("keydown", function (e) {
                    if (!(e.keyCode === $.ui.keyCode.LEFT || e.keyCode === $.ui.keyCode.RIGHT ||
                        e.keyCode === $.ui.keyCode.UP || e.keyCode === $.ui.keyCode.DOWN ||
                        e.keyCode === $.ui.keyCode.ENTER)) {
                        numberInputCount += 1;
                    }
                })
                .focus()
                .select();

        };

        this.destroy = function () {
            $input.remove();
        };

        this.focus = function () {
            $input.focus();
        };

        this.loadValue = function (item) {
            defaultValue = item[args.column.field];
            $input.val(defaultValue);
            $input[0].defaultValue = defaultValue;
            $input.select();
        };

        this.serializeValue = function () {
            return ($input.val() === "") ? "" : parseFloat($input.val());
        };

        this.applyValue = function (item, state) {
            item[args.column.field] = state;
        };

        this.isValueChanged = function () {
            return numberInputCount > 0;
        };

        this.chooseMsg = function (msgs) {
            var msg = "";
            var dfMsg = "";
            for (var lg in msgs) {
                if (lg === lang) {
                    msg = msgs[lg];
                } else if (lg === "default") {
                    dfMsg = msgs[lg];
                }
            }

            if (msg === "" && dfMsg !== "") {
                msg = dfMsg;
            }

            return msg;
        }

        this.validate = function () {
            if ($input.val() !== "") {
                if (isNaN($input.val())) {
                    return {
                        valid: false,
                        msg: this.chooseMsg({ "ja": "Please enter a numeric value", "default": "Please enter a number" })
                    };
                }
            }

            return {
                valid: true,
                msg: null
            };
        };

        this.init();
    }
})(jQuery);

//#endregion

//#region mututal exclusive editor ,



// like in the case of
//debit and credit ,user musty enter only one not the 2
// need some date liek
// MututalField ===> other field that cannot have value at the same time
// ErrorMsg ==> messgaer ot be shown in case of error
function MututalExclusiveNumericEditor(args) {

    var $input;
    var defaultValue = "";
    var scope = this;
    var lang = "";
    var numberInputCount = 0;
    this.getLang = function () {
        try {
            return (navigator.browserLanguage || navigator.language || navigator.userLanguage).substr(0, 2)
        } catch (e) {
            return undefined;
        }
    }
    args.column.AutoTooltips = false;

    this.init = function () {
        numberInputCount = 0;
        lang = this.getLang();

        $input = $("<INPUT type='text' class='editor-text' />")
            .appendTo(args.container)
            .bind("keydown", function (e) {
                if (!(e.keyCode === $.ui.keyCode.LEFT || e.keyCode === $.ui.keyCode.RIGHT ||
                    e.keyCode === $.ui.keyCode.UP || e.keyCode === $.ui.keyCode.DOWN ||
                    e.keyCode === $.ui.keyCode.ENTER)) {
                    numberInputCount += 1;
                }
            })
            .focus()
            .select();

        title = "";

    };

    this.handleKeyDown = function (e) {
        if (e.keyCode === $.ui.keyCode.LEFT || e.keyCode === $.ui.keyCode.RIGHT || e.keyCode === $.ui.keyCode.TAB) {
            e.stopImmediatePropagation();
        }
    };

    this.destroy = function () {
        $input.remove();
        $(args.container).empty();
    };

    this.focus = function () {
        $input.focus();
    };

    this.serializeValue = function () {
        return ($input.val() === "") ? "" : parseFloat($input.val());
    };

    this.applyValue = function (item, state) {
        item[args.column.field] = state;

    };

    this.loadValue = function (item) {
        defaultValue = item[args.column.field];
        $input.val(defaultValue);
        $input[0].defaultValue = defaultValue;
        $input.select();

    };

    this.isValueChanged = function () {
        return args.item[args.column.Field1] !== parseFloat($input.val());
    };

    this.validate = function () {

        if ((parseFloat(args.item[args.column.MututalField], 10) !== 0)
            && (parseFloat($input.val(), 10) !== 0)

        ) {

            alert(args.column.ErrorMsg);
            return { valid: false, msg: "Cannot have values in both columns" };
        }

        return { valid: true, msg: null };
    };

    this.init();
}
//#endregion

//#region preaprae lookup search editor for items
// to have an input for id and a search inpout to open search page 
// and return the chosen code

function SearchforEditor(args) {
    var $searchme, $input;
    var defaultValue;
    var newLine = "\n";
    var scope = this;
    this.init = function () {

        args.column.AutoTooltips = false;
        // prepare controls part

        //#region prepare control part with multi parts
        $(args.container).append("<div class=\"input-group input-group-sm\">");
        $input = $(" <input id=\"txt" + args.column.field + "\" class=\"form-control \" type=\"text\" placeholder=\"" + args.column.name + " \" />");
        $input.appendTo(args.container);
        // $(args.container).append("<br />");
        $(args.container).append(" <label id=\"lbl" + args.column.field + "Name\" class=\"help-block \"></label>");
        $searchme = $(
            " <div class=\"mvc-lookup\" data-dialog=\"MvcLookupDialog\" data-filters=\"\" data-for=\"ddl" + args.column.field + "\" data-multi=\"false\" data-order=\"Asc\" data-page=\"0\" data-readonly=\"false\" data-rows=\"5\" data-search=\"\" data-sort=\"ID\" data-title=\"SearchPageTitle.en-US\""
            + "     data-url=\"" + args.column.URL + "\">"
            + "     <div class=\"mvc-lookup-values\" data-for=\"ddl" + args.column.field + "\">"
            + "         <input class=\"mvc-lookup-value\" id=\"ddl" + args.column.field + "\" name=\"ddl" + args.column.field + "\" type=\"hidden\" value=\"\" />"
            + "      </div>"
            + "     <div class=\"mvc-lookup-control\" data-for=\"ddl" + args.column.field + "\">"
            + "          <input   class=\"mvc-lookup-input\" />"
            + "          <div class=\"mvc-lookup-control-loader\"> </div>"
            + "      </div>"
            + "      <div class=\"mvc-lookup-browse\" data-for=\"ddl" + args.column.field + "\">"
            + "          <i class=\"mvc-lookup-icon\"></i>"
            + "      </div>"
            + "   </div>"
            + " </div>"

        );
        $searchme.appendTo(args.container);

        var strjavapart = (
            "  <script language=\"JavaScript\">"
            + "        new MvcLookup(document.querySelector('#" + args.column.field + "'), {" + newLine
            + "            events: {" + newLine
            + "                select: function (data, triggerChanges) {" + newLine
            + "                 //   alert(data[0]['Name']);" + newLine
            + "                 //   alert(data[0]['ID']);" + newLine
            + "                    $('#lbl" + args.column.field + "').val(data.length ? data[0]['Name'] : '');" + newLine
            + "                      $('#txt" + args.column.field + "').val(data[0]['ID'] != null ? data[0]['ID'] : '');" + newLine
            + "        $('#lbltxt" + args.column.field + "Name').text(data[0]['Name'] != null ? data[0]['Name'] : 'nothing');" + newLine
            + "        data[0].Label = data[0].Name;" + newLine
            + "                }" + newLine
            + "            }" + newLine
            + "        });" + newLine
            + "        $(\"#txt" + args.column.field + "\").blur(function (e) {" + newLine

            + "            if ($(\"#" + args.column.field + "\").val() != \"\") {                " + newLine
            + "                //$(\"#lbl" + args.column.field + "Name\").text('helooo');" + newLine
            + "                var ID = $(\"#txt" + args.column.field + "\").val();" + newLine
            // + " alert(ID);" + newLine
            + "                $.ajax({" + newLine
            + "                    type: \"GET\"," + newLine
            + "                    contentType: \"application/json; charset=utf-8\"," + newLine
            + "                    url: \"" + args.column.NameURL + "\", //will generate erro t ochange it to search table name" + newLine
            + "                    data: { ID: ID }," + newLine
            + "                    dataType: \"json\"," + newLine
            + "                    success: function (data) {" + newLine
            + "                        $(\"#lbl" + args.column.field + "Name\").text(data);" + newLine
            + "                         $(\"#ddl" + args.column.field + "\").text(data);" + newLine
            + "                    }," + newLine
            + "                    error: function (err) {" + newLine
            + "                        alert(\"error : \" + err);" + newLine
            + "                    }" + newLine
            + "                });" + newLine
            + "            }" + newLine
            + "            return false;" + newLine
            + "        });" + newLine
            + " <\/script>"
        )
        $(args.container).append(strjavapart);
        //#endregion


        $searchme.on("keydown", scope.handleKeyDown);

        // console.log(args.container);
        new MvcLookup(document.querySelector('.mvc-lookup'));
        scope.focus();
    };
    this.handleKeyDown = function (e) {
        if (e.keyCode === $.ui.keyCode.LEFT || e.keyCode === $.ui.keyCode.RIGHT || e.keyCode === $.ui.keyCode.TAB) {
            e.stopImmediatePropagation();
        }
    };
    this.destroy = function () {
        //$searchme.mvclookup('destroy');
        $searchme.remove();
        $(args.container).empty();
    };
    this.focus = function () {
        $input.focus();
        $searchme.focus();
    };
    this.serializeValue = function () {
        return $input.val();
    };
    this.applyValue = function (item, state) {
        item[args.column.field] = state;

    };
    this.loadValue = function (item) {
        defaultValue = item[args.column.field];
        $input.val(defaultValue);

    };
    this.isValueChanged = function () {
        return ((!($input.val() === "" && defaultValue === null)) && ($input.val() !== defaultValue));
    };
    this.validate = function () {
        // no validation for now
        //if (isNaN(parseInt($from.val(), 10)) || isNaN(parseInt($to.val(), 10))) {
        //    return { valid: false, msg: "Please type in valid numbers." };
        //}
        //if (parseInt($from.val(), 10) > parseInt($to.val(), 10)) {
        //    return { valid: false, msg: "'from' cannot be greater than 'to'" };
        //}
        return { valid: true, msg: null };
    };
    this.init();
}
//#endregion

//#endregion

//#region auto resize p[rocess
// define some minimum height/width/padding before resizing
var DATAGRID_MIN_HEIGHT = 180;
var DATAGRID_MIN_WIDTH = 300;
var DATAGRID_BOTTOM_PADDING = 20;

///** Attach an auto resize trigger on the datagrid, if that is enable then it will resize itself to the available space
// * Options: we could also provide a % factor to resize on each height/width independently
// */
function attachAutoResizeDataGrid(grid, gridId, gridContainerId) {
    var gridDomElm = $('#' + gridId);
    if (!gridDomElm || typeof gridDomElm.offset() === "undefined") {
        // if we can't find the grid to resize, return without attaching anything
        return null;
    }

    //-- 1st resize the datagrid size on first load (because the onResize is not triggered on first page load)
    resizeToFitBrowserWindow(grid, gridId, gridContainerId);

    //-- 2nd attach a trigger on the Window DOM element, so that it happens also when resizing after first load
    $(window).on("resize", function () {
        // for some yet unknown reason, calling the resize twice removes any stuttering/flickering when changing the height and makes it much smoother
        resizeToFitBrowserWindow(grid, gridId, gridContainerId);
        resizeToFitBrowserWindow(grid, gridId, gridContainerId);
    });

    // in a SPA (Single Page App) environment you SHOULD also call the destroyAutoResize()
}

//* destroy the resizer when user leaves the page */
function destroyAutoResize() {
    $(window).trigger('resize').off('resize');
}

///**
//* Private function, calculate the datagrid new height/width from the available space, also consider that a % factor might be applied to calculation
//* object gridOptions
//*/
function calculateGridNewDimensions(gridId, gridContainerId) {
    var availableHeight = $(window).height() - $('#' + gridId).offset().top - DATAGRID_BOTTOM_PADDING;
    var availableWidth = $('#' + gridContainerId).width();

    var newHeight = availableHeight;
    var newWidth = availableWidth;

    // we want to keep a minimum datagrid size, apply these minimum if required
    if (newHeight < DATAGRID_MIN_HEIGHT) {
        newHeight = DATAGRID_MIN_HEIGHT;
    }
    if (newWidth < DATAGRID_MIN_WIDTH) {
        newWidth = DATAGRID_MIN_WIDTH;
    }

    return {
        height: newHeight,
        width: newWidth
    };
}

//** resize the datagrid to fit the browser height & width */
function resizeToFitBrowserWindow(grid, gridId, gridContainerId) {
    // calculate new available sizes but with minimum height of 220px
    var newSizes = calculateGridNewDimensions(gridId, gridContainerId);

    if (newSizes) {
        // apply these new height/width to the datagrid
        $('#' + gridId).height(newSizes.height);
        $('#' + gridId).width(newSizes.width);

        // resize the slickgrid canvas on all browser except some IE versions
        // exclude all IE below IE11
        if (new RegExp('MSIE [6-8]').exec(navigator.userAgent) === null && grid) {
            grid.resizeCanvas();
        }
    }
}


//#endregion




//#endregion