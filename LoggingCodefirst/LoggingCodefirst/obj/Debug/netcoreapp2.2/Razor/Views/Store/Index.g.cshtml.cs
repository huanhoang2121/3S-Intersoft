#pragma checksum "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Store/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3c4037cf3243b5f913b1dfa4f6a65d2c7be13952"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Store_Index), @"mvc.1.0.view", @"/Views/Store/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Store/Index.cshtml", typeof(AspNetCore.Views_Store_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c4037cf3243b5f913b1dfa4f6a65d2c7be13952", @"/Views/Store/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11f410c31c705207617b58f58f1f347a2556ba1e", @"/Views/_ViewImports.cshtml")]
    public class Views_Store_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<StoreViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Store", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Store/Index.cshtml"
  
    ViewBag.Title = StoreLocalizer.GetLocalizedString("lbl_Store");
    Layout = "_Layout";

#line default
#line hidden
            BeginContext(137, 147, true);
            WriteLiteral("\r\n<div class=\"page-breadcrumb\">\r\n    <div class=\"row\">\r\n        <div class=\"col-12 d-flex align-items-center\">\r\n            <h3 class=\"page-title\">");
            EndContext();
            BeginContext(285, 13, false);
#line 10 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Store/Index.cshtml"
                              Write(ViewBag.Title);

#line default
#line hidden
            EndContext();
            BeginContext(298, 197, true);
            WriteLiteral("</h3>\r\n            <div class=\"ml-auto text-right\">\r\n                <nav aria-label=\"breadcrumb\">\r\n                    <ol class=\"breadcrumb\">\r\n                        <li class=\"breadcrumb-item\">");
            EndContext();
            BeginContext(495, 63, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3c4037cf3243b5f913b1dfa4f6a65d2c7be139526002", async() => {
                BeginContext(541, 13, false);
#line 14 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Store/Index.cshtml"
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
#line 15 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Store/Index.cshtml"
                                                                          Write(Localizer.GetLocalizedString("btn_Index"));

#line default
#line hidden
            EndContext();
            BeginContext(686, 291, true);
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
            BeginContext(977, 129, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3c4037cf3243b5f913b1dfa4f6a65d2c7be139528581", async() => {
                BeginContext(1000, 59, true);
                WriteLiteral(" <i class=\"mdi mdi-library-plus\" style=\" color: green\"></i>");
                EndContext();
                BeginContext(1060, 42, false);
#line 27 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Store/Index.cshtml"
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
            BeginContext(1106, 298, true);
            WriteLiteral(@"
                    <div class=""table-responsive"">
                        <table id=""zero_config"" class=""table table-hover table-striped"">
                            <thead class=""thead-dark"">
                            <tr>
                                <th style=""text-align: center;"">");
            EndContext();
            BeginContext(1405, 43, false);
#line 32 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Store/Index.cshtml"
                                                           Write(StoreLocalizer.GetLocalizedString("lbl_No"));

#line default
#line hidden
            EndContext();
            BeginContext(1448, 71, true);
            WriteLiteral("</th>\r\n                                <th style=\"text-align: center;\">");
            EndContext();
            BeginContext(1520, 50, false);
#line 33 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Store/Index.cshtml"
                                                           Write(StoreLocalizer.GetLocalizedString("lbl_StoreName"));

#line default
#line hidden
            EndContext();
            BeginContext(1570, 71, true);
            WriteLiteral("</th>\r\n                                <th style=\"text-align: center;\">");
            EndContext();
            BeginContext(1642, 46, false);
#line 34 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Store/Index.cshtml"
                                                           Write(StoreLocalizer.GetLocalizedString("lbl_Email"));

#line default
#line hidden
            EndContext();
            BeginContext(1688, 71, true);
            WriteLiteral("</th>\r\n                                <th style=\"text-align: center;\">");
            EndContext();
            BeginContext(1760, 46, false);
#line 35 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Store/Index.cshtml"
                                                           Write(StoreLocalizer.GetLocalizedString("lbl_Phone"));

#line default
#line hidden
            EndContext();
            BeginContext(1806, 71, true);
            WriteLiteral("</th>\r\n                                <th style=\"text-align: center;\">");
            EndContext();
            BeginContext(1878, 48, false);
#line 36 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Store/Index.cshtml"
                                                           Write(StoreLocalizer.GetLocalizedString("lbl_Address"));

#line default
#line hidden
            EndContext();
            BeginContext(1926, 71, true);
            WriteLiteral("</th>\r\n                                <th style=\"text-align: center;\">");
            EndContext();
            BeginContext(1998, 47, false);
#line 37 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Store/Index.cshtml"
                                                           Write(StoreLocalizer.GetLocalizedString("lbl_Stocks"));

#line default
#line hidden
            EndContext();
            BeginContext(2045, 71, true);
            WriteLiteral("</th>\r\n                                <th style=\"text-align: center;\">");
            EndContext();
            BeginContext(2117, 48, false);
#line 38 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Store/Index.cshtml"
                                                           Write(StoreLocalizer.GetLocalizedString("lbl_ZipCode"));

#line default
#line hidden
            EndContext();
            BeginContext(2165, 71, true);
            WriteLiteral("</th>\r\n                                <th style=\"text-align: center;\">");
            EndContext();
            BeginContext(2237, 47, false);
#line 39 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Store/Index.cshtml"
                                                           Write(StoreLocalizer.GetLocalizedString("lbl_Action"));

#line default
#line hidden
            EndContext();
            BeginContext(2284, 117, true);
            WriteLiteral("</th>\r\n                            </tr>\r\n                            </thead>\r\n                            <tbody>\r\n");
            EndContext();
#line 43 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Store/Index.cshtml"
                               var stt = 0;

#line default
#line hidden
            BeginContext(2447, 28, true);
            WriteLiteral("                            ");
            EndContext();
#line 44 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Store/Index.cshtml"
                             foreach (var item in Model)
                            {
                                stt += 1;

#line default
#line hidden
            BeginContext(2579, 148, true);
            WriteLiteral("                                <tr>\r\n                                    <td style=\"text-align: center;\">\r\n                                        ");
            EndContext();
            BeginContext(2728, 3, false);
#line 49 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Store/Index.cshtml"
                                   Write(stt);

#line default
#line hidden
            EndContext();
            BeginContext(2731, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(2859, 44, false);
#line 52 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Store/Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.StoreName));

#line default
#line hidden
            EndContext();
            BeginContext(2903, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(3031, 40, false);
#line 55 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Store/Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
            EndContext();
            BeginContext(3071, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(3199, 40, false);
#line 58 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Store/Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Phone));

#line default
#line hidden
            EndContext();
            BeginContext(3239, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(3367, 41, false);
#line 61 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Store/Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Street));

#line default
#line hidden
            EndContext();
            BeginContext(3408, 2, true);
            WriteLiteral(", ");
            EndContext();
            BeginContext(3411, 39, false);
#line 61 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Store/Index.cshtml"
                                                                               Write(Html.DisplayFor(modelItem => item.City));

#line default
#line hidden
            EndContext();
            BeginContext(3450, 2, true);
            WriteLiteral(", ");
            EndContext();
            BeginContext(3453, 40, false);
#line 61 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Store/Index.cshtml"
                                                                                                                         Write(Html.DisplayFor(modelItem => item.State));

#line default
#line hidden
            EndContext();
            BeginContext(3493, 87, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n");
            EndContext();
#line 64 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Store/Index.cshtml"
                                          foreach (var stock in item.Stocks)
                                         {
                                             

#line default
#line hidden
            BeginContext(3748, 25, false);
#line 66 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Store/Index.cshtml"
                                        Write(stock.Product.ProductName);

#line default
#line hidden
            EndContext();
            BeginContext(3773, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(3776, 2, true);
            WriteLiteral(": ");
            EndContext();
            BeginContext(3779, 14, false);
#line 66 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Store/Index.cshtml"
                                                                       Write(stock.Quantity);

#line default
#line hidden
            EndContext();
            BeginContext(3793, 9, true);
            WriteLiteral(" <br />\r\n");
            EndContext();
#line 67 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Store/Index.cshtml"
                                         }

#line default
#line hidden
            BeginContext(3846, 125, true);
            WriteLiteral("                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(3972, 42, false);
#line 70 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Store/Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.ZipCode));

#line default
#line hidden
            EndContext();
            BeginContext(4014, 155, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td style=\"text-align: center;\">\r\n                                        ");
            EndContext();
            BeginContext(4169, 212, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3c4037cf3243b5f913b1dfa4f6a65d2c7be1395221040", async() => {
                BeginContext(4214, 163, true);
                WriteLiteral("\r\n                                            <i class=\"mdi mdi-grease-pencil\" style=\"font-size: 24px; color: black\"></i>\r\n                                        ");
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
#line 73 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Store/Index.cshtml"
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
            BeginContext(4381, 42, true);
            WriteLiteral("\r\n                                        ");
            EndContext();
            BeginContext(4423, 350, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3c4037cf3243b5f913b1dfa4f6a65d2c7be1395223583", async() => {
                BeginContext(4598, 171, true);
                WriteLiteral("\r\n                                            <i class=\"fa fa-trash\" style=\"font-size: 24px; color: red; padding-left: 5px;\"></i>\r\n                                        ");
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
#line 76 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Store/Index.cshtml"
                                                                 WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "onclick", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 4524, "return", 4524, 6, true);
            AddHtmlAttributeValue(" ", 4530, "confirm(\'", 4531, 10, true);
#line 77 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Store/Index.cshtml"
AddHtmlAttributeValue("", 4540, StoreLocalizer.GetLocalizedString("msg_DeleteStore"), 4540, 53, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 4593, "\');", 4593, 3, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4773, 84, true);
            WriteLiteral("\r\n                                    </td>\r\n                                </tr>\r\n");
            EndContext();
#line 82 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Store/Index.cshtml"
                            }

#line default
#line hidden
            BeginContext(4888, 178, true);
            WriteLiteral("                            </tbody>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<StoreViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
