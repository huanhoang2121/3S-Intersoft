#pragma checksum "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/User/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eb64cc13295a336c04fda3ef2989f776c345a44c"
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
#line 1 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/_ViewImports.cshtml"
using LoggingCodefirst;

#line default
#line hidden
#line 2 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/_ViewImports.cshtml"
using LoggingCodefirst.ViewModels;

#line default
#line hidden
#line 5 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#line 7 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/_ViewImports.cshtml"
using LoggingCodefirst.Services;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb64cc13295a336c04fda3ef2989f776c345a44c", @"/Views/User/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11f410c31c705207617b58f58f1f347a2556ba1e", @"/Views/_ViewImports.cshtml")]
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
#line 2 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/User/Index.cshtml"
  
    ViewBag.Title = UserLocalizer.GetLocalizedString("lbl_User");
    Layout = "_Layout";

#line default
#line hidden
            BeginContext(129, 143, true);
            WriteLiteral("\n<div class=\"page-breadcrumb\">\n    <div class=\"row\">\n        <div class=\"col-12 d-flex align-items-center\">\n            <h3 class=\"page-title\">");
            EndContext();
            BeginContext(273, 13, false);
#line 10 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/User/Index.cshtml"
                              Write(ViewBag.Title);

#line default
#line hidden
            EndContext();
            BeginContext(286, 193, true);
            WriteLiteral("</h3>\n            <div class=\"ml-auto text-right\">\n                <nav aria-label=\"breadcrumb\">\n                    <ol class=\"breadcrumb\">\n                        <li class=\"breadcrumb-item\">");
            EndContext();
            BeginContext(479, 62, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eb64cc13295a336c04fda3ef2989f776c345a44c5970", async() => {
                BeginContext(524, 13, false);
#line 14 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/User/Index.cshtml"
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
            BeginContext(541, 85, true);
            WriteLiteral("</li>\n                        <li class=\"breadcrumb-item active\" aria-current=\"page\">");
            EndContext();
            BeginContext(627, 41, false);
#line 15 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/User/Index.cshtml"
                                                                          Write(Localizer.GetLocalizedString("btn_Index"));

#line default
#line hidden
            EndContext();
            BeginContext(668, 279, true);
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
            BeginContext(947, 129, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eb64cc13295a336c04fda3ef2989f776c345a44c8532", async() => {
                BeginContext(970, 59, true);
                WriteLiteral(" <i class=\"mdi mdi-library-plus\" style=\" color: green\"></i>");
                EndContext();
                BeginContext(1030, 42, false);
#line 27 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/User/Index.cshtml"
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
            BeginContext(1076, 293, true);
            WriteLiteral(@"
                    <div class=""table-responsive"">
                        <table id=""zero_config"" class=""table table-hover table-striped"">
                            <thead class=""thead-dark"">
                            <tr>
                                <th style=""text-align: center;"">");
            EndContext();
            BeginContext(1370, 42, false);
#line 32 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/User/Index.cshtml"
                                                           Write(UserLocalizer.GetLocalizedString("lbl_No"));

#line default
#line hidden
            EndContext();
            BeginContext(1412, 70, true);
            WriteLiteral("</th>\n                                <th style=\"text-align: center;\">");
            EndContext();
            BeginContext(1483, 45, false);
#line 33 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/User/Index.cshtml"
                                                           Write(UserLocalizer.GetLocalizedString("lbl_Email"));

#line default
#line hidden
            EndContext();
            BeginContext(1528, 70, true);
            WriteLiteral("</th>\n                                <th style=\"text-align: center;\">");
            EndContext();
            BeginContext(1599, 48, false);
#line 34 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/User/Index.cshtml"
                                                           Write(UserLocalizer.GetLocalizedString("lbl_Fullname"));

#line default
#line hidden
            EndContext();
            BeginContext(1647, 70, true);
            WriteLiteral("</th>\n                                <th style=\"text-align: center;\">");
            EndContext();
            BeginContext(1718, 45, false);
#line 35 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/User/Index.cshtml"
                                                           Write(UserLocalizer.GetLocalizedString("lbl_Phone"));

#line default
#line hidden
            EndContext();
            BeginContext(1763, 70, true);
            WriteLiteral("</th>\n                                <th style=\"text-align: center;\">");
            EndContext();
            BeginContext(1834, 45, false);
#line 36 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/User/Index.cshtml"
                                                           Write(UserLocalizer.GetLocalizedString("lbl_Store"));

#line default
#line hidden
            EndContext();
            BeginContext(1879, 70, true);
            WriteLiteral("</th>\n                                <th style=\"text-align: center;\">");
            EndContext();
            BeginContext(1950, 47, false);
#line 37 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/User/Index.cshtml"
                                                           Write(UserLocalizer.GetLocalizedString("lbl_Address"));

#line default
#line hidden
            EndContext();
            BeginContext(1997, 70, true);
            WriteLiteral("</th>\n                                <th style=\"text-align: center;\">");
            EndContext();
            BeginContext(2068, 46, false);
#line 38 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/User/Index.cshtml"
                                                           Write(UserLocalizer.GetLocalizedString("lbl_Action"));

#line default
#line hidden
            EndContext();
            BeginContext(2114, 114, true);
            WriteLiteral("</th>\n                            </tr>\n                            </thead>\n                            <tbody> \n");
            EndContext();
#line 42 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/User/Index.cshtml"
                               var stt = 0; 

#line default
#line hidden
            BeginContext(2274, 28, true);
            WriteLiteral("                            ");
            EndContext();
#line 43 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/User/Index.cshtml"
                             foreach (var item in Model)
                            {
                                stt += 1;

#line default
#line hidden
            BeginContext(2403, 146, true);
            WriteLiteral("                                <tr>\n                                    <td style=\"text-align: center;\">\n                                        ");
            EndContext();
            BeginContext(2550, 3, false);
#line 48 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/User/Index.cshtml"
                                   Write(stt);

#line default
#line hidden
            EndContext();
            BeginContext(2553, 124, true);
            WriteLiteral("\n                                    </td>\n                                    <td>\n                                        ");
            EndContext();
            BeginContext(2678, 40, false);
#line 51 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/User/Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
            EndContext();
            BeginContext(2718, 124, true);
            WriteLiteral("\n                                    </td>\n                                    <td>\n                                        ");
            EndContext();
            BeginContext(2843, 43, false);
#line 54 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/User/Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Fullname));

#line default
#line hidden
            EndContext();
            BeginContext(2886, 124, true);
            WriteLiteral("\n                                    </td>\n                                    <td>\n                                        ");
            EndContext();
            BeginContext(3011, 40, false);
#line 57 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/User/Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Phone));

#line default
#line hidden
            EndContext();
            BeginContext(3051, 124, true);
            WriteLiteral("\n                                    </td>\n                                    <td>\n                                        ");
            EndContext();
            BeginContext(3176, 50, false);
#line 60 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/User/Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Store.StoreName));

#line default
#line hidden
            EndContext();
            BeginContext(3226, 124, true);
            WriteLiteral("\n                                    </td>\n                                    <td>\n                                        ");
            EndContext();
            BeginContext(3351, 42, false);
#line 63 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/User/Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Address));

#line default
#line hidden
            EndContext();
            BeginContext(3393, 152, true);
            WriteLiteral("\n                                    </td>\n                                    <td style=\"text-align: center;\">\n                                        ");
            EndContext();
            BeginContext(3545, 210, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eb64cc13295a336c04fda3ef2989f776c345a44c17961", async() => {
                BeginContext(3590, 161, true);
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
#line 66 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/User/Index.cshtml"
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
            BeginContext(3755, 79, true);
            WriteLiteral("\n                                        <a data-toggle=\"ajax-modal\" data-url=\"");
            EndContext();
            BeginContext(3835, 48, false);
#line 69 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/User/Index.cshtml"
                                                                         Write(Url.Action("ChangePassword", new {id = item.Id}));

#line default
#line hidden
            EndContext();
            BeginContext(3883, 206, true);
            WriteLiteral("\">\n                                            <i class=\"mdi mdi-key-variant\" style=\"font-size: 24px; color: black\"></i>\n                                        </a>\n                                        ");
            EndContext();
            BeginContext(4089, 345, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eb64cc13295a336c04fda3ef2989f776c345a44c21184", async() => {
                BeginContext(4261, 169, true);
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
#line 72 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/User/Index.cshtml"
                                                                 WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "onclick", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 4189, "return", 4189, 6, true);
            AddHtmlAttributeValue(" ", 4195, "confirm(\'", 4196, 10, true);
#line 73 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/User/Index.cshtml"
AddHtmlAttributeValue("", 4205, UserLocalizer.GetLocalizedString("msg_DeleteUser"), 4205, 51, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 4256, "\');", 4256, 3, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4434, 81, true);
            WriteLiteral("\n                                    </td>\n                                </tr>\n");
            EndContext();
#line 78 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/User/Index.cshtml"
                            }

#line default
#line hidden
            BeginContext(4545, 171, true);
            WriteLiteral("                            </tbody>\n                        </table>\n                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public LocalizationService<StoreResource> StoreLocalizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public LocalizationService<StockResource> StockLocalizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public LocalizationService<ProductResource> ProductLocalizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public LocalizationService<CategoryResource> CategoryLocalizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public LocalizationService<BrandResource> BrandLocalizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public LocalizationService<UserResource> UserLocalizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public LocalizationService<HomeResource> HomeLocalizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public LocalizationService<CommonResource> Localizer { get; private set; }
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
