using Microsoft.FeatureManagement.FeatureFilters;

namespace Project.APIS.Features
{
    public class UserTargetingContext : ITargetingContextAccessor
    {
        private const string CashKey = "UserTargetingContext.TargetingContext";
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserTargetingContext(IHttpContextAccessor contextAccessor)
        {
            this._httpContextAccessor = contextAccessor;
        }
        public ValueTask<TargetingContext> GetContextAsync()
        {

            HttpContext httpContext = _httpContextAccessor.HttpContext;

           if(httpContext.Items.TryGetValue(CashKey,out object?value))
            {
                return new ValueTask<TargetingContext>((TargetingContext)value!);
            }


            var targetingContext = new TargetingContext
            {
                UserId = GetUserd(httpContext),
                Groups = GetUserGroups(httpContext)
            };

            return new ValueTask<TargetingContext>(targetingContext);
        }

        private static string GetUserd(HttpContext? httpContext)
        {
            // for the Demo purpose we will check the user id from the header
            // In real app this might come from the authentication Claim

            return httpContext?.Request.Headers["x-user-id"].FirstOrDefault() ?? string.Empty;
        }



        private static string[] GetUserGroups(HttpContext? httpContext)
        {
            // for the Demo purpose we will check the user id from the header
            // In real app this might come from the authentication Claim

            return httpContext?.Request.Headers["x-user-groups"].FirstOrDefault()?.Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries) ?? [];
        }
    }
}
