#pragma checksum "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\MemberList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d13ffa8a978cafbc7ffbc59a5c8da1023d86b5c4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ProgrammingProject.Areas.Manager.Views.Reports.Admin.Areas_Manager_Views_Admin_MemberList), @"mvc.1.0.view", @"/Areas/Manager/Views/Admin/MemberList.cshtml")]
namespace ProgrammingProject.Areas.Manager.Views.Reports.Admin
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
#line 1 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\_ViewImports.cshtml"
using ProgrammingProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\_ViewImports.cshtml"
using ProgrammingProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\_ViewImports.cshtml"
using ProgrammingProject.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d13ffa8a978cafbc7ffbc59a5c8da1023d86b5c4", @"/Areas/Manager/Views/Admin/MemberList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4437d7e77dab32b69f4d834419fa95213b989a7a", @"/Areas/Manager/Views/_ViewImports.cshtml")]
    public class Areas_Manager_Views_Admin_MemberList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ProgrammingProject.Models.UserRoleViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditStaff", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/ManagerFunctions.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\MemberList.cshtml"
  
    ViewData["Title"] = "StaffList";
    var um = (ViewBag.UserManager as UserManager<ApplicationUser>);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
    .btn-manager {
        min-width: 150px;
    }
</style>

<h1>Members</h1>

<table class=""table"">
    <thead>
        <tr>
            <th>
                User Name
            </th>
            <th>
                Actions
            </th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 28 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\MemberList.cshtml"
         foreach (var u in um.Users.ToArray())
        {
            bool isMember = await um.IsInRoleAsync(u, "Member");
            if (isMember == true)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 34 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\MemberList.cshtml"
           Write(u.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d13ffa8a978cafbc7ffbc59a5c8da1023d86b5c47837", async() => {
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d13ffa8a978cafbc7ffbc59a5c8da1023d86b5c48115", async() => {
                    WriteLiteral("Edit");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 37 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\MemberList.cshtml"
                                                                       WriteLiteral(u.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n                    <span");
                BeginWriteAttribute("id", " id=\"", 964, "\"", 992, 2);
                WriteAttributeValue("", 969, "confirmDeleteSpan_", 969, 18, true);
#nullable restore
#line 39 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\MemberList.cshtml"
WriteAttributeValue("", 987, u.Id, 987, 5, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" style=\"display:none\">\r\n                        <span>Are you sure you want to delete?</span>\r\n                        <button type=\"submit\" class=\"btn btn-danger\">Yes</button>\r\n                        <button type=\"button\" class=\"btn btn-primary\"");
                BeginWriteAttribute("onclick", " onclick=\"", 1240, "\"", 1279, 4);
                WriteAttributeValue("", 1250, "confirmDelete(\'", 1250, 15, true);
#nullable restore
#line 42 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\MemberList.cshtml"
WriteAttributeValue("", 1265, u.Id, 1265, 5, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1270, "\',", 1270, 2, true);
                WriteAttributeValue(" ", 1272, "false)", 1273, 7, true);
                EndWriteAttribute();
                WriteLiteral(">No</button>\r\n                    </span>\r\n\r\n                    <span");
                BeginWriteAttribute("id", " id=\"", 1350, "\"", 1371, 2);
                WriteAttributeValue("", 1355, "deleteSpan_", 1355, 11, true);
#nullable restore
#line 45 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\MemberList.cshtml"
WriteAttributeValue("", 1366, u.Id, 1366, 5, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                        <button type=\"button\" class=\"btn btn-danger\"");
                BeginWriteAttribute("onclick", " onclick=\"", 1443, "\"", 1481, 4);
                WriteAttributeValue("", 1453, "confirmDelete(\'", 1453, 15, true);
#nullable restore
#line 46 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\MemberList.cshtml"
WriteAttributeValue("", 1468, u.Id, 1468, 5, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1473, "\',", 1473, 2, true);
                WriteAttributeValue(" ", 1475, "true)", 1476, 6, true);
                EndWriteAttribute();
                WriteLiteral(">Delete</button>\r\n                    </span>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 36 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\MemberList.cshtml"
                                                WriteLiteral(u.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 51 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\MemberList.cshtml"
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d13ffa8a978cafbc7ffbc59a5c8da1023d86b5c416485", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ProgrammingProject.Models.UserRoleViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
