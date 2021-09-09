using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PayCoin.Client.Models;
using PayCoin.Client.Requests;
using PayCoin.Client.Services;

namespace PayCoin.Client.Pages.BackEndAdmin.ChildCategoryPages
{
    public partial class Index
    {
        public IEnumerable<ChildCategory> childcategorys { get; set; }
        protected string Message = string.Empty;

        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject]
        public IChildCategoryService ChildCategoryService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            childcategorys = (await ChildCategoryService.GetAllChildCategorys()).ToList();                
        }
    

        protected async Task DeleteItem(long Id)
        {
            if (!(Id==0))
            {
                var itemId = Convert.ToInt32(Id);
                await ChildCategoryService.DeleteChildCategory(itemId);

                childcategorys = (await ChildCategoryService.GetAllChildCategorys()).ToList();
            }

            Message = "Something went wrong, unable to delete";
        }
        protected void goToAddPage()
        {
            navigationManager.NavigateTo("/admin/childcategory/add");
        }
    }
}