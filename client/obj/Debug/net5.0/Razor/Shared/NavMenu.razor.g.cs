#pragma checksum "C:\SDE\Code\VS\BlazorWeather\client\Shared\NavMenu.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5a9c02e232c6b521f4083a59a96754e8071bcd57"
// <auto-generated/>
#pragma warning disable 1591
namespace client.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\SDE\Code\VS\BlazorWeather\client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\SDE\Code\VS\BlazorWeather\client\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\SDE\Code\VS\BlazorWeather\client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\SDE\Code\VS\BlazorWeather\client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\SDE\Code\VS\BlazorWeather\client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\SDE\Code\VS\BlazorWeather\client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\SDE\Code\VS\BlazorWeather\client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\SDE\Code\VS\BlazorWeather\client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\SDE\Code\VS\BlazorWeather\client\_Imports.razor"
using client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\SDE\Code\VS\BlazorWeather\client\_Imports.razor"
using client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\SDE\Code\VS\BlazorWeather\client\_Imports.razor"
using MudBlazor;

#line default
#line hidden
#nullable disable
    public partial class NavMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<MudBlazor.MudNavMenu>(0);
            __builder.AddAttribute(1, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<MudBlazor.MudNavLink>(2);
                __builder2.AddAttribute(3, "Href", "");
                __builder2.AddAttribute(4, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(5, "Home");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(6, "\r\n    ");
                __builder2.OpenComponent<MudBlazor.MudNavLink>(7);
                __builder2.AddAttribute(8, "Href", "/counter");
                __builder2.AddAttribute(9, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(10, "Counter");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(11, "\r\n    ");
                __builder2.OpenComponent<MudBlazor.MudNavGroup>(12);
                __builder2.AddAttribute(13, "Title", "Weather");
                __builder2.AddAttribute(14, "Expanded", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 4 "C:\SDE\Code\VS\BlazorWeather\client\Shared\NavMenu.razor"
                                           true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(15, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<MudBlazor.MudNavLink>(16);
                    __builder3.AddAttribute(17, "Href", "/fetchdata");
                    __builder3.AddAttribute(18, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddContent(19, "Users");
                    }
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(20, "\r\n    ");
                __builder2.OpenComponent<MudBlazor.MudNavLink>(21);
                __builder2.AddAttribute(22, "Href", "/about");
                __builder2.AddAttribute(23, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(24, "About");
                }
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591