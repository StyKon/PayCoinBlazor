using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PayCoin.Client.Models;
using PayCoin.Client.Requests;
using PayCoin.Client.Services;

namespace PayCoin.Client.Pages.BackEndProvider.ProductPages
{
    public partial class Index
    {
        public IEnumerable<Product> products { get; set; }
        protected string Message = string.Empty;

        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject]
        public IProductService ProductService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            products = (await ProductService.GetActiveProductForProvider(1)).ToList();                
        }
    

        protected async Task DeleteItem(long Id)
        {
            if (!(Id==0))
            {
                var itemId = Convert.ToInt32(Id);
                await ProductService.DeleteProduct(itemId);

                products = (await ProductService.GetAllProducts()).ToList();
            }

            Message = "Something went wrong, unable to delete";
        }
        protected void goToAddPage()
        {
            navigationManager.NavigateTo("/provider/product/add");
        }
    }
}