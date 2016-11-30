/// <reference path="../../typings/jquery.d.ts" />
/// <reference path="../../typings/bootstrap.d.ts" />
/// <reference path="../../typings/sxgridview.d.ts" />

class SxDelivery {
    private _matUrl: string;
    private _mcts: JQuery;
    private _matTab: JQuery;
    private _matBlock: JQuery;
    private _matGrid: SxGridView;
    private _deliveryTab: JQuery;
    private _subscribersUrl: string;
    private _subscribersGrid: SxGridView;
    private _templatesUrl: string;
    private _templatesGrid: SxGridView;
    private _templatesTab: JQuery;
    private _templatesBlock: JQuery;
    private _sendUrl: string;
    private _modal: JQuery;

    constructor(matUrl: string, teplatesUrl: string, subscribersUrl: string, sendUrl: string) {
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
        this._sendUrl = sendUrl;
        this._modal = $("#modal-delivery");
    }

    public initialize = () => {
        // mcts
        this._mcts.on("click", "a", (e: JQueryEventObject) => {
            this.clickPill(e);
            this._matGrid.clearSelectedRows();
        });

        // materials tab shown
        this._matTab.on("shown.bs.tab", (e: JQueryEventObject) => {
            var selectedMcts: JQuery = this._mcts.find("li.active");
            if (selectedMcts.length === 0) { return; }

            var mcts: string = null;
            selectedMcts.each((i: number, e: Element) => {
                var id: string = $(e).attr("data-mct");
                mcts += "," + id;
            });

            $.ajax({
                method: "get",
                url: this._matUrl,
                data: { mcts: mcts.replace("null,", "") },
                success: (data: any, status: string, xhr: JQueryXHR): void => {
                    this._matBlock.html(data);
                    this._matGrid.selectCheckboxes();
                    this.checkTemplatesTab();
                }
            });
        });

        // templates tab shown
        this._templatesTab.on("shown.bs.tab", (e: JQueryEventObject) => {
            var selectedMcts: JQuery = this._mcts.find("li.active");
            if (selectedMcts.length === 0) { return; }

            var mcts: string = null;
            selectedMcts.each((i: number, e: Element) => {
                var id: string = $(e).attr("data-mct");
                mcts += "," + id;
            });

            $.ajax({
                method: "get",
                url: this._templatesUrl,
                data: { mcts: mcts.replace("null,", "") },
                success: (data: any, status: string, xhr: JQueryXHR): void => {
                    this._templatesBlock.html(data);
                    this._templatesGrid.selectCheckboxes();
                    this.checkDeliveryTab();
                }
            });
        });

        // material grid select all checkbox
        this._matBlock.on("change", ".sx-gv__select-all-chbx", (e: JQueryEventObject) => {
            this.checkTemplatesTab();
            this.checkDeliveryTab();
        });

        // material grid select checkbox
        this._matBlock.on("change", ".sx-gv__select-chbx", (e: JQueryEventObject) => {
            this.checkTemplatesTab();
            this.checkDeliveryTab();
        });

        // templates grid select all checkbox
        this._templatesBlock.on("change", ".sx-gv__select-all-chbx", (e: JQueryEventObject) => {
            this.checkDeliveryTab();
        });

        // templates grid select checkbox
        this._templatesBlock.on("change", ".sx-gv__select-chbx", (e: JQueryEventObject) => {
            this.checkDeliveryTab();
        });

        // delivery tab shown
        this._deliveryTab.on("shown.bs.tab", (e: JQueryEventObject) => {
            $.ajax({
                method: "get",
                url: this._subscribersUrl,
                success: (data: any, status: string, xhr: JQueryXHR): void => {
                    $("#subscribers").html(data);
                    this._subscribersGrid.selectCheckboxes();
                }
            });
        });

        // send to one
        $("#subscribers").on("click", ".btn-send-to-one", (e: JQueryEventObject) => {
            var btn: JQuery = $(e.currentTarget);
            var subscriberId: string = btn.closest("tr").attr("data-row-id");
            var subscribers: any[] = [subscriberId];

            var data: any = {
                mcts: this.selectedMcts(),
                materials: this._matGrid.selectedRows(),
                templates: this._templatesGrid.selectedRows(),
                subscribers: subscribers
            };

            this.send(data);
        });

        // send selected
        $("#subscribers").on("click", ".btn-send-to-all", (e: JQueryEventObject) => {

            if (this._subscribersGrid.selectedRows().length == 0) {
                return;
            }

            var data: any = {
                mcts: this.selectedMcts(),
                materials: this._matGrid.selectedRows(),
                templates: this._templatesGrid.selectedRows(),
                subscribers: this._subscribersGrid.selectedRows()
            };

            this.send(data);
        });
    };

    private send(data: any): void {
        $.ajax({
            method: "post",
            url: this._sendUrl,
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify(data),
            beforeSend: (xhr: JQueryXHR, setings: JQueryAjaxSettings): void => {
                this._modal.find(".modal-body").html("<div class=\"text-center\"><i class=\"fa fa-spinner fa-spin\"></i></div>");
                this._modal.modal("show");
            },
            success: (data: any, status: string, xhr: JQueryXHR): void => {
                this._modal.find(".modal-body").html(data.Message);
            }
        });
    };

    private clickPill = (e: JQueryEventObject) => {
        e.preventDefault();
        var a: JQuery = $(e.currentTarget);
        var li: JQuery = a.parent("li");
        li.toggleClass("active");
        this.checkMaterialsTab();
    };

    private checkMaterialsTab = () => {
        var mctsCount: number = this._mcts.find("li.active").length;
        var li: JQuery = this._matTab.parent("li");
        if (mctsCount === 0) {
            li.addClass("disabled");
            this._matTab.removeAttr("data-toggle");
            this._matGrid.clearSelectedRows();
            this._templatesGrid.clearSelectedRows();
            this._subscribersGrid.clearSelectedRows();
            this.checkTemplatesTab();
            return;
        }

        li.removeClass("disabled");
        this._matTab.attr("data-toggle", "tab");
    };

    private checkTemplatesTab = () => {
        var li: JQuery = this._templatesTab.parent("li");
        var selectedRowsCount: number = this._matGrid.selectedRows().length;
        if (selectedRowsCount === 0) {
            li.addClass("disabled");
            this._templatesTab.removeAttr("data-toggle");
            this._templatesGrid.clearSelectedRows();
            return;
        }

        li.removeClass("disabled");
        this._templatesTab.attr("data-toggle", "tab");
    };

    private checkDeliveryTab = () => {
        var li: JQuery = this._deliveryTab.parent("li");
        var selectedRowsCount: number = this._templatesGrid.selectedRows().length;
        if (selectedRowsCount === 0) {
            li.addClass("disabled");
            this._deliveryTab.removeAttr("data-toggle");
            this._subscribersGrid.clearSelectedRows();
            return;
        }

        li.removeClass("disabled");
        this._deliveryTab.attr("data-toggle", "tab");
    };

    private selectedMcts(): any[] {
        var result: any[] = [];
        this._mcts.find("li.active").each((i: number, e: Element) => {
            result.push($(e).attr("data-mct"));
        });
        return result;
    };
}