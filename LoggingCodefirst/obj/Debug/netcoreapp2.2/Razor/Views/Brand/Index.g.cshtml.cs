#pragma checksum "/home/huanhv/RiderProjects/3S-Intersoft/LoggingCodefirst/Views/Brand/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "416f65aa924a3fe05a09bf107e5b12b2bbeee73b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Brand_Index), @"mvc.1.0.view", @"/Views/Brand/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Brand/Index.cshtml", typeof(AspNetCore.Views_Brand_Index))]
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
#line 1 "/home/huanhv/RiderProjects/3S-Intersoft/LoggingCodefirst/Views/_ViewImports.cshtml"
using LoggingCodefirst;

#line default
#line hidden
#line 2 "/home/huanhv/RiderProjects/3S-Intersoft/LoggingCodefirst/Views/_ViewImports.cshtml"
using LoggingCodefirst.Interface;

#line default
#line hidden
#line 3 "/home/huanhv/RiderProjects/3S-Intersoft/LoggingCodefirst/Views/_ViewImports.cshtml"
using LoggingCodefirst.Resources;

#line default
#line hidden
#line 4 "/home/huanhv/RiderProjects/3S-Intersoft/LoggingCodefirst/Views/_ViewImports.cshtml"
using LoggingCodefirst.ViewModels;

#line default
#line hidden
#line 5 "/home/huanhv/RiderProjects/3S-Intersoft/LoggingCodefirst/Views/_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"416f65aa924a3fe05a09bf107e5b12b2bbeee73b", @"/Views/Brand/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2a31015e85e4a5f218136f52e310f72066c1f73d", @"/Views/_ViewImports.cshtml")]
    public class Views_Brand_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BrandViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Brand", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "/home/huanhv/RiderProjects/3S-Intersoft/LoggingCodefirst/Views/Brand/Index.cshtml"
  
    ViewBag.Title = BrandLocalizer.GetLocalizedString("lbl_Brand");
    Layout = "_Layout";

#line default
#line hidden
            BeginContext(137, 147, true);
            WriteLiteral("\r\n<div class=\"page-breadcrumb\">\r\n    <div class=\"row\">\r\n        <div class=\"col-12 d-flex align-items-center\">\r\n            <h3 class=\"page-title\">");
            EndContext();
            BeginContext(285, 13, false);
#line 10 "/home/huanhv/RiderProjects/3S-Intersoft/LoggingCodefirst/Views/Brand/Index.cshtml"
                              Write(ViewBag.Title);

#line default
#line hidden
            EndContext();
            BeginContext(298, 197, true);
            WriteLiteral("</h3>\r\n            <div class=\"ml-auto text-right\">\r\n                <nav aria-label=\"breadcrumb\">\r\n                    <ol class=\"breadcrumb\">\r\n                        <li class=\"breadcrumb-item\">");
            EndContext();
            BeginContext(495, 63, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "416f65aa924a3fe05a09bf107e5b12b2bbeee73b5462", async() => {
                BeginContext(541, 13, false);
#line 14 "/home/huanhv/RiderProjects/3S-Intersoft/LoggingCodefirst/Views/Brand/Index.cshtml"
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
            BeginContext(558, 86, true);
            WriteLiteral("</li>\r\n                        <li class=\"breadcrumb-item active\" aria-current=\"page\">");
            EndContext();
            BeginContext(645, 41, false);
#line 15 "/home/huanhv/RiderProjects/3S-Intersoft/LoggingCodefirst/Views/Brand/Index.cshtml"
                                                                          Write(Localizer.GetLocalizedString("btn_Index"));

#line default
#line hidden
            EndContext();
            BeginContext(686, 420, true);
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
                    <div>
                        <a class=""btn btn-outline-success"" style=""margin-bottom: 5px;"" data-toggle=""ajax-modal"" data-url=""");
            EndContext();
            BeginContext(1107, 20, false);
#line 28 "/home/huanhv/RiderProjects/3S-Intersoft/LoggingCodefirst/Views/Brand/Index.cshtml"
                                                                                                                     Write(Url.Action("Create"));

#line default
#line hidden
            EndContext();
            BeginContext(1127, 68, true);
            WriteLiteral("\">\r\n                            <i class=\"mdi mdi-library-plus\"></i>");
            EndContext();
            BeginContext(1196, 42, false);
#line 29 "/home/huanhv/RiderProjects/3S-Intersoft/LoggingCodefirst/Views/Brand/Index.cshtml"
                                                           Write(Localizer.GetLocalizedString("btn_Create"));

#line default
#line hidden
            EndContext();
            BeginContext(1238, 151, true);
            WriteLiteral("\r\n                        </a>\r\n                        <a class=\"btn btn-outline-cyan\" style=\"margin-bottom: 5px;\" data-toggle=\"ajax-modal\" data-url=\"");
            EndContext();
            BeginContext(1390, 20, false);
#line 31 "/home/huanhv/RiderProjects/3S-Intersoft/LoggingCodefirst/Views/Brand/Index.cshtml"
                                                                                                                  Write(Url.Action("Import"));

#line default
#line hidden
            EndContext();
            BeginContext(1410, 68, true);
            WriteLiteral("\">\r\n                            <i class=\"mdi mdi-library-plus\"></i>");
            EndContext();
            BeginContext(1479, 42, false);
#line 32 "/home/huanhv/RiderProjects/3S-Intersoft/LoggingCodefirst/Views/Brand/Index.cshtml"
                                                           Write(Localizer.GetLocalizedString("btn_Import"));

#line default
#line hidden
            EndContext();
            BeginContext(1521, 142, true);
            WriteLiteral("\r\n                        </a>\r\n                        <a class=\"btn btn-outline-orange\" style=\"margin-bottom: 5px;\" data-toggle=\"ajax-modal\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1663, "\"", 1691, 1);
#line 34 "/home/huanhv/RiderProjects/3S-Intersoft/LoggingCodefirst/Views/Brand/Index.cshtml"
WriteAttributeValue("", 1670, Url.Action("Export"), 1670, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1692, 67, true);
            WriteLiteral(">\r\n                            <i class=\"mdi mdi-library-plus\"></i>");
            EndContext();
            BeginContext(1760, 42, false);
#line 35 "/home/huanhv/RiderProjects/3S-Intersoft/LoggingCodefirst/Views/Brand/Index.cshtml"
                                                           Write(Localizer.GetLocalizedString("btn_Export"));

#line default
#line hidden
            EndContext();
            BeginContext(1802, 356, true);
            WriteLiteral(@"
                        </a>
                    </div>
                    <div class=""table-responsive"">
                        <table id=""zero_config"" class=""table table-hover table-striped"">
                            <thead class=""thead-dark"">
                            <tr>
                                <th style=""text-align: center;"">");
            EndContext();
            BeginContext(2159, 43, false);
#line 42 "/home/huanhv/RiderProjects/3S-Intersoft/LoggingCodefirst/Views/Brand/Index.cshtml"
                                                           Write(BrandLocalizer.GetLocalizedString("lbl_No"));

#line default
#line hidden
            EndContext();
            BeginContext(2202, 71, true);
            WriteLiteral("</th>\r\n                                <th style=\"text-align: center;\">");
            EndContext();
            BeginContext(2274, 50, false);
#line 43 "/home/huanhv/RiderProjects/3S-Intersoft/LoggingCodefirst/Views/Brand/Index.cshtml"
                                                           Write(BrandLocalizer.GetLocalizedString("lbl_BrandName"));

#line default
#line hidden
            EndContext();
            BeginContext(2324, 71, true);
            WriteLiteral("</th>\r\n                                <th style=\"text-align: center;\">");
            EndContext();
            BeginContext(2396, 47, false);
#line 44 "/home/huanhv/RiderProjects/3S-Intersoft/LoggingCodefirst/Views/Brand/Index.cshtml"
                                                           Write(BrandLocalizer.GetLocalizedString("lbl_Action"));

#line default
#line hidden
            EndContext();
            BeginContext(2443, 117, true);
            WriteLiteral("</th>\r\n                            </tr>\r\n                            </thead>\r\n                            <tbody>\r\n");
            EndContext();
#line 48 "/home/huanhv/RiderProjects/3S-Intersoft/LoggingCodefirst/Views/Brand/Index.cshtml"
                               var stt = 0;

#line default
#line hidden
            BeginContext(2606, 28, true);
            WriteLiteral("                            ");
            EndContext();
#line 49 "/home/huanhv/RiderProjects/3S-Intersoft/LoggingCodefirst/Views/Brand/Index.cshtml"
                             foreach (var item in Model)
                            {
                                stt += 1;

#line default
#line hidden
            BeginContext(2738, 148, true);
            WriteLiteral("                                <tr>\r\n                                    <td style=\"text-align: center;\">\r\n                                        ");
            EndContext();
            BeginContext(2887, 3, false);
#line 54 "/home/huanhv/RiderProjects/3S-Intersoft/LoggingCodefirst/Views/Brand/Index.cshtml"
                                   Write(stt);

#line default
#line hidden
            EndContext();
            BeginContext(2890, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(3018, 44, false);
#line 57 "/home/huanhv/RiderProjects/3S-Intersoft/LoggingCodefirst/Views/Brand/Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.BrandName));

#line default
#line hidden
            EndContext();
            BeginContext(3062, 193, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td style=\"text-align: center;\">\r\n                                        <a data-toggle=\"ajax-modal\" data-url=\"");
            EndContext();
            BeginContext(3256, 38, false);
#line 60 "/home/huanhv/RiderProjects/3S-Intersoft/LoggingCodefirst/Views/Brand/Index.cshtml"
                                                                         Write(Url.Action("Edit", new {id = item.Id}));

#line default
#line hidden
            EndContext();
            BeginContext(3294, 211, true);
            WriteLiteral("\">\r\n                                            <i class=\"mdi mdi-grease-pencil\" style=\"font-size: 24px; color: black\"></i>\r\n                                        </a>\r\n                                        ");
            EndContext();
            BeginContext(3505, 349, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "416f65aa924a3fe05a09bf107e5b12b2bbeee73b15467", async() => {
                BeginContext(3679, 171, true);
                WriteLiteral("\r\n                                            <i class=\"fa fa-trash\" style=\"font-size: 24px; color: red; padding-left: 5px;\"></i>\r\n                                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 63 "/home/huanhv/RiderProjects/3S-Intersoft/LoggingCodefirst/Views/Brand/Index.cshtml"
                                                                 WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "onclick", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3605, "return", 3605, 6, true);
            AddHtmlAttributeValue(" ", 3611, "confirm(\'", 3612, 10, true);
#line 64 "/home/huanhv/RiderProjects/3S-Intersoft/LoggingCodefirst/Views/Brand/Index.cshtml"
AddHtmlAttributeValue("", 3621, BrandLocalizer.GetLocalizedString("msg_DeleteBrand"), 3621, 53, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 3674, "\');", 3674, 3, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3854, 84, true);
            WriteLiteral("\r\n                                    </td>\r\n                                </tr>\r\n");
            EndContext();
#line 69 "/home/huanhv/RiderProjects/3S-Intersoft/LoggingCodefirst/Views/Brand/Index.cshtml"
                            }

#line default
#line hidden
            BeginContext(3969, 178, true);
            WriteLiteral("                            </tbody>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ILocalizationService<ErrorResource> ErrorLocalizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ILocalizationService<StoreResource> StoreLocalizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ILocalizationService<StockResource> StockLocalizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ILocalizationService<ProductResource> ProductLocalizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ILocalizationService<CategoryResource> CategoryLocalizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ILocalizationService<BrandResource> BrandLocalizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ILocalizationService<UserResource> UserLocalizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ILocalizationService<HomeResource> HomeLocalizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ILocalizationService<CommonResource> Localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BrandViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
