#pragma checksum "C:\Users\mu030\source\repos\Khinkali\Khinkali\Views\Khinkali\About.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5c00f4f82ef8cb3728d0c9902904e4bfd7f2c685"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Khinkali_About), @"mvc.1.0.view", @"/Views/Khinkali/About.cshtml")]
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
#line 1 "C:\Users\mu030\source\repos\Khinkali\Khinkali\Views\_ViewImports.cshtml"
using Khinkali;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\mu030\source\repos\Khinkali\Khinkali\Views\_ViewImports.cshtml"
using Khinkali.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c00f4f82ef8cb3728d0c9902904e4bfd7f2c685", @"/Views/Khinkali/About.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"97f8e52208c34434979c1a8334864699d96edc3b", @"/Views/_ViewImports.cshtml")]
    public class Views_Khinkali_About : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\mu030\source\repos\Khinkali\Khinkali\Views\Khinkali\About.cshtml"
  
    if (Model != null)
    {
        ViewData["Title"] = @Model.Name;
    }
    else
    {
        ViewData["Title"] = "Хинкали";
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"jumbotron mt-2\">\r\n    <div class=\"card text-center mt-5\">\r\n        <div class=\"card\" style=\"max-width: 1300px;\">\r\n            <div class=\"row\">\r\n");
#nullable restore
#line 16 "C:\Users\mu030\source\repos\Khinkali\Khinkali\Views\Khinkali\About.cshtml"
                  
                    if (Model != null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"col-md-6\">\r\n                            <img");
            BeginWriteAttribute("src", " src=\"", 473, "\"", 491, 1);
#nullable restore
#line 20 "C:\Users\mu030\source\repos\Khinkali\Khinkali\Views\Khinkali\About.cshtml"
WriteAttributeValue("", 479, Model.Image, 479, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"height: 100%;\" class=\"img-fluid rounded-start\"");
            BeginWriteAttribute("alt", " alt=\"", 546, "\"", 552, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        </div>\r\n                        <div class=\"col-md-6\">\r\n                            <div class=\"card-body my-5\">\r\n                                <h3 class=\"card-title\">");
#nullable restore
#line 24 "C:\Users\mu030\source\repos\Khinkali\Khinkali\Views\Khinkali\About.cshtml"
                                                  Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                                <h5 class=\"card-title\">Состав:</h5>\r\n                                <p class=\"card-text\">");
#nullable restore
#line 26 "C:\Users\mu030\source\repos\Khinkali\Khinkali\Views\Khinkali\About.cshtml"
                                                Write(Model.Compound);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <p class=\"card-text\"><small class=\"text-muted\">Кол-во: ");
#nullable restore
#line 27 "C:\Users\mu030\source\repos\Khinkali\Khinkali\Views\Khinkali\About.cshtml"
                                                                                  Write(Model.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" шт. &ensp; Начинка: ");
#nullable restore
#line 27 "C:\Users\mu030\source\repos\Khinkali\Khinkali\Views\Khinkali\About.cshtml"
                                                                                                                    Write(Model.Filling);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small></p>\r\n                                <div class=\"d-flex justify-content-between align-items-center mt-3\">\r\n                                    <h3>Цена: ");
#nullable restore
#line 29 "C:\Users\mu030\source\repos\Khinkali\Khinkali\Views\Khinkali\About.cshtml"
                                         Write(Model.Cost);

#line default
#line hidden
#nullable disable
            WriteLiteral("₽</h3>\r\n                                    <a href=\"#\" class=\"btn btn-outline-success float-right\">В корзину</a>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 34 "C:\Users\mu030\source\repos\Khinkali\Khinkali\Views\Khinkali\About.cshtml"
                    }
                

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
