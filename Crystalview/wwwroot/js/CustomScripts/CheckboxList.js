
(function () {
    $.fn.checkList = function (options) {
        var self = this,
            checkedItems = options.checkedItems ? options.checkedItems.slice() : [], //take a copy
            unCheckedItems = options.unCheckedItems ? options.unCheckedItems.slice() : [], //take a copy
            valuePath = options.valuePath,
            textPath = options.textPath,
            ShowInput = options.ShowInput
            ;

        this.addClass('list-group');

        $.each(checkedItems, function (key, item) {
            self.append(createListItem(item, true, valuePath, textPath));
        });

        $.each(unCheckedItems, function (key, item) {
            self.append(createListItem(item, false, valuePath, textPath));
        });

        this.addItem = function (item, isChecked) {
            if (isChecked) {
                checkedItems.push(item);
            } else {
                unCheckedItems.push(item);
            }
            self.append(createListItem(item, isChecked, valuePath, textPath));
        };
        this.getCheckedItems = function () {
            return checkedItems;
        };
        this.getUncheckedItems = function () {
            return unCheckedItems;
        };
        this.getCheckedCheckboxes = function () {
            return self.find('input:checkbox:checked');
        }
        this.getUnCheckedCheckboxes = function () {
            return self.find('input:checkbox:not(checked)');
        }
        return this;

        function createListItem(item, isChecked, valuePath, textPath) {
            return $(
                '<li class="list-group-item ' + (isChecked ? 'active' : '') + '">' +
                '	<label>' +
                '		<input type="checkbox" ' + (isChecked ? 'checked="checked" ' : '') +
                'value="' + item[valuePath] + '" ' +
                '		/> ' + item[textPath] +
                '	</label>' +
                '</li>')
                .change(function () {
                    var $el = $(this).closest('li').toggleClass('active'),
                        item = $el.data('item');

                    if (!$el.prop('checked')) {
                        unCheckedItems.splice(unCheckedItems.indexOf(item), 1);
                        checkedItems.push(item);
                    } else {
                        checkedItems.splice(checkedItems.indexOf(item), 1);
                        unCheckedItems.push(item);
                    }
                }).data('item', item);
        }
    }

    $.fn.checkListWithAddControl = function (options) {
        var ul, input;

        if (options.ShowInput) {
            this.html(
                '<ul></ul>' +
                '<div>' +
                '	<input type="text" class="form-control" placeholder="Add item">' +
                '	<span class="input-group-btn">' +
                '		<button class="btn btn-default" type="button">' +
                '			<i class="fas fa-plus"></i>' +
                '		</button>' +
                '	</span>' +
                '</div>');

            input = this.find('input');

            

            input.keypress(function (e) {
                var code = e.keyCode || e.which
                if (code == 13) {
                    onAdd();
                    e.preventDefault();
                    return false;
                }
            });

            this.find('button').click(onAdd);

            function onAdd() {
                var value = input.val();
                if (value && options.onAdd) {
                    options.onAdd(value, ul.addItem); //checkList.addItem
                }
                input.val('');
            }
        }
        else
            this.html(
                '<ul></ul>');

        ul = this.find('ul').checkList(options);

        this.getCheckedItems = ul.getCheckedItems;
        this.getUnCheckedItems = ul.getUncheckedItems;
        this.getCheckedCheckboxes = ul.getCheckedCheckboxes;
        this.getUnCheckedCheckboxes = ul.getUnCheckedCheckboxes;
        return this;
    }
})();