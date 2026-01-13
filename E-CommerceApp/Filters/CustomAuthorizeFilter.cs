using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace E_CommerceApp.Filters;

public class CustomAuthorizeFilter : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (!context.HttpContext.User.Identity.IsAuthenticated)
        {
            var returnUrl = context.HttpContext.Request.Path + context.HttpContext.Request.QueryString;

            if (context.HttpContext.Request.Method == "POST" &&
                context.HttpContext.Request.Path == "/Home/AddToCart")
            {
                var form = context.HttpContext.Request.Form;
                if (form.ContainsKey("returnUrl") && !string.IsNullOrEmpty(form["returnUrl"]))
                {
                    returnUrl = form["returnUrl"]; // e.g., /Home/Details/1003
                }
            }

            context.Result = new RedirectToPageResult(
                "/Account/Login",
                new { area = "Identity", returnUrl }
            );
        }
    }
}