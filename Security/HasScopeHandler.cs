using System.Linq;
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Authorization;

namespace SADZFP.Api.Security
{
    public class HasScopeHandler : AuthorizationHandler<HasScopeRequirement>
    {
        protected override Task HandleRequirementAsync( 
            AuthorizationHandlerContext context, 
            HasScopeRequirement requirement)
        {
            //If user does not have the scope claim, get out of here.

            if(!context.User.HasClaim(c => c.Type == "scope" && c.issuer == requirement.Issuer))
                return Task.CompletedTask;

            //Split the scopes string into an array
            var scopes = context.User
                .FindFirst(c => c.Type = "scope" && c.issuer == requirement.Issuer)
                .Value.Split(' ');

            //Succeed if the scope array contains the requirement scope
            if(scopes.Any(s => s == requirement.Scope))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}