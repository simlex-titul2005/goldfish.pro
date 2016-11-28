/// <reference path="../jquery.d.ts" />
/// <reference path="../bootstrap.d.ts" />
var SxGridView = (function () {
    function SxGridView(gridContainer, callback) {
        var _this = this;
        if (callback === void 0) { callback = null; }
        this._spinner = $("<i class=\"fa fa-spinner fa-spin\"></i>");
        this.getData = function (query) {
            var self = _this;
            $.ajax({
                method: "post",
                url: self._dataAjaxUrl,
                data: query,
                success: function (data, status, xhr) {
                    self._container.html(data);
                    if (_this._selectedRows.length > 0) {
                        _this.selectCheckboxes();
                    }
                }
            });
        };
        this.getCurrentPage = function () {
            return parseInt(_this._container.find(".sx-gv__pager li.active a").attr("data-page"), 0);
        };
        this.fillQueryFilters = function (query) {
            $(".sx-gv__filter-row input").each(function (i, e) {
                var input = $(e);
                var name = input.attr("name");
                var value = input.val();
                if (value !== "") {
                    query.filterModel[name] = value;
                }
            });
        };
        this.fillQueryOrders = function (query) {
            var arrow = _this._container.find(".sx-gv__sort-arow").first();
            if (arrow.length === 0) {
                return;
            }
            var dir = arrow.data("sort-direction");
            var fieldName = arrow.closest("th").attr("data-field-name");
            query.order = new SxGridViewOrderItem(fieldName, dir);
        };
        this.checkSelectAllCheckbox = function () {
            var rows = _this._container.find(".sx-gv__row");
            var count = 0;
            rows.each(function (i, e) {
                var existIndex = $.inArray($(e).attr("data-row-id"), _this._selectedRows);
                if (existIndex > -1) {
                    count++;
                }
            });
            _this._container.find(".sx-gv__select-all-chbx").prop("checked", count === rows.length);
        };
        this.selectCheckboxes = function () {
            _this._container.find("tr[data-row-id]").each(function (i, e) {
                var tr = $(e);
                var rowId = tr.attr("data-row-id");
                var existIndex = $.inArray(rowId, _this._selectedRows);
                if (existIndex > -1) {
                    _this.modifySelectedList(rowId, true);
                    tr.find(".sx-gv__select-chbx").prop("checked", true);
                }
            });
            _this.checkSelectAllCheckbox();
            console.log(_this._selectedRows);
        };
        this._selectedRows = new Array();
        this._container = $(gridContainer);
        this._grid = this._container.find(".sx-gv");
        this._callback = callback;
        this._dataAjaxUrl = this._grid.attr("data-ajax-url");
        // pager
        this._container.on("click", ".sx-gv__pager li:not('.active')", function (e) {
            var item = $(e.target);
            var page;
            page = parseInt(item.attr("data-page"), 0);
            item.prepend(_this._spinner);
            var query = new SxGridViewQuery();
            query.page = page;
            _this.fillQueryFilters(query);
            _this.fillQueryOrders(query);
            _this.getData(query);
        });
        // click thead th
        this._container.on("click", "th", function (e) {
            var rowsCount = _this._container.find(".sx-gv__row").length;
            if (rowsCount === 0) {
                return;
            }
            var th = $(e.currentTarget);
            var enableSorting = th.attr("data-enable-sorting") !== "false";
            if (!th.hasClass("sx-gv_first-column") && enableSorting) {
                var fieldName = th.attr("data-field-name");
                var arrow = th.find(".sx-gv__sort-arow");
                var direction = "Asc";
                if (arrow.length === 1) {
                    var dir = arrow.data("sort-direction");
                    if (dir === "Asc") {
                        direction = "Desc";
                    }
                }
                var query = new SxGridViewQuery();
                query.page = _this.getCurrentPage();
                _this.fillQueryFilters(query);
                query.order = new SxGridViewOrderItem(fieldName, direction);
                th.prepend(_this._spinner);
                _this.getData(query);
            }
        });
        // delete butttons
        this._container.on("click", ".sx-gv__delete-btn", function (e) {
            var btn = $(e.currentTarget);
            var url = btn.attr("data-url");
            var confirmMessage = btn.attr("data-del-conf-mes");
            var confirmCaption = btn.attr("data-del-conf-caption");
            var modal = $("#modal-del");
            var delBtn = modal.find("#modal-del-btn");
            modal.find('.modal-body').html(confirmMessage);
            modal.find('.modal-title').html(confirmCaption);
            delBtn.unbind();
            delBtn.on("click", function (e) {
                modal.modal("hide");
                $.post(url, function (data, status, xhr) {
                    _this._container.html(data);
                });
            });
        });
        // filter input
        this._container.on("keypress", ".sx-gv__filter-row input", function (e) {
            var key = e.key;
            if (key === "Enter") {
                var query = new SxGridViewQuery();
                query.page = _this.getCurrentPage();
                _this.fillQueryFilters(query);
                _this.fillQueryOrders(query);
                _this.getData(query);
            }
        });
        // clear filter button
        this._container.on("click", ".sx-gv__clear-btn", function (e) {
            var icon = $(e.currentTarget).children("i").first();
            icon.removeClass("fa-repeat");
            icon.addClass("fa-spinner").addClass("fa-spin");
            var query = new SxGridViewQuery();
            _this.getData(query);
            return false;
        });
        // select all checkbox
        this._container.on("change", ".sx-gv__select-all-chbx", function (e) {
            var isChecked = $(e.currentTarget).is(":checked");
            _this._container.find(".sx-gv__select-chbx").each(function (i, e) {
                var item = $(e);
                item.prop("checked", isChecked);
                var rowId = item.closest("tr").attr("data-row-id");
                _this.modifySelectedList(rowId, isChecked);
            });
        });
        // select checkbox
        this._container.on("change", ".sx-gv__select-chbx", function (e) {
            var input = $(e.currentTarget);
            var isChecked = input.is(":checked");
            var rowId = input.closest("tr").attr("data-row-id");
            _this.modifySelectedList(rowId, isChecked);
            _this.checkSelectAllCheckbox();
        });
    }
    SxGridView.prototype.modifySelectedList = function (rowId, isChecked) {
        var existIndex = $.inArray(rowId, this._selectedRows);
        if (isChecked && existIndex === -1) {
            this._selectedRows.push(rowId);
        }
        if (!isChecked && existIndex > -1) {
            this._selectedRows.splice(existIndex, 1);
        }
    };
    ;
    return SxGridView;
}());
var SxGridViewQuery = (function () {
    function SxGridViewQuery() {
        this.filterModel = {};
    }
    return SxGridViewQuery;
}());
var SxGridViewOrderItem = (function () {
    function SxGridViewOrderItem(fieldName, direction) {
        this.fieldName = fieldName;
        this.direction = direction;
    }
    return SxGridViewOrderItem;
}());
