using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Auth2.Infrastructure
{
    public class RolesFromClaims
    {
        public static IEnumerable<Claim> CreateRolesBasedOnClaims(ClaimsIdentity identity)
        {
            List<Claim> claims = new List<Claim>();
            //Creates a custom IncidentResolver Role based upon the user's claims that they are a Full Time Employee
            //And have role Admin assigned to them.
            if (identity.HasClaim(c => c.Type == "FTE" && c.Value == "1") &&
                identity.HasClaim(ClaimTypes.Role, "Admin"))
            {
                claims.Add(new Claim(ClaimTypes.Role, "IncidentResolvers"));
            }

            return claims;
        }
    }
}