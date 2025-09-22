using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using P0_ClassLibrary.Interfaces;

namespace P5_WebApi.Middlewares;

[AttributeUsage(AttributeTargets.All)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {

        var token = context.HttpContext.Request.Cookies["Authorization_Token_React"];

        if (token == null)
        {

            context.Result = new JsonResult(new { message = "Session Expired ! Kindly Login again .." }, new
            {
                StatusCodes = 401
            }
            );
            return;
        }

        var tokenService = context.HttpContext.RequestServices.GetService(typeof(ITokenService)) as ITokenService;

        var userId = tokenService?.VerifyTokenAndGetId(token);

        if (userId == Guid.Empty)
        {

            context.Result = new JsonResult(new { message = "Forbidden To access the Pages ! Kindly Login again .." }, new
            {
                StatusCodes = 403
            }
            );
            return;
        }


        context.HttpContext.Items["userId"] = userId;


    }
}
