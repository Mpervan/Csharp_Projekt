using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace ReceptiAplikacija
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        public CustomAuthStateProvider(ILocalStorageService localStorage)
        {
            _localStorageService = localStorage;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var state = new AuthenticationState(new ClaimsPrincipal());
            string username = await _localStorageService.GetItemAsStringAsync("username");
            if(!string.IsNullOrEmpty(username))
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username)
                }, "test authentication type");
                state = new AuthenticationState(new ClaimsPrincipal(identity));
            }
            NotifyAuthenticationStateChanged(Task.FromResult(state));
            return state;
        }
    }
}
