using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PayCoin.Client.Models;
using PayCoin.Client.Services;

namespace PayCoin.Client.Pages.BackEndAdmin.ProductPages
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
        [Inject]
        public ISmallCategoryService SmallCategoryService { get; set; }
        [Inject]
        public IProviderService ProviderService { get; set; }

        [Inject]
        public IProductService ProductService { get; set; }

        [Parameter]
        public string Id { get; set; }

        public Product product { get; set; } = new Product();
        public List<Category> categorys { get; set; } = new List<Category>();
        public List<ChildCategory> childcategorys { get; set; } = new List<ChildCategory>();
        public List<SmallCategory> smallcategorys { get; set; } = new List<SmallCategory>();
        public List<Provider> providers { get; set; } = new List<Provider>();

        protected async override Task OnInitializedAsync()
        {
           
            Saved = false;

            if (!String.IsNullOrEmpty(Id))
            {
                var itemId = Convert.ToInt32(Id);
                product = await ProductService.GetProduct(itemId);
            }
            categorys = (await CategoryService.GetAllCategorys()).ToList();
            providers = (await ProviderService.GetAllProviders()).ToList();
            childcategorys = (await ChildCategoryService.GetAllChildCategorys()).ToList();
            smallcategorys = (await SmallCategoryService.GetAllSmallCategorys()).ToList();


        }

        protected async Task HandleValidRequest()
        {
            if (String.IsNullOrEmpty(Id)) // We need to add the item
            {
                var res = await ProductService.AddProduct(product);

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
                await ProductService.UpdateProduct(product);
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
            navigationManager.NavigateTo("/admin/product");
        }

    }
}