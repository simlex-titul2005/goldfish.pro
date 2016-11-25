/// <reference path="../jquery.d.ts" />
/// <reference path="../bootstrap.d.ts" />

class SxGridView {
    private _container: JQuery;
    private _grid: JQuery;
    private _dataAjaxUrl: string;
    private _callback: any;
    private _selectedRows: Array<any>;

    private _spinner: JQuery = $("<i class=\"fa fa-spinner fa-spin\"></i>");

    constructor(gridContainer: string, callback: any = null) {
        this._selectedRows = new Array<any>();
        this._container = $(gridContainer);
        this._grid = this._container.find(".sx-gv");
        this._callback = callback;
        this._dataAjaxUrl = this._grid.attr("data-ajax-url");

        // pager
        this._container.on("click", ".sx-gv__pager li:not('.active')", (e: JQueryEventObject) => {
            var item: JQuery = $(e.target);
            var page: number;
            page = parseInt(item.attr("data-page"), 0);
            item.prepend(this._spinner);
            var query: SxGridViewQuery = new SxGridViewQuery();
            query.page = page;
            this.fillQueryFilters(query);
            this.fillQueryOrders(query);
            this.getData(query);
        });

        // click thead th
        this._container.on("click", "th", (e: JQueryEventObject) => {
            var rowsCount: number = this._container.find(".sx-gv__row").length;
            if (rowsCount === 0) { return; }

            var th: JQuery = $(e.currentTarget);
            var enableSorting: boolean = th.attr("data-enable-sorting") !== "false";
            if (!th.hasClass("sx-gv_first-column") && enableSorting) {
                var fieldName: string = th.attr("data-field-name");
                var arrow: JQuery = th.find(".sx-gv__sort-arow");
                var direction: string = "Asc";
                if (arrow.length === 1) {
                    var dir: string = arrow.data("sort-direction");
                    if (dir === "Asc") {
                        direction = "Desc";
                    }
                }

                var query: SxGridViewQuery = new SxGridViewQuery();
                query.page = this.getCurrentPage();
                this.fillQueryFilters(query);
                query.order = new SxGridViewOrderItem(fieldName, direction);
                th.prepend(this._spinner);
                this.getData(query);
            }
        });

        // delete butttons
        this._container.on("click", ".sx-gv__delete-btn", (e: JQueryEventObject) => {
            var btn: JQuery = $(e.currentTarget);
            var url: string = btn.attr("data-url");
            var modal: JQuery = $("#modal-del");
            var delBtn: JQuery = modal.find("#modal-del-btn");
            delBtn.unbind();
            delBtn.on("click", (e: JQueryEventObject) => {
                modal.modal("hide");
                $.post(url, (data: any, status: string, xhr: JQueryXHR): void => {
                    this._container.html(data);
                });
            });
        });

        // filter input
        this._container.on("keypress", ".sx-gv__filter-row input", (e: JQueryEventObject) => {
            var key: any = e.key;
            if (key === "Enter") {
                var query: SxGridViewQuery = new SxGridViewQuery();
                query.page = this.getCurrentPage();
                this.fillQueryFilters(query);
                this.fillQueryOrders(query);
                this.getData(query);
            }
        });

        // clear filter button
        this._container.on("click", ".sx-gv__clear-btn", (e: JQueryEventObject) => {
            var icon: JQuery = $(e.currentTarget).children("i").first();
            icon.removeClass("fa-repeat");
            icon.addClass("fa-spinner").addClass("fa-spin");
            var query: SxGridViewQuery = new SxGridViewQuery();
            this.getData(query);
            return false;
        });

        // select all checkbox
        this._container.on("change", ".sx-gv__select-all-chbx", (e: JQueryEventObject) => {
            var isChecked: boolean = $(e.currentTarget).is(":checked");
            this._container.find(".sx-gv__select-chbx").each((i: number, e: Element) => {
                var item: JQuery = $(e);
                item.prop("checked", isChecked);
                var rowId: any = item.closest("tr").attr("data-row-id");
                this.modifySelectedList(rowId, isChecked);
            });
        });

        // select checkbox
        this._container.on("change", ".sx-gv__select-chbx", (e: JQueryEventObject) => {
            var input: JQuery = $(e.currentTarget);
            var isChecked: boolean = input.is(":checked");
            var rowId: any = input.closest("tr").attr("data-row-id");
            this.modifySelectedList(rowId, isChecked);
            this.checkSelectAllCheckbox();
        });
    }

    private getData = (query: SxGridViewQuery) => {
        var self: SxGridView = this;

        $.ajax({
            method: "post",
            url: self._dataAjaxUrl,
            data: query,
            success: (data: any, status: string, xhr: JQueryXHR): void => {
                self._container.html(data);
                if (this._selectedRows.length > 0) {
                    this.selectCheckboxes();
                }
            }
        });
    };

    private getCurrentPage = (): number => {
        return parseInt(this._container.find(".sx-gv__pager li.active a").attr("data-page"), 0);
    };

    private fillQueryFilters = (query: SxGridViewQuery): void => {
        $(".sx-gv__filter-row input").each((i: number, e: Element) => {
            var input: JQuery = $(e);
            var name: string = input.attr("name");
            var value: any = input.val();
            if (value !== "") {
                query.filterModel[name] = value;
            }
        });
    };

    private fillQueryOrders = (query: SxGridViewQuery): void => {
        var arrow: JQuery = this._container.find(".sx-gv__sort-arow").first();
        if (arrow.length === 0) { return; }
        var dir: string = arrow.data("sort-direction");
        var fieldName: string = arrow.closest("th").attr("data-field-name");
        query.order = new SxGridViewOrderItem(fieldName, dir);
    };

    private modifySelectedList(rowId: any, isChecked: boolean): void {
        var existIndex: number = $.inArray(rowId, this._selectedRows);
        if (isChecked && existIndex === -1) {
            this._selectedRows.push(rowId);
        }
        if (!isChecked && existIndex > -1) {
            this._selectedRows.splice(existIndex, 1);
        }
    };

    private checkSelectAllCheckbox = () => {
        var rows: JQuery = this._container.find(".sx-gv__row");
        var count: number = 0;
        rows.each((i: number, e: Element) => {
            var existIndex = $.inArray($(e).attr("data-row-id"), this._selectedRows);
            if (existIndex > -1) {
                count++;
            }
        });

        this._container.find(".sx-gv__select-all-chbx").prop("checked", count === rows.length);
    };

    private selectCheckboxes = () => {
        this._container.find("tr[data-row-id]").each((i: number, e: Element) => {
            var tr: JQuery = $(e);
            var rowId: any = tr.attr("data-row-id");
            var existIndex: number = $.inArray(rowId, this._selectedRows);
            if (existIndex > -1) {
                this.modifySelectedList(rowId, true);
                tr.find(".sx-gv__select-chbx").prop("checked", true);
            }
        });
        this.checkSelectAllCheckbox();
        console.log(this._selectedRows);
    };
}

class SxGridViewQuery {
    public page: number;
    public filterModel: any = {};
    order: SxGridViewOrderItem;
}

class SxGridViewOrderItem {
    fieldName: string;
    direction: string;

    constructor(fieldName: string, direction: string) {
        this.fieldName = fieldName;
        this.direction = direction;
    }
}