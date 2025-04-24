using System;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using dotenv.net;
using P2WebMVC.Interfaces;

namespace P2WebMVC.Services;

public class CloudinaryService : ICloudinaryService
{

    private readonly Cloudinary cloudinary;

    // private readonly string  url;
    public CloudinaryService()
    {
        // this.cloudinary = cloudinary;

        // this.url = configuration["Cloudinary:CLOUDINARY_URL"] ?? throw new ArgumentNullException("Cloudinary Url is not configured.");
      

        try
        {
            DotEnv.Load(options: new DotEnvOptions(probeForEnv : true));
        }
        catch (System.Exception ex)
        {
            
            throw new InvalidOperationException("Failed to load .env file.", ex);
        }

      
        var CloudinaryUrl = Environment.GetEnvironmentVariable("CLOUDINARY_URL");

        this.cloudinary = new Cloudinary(CloudinaryUrl) { Api = { Secure = true } };


    }



    public async Task<string> UploadImage(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            throw new ArgumentException("File is invalid.");
        }

        using var stream = file.OpenReadStream();


        var uploadParams = new ImageUploadParams
        {
            File = new FileDescription(file.FileName, stream),
            UseFilename = true,
            UniqueFilename = false,
            Overwrite = true,
            Folder = "Trinkle"
            // Transformation = new Transformation().Width(150).Height(150).Crop("fill")
        };

      var uploadResult =  await cloudinary.UploadAsync(uploadParams);

        if (uploadResult.Error != null)
        {
            throw new InvalidOperationException($"Cloudinary upload failed: {uploadResult.Error.Message}");
        }

        return uploadResult.SecureUrl.ToString();
    }


}
