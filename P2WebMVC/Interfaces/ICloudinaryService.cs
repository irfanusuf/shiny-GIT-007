using System;

namespace P2WebMVC.Interfaces;

public interface ICloudinaryService
{

public  Task <string> UploadImage(IFormFile file);

}
