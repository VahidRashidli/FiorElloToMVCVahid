#pragma checksum "C:\Users\User\OneDrive\Рабочий стол\C#Practise\Work\FiorElloToMVCVahid\TemplatePractice\Views\Shared\Components\Footer\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "83cbb2d7a919869ba0aeca1f634cb7030e1c998b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Footer_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Footer/Default.cshtml")]
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
#nullable restore
#line 1 "C:\Users\User\OneDrive\Рабочий стол\C#Practise\Work\FiorElloToMVCVahid\TemplatePractice\Views\_ViewImports.cshtml"
using TemplatePractice.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\OneDrive\Рабочий стол\C#Practise\Work\FiorElloToMVCVahid\TemplatePractice\Views\_ViewImports.cshtml"
using TemplatePractice.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"83cbb2d7a919869ba0aeca1f634cb7030e1c998b", @"/Views/Shared/Components/Footer/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f19231416f28f494ac3e92a9922fd3c67301c6c9", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Footer_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FooterInvokeViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<footer>\r\n    <div class=\"container\">\r\n        <div class=\"row py-5\">\r\n");
#nullable restore
#line 5 "C:\Users\User\OneDrive\Рабочий стол\C#Practise\Work\FiorElloToMVCVahid\TemplatePractice\Views\Shared\Components\Footer\Default.cshtml"
             foreach (FooterCategory footerCategory in Model.FooterCategories)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-md-6 col-lg-3\">\r\n                    <div class=\"item\">\r\n                        <h6>");
#nullable restore
#line 9 "C:\Users\User\OneDrive\Рабочий стол\C#Practise\Work\FiorElloToMVCVahid\TemplatePractice\Views\Shared\Components\Footer\Default.cshtml"
                       Write(footerCategory.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                        <ul class=\"list-unstyled mt-4\">\r\n");
#nullable restore
#line 11 "C:\Users\User\OneDrive\Рабочий стол\C#Practise\Work\FiorElloToMVCVahid\TemplatePractice\Views\Shared\Components\Footer\Default.cshtml"
                             foreach (FooterCategorySection footerCategorySection in footerCategory.footerCategorySections)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li><a class=\"text-black-50\"");
            BeginWriteAttribute("href", " href=\"", 613, "\"", 647, 1);
#nullable restore
#line 13 "C:\Users\User\OneDrive\Рабочий стол\C#Practise\Work\FiorElloToMVCVahid\TemplatePractice\Views\Shared\Components\Footer\Default.cshtml"
WriteAttributeValue("", 620, footerCategorySection.Link, 620, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 13 "C:\Users\User\OneDrive\Рабочий стол\C#Practise\Work\FiorElloToMVCVahid\TemplatePractice\Views\Shared\Components\Footer\Default.cshtml"
                                                                                           Write(footerCategorySection.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 14 "C:\Users\User\OneDrive\Рабочий стол\C#Practise\Work\FiorElloToMVCVahid\TemplatePractice\Views\Shared\Components\Footer\Default.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </ul>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 19 "C:\Users\User\OneDrive\Рабочий стол\C#Practise\Work\FiorElloToMVCVahid\TemplatePractice\Views\Shared\Components\Footer\Default.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n\r\n        <hr>\r\n");
#nullable restore
#line 23 "C:\Users\User\OneDrive\Рабочий стол\C#Practise\Work\FiorElloToMVCVahid\TemplatePractice\Views\Shared\Components\Footer\Default.cshtml"
         if (Model.Footer != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""row py-2"">
                <div class="" col-lg-4 text-center text-lg-left"">
                    <p class=""text-black-50"">
                        Powered by <a class=""author text-muted""
                                      href=""https://www.bakhtiyar.az"">Bakhtiyar Shamilzada</a> 2020
                    </p>
                </div>
                <div class=""col-lg-4 text-center"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "83cbb2d7a919869ba0aeca1f634cb7030e1c998b7619", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1344, "~/img/", 1344, 6, true);
#nullable restore
#line 33 "C:\Users\User\OneDrive\Рабочий стол\C#Practise\Work\FiorElloToMVCVahid\TemplatePractice\Views\Shared\Components\Footer\Default.cshtml"
AddHtmlAttributeValue("", 1350, Model.Footer.Image, 1350, 19, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col-lg-4 text-center text-lg-right mt-3 mt-lg-0\">\r\n                    <a class=\"text-black-50 mr-5\"");
            BeginWriteAttribute("href", "\r\n                       href=\"", 1546, "\"", 1603, 1);
#nullable restore
#line 37 "C:\Users\User\OneDrive\Рабочий стол\C#Practise\Work\FiorElloToMVCVahid\TemplatePractice\Views\Shared\Components\Footer\Default.cshtml"
WriteAttributeValue("", 1577, Model.Footer.LinkedInLink, 1577, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">LINKEDIN</a>\r\n                    <a class=\"text-black-50\"");
            BeginWriteAttribute("href", " href=\"", 1663, "\"", 1696, 1);
#nullable restore
#line 38 "C:\Users\User\OneDrive\Рабочий стол\C#Practise\Work\FiorElloToMVCVahid\TemplatePractice\Views\Shared\Components\Footer\Default.cshtml"
WriteAttributeValue("", 1670, Model.Footer.FacebookLink, 1670, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">FACEBOOK</a>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 41 "C:\Users\User\OneDrive\Рабочий стол\C#Practise\Work\FiorElloToMVCVahid\TemplatePractice\Views\Shared\Components\Footer\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</footer>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FooterInvokeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
