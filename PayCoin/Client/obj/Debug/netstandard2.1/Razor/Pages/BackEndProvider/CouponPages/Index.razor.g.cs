#pragma checksum "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndProvider\CouponPages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8c91f406e7c1af943e4009247916bc2492a95229"
// <auto-generated/>
#pragma warning disable 1591
namespace PayCoin.Client.Pages.BackEndProvider.CouponPages
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
#nullable restore
#line 2 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndProvider\CouponPages\Index.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/provider/coupon")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, @"<div class=""page-bar"">
        <div class=""page-title-breadcrumb"">
            <div class="" pull-left"">
                <div class=""page-title"">Coupon</div>
            </div>
            <ol class=""breadcrumb page-breadcrumb pull-right"">
                <li>
                    <i class=""fa fa-home""></i>&nbsp;<a class=""parent-item"" href=""index.html"">Home</a>&nbsp;<i class=""fa fa-angle-right""></i>
                </li>
                <li>
                    <a class=""parent-item"" href=""#"">Apps</a>&nbsp;<i class=""fa fa-angle-right""></i>
                </li>
                <li class=""active"">Coupon List</li>
            </ol>
        </div>
    </div>
    ");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "row");
            __builder.AddMarkupContent(3, "\r\n        ");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "col-sm-12");
            __builder.AddMarkupContent(6, "\r\n            ");
            __builder.OpenElement(7, "div");
            __builder.AddAttribute(8, "class", "card-box");
            __builder.AddMarkupContent(9, "\r\n                ");
            __builder.AddMarkupContent(10, "<div class=\"card-head\">\r\n                    <header>Coupon List</header>\r\n                </div>\r\n                ");
            __builder.OpenElement(11, "div");
            __builder.AddAttribute(12, "class", "card-body ");
            __builder.AddMarkupContent(13, "\r\n                    ");
            __builder.AddMarkupContent(14, "<div class=\"state-overview\">\r\n                        <div class=\"row\">\r\n                            <div class=\"col-lg-3 col-sm-6\">\r\n                                <div class=\"overview-panel purple\">\r\n                                    <div class=\"symbol\">\r\n                                        <i class=\"fa fa-ticket usr-clr\"></i>\r\n                                    </div>\r\n                                    <div class=\"value white\">\r\n                                        <p class=\"sbold addr-font-h1\" data-counter=\"counterup\" data-value=\"1576\">0</p>\r\n                                        <p>Total Tickets</p>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                            <div class=\"col-lg-3 col-sm-6\">\r\n                                <div class=\"overview-panel deepPink-bgcolor\">\r\n                                    <div class=\"symbol\">\r\n                                        <i class=\"fa fa-reply\"></i>\r\n                                    </div>\r\n                                    <div class=\"value white\">\r\n                                        <p class=\"sbold addr-font-h1\" data-counter=\"counterup\" data-value=\"956\">0</p>\r\n                                        <p>Respond</p>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                            <div class=\"col-lg-3 col-sm-6\">\r\n                                <div class=\"overview-panel orange\">\r\n                                    <div class=\"symbol\">\r\n                                        <i class=\"fa fa-handshake-o\"></i>\r\n                                    </div>\r\n                                    <div class=\"value white\">\r\n                                        <p class=\"sbold addr-font-h1\" data-counter=\"counterup\" data-value=\"856\">0</p>\r\n                                        <p>Resolved</p>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                            <div class=\"col-lg-3 col-sm-6\">\r\n                                <div class=\"overview-panel blue-bgcolor\">\r\n                                    <div class=\"symbol\">\r\n                                        <i class=\"fa fa-clock-o\"></i>\r\n                                    </div>\r\n                                    <div class=\"value white\">\r\n                                        <p class=\"sbold addr-font-h1\" data-counter=\"counterup\" data-value=\"134\">0</p>\r\n                                        <p>Pending</p>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                    ");
            __builder.OpenElement(15, "div");
            __builder.AddAttribute(16, "class", "row p-b-20");
            __builder.AddMarkupContent(17, "\r\n                        ");
            __builder.OpenElement(18, "div");
            __builder.AddAttribute(19, "class", "col-md-6 col-sm-6 col-6");
            __builder.AddMarkupContent(20, "\r\n                            ");
            __builder.OpenElement(21, "div");
            __builder.AddAttribute(22, "class", "btn-group");
            __builder.AddMarkupContent(23, "\r\n                                ");
            __builder.OpenElement(24, "button");
            __builder.AddAttribute(25, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 82 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndProvider\CouponPages\Index.razor"
                                                   goToAddPage

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(26, "id", "addRow1");
            __builder.AddAttribute(27, "class", "btn btn-info");
            __builder.AddMarkupContent(28, "\r\n                                    Add New <i class=\"fa fa-plus\"></i>\r\n                                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(29, "\r\n                            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(31, "\r\n                        ");
            __builder.AddMarkupContent(32, @"<div class=""col-md-6 col-sm-6 col-6"">
                            <div class=""btn-group pull-right"">
                                <button class=""btn deepPink-bgcolor  btn-outline dropdown-toggle"" data-toggle=""dropdown"">
                                    Tools
                                    <i class=""fa fa-angle-down""></i>
                                </button>
                                <ul class=""dropdown-menu pull-right"">
                                    <li>
                                        <a href=""javascript:;"">
                                            <i class=""fa fa-print""></i> Print
                                        </a>
                                    </li>
                                    <li>
                                        <a href=""javascript:;"">
                                            <i class=""fa fa-file-pdf-o""></i> Save as PDF
                                        </a>
                                    </li>
                                    <li>
                                        <a href=""javascript:;"">
                                            <i class=""fa fa-file-excel-o""></i> Export to Excel
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    ");
            __builder.CloseElement();
#nullable restore
#line 113 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndProvider\CouponPages\Index.razor"
                             if (coupons == null)
                    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(33, "                ");
            __builder.AddMarkupContent(34, "<p>Loading...</p> ");
#nullable restore
#line 115 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndProvider\CouponPages\Index.razor"
                                  }
                    else
                    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(35, "                ");
            __builder.OpenElement(36, "table");
            __builder.AddAttribute(37, "class", "table table-hover table-checkable order-column full-width");
            __builder.AddAttribute(38, "id", "example4");
            __builder.AddMarkupContent(39, "\r\n                    ");
            __builder.AddMarkupContent(40, @"<thead>
                        <tr>
                            <th class=""center"">Photo</th>
                            <th class=""center"">Code</th>
                            <th class=""center"">Value</th>
                            <th class=""center"">Date Validation</th>
                            <th class=""center"">Date Expired</th>
                            <th class=""center"">Type</th>
                            <th class=""center"">Nature</th>
                            <th class=""center"">Validation</th>
                            <th class=""center"">Status</th>
                            <th class=""center"">Action</th>
                        </tr>
                    </thead>
                    ");
            __builder.OpenElement(41, "tbody");
            __builder.AddMarkupContent(42, "\r\n");
#nullable restore
#line 135 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndProvider\CouponPages\Index.razor"
                         foreach (var coupon in coupons)
                        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(43, "                        ");
            __builder.OpenElement(44, "tr");
            __builder.AddMarkupContent(45, "\r\n                            ");
            __builder.AddMarkupContent(46, "<td class=\"user-circle-img sorting_1\">\r\n                                <img src=\"BackEnd/assets/img/user/user1.jpg\" alt>\r\n                            </td>\r\n                            ");
            __builder.OpenElement(47, "td");
            __builder.AddAttribute(48, "class", "center");
            __builder.AddContent(49, 
#nullable restore
#line 141 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndProvider\CouponPages\Index.razor"
                                                coupon.Code

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(50, "\r\n                            ");
            __builder.OpenElement(51, "td");
            __builder.AddAttribute(52, "class", "center");
            __builder.AddContent(53, 
#nullable restore
#line 142 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndProvider\CouponPages\Index.razor"
                                                coupon.Value

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(54, "\r\n                            ");
            __builder.OpenElement(55, "td");
            __builder.AddAttribute(56, "class", "center");
            __builder.AddContent(57, 
#nullable restore
#line 143 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndProvider\CouponPages\Index.razor"
                                                coupon.DateValidation

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(58, "\r\n                            ");
            __builder.OpenElement(59, "td");
            __builder.AddAttribute(60, "class", "center");
            __builder.AddContent(61, 
#nullable restore
#line 144 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndProvider\CouponPages\Index.razor"
                                                coupon.DateExpired

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(62, "\r\n                            ");
            __builder.OpenElement(63, "td");
            __builder.AddAttribute(64, "class", "center");
            __builder.AddContent(65, 
#nullable restore
#line 145 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndProvider\CouponPages\Index.razor"
                                                coupon.Type

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(66, "\r\n                            ");
            __builder.OpenElement(67, "td");
            __builder.AddAttribute(68, "class", "center");
            __builder.AddContent(69, 
#nullable restore
#line 146 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndProvider\CouponPages\Index.razor"
                                                coupon.Nature

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(70, "\r\n                            ");
            __builder.OpenElement(71, "td");
            __builder.AddAttribute(72, "class", "center");
            __builder.AddMarkupContent(73, "\r\n");
#nullable restore
#line 148 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndProvider\CouponPages\Index.razor"
                                 if (coupon.Validation == "valid")
                                {

#line default
#line hidden
#nullable disable
            __builder.AddContent(74, "                                    ");
            __builder.AddMarkupContent(75, "<span class=\"label label-sm box-shadow-1 label-success\">Valid</span>");
#nullable restore
#line 150 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndProvider\CouponPages\Index.razor"
                                                                                                        }
                                else
                                {

#line default
#line hidden
#nullable disable
            __builder.AddContent(76, "                            ");
            __builder.AddMarkupContent(77, "<span class=\"label label-sm box-shadow-1 label-warning\">InValid</span>\r\n");
#nullable restore
#line 154 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndProvider\CouponPages\Index.razor"
                                }

#line default
#line hidden
#nullable disable
            __builder.AddContent(78, "                            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(79, "\r\n                            ");
            __builder.OpenElement(80, "td");
            __builder.AddAttribute(81, "class", "center");
            __builder.AddMarkupContent(82, "\r\n");
#nullable restore
#line 157 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndProvider\CouponPages\Index.razor"
                                 if (coupon.Status == "active")
                                {

#line default
#line hidden
#nullable disable
            __builder.AddContent(83, "                                    ");
            __builder.AddMarkupContent(84, "<span class=\"label label-sm box-shadow-1 label-success\">Active</span>");
#nullable restore
#line 159 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndProvider\CouponPages\Index.razor"
                                                                                                         }
                                else
                                {

#line default
#line hidden
#nullable disable
            __builder.AddContent(85, "                                    ");
            __builder.AddMarkupContent(86, "<span class=\"label label-sm box-shadow-1 label-warning\">InActive</span>\r\n");
#nullable restore
#line 163 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndProvider\CouponPages\Index.razor"
                                }

#line default
#line hidden
#nullable disable
            __builder.AddContent(87, "                            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(88, "\r\n                            ");
            __builder.OpenElement(89, "td");
            __builder.AddAttribute(90, "class", "center");
            __builder.AddMarkupContent(91, "\r\n                                ");
            __builder.OpenElement(92, "a");
            __builder.AddAttribute(93, "href", 
#nullable restore
#line 166 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndProvider\CouponPages\Index.razor"
                                           $"admin/coupon/edit/{coupon.CouponId}"

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(94, "class", "btn btn-tbl-edit btn-xs");
            __builder.AddMarkupContent(95, "\r\n                                    <i class=\"fa fa-pencil\"></i>\r\n                                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(96, "\r\n                                ");
            __builder.OpenElement(97, "button");
            __builder.AddAttribute(98, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 169 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndProvider\CouponPages\Index.razor"
                                                  () => DeleteItem(coupon.CouponId)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(99, "class", "btn btn-tbl-delete btn-xs");
            __builder.AddMarkupContent(100, "\r\n                                    <i class=\"fa fa-trash-o \"></i>\r\n                                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(101, "\r\n                            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(102, "\r\n                        ");
            __builder.CloseElement();
#nullable restore
#line 173 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndProvider\CouponPages\Index.razor"
                             }

#line default
#line hidden
#nullable disable
            __builder.AddContent(103, "                                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(104, "\r\n                ");
            __builder.CloseElement();
#nullable restore
#line 175 "C:\Users\khali\source\repos\PayCoin\PayCoin\Client\Pages\BackEndProvider\CouponPages\Index.razor"
                        }

#line default
#line hidden
#nullable disable
            __builder.AddContent(105, "                            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(106, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(107, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(108, "\r\n    ");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
