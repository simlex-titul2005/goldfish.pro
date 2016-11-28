/// <reference path="../../../../../../../sx.webcore/sx.webcore/scripts/ts/sxgridview/sxgridview.ts" />

class PageEditSiteProject {
    private _projectId: number;
    constructor(projectId: number) {
        this._projectId = projectId;
    }

    public initialize = () => {
        this.addSecurityBlock();
        this.addSecurityTab();

        $("#security").on("click", ".sx-gv__edit-btn", (e: JQueryEventObject) => {
            var id: number = parseInt($(e.currentTarget).closest(".sx-gv__row").attr("data-row-id"), 0);
            this.getEditSecurityItemForm(this._projectId, id);
            e.preventDefault();
        });
    };

    private addSecurityTab = () => {
        var i: JQuery = $("<i></i>")
            .addClass("fa fa-key")
            .attr("aria-hidden", "true");

        var a: JQuery = $("<a></a>")
            .on("shown.bs.tab", (e: JQueryEventObject) => {
                this.showSecurityTab(e);
            })
            .one("click", (e: JQueryEventObject) => {
                this.initializeSecurityGridView(e);
            })
            .attr("aria-controls", "security")
            .attr("role", "tab")
            .attr("data-toggle", "tab")
            .attr("href", "#security")
            .append(i).append("Ключи");

        var li: JQuery = $("<li></li>")
            .addClass("presentation")
            .append(a);

        li.insertBefore($("a[href=\"#recomendations\"]").parent("li"));
    };
    private showSecurityTab = (e: JQueryEventObject) => {
        var a: JQuery = $(e.target);

        $.ajax({
            method: "get",
            url: "/admin/siteprojectsecurityitems",
            data: { projectId: this._projectId },
            beforeSend: (xhr: JQueryXHR, setings: JQueryAjaxSettings): void => {
                $("<i></i>")
                    .addClass("fa fa-spinner fa-spin")
                    .prependTo(a);
            },
            success: (data: any, status: string, xhr: JQueryXHR): void => {
                $("#grid-security").html(data);
                a.find(".fa-spinner").remove();
            }
        });
    };
    private initializeSecurityGridView = (e: JQueryEventObject) => {
        var grid: SxGridView = new SxGridView($("#grid-security"));
    };

    private addSecurityBlock = () => {
        var tabDiv: JQuery = $("<div></div>")
            .attr("id", "security")
            .addClass("tab-pane")
            .attr("role", "tabpanel");

        var grid: JQuery = $("<div></div>")
            .attr("id", "grid-security")
            .appendTo(tabDiv);

        grid.on("click", ".sx-gv__create-btn", (e: JQueryEventObject) => {
            this.getEditSecurityItemForm(this._projectId, null);
            e.preventDefault();
        });

        tabDiv.insertBefore($("div[id=\"recomendations\"]"));
    };
    private getEditSecurityItemForm = (projectId: number, id: number = null) => {
        var modal: JQuery = $("#modal-additional");
        $.ajax({
            method: "get",
            url: "/admin/siteprojectsecurityitems/edit",
            data: { projectId: projectId, id: id },
            beforeSend: (xhr: JQueryXHR, setings: JQueryAjaxSettings): void => {
                var form: JQuery = $("<form></form>")
                    .attr("method", "post")
                    .attr("action", "/admin/siteprojectsecurityitems/edit")
                    .on("submit", (e: JQueryEventObject) => { this.submitEditSecurityItemForm(e); });

                modal.wrap(form);
                modal.find(".modal-title").html(id === null ? "Добавить ключ" : "Редактировать ключ");
                var footer: JQuery = modal.find(".modal-footer").first();
                if (footer.find("button[type=\"submit\"]").length === 0) {
                    modal.find(".modal-footer").first().prepend("<button type=\"submit\" class=\"btn btn-primary\">Сохранить</button>");
                }
            },
            success: (data: any, status: string, xhr: JQueryXHR): void => {
                modal.find(".modal-body").first().html(data);
                modal.modal("show");
            }
        });
    };
    private submitEditSecurityItemForm = (e: JQueryEventObject): void => {
        var modal: JQuery = $("#modal-additional");
        var form: JQuery = $(e.currentTarget);
        $.ajax({
            method: "post",
            url: form.attr("action"),
            data: form.serializeArray(),
            success: (data: any, status: string, xhr: JQueryXHR): void => {
                if (status === "success") {
                    modal.modal("hide");
                    $("#grid-security").html(data);
                }
            },
            error: (xhr: JQueryXHR, status: string, error: string): void => {
                modal.find(".modal-body").first().html(status);
                return;
            }
        });

        e.preventDefault();
    };
}