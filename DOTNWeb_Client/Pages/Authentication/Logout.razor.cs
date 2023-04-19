using DOTNWeb_Client.Service.IService;
using Microsoft.AspNetCore.Components;

namespace DOTNWeb_Client.Pages.Authentication
{
    public partial class Logout
    {
        [Inject]
        public IAuthenticationService _authSerivce { get; set; }
        [Inject]
        public NavigationManager _navigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await _authSerivce.Logout();
            //forceload da refresh napravi
            _navigationManager.NavigateTo("/", forceLoad: true);
        }
    }
}
