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

        // GET all action
        /// <summary>
        /// Get all the pharmacies
        /// </summary>
        /// <returns>List of all the Pharmacies</returns>
        [HttpGet]
        [SwaggerOperation("Get all Pharmacies")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<PharmacyModel>>> GetAllAsync() => Ok(await _pharmacyService.GetAllAsync());
        
        /// <summary>
        /// Get pharmacy for given id
        /// </summary>
        /// <param name="id">PharmacyId</param>
        /// <returns>Pharmacy</returns>
        [HttpGet("{id}")]
        [SwaggerOperation("Get Pharmacy by Id")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<PharmacyModel>> GetByIdAsync(int id)
        {
            if (id == 0)
                return BadRequest();
                
            PharmacyModel pharmacy = await _pharmacyService.GetPharmacyByIdAsync(id);
            return pharmacy is null ? NotFound() : Ok(pharmacy);
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
        public async Task<ActionResult<PharmacyModel>> UpdatePharmacyAsync(int id, [FromBody]PharmacyModel pharmacyModel)
        {
            if (id == 0 || pharmacyModel.PharmacyId != id) return BadRequest();            
            
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var updatedPharmacy = await _pharmacyService.UpdatePharmacyAsync(pharmacyModel);
            return updatedPharmacy is null ? NotFound() : Ok(updatedPharmacy);            
        }            
    }