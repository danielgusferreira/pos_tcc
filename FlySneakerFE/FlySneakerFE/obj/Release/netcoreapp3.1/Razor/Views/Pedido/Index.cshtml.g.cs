#pragma checksum "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Pedido\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d80ead6692d56a3a4a9087e998ae88f1cf7d0d2b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pedido_Index), @"mvc.1.0.view", @"/Views/Pedido/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d80ead6692d56a3a4a9087e998ae88f1cf7d0d2b", @"/Views/Pedido/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"392a9d34d66921618acec0d84c1e574af1f6b2b3", @"/Views/_ViewImports.cshtml")]
    public class Views_Pedido_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FlySneakerFE.Models.ConfirmarPedidoDto>
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Pedido\Index.cshtml"
  
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d80ead6692d56a3a4a9087e998ae88f1cf7d0d2b4445", async() => {
                WriteLiteral(@"
    <div class=""container"">
        <br />
        <br />
        <div class=""row"">
            <div class=""col"">
                <h4>Pedidos</h4>
            </div>
            <div class=""col-6"">
            </div>
            <div class=""col"">
                ");
#nullable restore
#line 35 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Pedido\Index.cshtml"
           Write(Html.ActionLink("Continuar comprando", "Index", "Home", null, new { @class = "btn btn-outline-primary text-center" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            </div>
        </div>
        <br />
        <br />
        <div class=""row"">
            <div class=""col-8"">
                <div class=""card"">
                    <div class=""card-body"">
                        <h3>Confira os dados abaixo e finalize a compra</h3>
                        <div class=""row"">
                            <div class=""col col-lg-4"">
                                CPF: ");
#nullable restore
#line 47 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Pedido\Index.cshtml"
                                Write(Model.UsuarioDados.Cpf);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </div>\r\n                            <div class=\"col col-lg-4\">\r\n                                Nascimento: ");
#nullable restore
#line 50 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Pedido\Index.cshtml"
                                       Write(Model.UsuarioDados.DataNascimento.ToShortDateString());

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </div>\r\n                            <div class=\"col col-lg-4\">\r\n                                Telefone: ");
#nullable restore
#line 53 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Pedido\Index.cshtml"
                                     Write(Model.UsuarioDados.Telefone);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col col-lg-4\">\r\n                                CEP: ");
#nullable restore
#line 58 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Pedido\Index.cshtml"
                                Write(Model.UsuarioDados.Cep);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </div>\r\n                            <div class=\"col col-lg-8\">\r\n                                Endereço: ");
#nullable restore
#line 61 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Pedido\Index.cshtml"
                                     Write(Model.UsuarioDados.Endereco);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col col-lg-4\">\r\n                                Número: ");
#nullable restore
#line 66 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Pedido\Index.cshtml"
                                   Write(Model.UsuarioDados.Numero);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </div>\r\n                            <div class=\"col col-lg-4\">\r\n                                Complemento: ");
#nullable restore
#line 69 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Pedido\Index.cshtml"
                                        Write(Model.UsuarioDados.Complemento);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </div>\r\n                            <div class=\"col col-lg-4\">\r\n                                Cidade: ");
#nullable restore
#line 72 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Pedido\Index.cshtml"
                                   Write(Model.UsuarioDados.Cidade);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col col-lg-4\">\r\n                                Bairro: ");
#nullable restore
#line 77 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Pedido\Index.cshtml"
                                   Write(Model.UsuarioDados.Bairro);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </div>\r\n                            <div class=\"col col-lg-4\">\r\n                                UF: ");
#nullable restore
#line 80 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Pedido\Index.cshtml"
                               Write(Model.UsuarioDados.Uf);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-4"">
                <div class=""card"">
                    <div class=""card-body"">
                        <div class=""row"">
                            <div class=""col"">
                                <h5>Escolha o tipo de pagamento: </h5>
                            </div>
                        </div>
                        <div class=""row"">
                            <div class=""col"">
                                <select name=""codigoMeioPagamento"" class=""form-select"" aria-label=""Default select example"">
");
#nullable restore
#line 97 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Pedido\Index.cshtml"
                                     foreach (var item in Model.MeioPagamento)
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d80ead6692d56a3a4a9087e998ae88f1cf7d0d2b11303", async() => {
                    WriteLiteral("  ");
#nullable restore
#line 99 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Pedido\Index.cshtml"
                                                                  Write(item.Nome);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 99 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Pedido\Index.cshtml"
                                           WriteLiteral(item.Codigo);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 100 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Pedido\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                </select>\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col\">\r\n                                <h5>Valor Pedido: ");
#nullable restore
#line 106 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Pedido\Index.cshtml"
                                             Write(Model.ValorPedido);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </h5>\r\n                            </div>\r\n                        </div>\r\n                        <input type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 4510, "\"", 4532, 1);
#nullable restore
#line 109 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Pedido\Index.cshtml"
WriteAttributeValue("", 4518, Model.Codigos, 4518, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" name=""codigosCarrinhos"">

                        <button class=""btn btn-outline-dark flex-shrink-0"" type=""submit"">
                            <i class=""bi-cart-fill me-1""></i>
                            Finalizar Pedido
                        </button>
                    </div>
                </div>
            </div>
        </div>

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
#line 24 "C:\Users\danie\OneDrive\Área de Trabalho\pos_tcc\FlySneakerFE\FlySneakerFE\Views\Pedido\Index.cshtml"
AddHtmlAttributeValue("", 596, Url.Action("Index", "Pedido"), 596, 30, false);

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FlySneakerFE.Models.ConfirmarPedidoDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
