#pragma checksum "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\User\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6b6635d4c3b1ddb5b4602c1448ac860dd3cb96c3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Index), @"mvc.1.0.view", @"/Views/User/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/User/Index.cshtml", typeof(AspNetCore.Views_User_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\_ViewImports.cshtml"
using LoggingCodefirst;

#line default
#line hidden
#line 2 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\_ViewImports.cshtml"
using LoggingCodefirst.ViewModels;

#line default
#line hidden
#line 4 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#line 6 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\_ViewImports.cshtml"
using LoggingCodefirst.Resources;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b6635d4c3b1ddb5b4602c1448ac860dd3cb96c3", @"/Views/User/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3082770567c8ff46d1bf3ed409854acd48444041", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<UserViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\User\Index.cshtml"
  
    ViewBag.Title = Localizer.GetLocalizedString("ctr_User");
    Layout = "_Layout";

#line default
#line hidden
            BeginContext(125, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 7 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\User\Index.cshtml"
 if (TempData["SuccessMessage"] != null)
{

#line default
#line hidden
            BeginContext(169, 82, true);
            WriteLiteral("    <div class=\"alert alert-success\" style=\"padding-left: 25px;\">\n        <strong>");
            EndContext();
            BeginContext(252, 26, false);
#line 10 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\User\Index.cshtml"
           Write(TempData["SuccessMessage"]);

#line default
#line hidden
            EndContext();
            BeginContext(278, 194, true);
            WriteLiteral("</strong> \n        <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">\n            <span aria-hidden=\"true\" style=\"font-size:20px\">×</span>\n        </button>\n    </div>\n");
            EndContext();
#line 15 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\User\Index.cshtml"
}

#line default
#line hidden
#line 16 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\User\Index.cshtml"
 if (TempData["ErrorMessage"] != null)
{

#line default
#line hidden
            BeginContext(515, 81, true);
            WriteLiteral("    <div class=\"alert alert-danger\" style=\"padding-left: 25px;\">\n        <strong>");
            EndContext();
            BeginContext(597, 24, false);
#line 19 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\User\Index.cshtml"
           Write(TempData["ErrorMessage"]);

#line default
#line hidden
            EndContext();
            BeginContext(621, 194, true);
            WriteLiteral("</strong> \n        <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">\n            <span aria-hidden=\"true\" style=\"font-size:20px\">×</span>\n        </button>\n    </div>\n");
            EndContext();
#line 24 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\User\Index.cshtml"
}

#line default
#line hidden
            BeginContext(817, 144, true);
            WriteLiteral("\n\n<div class=\"page-breadcrumb\">\n    <div class=\"row\">\n        <div class=\"col-12 d-flex align-items-center\">\n            <h3 class=\"page-title\">");
            EndContext();
            BeginContext(962, 13, false);
#line 30 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\User\Index.cshtml"
                              Write(ViewBag.Title);

#line default
#line hidden
            EndContext();
            BeginContext(975, 193, true);
            WriteLiteral("</h3>\n            <div class=\"ml-auto text-right\">\n                <nav aria-label=\"breadcrumb\">\n                    <ol class=\"breadcrumb\">\n                        <li class=\"breadcrumb-item\">");
            EndContext();
            BeginContext(1168, 62, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6b6635d4c3b1ddb5b4602c1448ac860dd3cb96c38026", async() => {
                BeginContext(1213, 13, false);
#line 34 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\User\Index.cshtml"
                                                                                           Write(ViewBag.Title);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1230, 85, true);
            WriteLiteral("</li>\n                        <li class=\"breadcrumb-item active\" aria-current=\"page\">");
            EndContext();
            BeginContext(1316, 41, false);
#line 35 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\User\Index.cshtml"
                                                                          Write(Localizer.GetLocalizedString("act_Index"));

#line default
#line hidden
            EndContext();
            BeginContext(1357, 279, true);
            WriteLiteral(@"</li>
                    </ol>
                </nav>
            </div>
        </div>
    </div>
</div>
<div class=""container-fluid"">
    <div class=""row"">
        <div class=""col-12"">
            <div class=""card"">
                <div class=""card-body"">
                    ");
            EndContext();
            BeginContext(1636, 129, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6b6635d4c3b1ddb5b4602c1448ac860dd3cb96c310589", async() => {
                BeginContext(1659, 59, true);
                WriteLiteral(" <i class=\"mdi mdi-library-plus\" style=\" color: green\"></i>");
                EndContext();
                BeginContext(1719, 42, false);
#line 47 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\User\Index.cshtml"
                                                                                                 Write(Localizer.GetLocalizedString("btn_Create"));

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1765, 293, true);
            WriteLiteral(@"
                    <div class=""table-responsive"">
                        <table id=""zero_config"" class=""table table-hover table-striped"">
                            <thead class=""thead-dark"">
                            <tr>
                                <th style=""text-align: center;"">");
            EndContext();
            BeginContext(2059, 38, false);
#line 52 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\User\Index.cshtml"
                                                           Write(Localizer.GetLocalizedString("lbl_No"));

#line default
#line hidden
            EndContext();
            BeginContext(2097, 70, true);
            WriteLiteral("</th>\n                                <th style=\"text-align: center;\">");
            EndContext();
            BeginContext(2168, 41, false);
#line 53 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\User\Index.cshtml"
                                                           Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
            EndContext();
            BeginContext(2209, 70, true);
            WriteLiteral("</th>\n                                <th style=\"text-align: center;\">");
            EndContext();
            BeginContext(2280, 44, false);
#line 54 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\User\Index.cshtml"
                                                           Write(Html.DisplayNameFor(model => model.Fullname));

#line default
#line hidden
            EndContext();
            BeginContext(2324, 70, true);
            WriteLiteral("</th>\n                                <th style=\"text-align: center;\">");
            EndContext();
            BeginContext(2395, 41, false);
#line 55 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\User\Index.cshtml"
                                                           Write(Html.DisplayNameFor(model => model.Phone));

#line default
#line hidden
            EndContext();
            BeginContext(2436, 70, true);
            WriteLiteral("</th>\n                                <th style=\"text-align: center;\">");
            EndContext();
            BeginContext(2507, 41, false);
#line 56 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\User\Index.cshtml"
                                                           Write(Html.DisplayNameFor(model => model.Store));

#line default
#line hidden
            EndContext();
            BeginContext(2548, 70, true);
            WriteLiteral("</th>\n                                <th style=\"text-align: center;\">");
            EndContext();
            BeginContext(2619, 43, false);
#line 57 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\User\Index.cshtml"
                                                           Write(Html.DisplayNameFor(model => model.Address));

#line default
#line hidden
            EndContext();
            BeginContext(2662, 70, true);
            WriteLiteral("</th>\n                                <th style=\"text-align: center;\">");
            EndContext();
            BeginContext(2733, 42, false);
#line 58 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\User\Index.cshtml"
                                                           Write(Localizer.GetLocalizedString("lbl_Action"));

#line default
#line hidden
            EndContext();
            BeginContext(2775, 114, true);
            WriteLiteral("</th>\n                            </tr>\n                            </thead>\n                            <tbody> \n");
            EndContext();
#line 62 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\User\Index.cshtml"
                               var stt = 0; 

#line default
#line hidden
            BeginContext(2935, 28, true);
            WriteLiteral("                            ");
            EndContext();
#line 63 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\User\Index.cshtml"
                             foreach (var item in Model)
                            {
                                stt += 1;

#line default
#line hidden
            BeginContext(3064, 146, true);
            WriteLiteral("                                <tr>\n                                    <td style=\"text-align: center;\">\n                                        ");
            EndContext();
            BeginContext(3211, 3, false);
#line 68 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\User\Index.cshtml"
                                   Write(stt);

#line default
#line hidden
            EndContext();
            BeginContext(3214, 124, true);
            WriteLiteral("\n                                    </td>\n                                    <td>\n                                        ");
            EndContext();
            BeginContext(3339, 40, false);
#line 71 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\User\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
            EndContext();
            BeginContext(3379, 124, true);
            WriteLiteral("\n                                    </td>\n                                    <td>\n                                        ");
            EndContext();
            BeginContext(3504, 43, false);
#line 74 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\User\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Fullname));

#line default
#line hidden
            EndContext();
            BeginContext(3547, 124, true);
            WriteLiteral("\n                                    </td>\n                                    <td>\n                                        ");
            EndContext();
            BeginContext(3672, 40, false);
#line 77 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\User\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Phone));

#line default
#line hidden
            EndContext();
            BeginContext(3712, 124, true);
            WriteLiteral("\n                                    </td>\n                                    <td>\n                                        ");
            EndContext();
            BeginContext(3837, 50, false);
#line 80 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\User\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Store.StoreName));

#line default
#line hidden
            EndContext();
            BeginContext(3887, 124, true);
            WriteLiteral("\n                                    </td>\n                                    <td>\n                                        ");
            EndContext();
            BeginContext(4012, 42, false);
#line 83 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\User\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Address));

#line default
#line hidden
            EndContext();
            BeginContext(4054, 287, true);
            WriteLiteral(@"
                                    </td>
                                    <td style=""text-align: center;"">
                                        <!-- Button trigger modal -->
                                        <a data-toggle=""ajax-modal"" data-target=""#add-contact"" data-url=""");
            EndContext();
            BeginContext(4342, 48, false);
#line 87 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\User\Index.cshtml"
                                                                                                    Write(Url.Action("ChangePassword", new {id = item.Id}));

#line default
#line hidden
            EndContext();
            BeginContext(4390, 207, true);
            WriteLiteral("\">\n                                            <i class=\"mdi mdi-key-variant\" style=\"font-size: 24px; color: black\"></i>\n                                        </a>\n\n                                        ");
            EndContext();
            BeginContext(4597, 210, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6b6635d4c3b1ddb5b4602c1448ac860dd3cb96c320632", async() => {
                BeginContext(4642, 161, true);
                WriteLiteral("\n                                            <i class=\"mdi mdi-grease-pencil\" style=\"font-size: 24px; color: black\"></i>\n                                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 91 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\User\Index.cshtml"
                                                               WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4807, 41, true);
            WriteLiteral("\n                                        ");
            EndContext();
            BeginContext(4848, 339, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6b6635d4c3b1ddb5b4602c1448ac860dd3cb96c323182", async() => {
                BeginContext(5014, 169, true);
                WriteLiteral("\n                                            <i class=\"fa fa-trash\" style=\"font-size: 24px; color: red; padding-left: 5px;\"></i>\n                                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 94 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\User\Index.cshtml"
                                                                 WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "onclick", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 4948, "return", 4948, 6, true);
            AddHtmlAttributeValue(" ", 4954, "confirm(\'", 4955, 10, true);
#line 95 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\User\Index.cshtml"
AddHtmlAttributeValue("", 4964, Localizer.GetLocalizedString("msg_del_User"), 4964, 45, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 5009, "\');", 5009, 3, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5187, 81, true);
            WriteLiteral("\n                                    </td>\n                                </tr>\n");
            EndContext();
#line 100 "G:\3S-Intersoft\LoggingCodefirst\LoggingCodefirst\Views\User\Index.cshtml"
                            }

#line default
#line hidden
            BeginContext(5298, 171, true);
            WriteLiteral("                            </tbody>\n                        </table>\n                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public LocalizationService Localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<UserViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
