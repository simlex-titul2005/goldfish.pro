/// <reference path="jquery.d.ts" />
var SxDelivery = (function () {
    function SxDelivery(urlMaterials) {
        var _this = this;
        this._spinner = $("<i class=\"fa fa-spinner fa-spin\" style=\"margin-right:5px;\"></i>");
        this.clickMct = function (e) {
            e.toggleClass("active");
            _this.checkTabs();
        };
        this.getSelectedMct = function () {
            var result = "";
            $("#mcts li.active").each(function (index, element) {
                result += "," + element.getAttribute("data-mct");
            });
            if (result != null) {
                result = result.substring(1);
            }
            console.log(result);
            return result;
        };
        this.checkTabs = function () {
            var selectedMctCount = $("#mcts li.active").length;
            if (selectedMctCount === 0) {
                _this._tabMaterialsLink.removeAttr("data-toggle");
                _this._tabMaterialsItem.addClass("disabled");
                _this._tabSubscribersLink.removeAttr("data-toggle");
                _this._tabSubscribersItem.addClass("disabled");
                return;
            }
            _this._tabMaterialsLink.attr("data-toggle", "tab");
            _this._tabMaterialsItem.removeClass("disabled");
        };
        this.clickMaterialsTab = function (e) {
            var a = $(e.target);
            var self = _this;
            $.ajax({
                method: "get",
                url: self._urlMaterials,
                data: { mcts: self.getSelectedMct() },
                beforeSend: function (xhr) {
                    a.prepend(self._spinner);
                },
                success: function (data, status, xhr) {
                    self._gridViewMaterials.html(data);
                    a.find(".fa-spinner").remove();
                }
            });
        };
        this._urlMaterials = urlMaterials;
        this._tabMaterialsLink = $("a[href=\"#materials-tab\"]");
        this._tabMaterialsItem = this._tabMaterialsLink.parent("li");
        this._tabSubscribersLink = $("a[href=\"#delivery\"]");
        this._tabSubscribersItem = this._tabSubscribersLink.parent("li");
        this._gridViewMaterials = $("#materials");
        $("#mcts li > a").on("click", function (e) {
            _this.clickMct($(e.target.parentElement));
            return false;
        });
        this._tabMaterialsLink.on("shown.bs.tab", this.clickMaterialsTab);
    }
    return SxDelivery;
}());
;
