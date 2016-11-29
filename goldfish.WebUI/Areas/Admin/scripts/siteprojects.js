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
var PageEditSiteProject = (function () {
    function PageEditSiteProject(projectId) {
        var _this = this;
        this.initialize = function () {
            _this.addSecurityBlock();
            _this.addSecurityTab();
            $("#security").on("click", ".sx-gv__edit-btn", function (e) {
                var id = parseInt($(e.currentTarget).closest(".sx-gv__row").attr("data-row-id"), 0);
                _this.getEditSecurityItemForm(_this._projectId, id);
                e.preventDefault();
            });
        };
        this.addSecurityTab = function () {
            var i = $("<i></i>")
                .addClass("fa fa-key")
                .attr("aria-hidden", "true");
            var a = $("<a></a>")
                .on("shown.bs.tab", function (e) {
                _this.showSecurityTab(e);
            })
                .one("click", function (e) {
                _this.initializeSecurityGridView(e);
            })
                .attr("aria-controls", "security")
                .attr("role", "tab")
                .attr("data-toggle", "tab")
                .attr("href", "#security")
                .append(i).append("Ключи");
            var li = $("<li></li>")
                .addClass("presentation")
                .append(a);
            li.insertBefore($("a[href=\"#recomendations\"]").parent("li"));
        };
        this.showSecurityTab = function (e) {
            var a = $(e.target);
            $.ajax({
                method: "get",
                url: "/admin/siteprojectsecurityitems",
                data: { projectId: _this._projectId },
                beforeSend: function (xhr, setings) {
                    $("<i></i>")
                        .addClass("fa fa-spinner fa-spin")
                        .prependTo(a);
                },
                success: function (data, status, xhr) {
                    $("#grid-security").html(data);
                    a.find(".fa-spinner").remove();
                }
            });
        };
        this.initializeSecurityGridView = function (e) {
            new SxGridView($("#grid-security"));
        };
        this.addSecurityBlock = function () {
            var tabDiv = $("<div></div>")
                .attr("id", "security")
                .addClass("tab-pane")
                .attr("role", "tabpanel");
            var grid = $("<div></div>")
                .attr("id", "grid-security")
                .appendTo(tabDiv);
            grid.on("click", ".sx-gv__create-btn", function (e) {
                _this.getEditSecurityItemForm(_this._projectId, null);
                e.preventDefault();
            });
            tabDiv.insertBefore($("div[id=\"recomendations\"]"));
        };
        this.getEditSecurityItemForm = function (projectId, id) {
            if (id === void 0) { id = null; }
            var modal = $("#modal-additional");
            $.ajax({
                method: "get",
                url: "/admin/siteprojectsecurityitems/edit",
                data: { projectId: projectId, id: id },
                beforeSend: function (xhr, setings) {
                    var form = $("<form></form>")
                        .attr("method", "post")
                        .attr("action", "/admin/siteprojectsecurityitems/edit")
                        .on("submit", function (e) { _this.submitEditSecurityItemForm(e); });
                    modal.wrap(form);
                    modal.find(".modal-title").html(id === null ? "Добавить ключ" : "Редактировать ключ");
                    var footer = modal.find(".modal-footer").first();
                    if (footer.find("button[type=\"submit\"]").length === 0) {
                        modal.find(".modal-footer").first().prepend("<button type=\"submit\" class=\"btn btn-primary\">Сохранить</button>");
                    }
                },
                success: function (data, status, xhr) {
                    modal.find(".modal-body").first().html(data);
                    modal.modal("show");
                }
            });
        };
        this.submitEditSecurityItemForm = function (e) {
            var modal = $("#modal-additional");
            var form = $(e.currentTarget);
            $.ajax({
                method: "post",
                url: form.attr("action"),
                data: form.serializeArray(),
                success: function (data, status, xhr) {
                    if (status === "success") {
                        modal.modal("hide");
                        $("#grid-security").html(data);
                    }
                },
                error: function (xhr, status, error) {
                    modal.find(".modal-body").first().html(status);
                    return;
                }
            });
            e.preventDefault();
        };
        this._projectId = projectId;
    }
    return PageEditSiteProject;
}());
