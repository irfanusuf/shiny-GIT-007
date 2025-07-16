using System;

namespace P5_WebApi.Models;

public class User
{


    public  string? Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }


}
