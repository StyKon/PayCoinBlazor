using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PayCoin.Client.Models;
using PayCoin.Client.Requests;
using PayCoin.Client.Services;

namespace PayCoin.Client.Pages.BackEndAdmin.SmallCategoryPages
{
    public partial class Index
    {
        public IEnumerable<SmallCategory> smallcategorys { get; set; }
        protected string Message = string.Empty;

        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject]
        public ISmallCategoryService SmallCategoryService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            smallcategorys = (await SmallCategoryService.GetAllSmallCategorys()).ToList();                
        }
    

        protected async Task DeleteItem(long Id)
        {
            if (!(Id==0))
            {
                var itemId = Convert.ToInt32(Id);
                await SmallCategoryService.DeleteSmallCategory(itemId);

                smallcategorys = (await SmallCategoryService.GetAllSmallCategorys()).ToList();
            }

            Message = "Something went wrong, unable to delete";
        }
        protected void goToAddPage()
        {
            navigationManager.NavigateTo("/admin/smallcategory/add");
        }
    }
}