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
