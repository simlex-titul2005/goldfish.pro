var SxGridView = (function () {
    function SxGridView(element, callback) {
        var _this = this;
        if (callback === void 0) { callback = null; }
        this._spinner = $("<i class=\"fa fa-spinner fa-spin\"></i>");
        this.getData = function (query) {
            var self = _this;
            var dataAjaxUrl = self._element.find(".sx-gv").attr("data-ajax-url");
            $.ajax({
                method: "post",
                url: dataAjaxUrl,
                data: query,
                success: function (data, status, xhr) {
                    self._element.find(".sx-gv").parent().html(data);
                    if (_this._selectedRows.length > 0) {
                        _this.selectCheckboxes();
                    }
                }
            });
        };
        this.getCurrentPage = function () {
            var page = _this._element.find(".sx-gv__pager li.active a").attr("data-page");
            return page === undefined ? 1 : parseInt(page, 0);
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
            var arrow = _this._element.find(".sx-gv__sort-arow").first();
            if (arrow.length === 0) {
                return;
            }
            var dir = arrow.data("sort-direction");
            var fieldName = arrow.closest("th").attr("data-field-name");
            query.order = new SxGridViewOrderItem(fieldName, dir);
        };
        this.checkSelectAllCheckbox = function () {
            var rows = _this._element.find(".sx-gv__row");
            var count = 0;
            rows.each(function (i, e) {
                var existIndex = $.inArray($(e).attr("data-row-id"), _this._selectedRows);
                if (existIndex > -1) {
                    count++;
                }
            });
            _this._element.find(".sx-gv__select-all-chbx").prop("checked", count === rows.length);
        };
        this.selectCheckboxes = function () {
            _this._element.find("tr[data-row-id]").each(function (i, e) {
                var tr = $(e);
                var rowId = tr.attr("data-row-id");
                var existIndex = $.inArray(rowId, _this._selectedRows);
                if (existIndex > -1) {
                    _this.modifySelectedList(rowId, true);
                    tr.find(".sx-gv__select-chbx").prop("checked", true);
                }
            });
            _this.checkSelectAllCheckbox();
        };
        this.selectedRows = function () {
            return _this._selectedRows;
        };
        this.clearSelectedRows = function () {
            _this._selectedRows = new Array();
        };
        this._selectedRows = new Array();
        this._element = $(element);
        this._callback = callback;
        this._element.on("click", ".sx-gv__pager li:not('.active')", function (e) {
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
        this._element.on("click", "th", function (e) {
            var rowsCount = _this._element.find(".sx-gv__row").length;
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
        this._element.on("click", ".sx-gv__delete-btn", function (e) {
            var btn = $(e.currentTarget);
            var url = btn.attr("data-url");
            var confirmMessage = btn.attr("data-del-conf-mes");
            var confirmCaption = btn.attr("data-del-conf-caption");
            var modal = $("#modal-del");
            var delBtn = modal.find("#modal-del-btn");
            modal.find(".modal-body").html(confirmMessage);
            modal.find(".modal-title").html(confirmCaption);
            delBtn.unbind();
            delBtn.on("click", function (e) {
                modal.modal("hide");
                $.ajax({
                    method: "post",
                    data: { __RequestVerificationToken: $("input[name=\"__RequestVerificationToken\"]").val() },
                    url: url,
                    success: function (data, status, xhr) {
                        _this._element.html(data);
                    }
                });
            });
        });
        this._element.on("keypress", ".sx-gv__filter-row input", function (e) {
            var key = e.key;
            if (key === "Enter") {
                var query = new SxGridViewQuery();
                query.page = _this.getCurrentPage();
                _this.fillQueryFilters(query);
                _this.fillQueryOrders(query);
                _this.getData(query);
            }
        });
        this._element.on("click", ".sx-gv__clear-btn", function (e) {
            var icon = $(e.currentTarget).children("i").first();
            icon.removeClass("fa-repeat");
            icon.addClass("fa-spinner").addClass("fa-spin");
            var query = new SxGridViewQuery();
            _this.getData(query);
            return false;
        });
        this._element.on("change", ".sx-gv__select-all-chbx", function (e) {
            var isChecked = $(e.currentTarget).is(":checked");
            _this._element.find(".sx-gv__select-chbx").each(function (i, e) {
                var item = $(e);
                item.prop("checked", isChecked);
                var rowId = item.closest("tr").attr("data-row-id");
                _this.modifySelectedList(rowId, isChecked);
            });
        });
        this._element.on("change", ".sx-gv__select-chbx", function (e) {
            var input = $(e.currentTarget);
            var isChecked = input.is(":checked");
            var rowId = input.closest("tr").attr("data-row-id");
            _this.modifySelectedList(rowId, isChecked);
            _this.checkSelectAllCheckbox();
        });
        this._element.on("click", ".sx-gv__filter-row select option", function (e) {
            var option = $(e.currentTarget);
            var select = option.closest("select");
            var value = option.val();
            var name = select.attr("name");
            var query = new SxGridViewQuery();
            query.page = 1;
            query.filterModel[name] = value;
            _this.getData(query);
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
        this.__RequestVerificationToken = $("input[name=\"__RequestVerificationToken\"]").val();
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
var SxDelivery = (function () {
    function SxDelivery(matUrl, teplatesUrl, subscribersUrl) {
        var _this = this;
        this.initialize = function () {
            _this._mcts.on("click", "a", function (e) {
                _this.clickPill(e);
                _this._matGrid.clearSelectedRows();
            });
            _this._matTab.on("shown.bs.tab", function (e) {
                var selectedMcts = _this._mcts.find("li.active");
                if (selectedMcts.length === 0) {
                    return;
                }
                var mcts = null;
                selectedMcts.each(function (i, e) {
                    var id = $(e).attr("data-mct");
                    mcts += "," + id;
                });
                $.ajax({
                    method: "get",
                    url: _this._matUrl,
                    data: { mcts: mcts.replace("null,", "") },
                    success: function (data, status, xhr) {
                        _this._matBlock.html(data);
                        _this._matGrid.selectCheckboxes();
                        _this.checkTemplatesTab();
                    }
                });
            });
            _this._templatesTab.on("shown.bs.tab", function (e) {
                var selectedMcts = _this._mcts.find("li.active");
                if (selectedMcts.length === 0) {
                    return;
                }
                var mcts = null;
                selectedMcts.each(function (i, e) {
                    var id = $(e).attr("data-mct");
                    mcts += "," + id;
                });
                $.ajax({
                    method: "get",
                    url: _this._templatesUrl,
                    data: { mcts: mcts.replace("null,", "") },
                    success: function (data, status, xhr) {
                        _this._templatesBlock.html(data);
                        _this._templatesGrid.selectCheckboxes();
                        _this.checkDeliveryTab();
                    }
                });
            });
            _this._matBlock.on("change", ".sx-gv__select-all-chbx", function (e) {
                _this.checkTemplatesTab();
                _this.checkDeliveryTab();
            });
            _this._matBlock.on("change", ".sx-gv__select-chbx", function (e) {
                _this.checkTemplatesTab();
                _this.checkDeliveryTab();
            });
            _this._templatesBlock.on("change", ".sx-gv__select-all-chbx", function (e) {
                _this.checkDeliveryTab();
            });
            _this._templatesBlock.on("change", ".sx-gv__select-chbx", function (e) {
                _this.checkDeliveryTab();
            });
            _this._deliveryTab.on("shown.bs.tab", function (e) {
                $.ajax({
                    method: "get",
                    url: _this._subscribersUrl,
                    success: function (data, status, xhr) {
                        $("#subscribers").html(data);
                        _this._subscribersGrid.selectCheckboxes();
                    }
                });
            });
        };
        this.clickPill = function (e) {
            e.preventDefault();
            var a = $(e.currentTarget);
            var li = a.parent("li");
            li.toggleClass("active");
            _this.checkMaterialsTab();
        };
        this.checkMaterialsTab = function () {
            var mctsCount = _this._mcts.find("li.active").length;
            var li = _this._matTab.parent("li");
            if (mctsCount === 0) {
                li.addClass("disabled");
                _this._matTab.removeAttr("data-toggle");
                _this._matGrid.clearSelectedRows();
                _this._templatesGrid.clearSelectedRows();
                _this._subscribersGrid.clearSelectedRows();
                _this.checkTemplatesTab();
                return;
            }
            li.removeClass("disabled");
            _this._matTab.attr("data-toggle", "tab");
        };
        this.checkTemplatesTab = function () {
            var li = _this._templatesTab.parent("li");
            var selectedRowsCount = _this._matGrid.selectedRows().length;
            if (selectedRowsCount === 0) {
                li.addClass("disabled");
                _this._templatesTab.removeAttr("data-toggle");
                _this._templatesGrid.clearSelectedRows();
                return;
            }
            li.removeClass("disabled");
            _this._templatesTab.attr("data-toggle", "tab");
        };
        this.checkDeliveryTab = function () {
            var li = _this._deliveryTab.parent("li");
            var selectedRowsCount = _this._templatesGrid.selectedRows().length;
            if (selectedRowsCount === 0) {
                li.addClass("disabled");
                _this._deliveryTab.removeAttr("data-toggle");
                _this._subscribersGrid.clearSelectedRows();
                return;
            }
            li.removeClass("disabled");
            _this._deliveryTab.attr("data-toggle", "tab");
        };
        this._matUrl = matUrl;
        this._subscribersUrl = subscribersUrl;
        this._mcts = $("#mcts");
        this._matTab = $("a[href=\"#materials-tab\"]");
        this._matBlock = $("#materials");
        this._matGrid = new SxGridView(this._matBlock);
        this._subscribersGrid = new SxGridView($("#subscribers"));
        this._deliveryTab = $("a[href=\"#delivery\"]");
        this._templatesUrl = teplatesUrl;
        this._templatesGrid = new SxGridView($("#templates"));
        this._templatesTab = $("a[href=\"#templates-tab\"]");
        this._templatesBlock = $("#templates");
    }
    return SxDelivery;
}());
