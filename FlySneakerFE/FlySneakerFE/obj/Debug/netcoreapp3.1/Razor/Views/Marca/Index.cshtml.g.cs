#pragma checksum "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Marca\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9873dae968acd8522494bc43b10cd47359405f72"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Marca_Index), @"mvc.1.0.view", @"/Views/Marca/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9873dae968acd8522494bc43b10cd47359405f72", @"/Views/Marca/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"392a9d34d66921618acec0d84c1e574af1f6b2b3", @"/Views/_ViewImports.cshtml")]
    public class Views_Marca_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FlySneakerFE.Models.MarcasDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Marca\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

    switch (ViewBag.PerfilUsuario)
    {
        case "1":
            Layout = "~/Views/Shared/_LayoutAdm.cshtml";
            break;
        case "2":
            Layout = "~/Views/Shared/_LayoutFunc.cshtml";
            break;
    }

    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container-fluid h-custom\">\r\n    <br />\r\n    <h4>Marcas</h4>\r\n    <br />\r\n    <div class=\"row d-flex justify-content-center align-items-center h-100\">\r\n        <div class=\"col-md-8 col-lg-6 col-xl-4 offset-xl-1\">\r\n");
#nullable restore
#line 23 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Marca\Index.cshtml"
              
                if (ViewBag.Mensagem != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"alert alert-success\" role=\"alert\">\r\n                        ");
#nullable restore
#line 27 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Marca\Index.cshtml"
                   Write(ViewBag.Mensagem);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 29 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Marca\Index.cshtml"
                }
                if (ViewBag.Erro != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"alert alert-danger\" role=\"alert\">\r\n                        ");
#nullable restore
#line 33 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Marca\Index.cshtml"
                   Write(ViewBag.Erro);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 35 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Marca\Index.cshtml"
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9873dae968acd8522494bc43b10cd47359405f725937", async() => {
                WriteLiteral("\r\n                <input type=\"hidden\" id=\"custId\" name=\"codigo\"");
                BeginWriteAttribute("value", " value=\"", 1168, "\"", 1190, 1);
#nullable restore
#line 38 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Marca\Index.cshtml"
WriteAttributeValue("", 1176, Model?.Codigo, 1176, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                <div class=\"form-outline mb-4\">\r\n                    <input type=\"text\" id=\"form3Example3\" class=\"form-control form-control-lg\"\r\n                           placeholder=\"Nome\" name=\"nome\"");
                BeginWriteAttribute("value", " value=\'", 1396, "\'", 1416, 1);
#nullable restore
#line 41 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Marca\Index.cshtml"
WriteAttributeValue("", 1404, Model?.Nome, 1404, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                </div>\r\n                <div class=\"form-outline mb-4\">\r\n                    <textarea id=\"form3Example3\" class=\"form-control form-control-lg\"\r\n                              placeholder=\"Descrição\" name=\"descricao\"");
                BeginWriteAttribute("value", " value=\'", 1652, "\'", 1677, 1);
#nullable restore
#line 45 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Marca\Index.cshtml"
WriteAttributeValue("", 1660, Model?.Descricao, 1660, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 45 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Marca\Index.cshtml"
                                                                                            Write(Model?.Descricao);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</textarea>
                </div>
                <div class=""text-center text-lg-start mt-4 pt-2"">
                    <button type=""submit"" class=""btn btn-outline-dark flex-shrink-0 text-center""
                            style=""padding-left: 2.5rem; padding-right: 2.5rem;"">
                        Cadastrar
                    </button>
                    <br />
                    <br />
                </div>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 37 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Marca\Index.cshtml"
AddHtmlAttributeValue("", 1073, Url.Action("Index", "Marca"), 1073, 29, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </div>
        <div class=""col-md-12 col-lg-12 col-xl-12 offset-xl-1"">
            <table id=""dtBasicExample"" class=""table table-striped table-bordered table-sm"" cellspacing=""0"" width=""100%"">
                <thead>
                    <tr>
                        <th class=""th-sm"">Código</th>
                        <th class=""th-sm"">Nome</th>
                        <th class=""th-sm"">Descrição</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 67 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Marca\Index.cshtml"
                     foreach (var item in Model.Marcas)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 70 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Marca\Index.cshtml"
                           Write(item.Codigo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 71 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Marca\Index.cshtml"
                           Write(item.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 72 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Marca\Index.cshtml"
                           Write(item.Descricao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 74 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Marca\Index.cshtml"
                           Write(Html.ActionLink("Editar", "Editar", "Marca", new { codigo = item.Codigo }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 77 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Marca\Index.cshtml"
                           Write(Html.ActionLink("Excluir", "Excluir", "Marca", new { codigo = item.Codigo, nome = item.Nome, descricao = item.Descricao }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 80 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Marca\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<script>\r\n    $(document).ready(function () {\r\n        $(\'#dtBasicExample\').DataTable();\r\n        $(\'.dataTables_length\').addClass(\'bs-select\');\r\n    });\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FlySneakerFE.Models.MarcasDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
