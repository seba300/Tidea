#pragma checksum "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Campaign/CampaignCatalog.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7608ec7eb431486277268f4b934ac74d337222fc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Tidea.Web.Pages.Campaign.Pages_Campaign_CampaignCatalog), @"mvc.1.0.razor-page", @"/Pages/Campaign/CampaignCatalog.cshtml")]
namespace Tidea.Web.Pages.Campaign
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7608ec7eb431486277268f4b934ac74d337222fc", @"/Pages/Campaign/CampaignCatalog.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de1249599f7fdd7e8f091e0dc9835e5ebd63ce55", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Campaign_CampaignCatalog : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "Campaign/Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("stretched-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./CampaignCatalog", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("page-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
            WriteLiteral(@"<style>
     /*Zoom image and fill the card*/
        .card-img-top {
            width: 100%;
            height: 10vw;
            object-fit: cover;
        }
        /*Cut the Campaign description to 3 lines*/
        p {
            display: -webkit-box;
            -webkit-line-clamp: 4;
            -webkit-box-orient: vertical;
            overflow: hidden;
        }
</style>


    <!-- Cards -->
<div class=""row row-cols-2 row-cols-md-4 mt-lg-5"">
");
#nullable restore
#line 25 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Campaign/CampaignCatalog.cshtml"
     foreach(var x in Model.Campaigns)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col mb-4\">\n            <div class=\"card h-100\">\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7608ec7eb431486277268f4b934ac74d337222fc5397", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 29 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Campaign/CampaignCatalog.cshtml"
                                                 WriteLiteral(x.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                <img");
            BeginWriteAttribute("src", " src=\"", 747, "\"", 771, 1);
#nullable restore
#line 30 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Campaign/CampaignCatalog.cshtml"
WriteAttributeValue("", 753, x.Media.ImagePath, 753, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top\" alt=\"...\">\n                <div class=\"card-body\">\n                    <h5 class=\"card-title\"><strong>");
#nullable restore
#line 32 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Campaign/CampaignCatalog.cshtml"
                                              Write(x.CampaignName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></h5>\n                    <p class=\"card-text\">");
#nullable restore
#line 33 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Campaign/CampaignCatalog.cshtml"
                                    Write(x.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                </div>\n            </div>\n        </div>\n");
#nullable restore
#line 37 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Campaign/CampaignCatalog.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n\n<div>\n    <ul class=\"pagination\">\n");
#nullable restore
#line 42 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Campaign/CampaignCatalog.cshtml"
         for (var i = 1; i <= Model.TotalPages; i++)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li");
            BeginWriteAttribute("class", " class=\"", 1169, "\"", 1228, 2);
            WriteAttributeValue("", 1177, "page-item", 1177, 9, true);
#nullable restore
#line 44 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Campaign/CampaignCatalog.cshtml"
WriteAttributeValue(" ", 1186, i == Model.CurrentPage ? "active" : "", 1187, 41, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7608ec7eb431486277268f4b934ac74d337222fc9727", async() => {
#nullable restore
#line 45 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Campaign/CampaignCatalog.cshtml"
                                                                                        Write(i);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-currentpage", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 45 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Campaign/CampaignCatalog.cshtml"
                                                           WriteLiteral(i);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["currentpage"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-currentpage", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["currentpage"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n            </li>\n");
#nullable restore
#line 47 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Campaign/CampaignCatalog.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tidea.Web.Pages.Campaign.CampaignCatalog> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Tidea.Web.Pages.Campaign.CampaignCatalog> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Tidea.Web.Pages.Campaign.CampaignCatalog>)PageContext?.ViewData;
        public Tidea.Web.Pages.Campaign.CampaignCatalog Model => ViewData.Model;
    }
}
#pragma warning restore 1591
