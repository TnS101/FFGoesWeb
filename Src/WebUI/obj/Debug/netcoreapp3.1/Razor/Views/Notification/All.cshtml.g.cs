#pragma checksum "C:\Users\PC\Desktop\FFGoesWeb\Src\WebUI\Views\Notification\All.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "26befbdd51ffc5c5989824cd509873ccb9925e58"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Notification_All), @"mvc.1.0.view", @"/Views/Notification/All.cshtml")]
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
#line 1 "C:\Users\PC\Desktop\FFGoesWeb\Src\WebUI\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\PC\Desktop\FFGoesWeb\Src\WebUI\Views\_ViewImports.cshtml"
using WebUI.Areas.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\PC\Desktop\FFGoesWeb\Src\WebUI\Views\_ViewImports.cshtml"
using Domain.Entities.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\PC\Desktop\FFGoesWeb\Src\WebUI\Views\_ViewImports.cshtml"
using Application.GameCQ.Monsters.Queries.GetAllMonstersQuery;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"26befbdd51ffc5c5989824cd509873ccb9925e58", @"/Views/Notification/All.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"72de99cefb048e3e38636f6b45588b33a393a074", @"/Views/_ViewImports.cshtml")]
    public class Views_Notification_All : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Application.CQ.Social.Notifications.Queries.GetPersonalNotificationsQuery.NotificationListViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_SocialNavBar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "26befbdd51ffc5c5989824cd509873ccb9925e584167", async() => {
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>All</title>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "26befbdd51ffc5c5989824cd509873ccb9925e584520", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
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
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "26befbdd51ffc5c5989824cd509873ccb9925e586405", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 12 "C:\Users\PC\Desktop\FFGoesWeb\Src\WebUI\Views\Notification\All.cshtml"
     if (Model.Notifications.Count() > 0)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <h1 class=\"has-text-align-center secondary-font-color\">Your Current Notifications</h1>\r\n        <br />\r\n");
#nullable restore
#line 16 "C:\Users\PC\Desktop\FFGoesWeb\Src\WebUI\Views\Notification\All.cshtml"
        foreach (var notification in Model.Notifications)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"has-text-align-center item-padding\">\r\n");
#nullable restore
#line 19 "C:\Users\PC\Desktop\FFGoesWeb\Src\WebUI\Views\Notification\All.cshtml"
                 if (notification.ApplicationSection == "Game")
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <i class=\"fas fa-gamepad has-large-font-size\"></i>\r\n");
#nullable restore
#line 22 "C:\Users\PC\Desktop\FFGoesWeb\Src\WebUI\Views\Notification\All.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <i class=\"fas fa-people-arrows has-large-font-size\"></i>\r\n");
#nullable restore
#line 26 "C:\Users\PC\Desktop\FFGoesWeb\Src\WebUI\Views\Notification\All.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                <p class=\"has-medium-font-size\">");
#nullable restore
#line 28 "C:\Users\PC\Desktop\FFGoesWeb\Src\WebUI\Views\Notification\All.cshtml"
                                           Write(notification.Type);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                <p class=\"has-medium-font-size\"><em>");
#nullable restore
#line 29 "C:\Users\PC\Desktop\FFGoesWeb\Src\WebUI\Views\Notification\All.cshtml"
                                               Write(notification.Content);

#line default
#line hidden
#nullable disable
                WriteLiteral("</em></p>\r\n");
#nullable restore
#line 30 "C:\Users\PC\Desktop\FFGoesWeb\Src\WebUI\Views\Notification\All.cshtml"
                 if (DateTime.UtcNow.Minute - notification.RecievedOn.Minute < 1)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <p class=\"main-font-color has-large-font-size\">Just Now.</p>\r\n");
#nullable restore
#line 33 "C:\Users\PC\Desktop\FFGoesWeb\Src\WebUI\Views\Notification\All.cshtml"
                }
                else if (DateTime.UtcNow.Hour - notification.RecievedOn.Hour < 1)
                {
                    int difference = DateTime.UtcNow.Minute - notification.RecievedOn.Minute;


#line default
#line hidden
#nullable disable
                WriteLiteral("                    <p class=\"main-font-color has-large-font-size\">\r\n                        ");
#nullable restore
#line 39 "C:\Users\PC\Desktop\FFGoesWeb\Src\WebUI\Views\Notification\All.cshtml"
                   Write(difference);

#line default
#line hidden
#nullable disable
                WriteLiteral(" Minutes Ago.\r\n                    </p>\r\n");
#nullable restore
#line 41 "C:\Users\PC\Desktop\FFGoesWeb\Src\WebUI\Views\Notification\All.cshtml"
                }
                else if (DateTime.UtcNow.Day - notification.RecievedOn.Day < 1)
                {
                    int difference = DateTime.UtcNow.Day - notification.RecievedOn.Day;

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <p class=\"main-font-color has-large-font-size\">\r\n                        ");
#nullable restore
#line 46 "C:\Users\PC\Desktop\FFGoesWeb\Src\WebUI\Views\Notification\All.cshtml"
                   Write(difference);

#line default
#line hidden
#nullable disable
                WriteLiteral(" Hours Ago.\r\n                    </p>\r\n");
#nullable restore
#line 48 "C:\Users\PC\Desktop\FFGoesWeb\Src\WebUI\Views\Notification\All.cshtml"
                }
                else if (DateTime.UtcNow.Day - notification.RecievedOn.Day == 1)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <p class=\"main-font-color has-large-font-size\">\r\n                        Yesterday.\r\n                    </p>\r\n");
#nullable restore
#line 54 "C:\Users\PC\Desktop\FFGoesWeb\Src\WebUI\Views\Notification\All.cshtml"
                }
                else if (DateTime.UtcNow.Day - notification.RecievedOn.Day > 1)
                {
                    int difference = DateTime.UtcNow.Day - notification.RecievedOn.Day;

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <p class=\"main-font-color has-large-font-size\">\r\n                        ");
#nullable restore
#line 59 "C:\Users\PC\Desktop\FFGoesWeb\Src\WebUI\Views\Notification\All.cshtml"
                   Write(difference);

#line default
#line hidden
#nullable disable
                WriteLiteral(" Days Ago.\r\n                    </p>\r\n");
#nullable restore
#line 61 "C:\Users\PC\Desktop\FFGoesWeb\Src\WebUI\Views\Notification\All.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </div>\r\n");
#nullable restore
#line 63 "C:\Users\PC\Desktop\FFGoesWeb\Src\WebUI\Views\Notification\All.cshtml"
        }
    }
    else
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <h1 class=\"has-text-align-center secondary-font-color\">No Notifications to display</h1>\r\n");
#nullable restore
#line 68 "C:\Users\PC\Desktop\FFGoesWeb\Src\WebUI\Views\Notification\All.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("    <div>\r\n\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<AppUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Application.CQ.Social.Notifications.Queries.GetPersonalNotificationsQuery.NotificationListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591