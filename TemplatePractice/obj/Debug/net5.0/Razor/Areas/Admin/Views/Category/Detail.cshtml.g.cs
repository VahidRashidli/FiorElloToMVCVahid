#pragma checksum "C:\Users\User\OneDrive\Рабочий стол\C#Practise\Work\FiorElloToMVCVahid\TemplatePractice\Areas\Admin\Views\Category\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "83c18b5ec048e534a667528d62b39a4eec38ed69"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Category_Detail), @"mvc.1.0.view", @"/Areas/Admin/Views/Category/Detail.cshtml")]
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
#line 1 "C:\Users\User\OneDrive\Рабочий стол\C#Practise\Work\FiorElloToMVCVahid\TemplatePractice\Areas\Admin\Views\_ViewImports.cshtml"
using TemplatePractice.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\OneDrive\Рабочий стол\C#Practise\Work\FiorElloToMVCVahid\TemplatePractice\Areas\Admin\Views\_ViewImports.cshtml"
using TemplatePractice.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\OneDrive\Рабочий стол\C#Practise\Work\FiorElloToMVCVahid\TemplatePractice\Areas\Admin\Views\_ViewImports.cshtml"
using TemplatePractice.Areas.Admin.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"83c18b5ec048e534a667528d62b39a4eec38ed69", @"/Areas/Admin/Views/Category/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dac7d07f8d5ce76eeef9be1234712530bcb463d4", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Category_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Category>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""row"">
    <div class=""col-lg-12 grid-margin stretch-card"">
        <div class=""card"">
            <div class=""card-body"">
                <h4 class=""card-title""> Category Detail </h4>
                <div class=""table-responsive pt-3"">
                    <table class=""table table-dark"">
                        <thead>
                            <tr>
                                <th>
                                    Category Id
                                </th>
                                <th>
                                    Category Name
                                </th>
                                <th>
                                    Category Description
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>");
#nullable restore
#line 24 "C:\Users\User\OneDrive\Рабочий стол\C#Practise\Work\FiorElloToMVCVahid\TemplatePractice\Areas\Admin\Views\Category\Detail.cshtml"
                               Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 25 "C:\Users\User\OneDrive\Рабочий стол\C#Practise\Work\FiorElloToMVCVahid\TemplatePractice\Areas\Admin\Views\Category\Detail.cshtml"
                               Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 26 "C:\Users\User\OneDrive\Рабочий стол\C#Practise\Work\FiorElloToMVCVahid\TemplatePractice\Areas\Admin\Views\Category\Detail.cshtml"
                               Write(Html.Raw(Model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n   \r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Category> Html { get; private set; }
    }
}
#pragma warning restore 1591