using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PayCoin.Client.Models;
using PayCoin.Client.Services;

namespace PayCoin.Client.Pages.BackEndAdmin.SmallCategoryPages
{
    public partial class CreateAndEdit
    {
        // State Management
        protected string Message = string.Empty;
        protected bool Saved;

        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject]
        public IChildCategoryService ChildCategoryService { get; set; }

        [Inject]
        public ISmallCategoryService SmallCategoryService { get; set; }

        [Parameter]
        public string Id { get; set; }

        public SmallCategory smallcategory { get; set; } = new SmallCategory();
        public List<ChildCategory> childcategorys { get; set; } = new List<ChildCategory>();

        protected async override Task OnInitializedAsync()
        {
           
            Saved = false;

            if (!String.IsNullOrEmpty(Id))
            {
                var itemId = Convert.ToInt32(Id);
                smallcategory = await SmallCategoryService.GetSmallCategory(itemId);
            }
            childcategorys = (await ChildCategoryService.GetAllChildCategorys()).ToList();

        }

        protected async Task HandleValidRequest()
        {
            if (String.IsNullOrEmpty(Id)) // We need to add the item
            {
                var res = await SmallCategoryService.AddSmallCategory(smallcategory);

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
                await SmallCategoryService.UpdateSmallCategory(smallcategory);
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
            navigationManager.NavigateTo("/admin/smallcategory");
        }

    }
}