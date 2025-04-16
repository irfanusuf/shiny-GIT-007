using System;

namespace P2WebMVC.Interfaces;

public interface IToken
{



public string VerifyTokenAndGetId(string token , string email);
}
