#pragma checksum "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\CadastroFuncionario\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f61863945fb312a2480f13c57055b55a17f07739"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CadastroFuncionario_Index), @"mvc.1.0.view", @"/Views/CadastroFuncionario/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f61863945fb312a2480f13c57055b55a17f07739", @"/Views/CadastroFuncionario/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"392a9d34d66921618acec0d84c1e574af1f6b2b3", @"/Views/_ViewImports.cshtml")]
    public class Views_CadastroFuncionario_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FlySneakerFE.Models.CadastroFuncionarioDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\CadastroFuncionario\Index.cshtml"
  
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
            WriteLiteral("\r\n<div class=\"container-fluid h-custom\">\r\n    <br />\r\n    <br />\r\n    <div class=\"row d-flex justify-content-center align-items-center h-100\">\r\n        <div class=\"col-md-8 col-lg-6 col-xl-4 offset-xl-1\">\r\n");
#nullable restore
#line 22 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\CadastroFuncionario\Index.cshtml"
              
                if (ViewBag.Mensagem != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"alert alert-success\" role=\"alert\">\r\n                        ");
#nullable restore
#line 26 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\CadastroFuncionario\Index.cshtml"
                   Write(ViewBag.Mensagem);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 28 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\CadastroFuncionario\Index.cshtml"
                }
                if (ViewBag.Erro != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"alert alert-danger\" role=\"alert\">\r\n                        ");
#nullable restore
#line 32 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\CadastroFuncionario\Index.cshtml"
                   Write(ViewBag.Erro);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 34 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\CadastroFuncionario\Index.cshtml"
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f61863945fb312a2480f13c57055b55a17f077396791", async() => {
                WriteLiteral("\r\n            <input type=\"hidden\" id=\"custId\" name=\"codigo\"");
                BeginWriteAttribute("value", " value=\"", 1166, "\"", 1188, 1);
#nullable restore
#line 37 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\CadastroFuncionario\Index.cshtml"
WriteAttributeValue("", 1174, Model?.Codigo, 1174, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
            <div class=""form-outline mb-4"">
                <input type=""text"" id=""form3Example3"" class=""form-control form-control-lg""
                       placeholder=""Nome"" name=""nome"" />
            </div>
            <div class=""form-outline mb-4"">
                <input type=""email"" id=""form3Example3"" class=""form-control form-control-lg""
                       placeholder=""Email"" name=""email"" />
            </div>
            <div class=""form-outline mb-3"">
                <input type=""password"" id=""form3Example4"" class=""form-control form-control-lg""
                       placeholder=""Senha"" name=""senha"" />
            </div>
            <div class=""form-outline mb-3"">
                <input type=""password"" id=""form3Example4"" class=""form-control form-control-lg""
                       placeholder=""Confirmar Senha"" name=""confirmarSenha"" />
            </div>
            <div class=""form-outline mb-4"">
                <input type=""number"" id=""form3Example3"" class=""form-control form-c");
                WriteLiteral(@"ontrol-lg""
                       placeholder=""CPF"" name=""cpf"" />
            </div>
            <div class=""form-outline mb-4"">
                <input type=""date"" id=""form3Example3"" class=""form-control form-control-lg""
                       placeholder=""Data Nascimento"" name=""dataNascimento"" />
            </div>
            <div class=""form-outline mb-3"">
                <input type=""tel"" id=""form3Example4"" class=""form-control form-control-lg""
                       placeholder=""Telefone"" name=""telefone"" />
            </div>
            <div class=""form-outline mb-3"">
                <input type=""text"" id=""form3Example4"" class=""form-control form-control-lg""
                       placeholder=""CEP"" name=""cep"" />
            </div>
            <div class=""form-outline mb-3"">
                <input type=""text"" id=""form3Example4"" class=""form-control form-control-lg""
                       placeholder=""Endereço"" name=""endereco"" />
            </div>
            <div class=""form-outline mb-3""");
                WriteLiteral(@">
                <input type=""text"" id=""form3Example4"" class=""form-control form-control-lg""
                       placeholder=""Número"" name=""numero"" />
            </div>
            <div class=""form-outline mb-3"">
                <input type=""text"" id=""form3Example4"" class=""form-control form-control-lg""
                       placeholder=""Complemento"" name=""complemento"" />
            </div>
            <div class=""form-outline mb-3"">
                <input type=""text"" id=""form3Example4"" class=""form-control form-control-lg""
                       placeholder=""Bairro"" name=""bairro"" />
            </div>
            <div class=""form-outline mb-3"">
                <input type=""text"" id=""form3Example4"" class=""form-control form-control-lg""
                       placeholder=""Cidade"" name=""cidade"" />
            </div>
            <div class=""form-outline mb-3"">
                <input type=""text"" id=""form3Example4"" class=""form-control form-control-lg""
                       placeholder=""UF"" nam");
                WriteLiteral("e=\"uf\" />\r\n            </div>\r\n            <div class=\"form-outline mb-3\">\r\n                <select name=\"codigoTipoUsuario\" class=\"form-select\" aria-label=\"Default select example\">\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f61863945fb312a2480f13c57055b55a17f0773911093", async() => {
                    WriteLiteral(" Administrador");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f61863945fb312a2480f13c57055b55a17f0773912345", async() => {
                    WriteLiteral(" Funcionário");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                </select>
            </div>
            <div class=""text-center text-lg-start mt-4 pt-2"">
                <button type=""submit"" class=""btn btn-outline-dark flex-shrink-0 text-center""
                        style=""padding-left: 2.5rem; padding-right: 2.5rem;"">
                    Cadastrar
                </button>
            </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 36 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\CadastroFuncionario\Index.cshtml"
AddHtmlAttributeValue("", 1061, Url.Action("Index", "CadastroFuncionario"), 1061, 43, false);

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
            <table id=""dtBasicExample"" class=""table table-striped table-bordered table-sm"" cellspacing=""0"" width=""100%"">
                <thead>
                    <tr>
                        <th class=""th-sm"">Código</th>
                        <th class=""th-sm"">Nome</th>
                        <th class=""th-sm"">Email</th>
                        <th class=""th-sm"">Cpf</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 117 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\CadastroFuncionario\Index.cshtml"
                     foreach (var item in Model.UsuariosDtos)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 120 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\CadastroFuncionario\Index.cshtml"
                       Write(item.Codigo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 121 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\CadastroFuncionario\Index.cshtml"
                       Write(item.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 122 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\CadastroFuncionario\Index.cshtml"
                       Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 123 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\CadastroFuncionario\Index.cshtml"
                       Write(item.Cpf);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 125 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\CadastroFuncionario\Index.cshtml"
                       Write(Html.ActionLink("Editar", "Editar", "CadastroFuncionario", new { codigo = item.Codigo }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 128 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\CadastroFuncionario\Index.cshtml"
                       Write(Html.ActionLink("Excluir", "Excluir", "CadastroFuncionario", new { codigo = item.Codigo }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 131 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\CadastroFuncionario\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FlySneakerFE.Models.CadastroFuncionarioDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
