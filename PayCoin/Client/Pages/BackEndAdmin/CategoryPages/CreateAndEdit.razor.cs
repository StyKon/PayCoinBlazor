using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PayCoin.Client.Models;
using PayCoin.Client.Services;

namespace PayCoin.Client.Pages.BackEndAdmin.CategoryPages
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

        [Parameter]
        public string Id { get; set; }

        public Category category { get; set; } = new Category();

        protected async override Task OnInitializedAsync()
        {
            Saved = false;

            if (!String.IsNullOrEmpty(Id))
            {
                var itemId = Convert.ToInt32(Id);
                category = await CategoryService.GetCategory(itemId);
            }

        }

        protected async Task HandleValidRequest()
        {
            if (String.IsNullOrEmpty(Id)) // We need to add the item
            {
                var res = await CategoryService.AddCategory(category);

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
                await CategoryService.UpdateCategory(category);
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
            navigationManager.NavigateTo("/admin/category");
        }

    }
}