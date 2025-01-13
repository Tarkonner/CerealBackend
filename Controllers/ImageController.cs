using Microsoft.AspNetCore.Mvc;
using Test.Interfaces;

namespace Test.Controllers;

[Route("api/images")]
[ApiController] // Marks this class as an API controller
public class ImageController : ControllerBase
{
    private readonly IImageRepository _imageRepository; // Repository for handling image-specific operations

    public ImageController(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository; // Injected image repository
    }
    
    [HttpGet]
    [Route("{cerealId:int}")] // Route expects an integer `cerealId` parameter
    public async Task<IActionResult> GetImageById([FromRoute] int cerealId)
    {
        // Retrieves the image path associated with the given cereal ID
        var imagePath = await _imageRepository.GetImageByIdAsync(cerealId);

        // Returns the image path in the response
        return Ok(imagePath);
    }
}