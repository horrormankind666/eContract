using System.Configuration;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using eContract.Class;

namespace eContract {
    public partial class Startup {
        private static readonly string clientId = ConfigurationManager.AppSettings["ida:ClientId"];
        private static readonly string clientSecret = ConfigurationManager.AppSettings["ida:ClientSecret"];
        private static readonly string resource = ConfigurationManager.AppSettings["ida:ResourceID"];
        private static readonly string metadataAddress = ConfigurationManager.AppSettings["ida:ADFSDiscoveryDoc"];
        private static readonly string postLogoutRedirectUri = ConfigurationManager.AppSettings["ida:PostLogoutRedirectUri"];

        public void ConfigureAuth(IAppBuilder app) {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions() {
                CookieManager = new SystemWebCookieManager()
            });
            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions {
                    ClientId = clientId,
                    ClientSecret = clientSecret,
                    Resource = resource,
                    Scope = "openid allatclaims",
                    MetadataAddress = metadataAddress,
                    PostLogoutRedirectUri = postLogoutRedirectUri,
                    RedirectUri = postLogoutRedirectUri,
                    Notifications = new OpenIdConnectAuthenticationNotifications {
                        AuthenticationFailed = context => {
                            context.HandleResponse();
                            context.Response.Redirect("/?message=" + context.Exception.Message);
                            //context.Response.Redirect("/Error?message=" + context.Response.StatusCode.ToString());
                            return Task.FromResult(0);
                        }
                    }
                }
            );
        }
    }
}