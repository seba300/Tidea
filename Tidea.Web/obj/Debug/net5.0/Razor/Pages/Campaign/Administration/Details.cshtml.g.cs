#pragma checksum "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Campaign/Administration/Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "51dab918ef528fddb16c24841f6e3d4838e0bacc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Tidea.Web.Pages.Campaign.Administration.Pages_Campaign_Administration_Details), @"mvc.1.0.razor-page", @"/Pages/Campaign/Administration/Details.cshtml")]
namespace Tidea.Web.Pages.Campaign.Administration
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"51dab918ef528fddb16c24841f6e3d4838e0bacc", @"/Pages/Campaign/Administration/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de1249599f7fdd7e8f091e0dc9835e5ebd63ce55", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Campaign_Administration_Details : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Campaign/Administration/Details.cshtml"
  
    ViewData["Title"] = "Details";
  

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral(@"
<style>
    img {
        max-width: 100%;
        height: auto;
    }
    
</style>


<div class=""container-fluid"">
    <div class=""row"">
        <div class=""col-md-8 "">
            <div class=""row"">
                <div class=""pb-3 pt-3 col-md-12 text-center"">
                    <h1>");
#nullable restore
#line 28 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Campaign/Administration/Details.cshtml"
                   Write(Model.Campaign.CampaignName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                </div>\r\n            </div>\r\n            <div class=\"row\">\r\n                <div class=\"col-md-12\" style=\"min-height: 50vh;max-height: 60vh;\">\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 754, "\"", 776, 1);
#nullable restore
#line 33 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Campaign/Administration/Details.cshtml"
WriteAttributeValue("", 760, Model.ImagePath, 760, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid\" style=\'height: 100%; width: auto; object-fit: cover; border-radius: 7%\'/>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-8  pt-3\">\r\n            ");
#nullable restore
#line 40 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Campaign/Administration/Details.cshtml"
       Write(Html.Raw(Model.Campaign.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DetailsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DetailsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DetailsModel>)PageContext?.ViewData;
        public DetailsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
