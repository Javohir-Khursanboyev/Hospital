using Hospital.Service.Configurations;
using Hospital.Service.DTOs.Appointments;
using Hospital.Service.Services.Appointments;
using Hospital.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AppointmentsController(IAppiontmentService appiontmentService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostAsync(AppointmentCreateModel createModel)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Succes",
                Data = await appiontmentService.CreateAsync(createModel)
            });
        }


        [HttpPut("{id:long}")]
        public async Task<IActionResult> PutAsync(long id, AppointmentUpdateModel updateModel)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Succes",
                Data = await appiontmentService.UpdateAsync(id, updateModel)
            });
        }


        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Succes",
                Data = await appiontmentService.DeleteAsync(id)
            });
        }


        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Succes",
                Data = await appiontmentService.GetByIdAsync(id)
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Succes",
                Data = await appiontmentService.GetAllAsync(@params)
            });
        }
    }
}
