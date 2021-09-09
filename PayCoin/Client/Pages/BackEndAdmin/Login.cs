using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using PayCoin.Client.Models;
using PayCoin.Client.Requests;
using PayCoin.Client.Services;

namespace PayCoin.Client.Pages.BackEndAdmin
{
    public partial class Login
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected string Message = string.Empty;
        public Model model { get; set; } = new Model();
        private bool loading;
        private string error;
        public LoginResult user { get; set; }
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }
        [Inject]
        public ILocalStorageService LocalStorageService { get; set; }


        protected async Task HandleValidSubmit()
        {
            

               await AuthenticationService.Login(model.Phone, model.Password);
           
        }
        public async Task Initialize()
        {
            Console.WriteLine("hi");
            user = await LocalStorageService.GetItemAsync<LoginResult>("user");
            Message = user.UserId.ToString();

        }
        protected override void OnInitialized()
        {
            // redirect to home if already logged in
            if (AuthenticationService.User != null)
            {
                NavigationManager.NavigateTo("");
            }
        }


    }
}