using CompanyRegistration.Manager;
using CompanyRegistration.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;

namespace CompanyRegistration.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class Company_DetailsController : ControllerBase
    {
        private readonly ICdetail _cdetail;
        private readonly ILogger<Company_DetailsController> logger;
        public Company_DetailsController(ICdetail cdetail, ILogger<Company_DetailsController> logger)
        {
            _cdetail = cdetail;
            this.logger = logger;
        }

        [HttpPost("CreateCompanyDetails")]
        [MapToApiVersion("1.0")]
        [Authorize]
        public IActionResult Create([FromBody] CompanyDetailsRequest request)
        {
            logger.LogInformation("Creating company Details");
            try
            {
                var result = _cdetail.Create(request);
                return Ok(result);
            }
            catch (Exception ex)
            {

                logger.LogError(ex, "Error while creating company details");

                if (ex.Message.Contains("Company name already in use"))
                {
                    return BadRequest("Company name already in use");
                }
                else
                {
                    return StatusCode(500, "An error occurred while processing your request. Please try again later or contact support for assistance.");
                }
            }
        
        }

        [HttpGet("GetCompanyDetails")]
        [MapToApiVersion("1.0")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(204, "No Content Found")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Internal server error")]
       [Authorize]
        public IActionResult Get()
        {
            try
            {

                logger.LogInformation("get company Details method is executed");
                var result = _cdetail.Getall();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }
        }
     
        [HttpGet("GetCompanyDetails/{UserID}")]
        [MapToApiVersion("1.0")]
        [Authorize]
        public IActionResult Get([FromRoute] int UserID)
        {
            try
            {
                logger.LogInformation("getbyID method is executed");
                var result = _cdetail.GetbyId(UserID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogDebug($"there is no {UserID} present with this Id");
                return StatusCode(500, "An error has occured");
            }
        }

        [HttpPut("UpdateCompanyDetails")]
        [MapToApiVersion("1.0")]
        [Authorize]
        public IActionResult Update([FromBody] CompanyDetailsRequest request)
        {
            try
            {
                logger.LogDebug($"request is updated {request} ");
                var result = _cdetail.Update(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

        }

        [HttpDelete("DeleteCompanyDetails/{UserID}")]
        [MapToApiVersion("1.0")]
        [Authorize]
        public IActionResult Delete([FromRoute] int UserID)
        {
            try
            {
                logger.LogDebug($" {UserID} is deleted");
                var result = _cdetail.DeletebyId(UserID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }
        }
    }
}
