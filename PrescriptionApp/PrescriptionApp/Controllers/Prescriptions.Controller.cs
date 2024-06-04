using Microsoft.AspNetCore.Mvc;
using PrescriptionApp.DTOs;
using PrescriptionApp.Repositories;


namespace PrescriptionApp.Controllers;

[ApiController]
[Route("api/prescriptions")]

public class PrescriptionsController : ControllerBase

{
    private readonly IPrescriptionRepository _prescriptionRepository;

    public PrescriptionsController(IPrescriptionRepository prescriptionRepository)
    {
        _prescriptionRepository = prescriptionRepository;
    }

    [HttpPost]
    public async Task<IActionResult> AddPrescriptionAsync([FromBody] NewPrescriptionDtos request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _prescriptionRepository.AddPrescriptionAsync(request);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
