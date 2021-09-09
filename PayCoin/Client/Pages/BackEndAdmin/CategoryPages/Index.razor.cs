using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PayCoin.Client.Models;
using PayCoin.Client.Requests;
using PayCoin.Client.Services;

namespace PayCoin.Client.Pages.BackEndAdmin.CategoryPages
{
    public partial class Index
    {
        public IEnumerable<Category> categorys { get; set; }
        protected string Message = string.Empty;

        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject]
        public ICategoryService CategoryService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            categorys = (await CategoryService.GetAllCategorys()).ToList();                
        }
    

        protected async Task DeleteItem(long Id)
        {
            if (!(Id==0))
            {
                var itemId = Convert.ToInt32(Id);
                await CategoryService.DeleteCategory(itemId);

                categorys = (await CategoryService.GetAllCategorys()).ToList();
            }

            Message = "Something went wrong, unable to delete";
        }
        protected void goToAddPage()
        {
            navigationManager.NavigateTo("/admin/category/add");
        }
    }
}