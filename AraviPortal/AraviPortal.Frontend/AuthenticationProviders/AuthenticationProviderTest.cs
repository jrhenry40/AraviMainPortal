using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace AraviPortal.Frontend.AuthenticationProviders;

public class AuthenticationProviderTest : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        await Task.Delay(1000);
        var anonimous = new ClaimsIdentity();
        var user = new ClaimsIdentity(authenticationType: "test");
        var superadmin = new ClaimsIdentity(new List<Claim>
    {
        new Claim("FirstName", "Henry"),
        new Claim("LastName", "Rios"),
        new Claim(ClaimTypes.Name, "hrios@yopmail.com"),
        new Claim(ClaimTypes.Role, "Superadmin")
    },
    authenticationType: "test");

        return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(user)));
    }
}