using Hospital.Service.Configurations;
using Hospital.Service.DTOs.Doctors;
using Hospital.Service.Services.Doctors;
using Hospital.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DoctorsController(IDoctorService doctorService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostAsync(DoctorCreateModel createModel)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Succes",
                Data = await doctorService.CreateAsync(createModel)
            });
        }


        [HttpPut("{id:long}")]
        public async Task<IActionResult> PutAsync(long id, DoctorUpdateModel updateModel)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Succes",
                Data = await doctorService.UpdateAsync(id, updateModel)
            });
        }


        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Succes",
                Data = await doctorService.DeleteAsync(id)
            });
        }


        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Succes",
                Data = await doctorService.GetByIdAsync(id)
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Succes",
                Data = await doctorService.GetAllAsync(@params)
            });
        }
    }
}
