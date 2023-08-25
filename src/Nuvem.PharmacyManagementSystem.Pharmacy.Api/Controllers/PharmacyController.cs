using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using Nuvem.PharmacyManagementSystem.Pharmacy.Services;
using Nuvem.PharmacyManagementSystem.Pharmacy.Services.Models;

namespace Nuvem.PharmacyManagementSystem.Pharmacy.Api.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class PharmacyController : ControllerBase
    {
        private readonly IPharmacyService _pharmacyService;
        public PharmacyController(IPharmacyService pharmacyService)
        {
            _pharmacyService = pharmacyService;
        }

        [HttpGet]
        [HttpGet("{id}")]
        [SwaggerOperation("Get Pharmacy(s)")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetPharmacies(int? id=null)
        {
            if(id is null)
            {
                return Ok(await _pharmacyService.GetAllAsync());
            }
            else
            {
                PharmacyModel pharmacy = await _pharmacyService.GetPharmacyByIdAsync(id.GetValueOrDefault());
                return pharmacy is null ? NotFound() : Ok(pharmacy);
            }
        }

        /// <summary>
        /// Update the Pharmacy
        /// </summary>
        /// <param name="id">PharmacyId</param>
        /// <param name="">Values to update the existing pharmacy</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [SwaggerOperation("Updates Pharmacy")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> UpdatePharmacyById(int id, [FromBody]PharmacyModel pharmacyModel)
        {
            if (id == 0 || pharmacyModel.PharmacyId != id) return BadRequest("Pharmacy id not correct!");            
            
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var updatedPharmacy = await _pharmacyService.UpdatePharmacyAsync(pharmacyModel);
            return updatedPharmacy is null ? NotFound() : Ok(updatedPharmacy);            
        }            
    }