using Hospital.Service.Configurations;
using Hospital.Service.DTOs.Prescription;
using Hospital.Service.Services.Prescriptions;
using Hospital.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PrescriptionsController(IPrescriptionService prescriptionService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostAsync(PrescriptionCreateModel createModel)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Succes",
                Data = await prescriptionService.CreateAsync(createModel)
            });
        }


        [HttpPut("{id:long}")]
        public async Task<IActionResult> PutAsync(long id, PrescriptionUpdateModel updateModel)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Succes",
                Data = await prescriptionService.UpdateAsync(id, updateModel)
            });
        }


        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Succes",
                Data = await prescriptionService.DeleteAsync(id)
            });
        }


        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Succes",
                Data = await prescriptionService.GetByIdAsync(id)
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Succes",
                Data = await prescriptionService.GetAllAsync()
            });
        }

    }
}
