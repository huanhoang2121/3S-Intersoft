#pragma checksum "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Error/Error400.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b81cd357885fc39b32fe02d17e3287d31e40aa23"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Error_Error400), @"mvc.1.0.view", @"/Views/Error/Error400.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Error/Error400.cshtml", typeof(AspNetCore.Views_Error_Error400))]
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
#line 1 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Error/Error400.cshtml"
using LoggingCodefirst.Services;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b81cd357885fc39b32fe02d17e3287d31e40aa23", @"/Views/Error/Error400.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"084beeae2ac9f6e40ae781fbeb71ad2ef457af1e", @"/Views/_ViewImports.cshtml")]
    public class Views_Error_Error400 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Error/Error400.cshtml"
  
    ViewBag.Title = "400";
    Layout = "_ErrorLayout";

#line default
#line hidden
            BeginContext(94, 110, true);
            WriteLiteral("\n<div class=\"error-box\">\n    <div class=\"error-body text-center\">\n        <h1 class=\"error-title text-danger\">");
            EndContext();
            BeginContext(205, 13, false);
#line 9 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Error/Error400.cshtml"
                                       Write(ViewBag.Title);

#line default
#line hidden
            EndContext();
            BeginContext(218, 41, true);
            WriteLiteral("</h1>\n        <h3 class=\"text-uppercase\">");
            EndContext();
            BeginContext(260, 45, false);
#line 10 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Error/Error400.cshtml"
                              Write(Localizer.GetLocalizedString("err_400_Title"));

#line default
#line hidden
            EndContext();
            BeginContext(305, 50, true);
            WriteLiteral("</h3>\n        <p class=\"text-muted m-t-30 m-b-30\">");
            EndContext();
            BeginContext(356, 46, false);
#line 11 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Error/Error400.cshtml"
                                       Write(Localizer.GetLocalizedString("err_400_Detail"));

#line default
#line hidden
            EndContext();
            BeginContext(402, 116, true);
            WriteLiteral("</p>\n        <a href=\"javascript:history.go(-1)\" class=\"btn btn-danger btn-rounded waves-effect waves-light m-b-40\">");
            EndContext();
            BeginContext(519, 40, false);
#line 12 "/home/local/3SI/huan.hv/3S-Intersoft/LoggingCodefirst/LoggingCodefirst/Views/Error/Error400.cshtml"
                                                                                                          Write(Localizer.GetLocalizedString("btn_Back"));

#line default
#line hidden
            EndContext();
            BeginContext(559, 18, true);
            WriteLiteral("</a> </div>\n</div>");
            EndContext();
        }
        #pragma warning restore 1998
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
