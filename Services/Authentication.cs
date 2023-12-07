using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using OnlineStore.Domain;
using System.Security.Claims;

namespace OnlineStore.Services
{
    public class Authentication : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage session_storage;
        private ClaimsPrincipal anonymous = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim> { new Claim(ClaimTypes.Anonymous, "true") }));

        public Authentication(ProtectedSessionStorage session_storage)
        {
            this.session_storage = session_storage;
        }

        public async Task<UserSession> getUserSession()
        {
            var user_session_storage_result = await session_storage.GetAsync<UserSession>("UserSession");
            var user_session = user_session_storage_result.Success ? user_session_storage_result.Value : null;
            return user_session;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var user_session = await getUserSession();
                if (user_session == null)
                    return await Task.FromResult(new AuthenticationState(anonymous));

                var claims_principal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim> {
                    new Claim(ClaimTypes.Name, user_session.id),
                    new Claim(ClaimTypes.Role, user_session.role),
                    new Claim(ClaimTypes.Anonymous, "false")
                }, "Login")); ;

                return await Task.FromResult(new AuthenticationState(claims_principal));
            }
            catch
            {
                return await Task.FromResult(new AuthenticationState(anonymous));
            }
        }

        public async Task updateAuthenticationState(UserSession? user_session)
        {
            ClaimsPrincipal claims_principal;
            if (user_session != null) // user is logged in
            {
                await session_storage.SetAsync("UserSession", user_session);
                claims_principal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user_session.id),
                    new Claim(ClaimTypes.Role, user_session.role)
                }));
            }
            else // user is logged out
            {
                await session_storage.DeleteAsync("UserSession");
                claims_principal = anonymous;
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claims_principal)));
        }
    }
}
