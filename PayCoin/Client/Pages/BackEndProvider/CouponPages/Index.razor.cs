using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PayCoin.Client.Models;
using PayCoin.Client.Requests;
using PayCoin.Client.Services;

namespace PayCoin.Client.Pages.BackEndProvider.CouponPages
{
    public partial class Index
    {
        public IEnumerable<Coupon> coupons { get; set; }
        protected string Message = string.Empty;

        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject]
        public ICouponService CouponService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            coupons = (await CouponService.GetUsedCouponForProvider(1)).ToList();                
        }
    

        protected async Task DeleteItem(long Id)
        {
            if (!(Id==0))
            {
                var itemId = Convert.ToInt32(Id);
                await CouponService.DeleteCoupon(itemId);

                coupons = (await CouponService.GetAllCoupons()).ToList();
            }

            Message = "Something went wrong, unable to delete";
        }
        protected void goToAddPage()
        {
            navigationManager.NavigateTo("/provider/coupon/add");
        }
    }
}