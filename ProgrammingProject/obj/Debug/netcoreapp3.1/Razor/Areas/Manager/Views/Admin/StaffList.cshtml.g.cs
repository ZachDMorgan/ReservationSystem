#pragma checksum "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\StaffList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "88aca69785094f363cd93bb67484c91b081694cc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ProgrammingProject.Areas.Manager.Views.Reports.Admin.Areas_Manager_Views_Admin_StaffList), @"mvc.1.0.view", @"/Areas/Manager/Views/Admin/StaffList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"88aca69785094f363cd93bb67484c91b081694cc", @"/Areas/Manager/Views/Admin/StaffList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4437d7e77dab32b69f4d834419fa95213b989a7a", @"/Areas/Manager/Views/_ViewImports.cshtml")]
    public class Areas_Manager_Views_Admin_StaffList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ProgrammingProject.Models.UserRoleViewModel>>
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
#line 3 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\StaffList.cshtml"
  
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

<h1>Managers</h1>

<table class=""table"">
    <thead>
        <tr>
            <th>
                User Name
            </th>
            <th>
                Manager's Role
            </th>
            <th>
                Actions
            </th>
            <th>
            </th>
            <th />
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 34 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\StaffList.cshtml"
         foreach (var u in um.Users.ToArray())
        {
            bool isManager = await um.IsInRoleAsync(u, "Manager");
            bool isStaff = await um.IsInRoleAsync(u, "Staff");
            if (isManager == true && isStaff == true)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 41 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\StaffList.cshtml"
                   Write(u.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n\r\n                        <input type=\"button\" id=\"managerButton\"");
            BeginWriteAttribute("class", " class=\"", 1032, "\"", 1095, 4);
            WriteAttributeValue("", 1040, "btn-manager", 1040, 11, true);
            WriteAttributeValue(" ", 1051, "btn", 1052, 4, true);
            WriteAttributeValue(" ", 1055, "btn-", 1056, 5, true);
#nullable restore
#line 44 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\StaffList.cshtml"
WriteAttributeValue("", 1060, isManager ? "danger" : "success", 1060, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-user=\"");
#nullable restore
#line 44 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\StaffList.cshtml"
                                                                                                                                      Write(u.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-action=\"");
#nullable restore
#line 44 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\StaffList.cshtml"
                                                                                                                                                           Write(isManager ? "remove" : "add");

#line default
#line hidden
#nullable disable
            WriteLiteral("\"");
            BeginWriteAttribute("value", " value=\"", 1160, "\"", 1199, 1);
#nullable restore
#line 44 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\StaffList.cshtml"
WriteAttributeValue("", 1168, isManager ? "Remove" : "Add", 1168, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                    </td>\r\n\r\n                    <td>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "88aca69785094f363cd93bb67484c91b081694cc10208", async() => {
                WriteLiteral("\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "88aca69785094f363cd93bb67484c91b081694cc10495", async() => {
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
#line 49 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\StaffList.cshtml"
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
                WriteLiteral("\r\n\r\n                            <span");
                BeginWriteAttribute("id", " id=\"", 1518, "\"", 1546, 2);
                WriteAttributeValue("", 1523, "confirmDeleteSpan_", 1523, 18, true);
#nullable restore
#line 51 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\StaffList.cshtml"
WriteAttributeValue("", 1541, u.Id, 1541, 5, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" style=""display:none"">
                                <span>Are you sure you want to delete?</span>
                                <button type=""submit"" class=""btn btn-danger"">Yes</button>
                                <button type=""button"" class=""btn btn-primary""");
                BeginWriteAttribute("onclick", " onclick=\"", 1818, "\"", 1857, 4);
                WriteAttributeValue("", 1828, "confirmDelete(\'", 1828, 15, true);
#nullable restore
#line 54 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\StaffList.cshtml"
WriteAttributeValue("", 1843, u.Id, 1843, 5, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1848, "\',", 1848, 2, true);
                WriteAttributeValue(" ", 1850, "false)", 1851, 7, true);
                EndWriteAttribute();
                WriteLiteral(">No</button>\r\n                            </span>\r\n\r\n                            <span");
                BeginWriteAttribute("id", " id=\"", 1944, "\"", 1965, 2);
                WriteAttributeValue("", 1949, "deleteSpan_", 1949, 11, true);
#nullable restore
#line 57 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\StaffList.cshtml"
WriteAttributeValue("", 1960, u.Id, 1960, 5, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                <button type=\"button\" class=\"btn btn-danger\"");
                BeginWriteAttribute("onclick", " onclick=\"", 2045, "\"", 2083, 4);
                WriteAttributeValue("", 2055, "confirmDelete(\'", 2055, 15, true);
#nullable restore
#line 58 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\StaffList.cshtml"
WriteAttributeValue("", 2070, u.Id, 2070, 5, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2075, "\',", 2075, 2, true);
                WriteAttributeValue(" ", 2077, "true)", 2078, 6, true);
                EndWriteAttribute();
                WriteLiteral(">Delete</button>\r\n                            </span>\r\n                        ");
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
#line 48 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\StaffList.cshtml"
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
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 63 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\StaffList.cshtml"
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </tbody>
</table>

<h1>Staff</h1>

<table class=""table"">
    <thead>
        <tr>
            <th>
                Name
            </th>
            <th>
                Manager's Role
            </th>
            <th>
                Actions
            </th>
            <th>
            </th>
            <th />
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 88 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\StaffList.cshtml"
         foreach (var u in um.Users.ToArray())
        {
            bool isManager = await um.IsInRoleAsync(u, "Manager");
            bool isStaff = await um.IsInRoleAsync(u, "Staff");
            if (isStaff == true && isManager == false)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 95 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\StaffList.cshtml"
                   Write(u.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n\r\n                        <input type=\"button\" id=\"managerButton\"");
            BeginWriteAttribute("class", " class=\"", 3048, "\"", 3111, 4);
            WriteAttributeValue("", 3056, "btn-manager", 3056, 11, true);
            WriteAttributeValue(" ", 3067, "btn", 3068, 4, true);
            WriteAttributeValue(" ", 3071, "btn-", 3072, 5, true);
#nullable restore
#line 98 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\StaffList.cshtml"
WriteAttributeValue("", 3076, isManager ? "danger" : "success", 3076, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-user=\"");
#nullable restore
#line 98 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\StaffList.cshtml"
                                                                                                                                      Write(u.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-action=\"");
#nullable restore
#line 98 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\StaffList.cshtml"
                                                                                                                                                           Write(isManager ? "remove" : "add");

#line default
#line hidden
#nullable disable
            WriteLiteral("\"");
            BeginWriteAttribute("value", " value=\"", 3176, "\"", 3215, 1);
#nullable restore
#line 98 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\StaffList.cshtml"
WriteAttributeValue("", 3184, isManager ? "Remove" : "Add", 3184, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                    </td>\r\n\r\n                    <td>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "88aca69785094f363cd93bb67484c91b081694cc22266", async() => {
                WriteLiteral("\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "88aca69785094f363cd93bb67484c91b081694cc22553", async() => {
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
#line 103 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\StaffList.cshtml"
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
                WriteLiteral("\r\n\r\n                            <span");
                BeginWriteAttribute("id", " id=\"", 3534, "\"", 3562, 2);
                WriteAttributeValue("", 3539, "confirmDeleteSpan_", 3539, 18, true);
#nullable restore
#line 105 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\StaffList.cshtml"
WriteAttributeValue("", 3557, u.Id, 3557, 5, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" style=""display:none"">
                                <span>Are you sure you want to delete?</span>
                                <button type=""submit"" class=""btn btn-danger"">Yes</button>
                                <button type=""button"" class=""btn btn-primary""");
                BeginWriteAttribute("onclick", " onclick=\"", 3834, "\"", 3873, 4);
                WriteAttributeValue("", 3844, "confirmDelete(\'", 3844, 15, true);
#nullable restore
#line 108 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\StaffList.cshtml"
WriteAttributeValue("", 3859, u.Id, 3859, 5, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3864, "\',", 3864, 2, true);
                WriteAttributeValue(" ", 3866, "false)", 3867, 7, true);
                EndWriteAttribute();
                WriteLiteral(">No</button>\r\n                            </span>\r\n\r\n                            <span");
                BeginWriteAttribute("id", " id=\"", 3960, "\"", 3981, 2);
                WriteAttributeValue("", 3965, "deleteSpan_", 3965, 11, true);
#nullable restore
#line 111 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\StaffList.cshtml"
WriteAttributeValue("", 3976, u.Id, 3976, 5, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                <button type=\"button\" class=\"btn btn-danger\"");
                BeginWriteAttribute("onclick", " onclick=\"", 4061, "\"", 4099, 4);
                WriteAttributeValue("", 4071, "confirmDelete(\'", 4071, 15, true);
#nullable restore
#line 112 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\StaffList.cshtml"
WriteAttributeValue("", 4086, u.Id, 4086, 5, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 4091, "\',", 4091, 2, true);
                WriteAttributeValue(" ", 4093, "true)", 4094, 6, true);
                EndWriteAttribute();
                WriteLiteral(">Delete</button>\r\n                            </span>\r\n                        ");
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
#line 102 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\StaffList.cshtml"
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
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 117 "C:\Users\zach-\Desktop\Diploma\Programming\ProgrammingProject\ProgrammingProject\ProgrammingProject\Areas\Manager\Views\Admin\StaffList.cshtml"
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "88aca69785094f363cd93bb67484c91b081694cc31029", async() => {
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