﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using SX.WebCore;
    using SX.WebCore.HtmlHelpers;
    using SX.WebCore.ViewModels;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Admin/Views/Shared/_Layout.cshtml")]
    public partial class _Areas_Admin_Views_Shared__Layout_cshtml : SX.WebCore.MvcWebViewPage.SxWebViewPage<dynamic>
    {
        public _Areas_Admin_Views_Shared__Layout_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\Admin\Views\Shared\_Layout.cshtml"
   
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\n\n<!DOCTYPE html>\n<html");

WriteLiteral(" lang=\"ru\"");

WriteLiteral(">\n<head>\n    <meta");

WriteLiteral(" charset=\"utf-8\"");

WriteLiteral(">\n    <meta");

WriteLiteral(" http-equiv=\"X-UA-Compatible\"");

WriteLiteral(" content=\"IE=edge\"");

WriteLiteral(">\n    <meta");

WriteLiteral(" name=\"viewport\"");

WriteLiteral(" content=\"width=device-width, initial-scale=1\"");

WriteLiteral(">\n    <title>");

            
            #line 11 "..\..\Areas\Admin\Views\Shared\_Layout.cshtml"
       Write(ViewBag.Title==null?"admin | leavingrussia.ru":ViewBag.Title+ " | admin | leavingrussia.ru");

            
            #line default
            #line hidden
WriteLiteral("</title>\n\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 348), Tuple.Create("\"", 424)
            
            #line 13 "..\..\Areas\Admin\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 355), Tuple.Create<System.Object, System.Int32>(Url.Action("Css", "StaticContent", new { name="bootstrap", area=""})
            
            #line default
            #line hidden
, 355), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 456), Tuple.Create("\"", 535)
            
            #line 14 "..\..\Areas\Admin\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 463), Tuple.Create<System.Object, System.Int32>(Url.Action("Css", "StaticContent", new { name="font-awesome", area=""})
            
            #line default
            #line hidden
, 463), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 567), Tuple.Create("\"", 644)
            
            #line 15 "..\..\Areas\Admin\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 574), Tuple.Create<System.Object, System.Int32>(Url.Action("Css", "StaticContent", new { name="metis-menu", area=""})
            
            #line default
            #line hidden
, 574), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 676), Tuple.Create("\"", 748)
            
            #line 16 "..\..\Areas\Admin\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 683), Tuple.Create<System.Object, System.Int32>(Url.Action("Css", "StaticContent", new { name="admin", area=""})
            
            #line default
            #line hidden
, 683), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 780), Tuple.Create("\"", 854)
            
            #line 17 "..\..\Areas\Admin\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 787), Tuple.Create<System.Object, System.Int32>(Url.Action("Css", "StaticContent", new { name="sx-core", area=""})
            
            #line default
            #line hidden
, 787), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\n");

WriteLiteral("    ");

            
            #line 18 "..\..\Areas\Admin\Views\Shared\_Layout.cshtml"
Write(RenderSection("styles", false));

            
            #line default
            #line hidden
WriteLiteral("\n</head>\n<body>\n    <div");

WriteLiteral(" id=\"wrapper\"");

WriteLiteral(">\n        <nav");

WriteLiteral(" class=\"navbar navbar-default navbar-static-top\"");

WriteLiteral(" role=\"navigation\"");

WriteLiteral(" style=\"margin-bottom: 0\"");

WriteLiteral(">\n            <div");

WriteLiteral(" class=\"navbar-header\"");

WriteLiteral(">\n                <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"navbar-toggle\"");

WriteLiteral(" data-toggle=\"collapse\"");

WriteLiteral(" data-target=\".navbar-collapse\"");

WriteLiteral(">\n                    <span");

WriteLiteral(" class=\"sr-only\"");

WriteLiteral(">Toggle navigation</span>\n                    <span");

WriteLiteral(" class=\"icon-bar\"");

WriteLiteral("></span>\n                    <span");

WriteLiteral(" class=\"icon-bar\"");

WriteLiteral("></span>\n                    <span");

WriteLiteral(" class=\"icon-bar\"");

WriteLiteral("></span>\n                </button>\n                <a");

WriteLiteral(" class=\"navbar-brand\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1495), Tuple.Create("\"", 1530)
            
            #line 30 "..\..\Areas\Admin\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 1502), Tuple.Create<System.Object, System.Int32>(Url.Action("Index", "Home")
            
            #line default
            #line hidden
, 1502), false)
);

WriteLiteral(">");

            
            #line 30 "..\..\Areas\Admin\Views\Shared\_Layout.cshtml"
                                                                       Write(SX.WebCore.Resources.Settings.adminPanelName);

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 30 "..\..\Areas\Admin\Views\Shared\_Layout.cshtml"
                                                                                                                     Write(SX.WebCore.Resources.Settings.adminPanelVersion);

            
            #line default
            #line hidden
WriteLiteral("</a><br />\n            </div>\n\n            <ul");

WriteLiteral(" class=\"nav navbar-top-links navbar-right\"");

WriteLiteral(">\n                <li");

WriteLiteral(" class=\"dropdown\"");

WriteLiteral(">\n                    <a");

WriteLiteral(" class=\"dropdown-toggle\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\n                        <i");

WriteLiteral(" class=\"fa fa-envelope fa-fw\"");

WriteLiteral("></i>  <i");

WriteLiteral(" class=\"fa fa-caret-down\"");

WriteLiteral("></i>\n                    </a>\n                    <ul");

WriteLiteral(" class=\"dropdown-menu dropdown-messages\"");

WriteLiteral(">\n                        <li>\n                            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\n                                <div>\n                                    <stro" +
"ng>John Smith</strong>\n                                    <span");

WriteLiteral(" class=\"pull-right text-muted\"");

WriteLiteral(@">
                                        <em>Yesterday</em>
                                    </span>
                                </div>
                                <div>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque eleifend...</div>
                            </a>
                        </li>
                        <li");

WriteLiteral(" class=\"divider\"");

WriteLiteral("></li>\n                        <li>\n                            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\n                                <div>\n                                    <stro" +
"ng>John Smith</strong>\n                                    <span");

WriteLiteral(" class=\"pull-right text-muted\"");

WriteLiteral(@">
                                        <em>Yesterday</em>
                                    </span>
                                </div>
                                <div>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque eleifend...</div>
                            </a>
                        </li>
                        <li");

WriteLiteral(" class=\"divider\"");

WriteLiteral("></li>\n                        <li>\n                            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\n                                <div>\n                                    <stro" +
"ng>John Smith</strong>\n                                    <span");

WriteLiteral(" class=\"pull-right text-muted\"");

WriteLiteral(@">
                                        <em>Yesterday</em>
                                    </span>
                                </div>
                                <div>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque eleifend...</div>
                            </a>
                        </li>
                        <li");

WriteLiteral(" class=\"divider\"");

WriteLiteral("></li>\n                        <li>\n                            <a");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\n                                <strong>Read All Messages</strong>\n            " +
"                    <i");

WriteLiteral(" class=\"fa fa-angle-right\"");

WriteLiteral("></i>\n                            </a>\n                        </li>\n            " +
"        </ul>\n                </li>\n                <li");

WriteLiteral(" class=\"dropdown\"");

WriteLiteral(">\n                    <a");

WriteLiteral(" class=\"dropdown-toggle\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\n                        <i");

WriteLiteral(" class=\"fa fa-tasks fa-fw\"");

WriteLiteral("></i>  <i");

WriteLiteral(" class=\"fa fa-caret-down\"");

WriteLiteral("></i>\n                    </a>\n                    <ul");

WriteLiteral(" class=\"dropdown-menu dropdown-tasks\"");

WriteLiteral(">\n                        <li>\n                            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\n                                <div>\n                                    <p>\n " +
"                                       <strong>Task 1</strong>\n                 " +
"                       <span");

WriteLiteral(" class=\"pull-right text-muted\"");

WriteLiteral(">40% Complete</span>\n                                    </p>\n                   " +
"                 <div");

WriteLiteral(" class=\"progress progress-striped active\"");

WriteLiteral(">\n                                        <div");

WriteLiteral(" class=\"progress-bar progress-bar-success\"");

WriteLiteral(" role=\"progressbar\"");

WriteLiteral(" aria-valuenow=\"40\"");

WriteLiteral(" aria-valuemin=\"0\"");

WriteLiteral(" aria-valuemax=\"100\"");

WriteLiteral(" style=\"width: 40%\"");

WriteLiteral(">\n                                            <span");

WriteLiteral(" class=\"sr-only\"");

WriteLiteral(">40% Complete (success)</span>\n                                        </div>\n   " +
"                                 </div>\n                                </div>\n " +
"                           </a>\n                        </li>\n                  " +
"      <li");

WriteLiteral(" class=\"divider\"");

WriteLiteral("></li>\n                        <li>\n                            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\n                                <div>\n                                    <p>\n " +
"                                       <strong>Task 2</strong>\n                 " +
"                       <span");

WriteLiteral(" class=\"pull-right text-muted\"");

WriteLiteral(">20% Complete</span>\n                                    </p>\n                   " +
"                 <div");

WriteLiteral(" class=\"progress progress-striped active\"");

WriteLiteral(">\n                                        <div");

WriteLiteral(" class=\"progress-bar progress-bar-info\"");

WriteLiteral(" role=\"progressbar\"");

WriteLiteral(" aria-valuenow=\"20\"");

WriteLiteral(" aria-valuemin=\"0\"");

WriteLiteral(" aria-valuemax=\"100\"");

WriteLiteral(" style=\"width: 20%\"");

WriteLiteral(">\n                                            <span");

WriteLiteral(" class=\"sr-only\"");

WriteLiteral(">20% Complete</span>\n                                        </div>\n             " +
"                       </div>\n                                </div>\n           " +
"                 </a>\n                        </li>\n                        <li");

WriteLiteral(" class=\"divider\"");

WriteLiteral("></li>\n                        <li>\n                            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\n                                <div>\n                                    <p>\n " +
"                                       <strong>Task 3</strong>\n                 " +
"                       <span");

WriteLiteral(" class=\"pull-right text-muted\"");

WriteLiteral(">60% Complete</span>\n                                    </p>\n                   " +
"                 <div");

WriteLiteral(" class=\"progress progress-striped active\"");

WriteLiteral(">\n                                        <div");

WriteLiteral(" class=\"progress-bar progress-bar-warning\"");

WriteLiteral(" role=\"progressbar\"");

WriteLiteral(" aria-valuenow=\"60\"");

WriteLiteral(" aria-valuemin=\"0\"");

WriteLiteral(" aria-valuemax=\"100\"");

WriteLiteral(" style=\"width: 60%\"");

WriteLiteral(">\n                                            <span");

WriteLiteral(" class=\"sr-only\"");

WriteLiteral(">60% Complete (warning)</span>\n                                        </div>\n   " +
"                                 </div>\n                                </div>\n " +
"                           </a>\n                        </li>\n                  " +
"      <li");

WriteLiteral(" class=\"divider\"");

WriteLiteral("></li>\n                        <li>\n                            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\n                                <div>\n                                    <p>\n " +
"                                       <strong>Task 4</strong>\n                 " +
"                       <span");

WriteLiteral(" class=\"pull-right text-muted\"");

WriteLiteral(">80% Complete</span>\n                                    </p>\n                   " +
"                 <div");

WriteLiteral(" class=\"progress progress-striped active\"");

WriteLiteral(">\n                                        <div");

WriteLiteral(" class=\"progress-bar progress-bar-danger\"");

WriteLiteral(" role=\"progressbar\"");

WriteLiteral(" aria-valuenow=\"80\"");

WriteLiteral(" aria-valuemin=\"0\"");

WriteLiteral(" aria-valuemax=\"100\"");

WriteLiteral(" style=\"width: 80%\"");

WriteLiteral(">\n                                            <span");

WriteLiteral(" class=\"sr-only\"");

WriteLiteral(">80% Complete (danger)</span>\n                                        </div>\n    " +
"                                </div>\n                                </div>\n  " +
"                          </a>\n                        </li>\n                   " +
"     <li");

WriteLiteral(" class=\"divider\"");

WriteLiteral("></li>\n                        <li>\n                            <a");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\n                                <strong>See All Tasks</strong>\n                " +
"                <i");

WriteLiteral(" class=\"fa fa-angle-right\"");

WriteLiteral("></i>\n                            </a>\n                        </li>\n            " +
"        </ul>\n                </li>\n                <li");

WriteLiteral(" class=\"dropdown\"");

WriteLiteral(">\n                    <a");

WriteLiteral(" class=\"dropdown-toggle\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\n                        <i");

WriteLiteral(" class=\"fa fa-bell fa-fw\"");

WriteLiteral("></i>  <i");

WriteLiteral(" class=\"fa fa-caret-down\"");

WriteLiteral("></i>\n                    </a>\n                    <ul");

WriteLiteral(" class=\"dropdown-menu dropdown-alerts\"");

WriteLiteral(">\n                        <li>\n                            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\n                                <div>\n                                    <i");

WriteLiteral(" class=\"fa fa-comment fa-fw\"");

WriteLiteral("></i> New Comment\n                                    <span");

WriteLiteral(" class=\"pull-right text-muted small\"");

WriteLiteral(">4 minutes ago</span>\n                                </div>\n                    " +
"        </a>\n                        </li>\n                        <li");

WriteLiteral(" class=\"divider\"");

WriteLiteral("></li>\n                        <li>\n                            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\n                                <div>\n                                    <i");

WriteLiteral(" class=\"fa fa-twitter fa-fw\"");

WriteLiteral("></i> 3 New Followers\n                                    <span");

WriteLiteral(" class=\"pull-right text-muted small\"");

WriteLiteral(">12 minutes ago</span>\n                                </div>\n                   " +
"         </a>\n                        </li>\n                        <li");

WriteLiteral(" class=\"divider\"");

WriteLiteral("></li>\n                        <li>\n                            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\n                                <div>\n                                    <i");

WriteLiteral(" class=\"fa fa-envelope fa-fw\"");

WriteLiteral("></i> Message Sent\n                                    <span");

WriteLiteral(" class=\"pull-right text-muted small\"");

WriteLiteral(">4 minutes ago</span>\n                                </div>\n                    " +
"        </a>\n                        </li>\n                        <li");

WriteLiteral(" class=\"divider\"");

WriteLiteral("></li>\n                        <li>\n                            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\n                                <div>\n                                    <i");

WriteLiteral(" class=\"fa fa-tasks fa-fw\"");

WriteLiteral("></i> New Task\n                                    <span");

WriteLiteral(" class=\"pull-right text-muted small\"");

WriteLiteral(">4 minutes ago</span>\n                                </div>\n                    " +
"        </a>\n                        </li>\n                        <li");

WriteLiteral(" class=\"divider\"");

WriteLiteral("></li>\n                        <li>\n                            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\n                                <div>\n                                    <i");

WriteLiteral(" class=\"fa fa-upload fa-fw\"");

WriteLiteral("></i> Server Rebooted\n                                    <span");

WriteLiteral(" class=\"pull-right text-muted small\"");

WriteLiteral(">4 minutes ago</span>\n                                </div>\n                    " +
"        </a>\n                        </li>\n                        <li");

WriteLiteral(" class=\"divider\"");

WriteLiteral("></li>\n                        <li>\n                            <a");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\n                                <strong>See All Alerts</strong>\n               " +
"                 <i");

WriteLiteral(" class=\"fa fa-angle-right\"");

WriteLiteral("></i>\n                            </a>\n                        </li>\n            " +
"        </ul>\n                </li>\n                <li");

WriteLiteral(" class=\"dropdown\"");

WriteLiteral(">\n                    <a");

WriteLiteral(" class=\"dropdown-toggle\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\n                        <i");

WriteLiteral(" class=\"fa fa-user fa-fw\"");

WriteLiteral("></i>  <i");

WriteLiteral(" class=\"fa fa-caret-down\"");

WriteLiteral("></i>\n                    </a>\n                    <ul");

WriteLiteral(" class=\"dropdown-menu dropdown-user\"");

WriteLiteral(">\n                        <li>\n                            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-user fa-fw\"");

WriteLiteral("></i> User Profile</a>\n                        </li>\n                        <li>" +
"\n                            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-gear fa-fw\"");

WriteLiteral("></i> Settings</a>\n                        </li>\n                        <li");

WriteLiteral(" class=\"divider\"");

WriteLiteral("></li>\n                        <li>\n                            <form");

WriteLiteral(" method=\"post\"");

WriteAttribute("action", Tuple.Create(" action=\"", 12215), Tuple.Create("\"", 12271)
            
            #line 231 "..\..\Areas\Admin\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 12224), Tuple.Create<System.Object, System.Int32>(Url.Action("Logoff","Account", new { area=""})
            
            #line default
            #line hidden
, 12224), false)
);

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(">\n");

WriteLiteral("                                ");

            
            #line 232 "..\..\Areas\Admin\Views\Shared\_Layout.cshtml"
                           Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
WriteLiteral("\n                            </form>\n                            <a");

WriteLiteral(" href=\"javascript:void(0)\"");

WriteLiteral(" onclick=\"if(confirm(\'Вы действительно хотите покинуть панель управления?\')){$(th" +
"is).prev(\'form\').submit();}\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-sign-out fa-fw\"");

WriteLiteral("></i> Выйти</a>\n                        </li>\n                    </ul>\n         " +
"       </li>\n            </ul>\n\n            <div");

WriteLiteral(" class=\"navbar-default sidebar\"");

WriteLiteral(" role=\"navigation\"");

WriteLiteral(">\n                <div");

WriteLiteral(" class=\"sidebar-nav navbar-collapse\"");

WriteLiteral(">\n");

WriteLiteral("                    ");

            
            #line 242 "..\..\Areas\Admin\Views\Shared\_Layout.cshtml"
               Write(Html.Action("AdminMenu", "MenuItems"));

            
            #line default
            #line hidden
WriteLiteral("\n                </div>\n            </div>\n        </nav>\n\n        <div");

WriteLiteral(" id=\"page-wrapper\"");

WriteLiteral(">\n            <small");

WriteLiteral(" class=\"pull-right text-muted\"");

WriteLiteral(">Последний старт: ");

            
            #line 248 "..\..\Areas\Admin\Views\Shared\_Layout.cshtml"
                                                             Write(SX.WebCore.MvcApplication.SxMvcApplication.LastStartDate);

            
            #line default
            #line hidden
WriteLiteral("</small>\n");

WriteLiteral("            ");

            
            #line 249 "..\..\Areas\Admin\Views\Shared\_Layout.cshtml"
       Write(RenderBody());

            
            #line default
            #line hidden
WriteLiteral("\n        </div>\n    </div>\n\n    ");

WriteLiteral("\n    <div");

WriteLiteral(" class=\"modal fade\"");

WriteLiteral(" tabindex=\"-1\"");

WriteLiteral(" role=\"dialog\"");

WriteLiteral(" id=\"modal-error\"");

WriteLiteral(">\n");

            
            #line 255 "..\..\Areas\Admin\Views\Shared\_Layout.cshtml"
        
            
            #line default
            #line hidden
            
            #line 255 "..\..\Areas\Admin\Views\Shared\_Layout.cshtml"
         using (Ajax.BeginForm("SendErrorToArchitect", new { controller = "Errors" }, new AjaxOptions { HttpMethod = "post", OnBegin= "$('#modal-error-send-btn').append('<i class=\"fa fa-spinner fa-spipn\"></i>')", OnSuccess= "$('#modal-error-send-btn').find('.fa-spinner').remove();$('#modal-error').modal('hide'); alert('Письмо успешно отправлено!')" }, new { @id = "modal-error-form" }))
        {

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"modal-dialog modal-lg\"");

WriteLiteral(" role=\"document\"");

WriteLiteral(">\n                <div");

WriteLiteral(" class=\"modal-content panel-danger\"");

WriteLiteral(">\n                    <div");

WriteLiteral(" class=\"modal-header panel-heading\"");

WriteLiteral(" style=\"border-top-left-radius: inherit; border-top-right-radius: inherit;\"");

WriteLiteral(">\n                        <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"close\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(" aria-label=\"Close\"");

WriteLiteral("><span");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(">&times;</span></button>\n                        <h4");

WriteLiteral(" class=\"modal-title\"");

WriteLiteral("></h4>\n                    </div>\n                    <div");

WriteLiteral(" class=\"modal-body\"");

WriteLiteral(">\n                        <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"rawUrl\"");

WriteLiteral(" />\n                        <textarea");

WriteLiteral(" name=\"html\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"height:300px; resize:none;\"");

WriteLiteral("></textarea>\n                    </div>\n                    <div");

WriteLiteral(" class=\"modal-footer\"");

WriteLiteral(">\n                        <ul");

WriteLiteral(" class=\"list-unstyled list-inline\"");

WriteLiteral(">\n                            <li>\n                                <button");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" id=\"modal-error-send-btn\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-envelope-o\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral("></i> Отправить разработчику</button>\n                            </li>\n         " +
"                   <li>\n                                <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(">Закрыть</button>\n                            </li>\n                        </ul>" +
"\n                    </div>\n                </div>\n            </div>\n");

            
            #line 279 "..\..\Areas\Admin\Views\Shared\_Layout.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\n\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 15068), Tuple.Create("\"", 15142)
            
            #line 282 "..\..\Areas\Admin\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 15074), Tuple.Create<System.Object, System.Int32>(Url.Action("Js", "StaticContent", new { name = "jquery", area="" })
            
            #line default
            #line hidden
, 15074), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 15166), Tuple.Create("\"", 15244)
            
            #line 283 "..\..\Areas\Admin\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 15172), Tuple.Create<System.Object, System.Int32>(Url.Action("Js", "StaticContent", new { name = "bootstrap",  area="" })
            
            #line default
            #line hidden
, 15172), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 15268), Tuple.Create("\"", 15360)
            
            #line 284 "..\..\Areas\Admin\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 15274), Tuple.Create<System.Object, System.Int32>(Url.Action("Js", "StaticContent", new { name = "jquery.unobtrusive-ajax",  area="" })
            
            #line default
            #line hidden
, 15274), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 15384), Tuple.Create("\"", 15463)
            
            #line 285 "..\..\Areas\Admin\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 15390), Tuple.Create<System.Object, System.Int32>(Url.Action("Js", "StaticContent", new { name = "metis-menu",  area="" })
            
            #line default
            #line hidden
, 15390), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 15487), Tuple.Create("\"", 15563)
            
            #line 286 "..\..\Areas\Admin\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 15493), Tuple.Create<System.Object, System.Int32>(Url.Action("Js", "StaticContent", new { name = "sx-core",  area="" })
            
            #line default
            #line hidden
, 15493), false)
);

WriteLiteral("></script>\n    <script>\n        $(function () {\n            $(\'#side-menu\').metis" +
"Menu();\n\n            $(window).bind(\"load resize\", function () {\n               " +
" topOffset = 50;\n                width = (this.window.innerWidth > 0) ? this.win" +
"dow.innerWidth : this.screen.width;\n                if (width < 768) {\n         " +
"           $(\'div.navbar-collapse\').addClass(\'collapse\');\n                    to" +
"pOffset = 100; // 2-row-menu\n                } else {\n                    $(\'div" +
".navbar-collapse\').removeClass(\'collapse\');\n                }\n\n                h" +
"eight = ((this.window.innerHeight > 0) ? this.window.innerHeight : this.screen.h" +
"eight) - 1;\n                height = height - topOffset;\n                if (hei" +
"ght < 1) height = 1;\n                if (height > topOffset) {\n                 " +
"   $(\"#page-wrapper\").css(\"min-height\", (height) + \"px\");\n                }\n    " +
"        });\n\n            var url = window.location;\n            var element = $(" +
"\'ul.nav a\').filter(function () {\n                return this.href == url || url." +
"href.indexOf(this.href) == 0;\n            }).addClass(\'active\').parent().parent(" +
").addClass(\'in\').parent();\n            if (element.is(\'li\')) {\n                e" +
"lement.addClass(\'active\');\n            }\n\n            $(document).ajaxError(func" +
"tion (event, xhr, settings) {\n                $modal = $(\'#modal-error\');\n      " +
"          $modal.find(\'.modal-header h4\').html(\'<span class=\"text-danger\">Ошибка" +
" \' + xhr.status+ \'</span>\');\n                $modal.find(\'.modal-body textarea\')" +
".val(xhr.responseText);\n                $modal.find(\'.modal-body input[name=\"raw" +
"Url\"]\').val(\'");

            
            #line 321 "..\..\Areas\Admin\Views\Shared\_Layout.cshtml"
                                                                Write(Request.RawUrl);

            
            #line default
            #line hidden
WriteLiteral(@"');
                $('.modal').modal('hide');
                $('#modal-error').modal('show');
            });

            $().alert();

            $('[data-toggle=""tooltip""]').tooltip();

            $(document).mouseup(function (e) {
                var container = $("".sx-gvl__dropdown"");

                if (!container.is(e.target) && container.has(e.target).length === 0) {
                    container.hide();
                }
            });
        });
    </script>
");

WriteLiteral("    ");

            
            #line 339 "..\..\Areas\Admin\Views\Shared\_Layout.cshtml"
Write(RenderSection("scripts", false));

            
            #line default
            #line hidden
WriteLiteral("\n</body>\n</html>\n");

        }
    }
}
#pragma warning restore 1591
