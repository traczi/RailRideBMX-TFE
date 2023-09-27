using Microsoft.AspNetCore.Http;

namespace Application.Services.Impl;

public class ImageService
{
    private readonly string _imageDirectory = "wwwroot/images";

    public async Task<string> SaveImageAsync(IFormFile imgFile)
    {
        if (imgFile == null || imgFile.Length <= 0)
        {
            throw new Exception("No image upload.");
        }

        var uniqueFileName = Guid.NewGuid().ToString() + "-" + imgFile.FileName;
        var filePath = Path.Combine(_imageDirectory, uniqueFileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await imgFile.CopyToAsync(fileStream);
        }
        return uniqueFileName;
    }
}