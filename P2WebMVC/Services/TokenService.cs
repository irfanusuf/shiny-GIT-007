using System;
using P2WebMVC.Interfaces;

namespace P2WebMVC.Services;

public class TokenService : ITokenService
{
    public string CreateToken(string UserName, Guid UserId, string Email, int Time)
    {
        throw new NotImplementedException();
    }
}
