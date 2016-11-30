var SxDelivery = (function () {
    function SxDelivery(matUrl, teplatesUrl, subscribersUrl, sendUrl) {
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
            $("#subscribers").on("click", ".btn-send-to-one", function (e) {
                var btn = $(e.currentTarget);
                var subscriberId = btn.closest("tr").attr("data-row-id");
                var subscribers = [subscriberId];
                var data = {
                    mcts: _this.selectedMcts(),
                    materials: _this._matGrid.selectedRows(),
                    templates: _this._templatesGrid.selectedRows(),
                    subscribers: subscribers
                };
                _this.send(data);
            });
            $("#subscribers").on("click", ".btn-send-to-all", function (e) {
                if (_this._subscribersGrid.selectedRows().length == 0) {
                    return;
                }
                var data = {
                    mcts: _this.selectedMcts(),
                    materials: _this._matGrid.selectedRows(),
                    templates: _this._templatesGrid.selectedRows(),
                    subscribers: _this._subscribersGrid.selectedRows()
                };
                _this.send(data);
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
        this._sendUrl = sendUrl;
        this._modal = $("#modal-delivery");
    }
    SxDelivery.prototype.send = function (data) {
        var _this = this;
        $.ajax({
            method: "post",
            url: this._sendUrl,
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify(data),
            beforeSend: function (xhr, setings) {
                _this._modal.find(".modal-body").html("<div class=\"text-center\"><i class=\"fa fa-spinner fa-spin\"></i></div>");
                _this._modal.modal("show");
            },
            success: function (data, status, xhr) {
                _this._modal.find(".modal-body").html(data.Message);
            }
        });
    };
    ;
    SxDelivery.prototype.selectedMcts = function () {
        var result = [];
        this._mcts.find("li.active").each(function (i, e) {
            result.push($(e).attr("data-mct"));
        });
        return result;
    };
    ;
    return SxDelivery;
}());
