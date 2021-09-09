using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PayCoin.Client.Models;
using PayCoin.Client.Services;

namespace PayCoin.Client.Pages.BackEndAdmin.CouponPages
{
    public partial class CreateAndEdit
    {
        // State Management
        protected string Message = string.Empty;
        protected bool Saved;

        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject]
        public ICouponService CouponService { get; set; }

        [Inject]
        public IProviderService ProviderService { get; set; }
        [Inject]
        public ICommunityService CommunityService { get; set; }

        [Parameter]
        public string Id { get; set; }

        public Coupon coupon { get; set; } = new Coupon();
        public List<Provider> providers { get; set; } = new List<Provider>();
        public List<Community> communitys { get; set; } = new List<Community>();

        protected async override Task OnInitializedAsync()
        {
           
            Saved = false;

            if (!String.IsNullOrEmpty(Id))
            {
                var itemId = Convert.ToInt32(Id);
                coupon = await CouponService.GetCoupon(itemId);
            }
            providers = (await ProviderService.GetAllProviders()).ToList();
            communitys = (await CommunityService.GetAllCommunitys()).ToList();

        }

        protected async Task HandleValidRequest()
        {
            if (String.IsNullOrEmpty(Id)) // We need to add the item
            {
                var res = await CouponService.AddCoupon(coupon);

                if (res != null)
                {
                    Saved = true;
                    Message = "Item has been added";
                }
                else
                {

                    Message = "Something went wrong";
                }
            }
            else // We are updating the item
            {
                await CouponService.UpdateCoupon(coupon);
                Saved = true;
                Message = "Item has been updated";
            }
        }

        protected void HandleInvalidRequest()
        {
            Message = "Failed to submit form";
        }

        protected void goToOverview()
        {
            navigationManager.NavigateTo("/admin/coupon");
        }

    }
}