#pragma checksum "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "43aabd60d37bf5d62199dbac71c84c9f1890ebe5"
// <auto-generated/>
#pragma warning disable 1591
namespace PayCoin.Client.Pages.BackEndCommunity.CouponPages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\_Imports.razor"
using PayCoin.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\_Imports.razor"
using PayCoin.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\_Imports.razor"
using PayCoin.Client.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\_Imports.razor"
using PayCoin.Client.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\_Imports.razor"
using PayCoin.Client.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\_Imports.razor"
using System.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\_Imports.razor"
using System.IO;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/community/coupon/add")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/community/coupon/edit/{Id}")]
    public partial class CreateAndEdit : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "card card-box");
            __builder.AddMarkupContent(2, "\n    ");
            __builder.AddMarkupContent(3, "<div class=\"card-head\">\n        <header>Coupon Form</header>\n    </div>\n    ");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "card-body");
            __builder.AddAttribute(6, "id", "bar-parent2");
            __builder.AddMarkupContent(7, "\n        ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(8);
            __builder.AddAttribute(9, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 8 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor"
                          coupon

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(10, "class", "form-horizontal");
            __builder.AddAttribute(11, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 8 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor"
                                                                          HandleValidRequest

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(12, "OnInvalidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 8 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor"
                                                                                                               HandleInvalidRequest

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(13, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(14, "\n            ");
                __builder2.OpenElement(15, "div");
                __builder2.AddAttribute(16, "class", "form-body");
                __builder2.AddMarkupContent(17, "\n                ");
                __builder2.OpenElement(18, "div");
                __builder2.AddAttribute(19, "class", "form-group");
                __builder2.AddMarkupContent(20, "\n                    ");
                __builder2.AddMarkupContent(21, "<label for=\"simpleFormEmail\">Code</label>\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(22);
                __builder2.AddAttribute(23, "class", "form-control");
                __builder2.AddAttribute(24, "placeholder", "Enter Code");
                __builder2.AddAttribute(25, "id", "Code");
                __builder2.AddAttribute(26, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 12 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor"
                                                                                           coupon.Code

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(27, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => coupon.Code = __value, coupon.Code))));
                __builder2.AddAttribute(28, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => coupon.Code));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(29, "\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(30, "\n                ");
                __builder2.OpenElement(31, "div");
                __builder2.AddAttribute(32, "class", "form-group");
                __builder2.AddMarkupContent(33, "\n                    ");
                __builder2.AddMarkupContent(34, "<label for=\"simpleFormEmail\">Value</label>\n                    ");
                __Blazor.PayCoin.Client.Pages.BackEndCommunity.CouponPages.CreateAndEdit.TypeInference.CreateInputNumber_0(__builder2, 35, 36, "form-control", 37, "Enter Value", 38, "Value", 39, 
#nullable restore
#line 16 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor"
                                                                                              coupon.Value

#line default
#line hidden
#nullable disable
                , 40, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => coupon.Value = __value, coupon.Value)), 41, () => coupon.Value);
                __builder2.AddMarkupContent(42, "\n\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(43, "\n                ");
                __builder2.OpenElement(44, "div");
                __builder2.AddAttribute(45, "class", "form-group");
                __builder2.AddMarkupContent(46, "\n                    ");
                __builder2.AddMarkupContent(47, "<label for=\"simpleFormEmail\">Date Validation</label>\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(48);
                __builder2.AddAttribute(49, "class", "form-control");
                __builder2.AddAttribute(50, "placeholder", "Enter DateValidation");
                __builder2.AddAttribute(51, "id", "DateValidation");
                __builder2.AddAttribute(52, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 21 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor"
                                                                                                     coupon.DateValidation

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(53, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => coupon.DateValidation = __value, coupon.DateValidation))));
                __builder2.AddAttribute(54, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => coupon.DateValidation));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(55, "\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(56, "\n                ");
                __builder2.OpenElement(57, "div");
                __builder2.AddAttribute(58, "class", "form-group");
                __builder2.AddMarkupContent(59, "\n                    ");
                __builder2.AddMarkupContent(60, "<label for=\"simpleFormEmail\">Date Expired</label>\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(61);
                __builder2.AddAttribute(62, "class", "form-control");
                __builder2.AddAttribute(63, "placeholder", "Enter DateExpired");
                __builder2.AddAttribute(64, "id", "DateExpired");
                __builder2.AddAttribute(65, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 25 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor"
                                                                                                  coupon.DateExpired

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(66, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => coupon.DateExpired = __value, coupon.DateExpired))));
                __builder2.AddAttribute(67, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => coupon.DateExpired));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(68, "\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(69, "\n                ");
                __builder2.OpenElement(70, "div");
                __builder2.AddAttribute(71, "class", "form-group");
                __builder2.AddMarkupContent(72, "\n                    ");
                __builder2.AddMarkupContent(73, "<label for=\"simpleFormEmail\">Type</label>\n                    ");
                __Blazor.PayCoin.Client.Pages.BackEndCommunity.CouponPages.CreateAndEdit.TypeInference.CreateInputSelect_1(__builder2, 74, 75, "form-control", 76, "Enter Type", 77, "Type", 78, 
#nullable restore
#line 29 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor"
                                                                                             coupon.Type

#line default
#line hidden
#nullable disable
                , 79, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => coupon.Type = __value, coupon.Type)), 80, () => coupon.Type, 81, (__builder3) => {
                    __builder3.AddMarkupContent(82, "\n                        ");
                    __builder3.AddMarkupContent(83, "<option value=\"fixed\">Fixed</option>\n                        ");
                    __builder3.AddMarkupContent(84, "<option value=\"percent\">Percent</option>\n                    ");
                }
                );
                __builder2.AddMarkupContent(85, "\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(86, "\n                ");
                __builder2.OpenElement(87, "div");
                __builder2.AddAttribute(88, "class", "form-group");
                __builder2.AddMarkupContent(89, "\n                    ");
                __builder2.AddMarkupContent(90, "<label for=\"simpleFormEmail\">Nature</label>\n                    ");
                __Blazor.PayCoin.Client.Pages.BackEndCommunity.CouponPages.CreateAndEdit.TypeInference.CreateInputSelect_2(__builder2, 91, 92, "form-control", 93, "Enter Nature", 94, "Nature", 95, 
#nullable restore
#line 36 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor"
                                                                                               coupon.Nature

#line default
#line hidden
#nullable disable
                , 96, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => coupon.Nature = __value, coupon.Nature)), 97, () => coupon.Nature, 98, (__builder3) => {
                    __builder3.AddMarkupContent(99, "\n                        ");
                    __builder3.AddMarkupContent(100, "<option value=\"real\">Real</option>\n                        ");
                    __builder3.AddMarkupContent(101, "<option value=\"virtual\">Virtual</option>\n                    ");
                }
                );
                __builder2.AddMarkupContent(102, "\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(103, "\n                ");
                __builder2.OpenElement(104, "div");
                __builder2.AddAttribute(105, "class", "form-group");
                __builder2.AddMarkupContent(106, "\n                    ");
                __builder2.AddMarkupContent(107, "<label for=\"simpleFormEmail\">Validation</label>\n                    ");
                __Blazor.PayCoin.Client.Pages.BackEndCommunity.CouponPages.CreateAndEdit.TypeInference.CreateInputSelect_3(__builder2, 108, 109, "form-control", 110, "Enter Validation", 111, "Validation", 112, 
#nullable restore
#line 43 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor"
                                                                                                   coupon.Validation

#line default
#line hidden
#nullable disable
                , 113, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => coupon.Validation = __value, coupon.Validation)), 114, () => coupon.Validation, 115, (__builder3) => {
                    __builder3.AddMarkupContent(116, "\n                        ");
                    __builder3.AddMarkupContent(117, "<option value=\"valid\">Valid</option>\n                        ");
                    __builder3.AddMarkupContent(118, "<option value=\"invalid\">InValid</option>\n                    ");
                }
                );
                __builder2.AddMarkupContent(119, "\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(120, "\n                ");
                __builder2.OpenElement(121, "div");
                __builder2.AddAttribute(122, "class", "form-group");
                __builder2.AddMarkupContent(123, "\n                    ");
                __builder2.AddMarkupContent(124, "<label for=\"simpleFormEmail\">Provider</label>\n                    ");
                __builder2.OpenElement(125, "select");
                __builder2.AddAttribute(126, "class", "form-control");
                __builder2.AddAttribute(127, "placeholder", "Enter Provider");
                __builder2.AddAttribute(128, "id", "ProviderId");
                __builder2.AddAttribute(129, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 50 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor"
                                                                                      coupon.ProviderId

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(130, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => coupon.ProviderId = __value, coupon.ProviderId));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.AddMarkupContent(131, "\n                        ");
                __builder2.OpenElement(132, "option");
                __builder2.AddAttribute(133, "value", true);
                __builder2.AddContent(134, "Chose One Provider");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(135, "\n\n");
#nullable restore
#line 53 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor"
                         foreach (var provider in providers)
                        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor"
             if (provider.ProviderId == coupon.ProviderId)
            {

#line default
#line hidden
#nullable disable
                __builder2.AddContent(136, "            ");
                __builder2.OpenElement(137, "option");
                __builder2.AddAttribute(138, "value", 
#nullable restore
#line 57 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor"
                            provider.ProviderId

#line default
#line hidden
#nullable disable
                );
                __builder2.AddAttribute(139, "selected", true);
                __builder2.AddContent(140, 
#nullable restore
#line 57 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor"
                                                           provider.CompanyName

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddContent(141, " ");
#nullable restore
#line 57 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor"
                                                                                         }
                                else
                                {

#line default
#line hidden
#nullable disable
                __builder2.AddContent(142, "            ");
                __builder2.OpenElement(143, "option");
                __builder2.AddAttribute(144, "value", 
#nullable restore
#line 60 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor"
                            provider.ProviderId

#line default
#line hidden
#nullable disable
                );
                __builder2.AddContent(145, 
#nullable restore
#line 60 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor"
                                                  provider.CompanyName

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
#nullable restore
#line 60 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor"
                                                                               }

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor"
                                                                                }

#line default
#line hidden
#nullable disable
                __builder2.AddContent(146, "                    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(147, "\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(148, "\n                ");
                __builder2.OpenElement(149, "div");
                __builder2.AddAttribute(150, "class", "form-group");
                __builder2.AddMarkupContent(151, "\n                    ");
                __builder2.AddMarkupContent(152, "<label for=\"simpleFormEmail\">Community</label>\n                    ");
                __builder2.OpenElement(153, "select");
                __builder2.AddAttribute(154, "class", "form-control");
                __builder2.AddAttribute(155, "placeholder", "Enter Community");
                __builder2.AddAttribute(156, "id", "CommunityId");
                __builder2.AddAttribute(157, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 65 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor"
                                                                                       coupon.CommunityId

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(158, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => coupon.CommunityId = __value, coupon.CommunityId));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.AddMarkupContent(159, "\n                        ");
                __builder2.OpenElement(160, "option");
                __builder2.AddAttribute(161, "value", true);
                __builder2.AddContent(162, "Chose One Community");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(163, "\n\n");
#nullable restore
#line 68 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor"
                         foreach (var community in communitys)
                        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 70 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor"
             if (community.CommunityId == coupon.CommunityId)
            {

#line default
#line hidden
#nullable disable
                __builder2.AddContent(164, "            ");
                __builder2.OpenElement(165, "option");
                __builder2.AddAttribute(166, "value", 
#nullable restore
#line 72 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor"
                            community.CommunityId

#line default
#line hidden
#nullable disable
                );
                __builder2.AddAttribute(167, "selected", true);
                __builder2.AddContent(168, 
#nullable restore
#line 72 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor"
                                                             community.Phone

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddContent(169, " ");
#nullable restore
#line 72 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor"
                                                                                      }
                                else
                                {

#line default
#line hidden
#nullable disable
                __builder2.AddContent(170, "            ");
                __builder2.OpenElement(171, "option");
                __builder2.AddAttribute(172, "value", 
#nullable restore
#line 75 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor"
                            community.CommunityId

#line default
#line hidden
#nullable disable
                );
                __builder2.AddContent(173, 
#nullable restore
#line 75 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor"
                                                    community.Phone

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
#nullable restore
#line 75 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor"
                                                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor"
                                                                             }

#line default
#line hidden
#nullable disable
                __builder2.AddContent(174, "                    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(175, "\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(176, "\n                ");
                __builder2.OpenElement(177, "div");
                __builder2.AddAttribute(178, "class", "form-group");
                __builder2.AddMarkupContent(179, "\n                    ");
                __builder2.AddMarkupContent(180, "<label for=\"simpleFormEmail\">Status</label>\n                    ");
                __Blazor.PayCoin.Client.Pages.BackEndCommunity.CouponPages.CreateAndEdit.TypeInference.CreateInputSelect_4(__builder2, 181, 182, "form-control", 183, "Enter Status", 184, "Status", 185, 
#nullable restore
#line 80 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor"
                                                                                               coupon.Status

#line default
#line hidden
#nullable disable
                , 186, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => coupon.Status = __value, coupon.Status)), 187, () => coupon.Status, 188, (__builder3) => {
                    __builder3.AddMarkupContent(189, "\n                        ");
                    __builder3.AddMarkupContent(190, "<option value=\"active\">Active</option>\n                        ");
                    __builder3.AddMarkupContent(191, "<option value=\"inactive\">InActive</option>\n                    ");
                }
                );
                __builder2.AddMarkupContent(192, "\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(193, "\n                ");
                __builder2.OpenElement(194, "div");
                __builder2.AddAttribute(195, "class", "form-group");
                __builder2.AddMarkupContent(196, "\n                    ");
                __builder2.OpenElement(197, "div");
                __builder2.AddAttribute(198, "class", "offset-md-5");
                __builder2.AddMarkupContent(199, "\n                        ");
                __builder2.AddMarkupContent(200, "<button type=\"submit\" class=\"btn btn-info\">Save</button>\n                        ");
                __builder2.OpenElement(201, "button");
                __builder2.AddAttribute(202, "type", "button");
                __builder2.AddAttribute(203, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 88 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor"
                                                         goToOverview

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(204, "class", "btn btn-default");
                __builder2.AddContent(205, "Back");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(206, "\n                    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(207, "\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(208, "\n\n                ");
                __builder2.OpenElement(209, "label");
                __builder2.AddContent(210, 
#nullable restore
#line 92 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndCommunity\CouponPages\CreateAndEdit.razor"
                        Message

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(211, "\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(212, "\n        ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(213, "\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(214, "\n\n\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
namespace __Blazor.PayCoin.Client.Pages.BackEndCommunity.CouponPages.CreateAndEdit
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateInputNumber_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, System.Object __arg1, int __seq2, System.Object __arg2, int __seq3, TValue __arg3, int __seq4, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg4, int __seq5, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg5)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputNumber<TValue>>(seq);
        __builder.AddAttribute(__seq0, "class", __arg0);
        __builder.AddAttribute(__seq1, "placeholder", __arg1);
        __builder.AddAttribute(__seq2, "id", __arg2);
        __builder.AddAttribute(__seq3, "Value", __arg3);
        __builder.AddAttribute(__seq4, "ValueChanged", __arg4);
        __builder.AddAttribute(__seq5, "ValueExpression", __arg5);
        __builder.CloseComponent();
        }
        public static void CreateInputSelect_1<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, System.Object __arg1, int __seq2, System.Object __arg2, int __seq3, TValue __arg3, int __seq4, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg4, int __seq5, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg5, int __seq6, global::Microsoft.AspNetCore.Components.RenderFragment __arg6)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputSelect<TValue>>(seq);
        __builder.AddAttribute(__seq0, "class", __arg0);
        __builder.AddAttribute(__seq1, "placeholder", __arg1);
        __builder.AddAttribute(__seq2, "id", __arg2);
        __builder.AddAttribute(__seq3, "Value", __arg3);
        __builder.AddAttribute(__seq4, "ValueChanged", __arg4);
        __builder.AddAttribute(__seq5, "ValueExpression", __arg5);
        __builder.AddAttribute(__seq6, "ChildContent", __arg6);
        __builder.CloseComponent();
        }
        public static void CreateInputSelect_2<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, System.Object __arg1, int __seq2, System.Object __arg2, int __seq3, TValue __arg3, int __seq4, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg4, int __seq5, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg5, int __seq6, global::Microsoft.AspNetCore.Components.RenderFragment __arg6)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputSelect<TValue>>(seq);
        __builder.AddAttribute(__seq0, "class", __arg0);
        __builder.AddAttribute(__seq1, "placeholder", __arg1);
        __builder.AddAttribute(__seq2, "id", __arg2);
        __builder.AddAttribute(__seq3, "Value", __arg3);
        __builder.AddAttribute(__seq4, "ValueChanged", __arg4);
        __builder.AddAttribute(__seq5, "ValueExpression", __arg5);
        __builder.AddAttribute(__seq6, "ChildContent", __arg6);
        __builder.CloseComponent();
        }
        public static void CreateInputSelect_3<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, System.Object __arg1, int __seq2, System.Object __arg2, int __seq3, TValue __arg3, int __seq4, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg4, int __seq5, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg5, int __seq6, global::Microsoft.AspNetCore.Components.RenderFragment __arg6)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputSelect<TValue>>(seq);
        __builder.AddAttribute(__seq0, "class", __arg0);
        __builder.AddAttribute(__seq1, "placeholder", __arg1);
        __builder.AddAttribute(__seq2, "id", __arg2);
        __builder.AddAttribute(__seq3, "Value", __arg3);
        __builder.AddAttribute(__seq4, "ValueChanged", __arg4);
        __builder.AddAttribute(__seq5, "ValueExpression", __arg5);
        __builder.AddAttribute(__seq6, "ChildContent", __arg6);
        __builder.CloseComponent();
        }
        public static void CreateInputSelect_4<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, System.Object __arg1, int __seq2, System.Object __arg2, int __seq3, TValue __arg3, int __seq4, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg4, int __seq5, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg5, int __seq6, global::Microsoft.AspNetCore.Components.RenderFragment __arg6)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputSelect<TValue>>(seq);
        __builder.AddAttribute(__seq0, "class", __arg0);
        __builder.AddAttribute(__seq1, "placeholder", __arg1);
        __builder.AddAttribute(__seq2, "id", __arg2);
        __builder.AddAttribute(__seq3, "Value", __arg3);
        __builder.AddAttribute(__seq4, "ValueChanged", __arg4);
        __builder.AddAttribute(__seq5, "ValueExpression", __arg5);
        __builder.AddAttribute(__seq6, "ChildContent", __arg6);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
