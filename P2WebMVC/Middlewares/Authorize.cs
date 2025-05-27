using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using P2WebMVC.Interfaces;

namespace P2WebMVC.Middlewares;


[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{

    public void OnAuthorization(AuthorizationFilterContext context)
    {

        // token from cookies 
        var token = context.HttpContext.Request.Cookies["Authorization_Token_Trinkle"];

        // service injection 
        var tokenService = context.HttpContext.RequestServices.GetService(typeof(ITokenService)) as ITokenService;
        

        if (string.IsNullOrEmpty(token) || tokenService?.VerifyTokenAndGetId(token) == null)
        {
            // extract retrurn url

            var returnUrl = context.HttpContext.Request.Path + context.HttpContext.Request.QueryString;

            // save return url in session  storage in which data doenst persist for longer period

            context.HttpContext.Session.SetString("ReturnUrl", returnUrl);

            // redirection 

            context.Result = new RedirectToActionResult("Login", "User", null);

        }
        else
        {

            context.HttpContext.Items["UserId"] = tokenService?.VerifyTokenAndGetId(token);
        }


    }
}
