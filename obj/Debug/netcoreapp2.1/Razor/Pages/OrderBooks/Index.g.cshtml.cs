#pragma checksum "D:\software\workspace\VSspace\BookStore\BookStore\Pages\OrderBooks\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d9ac20fb877552dd8baa8e3bdc7562468b3ec8c7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(BookStore.Pages.OrderBooks.Pages_OrderBooks_Index), @"mvc.1.0.razor-page", @"/Pages/OrderBooks/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/OrderBooks/Index.cshtml", typeof(BookStore.Pages.OrderBooks.Pages_OrderBooks_Index), null)]
namespace BookStore.Pages.OrderBooks
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\software\workspace\VSspace\BookStore\BookStore\Pages\_ViewImports.cshtml"
using BookStore;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d9ac20fb877552dd8baa8e3bdc7562468b3ec8c7", @"/Pages/OrderBooks/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"36b8241c3eda258e91c9ad2f004526cf8039f262", @"/Pages/_ViewImports.cshtml")]
    public class Pages_OrderBooks_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(53, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "D:\software\workspace\VSspace\BookStore\BookStore\Pages\OrderBooks\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(96, 29, true);
            WriteLiteral("\r\n<h2>Index</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(125, 35, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "797b70c2228d4fb88ff32788a37cbb46", async() => {
                BeginContext(146, 10, true);
                WriteLiteral("Create New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(160, 92, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(253, 54, false);
#line 17 "D:\software\workspace\VSspace\BookStore\BookStore\Pages\OrderBooks\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.OrderBook[0].Count));

#line default
#line hidden
            EndContext();
            BeginContext(307, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(363, 53, false);
#line 20 "D:\software\workspace\VSspace\BookStore\BookStore\Pages\OrderBooks\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.OrderBook[0].Book));

#line default
#line hidden
            EndContext();
            BeginContext(416, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(472, 54, false);
#line 23 "D:\software\workspace\VSspace\BookStore\BookStore\Pages\OrderBooks\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.OrderBook[0].Order));

#line default
#line hidden
            EndContext();
            BeginContext(526, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 29 "D:\software\workspace\VSspace\BookStore\BookStore\Pages\OrderBooks\Index.cshtml"
 foreach (var item in Model.OrderBook) {

#line default
#line hidden
            BeginContext(654, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(703, 40, false);
#line 32 "D:\software\workspace\VSspace\BookStore\BookStore\Pages\OrderBooks\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Count));

#line default
#line hidden
            EndContext();
            BeginContext(743, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(799, 48, false);
#line 35 "D:\software\workspace\VSspace\BookStore\BookStore\Pages\OrderBooks\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Book.BookName));

#line default
#line hidden
            EndContext();
            BeginContext(847, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(903, 48, false);
#line 38 "D:\software\workspace\VSspace\BookStore\BookStore\Pages\OrderBooks\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Order.OrderId));

#line default
#line hidden
            EndContext();
            BeginContext(951, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1007, 65, false);
#line 41 "D:\software\workspace\VSspace\BookStore\BookStore\Pages\OrderBooks\Index.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1072, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1093, 71, false);
#line 42 "D:\software\workspace\VSspace\BookStore\BookStore\Pages\OrderBooks\Index.cshtml"
           Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1164, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1185, 69, false);
#line 43 "D:\software\workspace\VSspace\BookStore\BookStore\Pages\OrderBooks\Index.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1254, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 46 "D:\software\workspace\VSspace\BookStore\BookStore\Pages\OrderBooks\Index.cshtml"
}

#line default
#line hidden
            BeginContext(1293, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BookStore.Pages.OrderBooks.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BookStore.Pages.OrderBooks.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BookStore.Pages.OrderBooks.IndexModel>)PageContext?.ViewData;
        public BookStore.Pages.OrderBooks.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
