/// <reference path="../jquery.d.ts" />

class SxDelivery {
    _urlMaterials: string;

    _tabMaterialsLink: JQuery;
    _tabMaterialsItem: JQuery;
    _tabSubscribersLink: JQuery;
    _tabSubscribersItem: JQuery;

    _gridViewMaterials: JQuery;

    _spinner: JQuery = $("<i class=\"fa fa-spinner fa-spin\" style=\"margin-right:5px;\"></i>");

    constructor(urlMaterials: string) {
        this._urlMaterials = urlMaterials;

        this._tabMaterialsLink = $("a[href=\"#materials-tab\"]");
        this._tabMaterialsItem = this._tabMaterialsLink.parent("li");
        this._tabSubscribersLink = $("a[href=\"#delivery\"]");
        this._tabSubscribersItem = this._tabSubscribersLink.parent("li");

        this._gridViewMaterials = $("#materials");

        $("#mcts li > a").on("click", (e: JQueryEventObject) => {
            this.clickMct($(e.target.parentElement));
            return false;
        });

        this._tabMaterialsLink.on("shown.bs.tab", this.clickMaterialsTab);
    }

    clickMct = (e: JQuery) => {
        e.toggleClass("active");
        this.checkTabs();
    };

    getSelectedMct = (): string => {
        var result: string = "";
        $("#mcts li.active").each((index: number, element: Element) => {
            result += "," + element.getAttribute("data-mct");
        });
        if (result !== null) {
            result = result.substring(1);
        }
        console.log(result);
        return result;
    };

    checkTabs = () => {
        var selectedMctCount: number = $("#mcts li.active").length;
        if (selectedMctCount === 0) {
            this._tabMaterialsLink.removeAttr("data-toggle");
            this._tabMaterialsItem.addClass("disabled");

            this._tabSubscribersLink.removeAttr("data-toggle");
            this._tabSubscribersItem.addClass("disabled");

            return;
        }

        this._tabMaterialsLink.attr("data-toggle", "tab");
        this._tabMaterialsItem.removeClass("disabled");
    };

    clickMaterialsTab = (e: JQueryEventObject) => {
        var a: JQuery = $(e.target);
        var self: SxDelivery = this;

        $.ajax({
            method: "get",
            url: self._urlMaterials,
            data: { mcts: self.getSelectedMct() },
            beforeSend: (xhr: JQueryXHR): void => {
                a.prepend(self._spinner);
            },
            success: (data: any, status: string, xhr: JQueryXHR): void => {
                self._gridViewMaterials.html(data);
                a.find(".fa-spinner").remove();
            }
        });
    };
};