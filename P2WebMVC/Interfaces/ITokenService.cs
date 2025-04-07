using System;

namespace P2WebMVC.Interfaces;

public interface ITokenService
{


public string CreateToken(string UserName , Guid UserId , string Email , int Time);



}
