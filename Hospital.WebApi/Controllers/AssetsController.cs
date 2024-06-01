using Hospital.Domain.Enums;
using Hospital.Service.Services.Assets;
using Hospital.Service.Services.Doctors;
using Hospital.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.WebApi.Controllers;


[Route("[controller]")]
[ApiController]
public class AssetsController (IAssetService assetService) : Controller
{
    [HttpPost]
    public async Task<IActionResult> PostAsync(IFormFile file, FileType fileType)
    {
        return Ok(
            new Response
            {
                StatusCode = 200,
                Message = "Succes",
                Data = await assetService.UploadAsync(file, fileType)
            }
        );
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await assetService.DeleteAsync(id)
        });
    }
}
