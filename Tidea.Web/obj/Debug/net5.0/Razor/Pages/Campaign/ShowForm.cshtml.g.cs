#pragma checksum "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Campaign/ShowForm.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8ec6e58ffa44c06bf95ed2c9d9acbd7b05fd9c7f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Tidea.Web.Pages.Campaign.Pages_Campaign_ShowForm), @"mvc.1.0.razor-page", @"/Pages/Campaign/ShowForm.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ec6e58ffa44c06bf95ed2c9d9acbd7b05fd9c7f", @"/Pages/Campaign/ShowForm.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de1249599f7fdd7e8f091e0dc9835e5ebd63ce55", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Campaign_ShowForm : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 7 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Campaign/ShowForm.cshtml"
Write(Html.Raw(Model.Campaign.CampaignName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 8 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Campaign/ShowForm.cshtml"
Write(Html.Raw(Model.Campaign.CampaignIntroduction));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 9 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Campaign/ShowForm.cshtml"
Write(Html.Raw(Model.Campaign.CampaignPurpose));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 10 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Campaign/ShowForm.cshtml"
Write(Html.Raw(Model.Campaign.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 11 "/Users/Dom/Desktop/Praca Dyplomowa/Tidea/Tidea.Web/Pages/Campaign/ShowForm.cshtml"
Write(Html.Raw(Model.Campaign.CampaignEndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tidea.Web.Pages.Campaign.ShowForm> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Tidea.Web.Pages.Campaign.ShowForm> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Tidea.Web.Pages.Campaign.ShowForm>)PageContext?.ViewData;
        public Tidea.Web.Pages.Campaign.ShowForm Model => ViewData.Model;
    }
}
#pragma warning restore 1591