using System.Collections.Generic;
using System.Security.Claims;

namespace eContract.Models {
    public class UserProfile {
        private readonly Dictionary<string, string> claim = new Dictionary<string, string>();
        private readonly Dictionary<string, string> claimType = new Dictionary<string, string>() {
            { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress","email" },
            { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname","given_name" },
            { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name","unique_name" },
            { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn","upn" },
            { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname","family_name" },
            {"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/privatepersonalidentifier","ppid" },
            {"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier","sub" },
            {"http://schemas.microsoft.com/ws/2008/06/identity/claims/windowsaccountname","winaccountname" },
        };

        public UserProfile(ClaimsIdentity ci) {
            foreach (Claim c in ci.Claims) {
                string claimTypeKey = (claimType.ContainsKey(c.Type) == true ? claimType[c.Type] : c.Type);

                claim.Add(claimTypeKey, c.Value);
            }
        }

        public Dictionary<string, string> Claims { get { return claim; } }
    }
}