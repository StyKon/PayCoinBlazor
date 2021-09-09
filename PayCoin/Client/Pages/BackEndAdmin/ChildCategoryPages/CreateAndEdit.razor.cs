using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PayCoin.Client.Models;
using PayCoin.Client.Services;

namespace PayCoin.Client.Pages.BackEndAdmin.ChildCategoryPages
{
    public partial class CreateAndEdit
    {
        // State Management
        protected string Message = string.Empty;
        protected bool Saved;

        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject]
        public ICategoryService CategoryService { get; set; }

        [Inject]
        public IChildCategoryService ChildCategoryService { get; set; }

        [Parameter]
        public string Id { get; set; }

        public ChildCategory childcategory { get; set; } = new ChildCategory();
        public List<Category> categorys { get; set; } = new List<Category>();

        protected async override Task OnInitializedAsync()
        {
           
            Saved = false;

            if (!String.IsNullOrEmpty(Id))
            {
                var itemId = Convert.ToInt32(Id);
                childcategory = await ChildCategoryService.GetChildCategory(itemId);
            }
            categorys = (await CategoryService.GetAllCategorys()).ToList();

        }

        protected async Task HandleValidRequest()
        {
            if (String.IsNullOrEmpty(Id)) // We need to add the item
            {
                var res = await ChildCategoryService.AddChildCategory(childcategory);

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
                await ChildCategoryService.UpdateChildCategory(childcategory);
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
            navigationManager.NavigateTo("/admin/childcategory");
        }

    }
}