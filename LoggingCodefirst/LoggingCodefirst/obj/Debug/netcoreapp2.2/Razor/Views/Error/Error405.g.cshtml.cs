#pragma checksum "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Error/Error405.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e1f3cef3f67cfc9899898819a211f832be0c5178"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Error_Error405), @"mvc.1.0.view", @"/Views/Error/Error405.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Error/Error405.cshtml", typeof(AspNetCore.Views_Error_Error405))]
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
using LoggingCodefirst.Models;

#line default
#line hidden
#line 1 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Error/Error405.cshtml"
using LoggingCodefirst.Resources;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e1f3cef3f67cfc9899898819a211f832be0c5178", @"/Views/Error/Error405.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5b10f8ec59eaf4a7ae527c540e899f60e2f12309", @"/Views/_ViewImports.cshtml")]
    public class Views_Error_Error405 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(34, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 4 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Error/Error405.cshtml"
  
    ViewBag.Title = Localizer.GetLocalizedString("405");
    Layout = "_ErrorLayout";

#line default
#line hidden
            BeginContext(164, 110, true);
            WriteLiteral("\n<div class=\"error-box\">\n    <div class=\"error-body text-center\">\n        <h1 class=\"error-title text-danger\">");
            EndContext();
            BeginContext(275, 13, false);
#line 11 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Error/Error405.cshtml"
                                       Write(ViewBag.Title);

#line default
#line hidden
            EndContext();
            BeginContext(288, 41, true);
            WriteLiteral("</h1>\n        <h3 class=\"text-uppercase\">");
            EndContext();
            BeginContext(330, 51, false);
#line 12 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Error/Error405.cshtml"
                              Write(Localizer.GetLocalizedString("Method not allowed!"));

#line default
#line hidden
            EndContext();
            BeginContext(381, 50, true);
            WriteLiteral("</h3>\n        <p class=\"text-muted m-t-30 m-b-30\">");
            EndContext();
            BeginContext(432, 92, false);
#line 13 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Error/Error405.cshtml"
                                       Write(Localizer.GetLocalizedString("The requested request method is not accepted on this server."));

#line default
#line hidden
            EndContext();
            BeginContext(524, 116, true);
            WriteLiteral("</p>\n        <a href=\"javascript:history.go(-1)\" class=\"btn btn-danger btn-rounded waves-effect waves-light m-b-40\">");
            EndContext();
            BeginContext(641, 36, false);
#line 14 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Error/Error405.cshtml"
                                                                                                          Write(Localizer.GetLocalizedString("Back"));

#line default
#line hidden
            EndContext();
            BeginContext(677, 18, true);
            WriteLiteral("</a> </div>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
