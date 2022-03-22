#pragma checksum "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Order/CreateOrder.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f89ecb2cf57be2783d276c2ad6d16784da081f4a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Tidea.Web.Pages.Order.Pages_Order_CreateOrder), @"mvc.1.0.razor-page", @"/Pages/Order/CreateOrder.cshtml")]
namespace Tidea.Web.Pages.Order
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
#line 1 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/_ViewImports.cshtml"
using Tidea.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/_ViewImports.cshtml"
using Tidea.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/_ViewImports.cshtml"
using Tidea.Infrastructure;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f89ecb2cf57be2783d276c2ad6d16784da081f4a", @"/Pages/Order/CreateOrder.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de1249599f7fdd7e8f091e0dc9835e5ebd63ce55", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Order_CreateOrder : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
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
            WriteLiteral(@"
<style>
html,body{
            min-height: 100vh;
            min-width: 100vw;
        }
        .parent{
            min-height: 50vh;
        }
        .parent>.row{
            display: flex;
            align-items: center;
            height: 50%;
        }
        .col img{
            height:100px;
            width: 100%;
            cursor: pointer;
            transition: transform 1s;
            object-fit: cover;
        }
        .col label{
            overflow: hidden;
            position: relative;
        }
        /*Green check */
        .imgbgchk:checked + label>.tick_container{
            opacity: 1;
        }
        /*Animation */
        .imgbgchk:checked + label>img{
            transform: scale(1.15);
            opacity: 0.3;
        }
        .tick_container {
            transition: .5s ease;
            opacity: 0;
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            -ms-transform: translate(-5");
            WriteLiteral(@"0%, -50%);
            cursor: pointer;
            text-align: center;
        }
        .tick {
            background-color: #4CAF50;
            color: white;
            font-size: 16px;
            padding: 8px 12px;
            height: 40px;
            width: 40px;
            border-radius: 100%;
        }
</style>

<div class=""card card-collapsable"">

    <div class=""card-body pb-0 px-3 px-sm-4 mx-sm-4 mx-md-0 pt-md-4 mt-md-2 px-md-3"">
        <div class=""row"">
            <div class=""col-md-10 mx-auto"">
                <h3 class=""mb-2"" style=""text-align: center"">
                    Wybierz kwotę oraz sposób płatności
                </h3>
            </div>
        </div>
    </div>

    <hr/>
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f89ecb2cf57be2783d276c2ad6d16784da081f4a5446", async() => {
                WriteLiteral("\n    <div class=\"container mt-lg-3 w-50\" style=\"min-height: 20vh\">\n        <div class=\"row row-cols-2 row-cols-md-4\">\n");
#nullable restore
#line 75 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Order/CreateOrder.cshtml"
             for (int i = 0; i < 8; i++)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <div class=\"col text-center p-1\">\n                    <input type=\"radio\" name=\"checkedPaidIn\"");
                BeginWriteAttribute("id", " id=\"", 2093, "\"", 2100, 1);
#nullable restore
#line 78 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Order/CreateOrder.cshtml"
WriteAttributeValue("", 2098, i, 2098, 2, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"d-none imgbgchk\"");
                BeginWriteAttribute("value", " value=\"", 2125, "\"", 2153, 1);
#nullable restore
#line 78 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Order/CreateOrder.cshtml"
WriteAttributeValue("", 2133, Model.PaidInList[i], 2133, 20, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\n                    <label");
                BeginWriteAttribute("for", " for=\"", 2182, "\"", 2190, 1);
#nullable restore
#line 79 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Order/CreateOrder.cshtml"
WriteAttributeValue("", 2188, i, 2188, 2, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\n                        <button type=\"button\" class=\"text-center btn btn-lg border\"><i class=\"fa-solid fa-money-bill-wave\"></i> ");
#nullable restore
#line 80 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Order/CreateOrder.cshtml"
                                                                                                                           Write(Model.PaidInList[i]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@" zł</button>
                        <div class=""tick_container"">
                            <div class=""tick"">
                                <i class=""fa fa-check""></i>
                            </div>
                        </div>
                    </label>
                </div>
");
#nullable restore
#line 88 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Order/CreateOrder.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </div>\n    </div>\n\n    <hr/>\n    <div class=\"container parent \">\n            <div class=\"row row-cols-2 row-cols-md-4\">\n");
#nullable restore
#line 95 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Order/CreateOrder.cshtml"
                 foreach (var item in @Model.PayUMethods.payByLinks)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <div class=\"col text-center p-4\">\n                        <input type=\"radio\" name=\"checkedPayUMethod\"");
                BeginWriteAttribute("id", " id=\"", 2983, "\"", 2999, 1);
#nullable restore
#line 98 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Order/CreateOrder.cshtml"
WriteAttributeValue("", 2988, item.value, 2988, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"d-none imgbgchk\"");
                BeginWriteAttribute("value", " value=\"", 3024, "\"", 3043, 1);
#nullable restore
#line 98 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Order/CreateOrder.cshtml"
WriteAttributeValue("", 3032, item.value, 3032, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\n                        <label");
                BeginWriteAttribute("for", " for=\"", 3076, "\"", 3093, 1);
#nullable restore
#line 99 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Order/CreateOrder.cshtml"
WriteAttributeValue("", 3082, item.value, 3082, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\n                            <img");
                BeginWriteAttribute("src", " src=\"", 3128, "\"", 3153, 1);
#nullable restore
#line 100 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Order/CreateOrder.cshtml"
WriteAttributeValue("", 3134, item.brandImageUrl, 3134, 19, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" alt=""Image 1"" class=""w-50 h-auto text-center"">
                            <div class=""tick_container"">
                                <div class=""tick"">
                                    <i class=""fa fa-check""></i>
                                </div>
                            </div>
                        </label>
                    </div>
");
#nullable restore
#line 108 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Order/CreateOrder.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </div>\n        </div>\n        <button class=\"btn-block btn btn-outline-success\" type=\"submit\">Wpłać</button>\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tidea.Web.Pages.Order.CreateOrder> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Tidea.Web.Pages.Order.CreateOrder> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Tidea.Web.Pages.Order.CreateOrder>)PageContext?.ViewData;
        public Tidea.Web.Pages.Order.CreateOrder Model => ViewData.Model;
    }
}
#pragma warning restore 1591
