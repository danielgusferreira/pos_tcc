#pragma checksum "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "032ff447be149f02b388184c47335dafb8bcc033"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\_ViewImports.cshtml"
using FlySneakerFE;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\_ViewImports.cshtml"
using FlySneakerFE.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"032ff447be149f02b388184c47335dafb8bcc033", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"392a9d34d66921618acec0d84c1e574af1f6b2b3", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable< FlySneakerFE.Models.ProdutoPagInicialDto>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

    switch (ViewBag.PerfilUsuario)
    {
        case "1":
            Layout = "~/Views/Shared/_LayoutAdm.cshtml";
            break;
        case "2":
            Layout = "~/Views/Shared/_LayoutAdm.cshtml";
            break;
        case "3":
            Layout = "~/Views/Shared/_LayoutUsuario.cshtml";
            break;
        default:
            //Admin layout  
            Layout = "~/Views/Shared/_Layout.cshtml";
            break;
    }

    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n    <br />\r\n    <h4>Conheça nossas novidades</h4>\r\n    <br />\r\n    <div class=\"row align-items-start\">\r\n\r\n");
#nullable restore
#line 30 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Home\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col\">\r\n                <div class=\"card\" style=\"width: 18rem;\">\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 879, "\"", 895, 1);
#nullable restore
#line 34 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Home\Index.cshtml"
WriteAttributeValue("", 885, item.Foto, 885, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top\" alt=\"foto\">\r\n                    <div class=\"card-body\">\r\n                        <h5 class=\"card-title\">");
#nullable restore
#line 36 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Home\Index.cshtml"
                                          Write(item.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                        <p class=\"card-text\">");
#nullable restore
#line 37 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Home\Index.cshtml"
                                        Write(item.Valor);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        ");
#nullable restore
#line 38 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Home\Index.cshtml"
                   Write(Html.ActionLink("Detalhes", "Details", "Produto", new { codigo = @item.Codigo }, new { @class = "btn btn-outline-primary text-center" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <br />\r\n            </div>\r\n");
#nullable restore
#line 43 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable< FlySneakerFE.Models.ProdutoPagInicialDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
