#pragma checksum "C:\Users\PC\Desktop\FFGoesWeb\Src\WebUI\Views\Home\PrivacyPolicy.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ab13875c71f90f1b397b8a330e3804146e16370c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_PrivacyPolicy), @"mvc.1.0.view", @"/Views/Home/PrivacyPolicy.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab13875c71f90f1b397b8a330e3804146e16370c", @"/Views/Home/PrivacyPolicy.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"72de99cefb048e3e38636f6b45588b33a393a074", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_PrivacyPolicy : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_NavBar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ab13875c71f90f1b397b8a330e3804146e16370c4091", async() => {
                WriteLiteral("\r\n    <title></title>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ab13875c71f90f1b397b8a330e3804146e16370c4376", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ab13875c71f90f1b397b8a330e3804146e16370c6261", async() => {
                WriteLiteral(@"
    <h1 class=""secondary-font-color has-text-align-center"">Privacy Policy</h1>
    <br />
    <div class=""item-padding has-text-align-center"">

        <p class=""main-font-color has-normal-font-size"">At FFGoesWeb, accessible from https://localhost:44342/, one of our main priorities is the privacy of our visitors. This Privacy Policy document contains types of information that is collected and recorded by FFGoesWeb and how we use it.</p>

        <p class=""main-font-color has-normal-font-size"">If you have additional questions or require more information about our Privacy Policy, do not hesitate to contact us.</p>

        <p class=""main-font-color has-normal-font-size"">This Privacy Policy applies only to our online activities and is valid for visitors to our website with regards to the information that they shared and/or collect in FFGoesWeb. This policy is not applicable to any information collected offline or via channels other than this website.</p>

        <br />
        <hr />
        <h2 c");
                WriteLiteral(@"lass=""main-font-color has-normal-font-size"">Consent</h2>
        <hr />

        <p class=""main-font-color has-normal-font-size"">By using our website, you hereby consent to our Privacy Policy and agree to its terms.</p>

        <br />
        <hr />
        <h2 class=""main-font-color has-normal-font-size"">Information we collect</h2>
        <hr />

        <p class=""main-font-color has-normal-font-size"">The personal information that you are asked to provide, and the reasons why you are asked to provide it, will be made clear to you at the point we ask you to provide your personal information.</p>
        <p class=""main-font-color has-normal-font-size"">If you contact us directly, we may receive additional information about you such as your name, email address, phone number, the contents of the message and/or attachments you may send us, and any other information you may choose to provide.</p>
        <p class=""main-font-color has-normal-font-size"">When you register for an Account, we may ask for y");
                WriteLiteral(@"our contact information, including items such as name, company name, address, email address, and telephone number.</p>

        <br />
        <hr />
        <h2 class=""main-font-color has-normal-font-size"">How we use your information</h2>
        <hr />

        <p class=""main-font-color has-normal-font-size"">We use the information we collect in various ways, including to:</p>

        <ul class=""main-font-color has-normal-font-size"" style=""list-style:none"">
            <li>Provide, operate, and maintain our webste</li>
            <li>Improve, personalize, and expand our webste</li>
            <li>Understand and analyze how you use our webste</li>
            <li>Develop new products, services, features, and functionality</li>
            <li>Communicate with you, either directly or through one of our partners, including for customer service, to provide you with updates and other information relating to the webste, and for marketing and promotional purposes</li>
            <li>Send you emai");
                WriteLiteral(@"ls</li>
            <li>Find and prevent fraud</li>
        </ul>

        <br />
        <hr />
        <h2 class=""main-font-color has-normal-font-size"">Log Files</h2>
        <hr />

        <p class=""main-font-color has-normal-font-size"">FFGoesWeb follows a standard procedure of using log files. These files log visitors when they visit websites. All hosting companies do this and a part of hosting services' analytics. The information collected by log files include internet protocol (IP) addresses, browser type, Internet Service Provider (ISP), date and time stamp, referring/exit pages, and possibly the number of clicks. These are not linked to any information that is personally identifiable. The purpose of the information is for analyzing trends, administering the site, tracking users' movement on the website, and gathering demographic information. Our Privacy Policy was created with the help of the <a href=""https://www.privacypolicygenerator.info"">Privacy Policy Generator</a> and the <a href=""http");
                WriteLiteral(@"s://www.privacypolicytemplate.net/"">Privacy Policy Template</a>.</p>

        <br />
        <hr />
        <h2 class=""main-font-color has-normal-font-size"">Cookies and Web Beacons</h2>
        <hr />

        <p class=""main-font-color has-normal-font-size"">Like any other website, FFGoesWeb uses 'cookies'. These cookies are used to store information including visitors' preferences, and the pages on the website that the visitor accessed or visited. The information is used to optimize the users' experience by customizing our web page content based on visitors' browser type and/or other information.</p>

        <p class=""main-font-color has-normal-font-size"">For more general information on cookies, please read <a href=""https://www.cookieconsent.com/what-are-cookies/"">""What Are Cookies""</a>.</p>

        <br />
        <hr />
        <h2 class=""main-font-color has-normal-font-size"">Advertising Partners Privacy Policies</h2>
        <hr />

        <P class=""main-font-color has-normal-font-size"">Y");
                WriteLiteral(@"ou may consult this list to find the Privacy Policy for each of the advertising partners of FFGoesWeb.</P>

        <p class=""main-font-color has-normal-font-size"">Third-party ad servers or ad networks uses technologies like cookies, JavaScript, or Web Beacons that are used in their respective advertisements and links that appear on FFGoesWeb, which are sent directly to users' browser. They automatically receive your IP address when this occurs. These technologies are used to measure the effectiveness of their advertising campaigns and/or to personalize the advertising content that you see on websites that you visit.</p>

        <p class=""main-font-color has-normal-font-size"">Note that FFGoesWeb has no access to or control over these cookies that are used by third-party advertisers.</p>

        <br />
        <hr />
        <h2 class=""main-font-color has-normal-font-size"">Third Party Privacy Policies</h2>
        <hr />

        <p class=""main-font-color has-normal-font-size"">FFGoesWeb's Privacy ");
                WriteLiteral(@"Policy does not apply to other advertisers or websites. Thus, we are advising you to consult the respective Privacy Policies of these third-party ad servers for more detailed information. It may include their practices and instructions about how to opt-out of certain options. You may find a complete list of these Privacy Policies and their links here: Privacy Policy Links.</p>

        <p class=""main-font-color has-normal-font-size"">You can choose to disable cookies through your individual browser options. To know more detailed information about cookie management with specific web browsers, it can be found at the browsers' respective websites. What Are Cookies?</p>

        <br />
        <hr />
        <h2 class=""main-font-color has-normal-font-size"">CCPA Privacy Rights (Do Not Sell My Personal Information)</h2>
        <hr />

        <p class=""main-font-color has-normal-font-size"">Under the CCPA, among other rights, California consumers have the right to:</p>
        <p class=""main-font-color has");
                WriteLiteral(@"-normal-font-size"">Request that a business that collects a consumer's personal data disclose the categories and specific pieces of personal data that a business has collected about consumers.</p>
        <p class=""main-font-color has-normal-font-size"">Request that a business delete any personal data about the consumer that a business has collected.</p>
        <p class=""main-font-color has-normal-font-size"">Request that a business that sells a consumer's personal data, not sell the consumer's personal data.</p>
        <p class=""main-font-color has-normal-font-size"">If you make a request, we have one month to respond to you. If you would like to exercise any of these rights, please contact us.</p>

        <br />
        <hr />
        <h2 class=""main-font-color has-normal-font-size"">GDPR Data Protection Rights</h2>
        <hr />

        <p class=""main-font-color has-normal-font-size"">We would like to make sure you are fully aware of all of your data protection rights. Every user is entitled to th");
                WriteLiteral(@"e following:</p>
        <p class=""main-font-color has-normal-font-size"">The right to access – You have the right to request copies of your personal data. We may charge you a small fee for this service.</p>
        <p class=""main-font-color has-normal-font-size"">The right to rectification – You have the right to request that we correct any information you believe is inaccurate. You also have the right to request that we complete the information you believe is incomplete.</p>
        <p class=""main-font-color has-normal-font-size"">The right to erasure – You have the right to request that we erase your personal data, under certain conditions.</p>
        <p class=""main-font-color has-normal-font-size"">The right to restrict processing – You have the right to request that we restrict the processing of your personal data, under certain conditions.</p>
        <p class=""main-font-color has-normal-font-size"">The right to object to processing – You have the right to object to our processing of your personal data");
                WriteLiteral(@", under certain conditions.</p>
        <p class=""main-font-color has-normal-font-size"">The right to data portability – You have the right to request that we transfer the data that we have collected to another organization, or directly to you, under certain conditions.</p>
        <p class=""main-font-color has-normal-font-size"">If you make a request, we have one month to respond to you. If you would like to exercise any of these rights, please contact us.</p>

        <br />
        <hr />
        <h2 class=""main-font-color has-normal-font-size"">Children's Information</h2>
        <hr />

        <p class=""main-font-color has-normal-font-size"">Another part of our priority is adding protection for children while using the internet. We encourage parents and guardians to observe, participate in, and/or monitor and guide their online activity.</p>

        <p class=""main-font-color has-normal-font-size"">FFGoesWeb does not knowingly collect any Personal Identifiable Information from children under the a");
                WriteLiteral("ge of 13. If you think that your child provided this kind of information on our website, we strongly encourage you to contact us immediately and we will do our best efforts to promptly remove such information from our records.</p>\r\n    </div>\r\n\r\n");
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
            WriteLiteral("\r\n</html>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591