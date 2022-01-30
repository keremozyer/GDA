using FluentValidation;
using FluentValidation.Results;
using GDA.Concern.Enums;
using GDA.Managers.PassengerManagers;
using GDA.Model.WebModel;
using Microsoft.AspNetCore.Mvc;

namespace GDA.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly IPassengerManager PassengerManager;
        private readonly IValidator<CreatePassengerRequestModel> CreateValidator;
        private readonly IValidator<UpdatePassengerRequestModel> UpdateValidator;

        public PassengerController(IPassengerManager passengerManager, IValidator<CreatePassengerRequestModel> createValidator, IValidator<UpdatePassengerRequestModel> updateValidator)
        {
            this.PassengerManager = passengerManager;
            this.CreateValidator = createValidator;
            this.UpdateValidator = updateValidator;
        }

        /// <summary>
        /// Lists all passengers in given mode. Returns a list of objects containing passenger data. Returns an empty list if no passengers has been found.
        /// </summary>
        /// <response code="200">Request got processed successfuly.</response>
        /// <param name="mode">Passenger mode.</param>
        /// <returns>A list of objects containing passenger data. Returns an empty list if no passengers has been found.</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetPassengerResponseModel[]))]
        [HttpGet("{mode}")]
        public IActionResult Get(PassengerMode mode)
        {            
            return Ok(this.PassengerManager.Get(mode));
        }

        /// <summary>
        /// Searches passenger with given ID in given mode. Returns an object containing passenger data.
        /// </summary>
        /// <response code="200">Passenger found.</response>
        /// <response code="404">Passenger not found.</response>
        /// <param name="mode">Passenger mode.</param>
        /// <param name="id">ID of passenger.</param>
        /// <returns>An object containing passenger data.</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetPassengerResponseModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [HttpGet("{mode}/{id}")]
        public IActionResult Get(PassengerMode mode, Guid id)
        {
            GetPassengerResponseModel response = this.PassengerManager.Get(mode, id);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        /// <summary>
        /// Creates passenger with given parameters.
        /// </summary>
        /// <response code="200">Passenger created successfuly.</response>
        /// <response code="400">There were errors in data.</response>
        /// <param name="request">Passenger data.</param>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetPassengerResponseModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationResult))]
        [HttpPost]
        public IActionResult Post(CreatePassengerRequestModel request)
        {
            ValidationResult validationResult = this.CreateValidator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }

            this.PassengerManager.Create(request);

            return Ok();
        }

        /// <summary>
        /// Updates data of passenger with given ID.
        /// </summary>
        /// <response code="200">Passenger updated successfuly.</response>
        /// <response code="400">There were errors in data.</response>
        /// <response code="404">Passenger not found.</response>
        /// <param name="mode">Passenger mode.</param>
        /// <param name="id">ID of passenger.</param>
        /// <param name="request">Passenger data.</param>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetPassengerResponseModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [HttpPatch("{mode}/{id}")]
        public IActionResult Patch(PassengerMode mode, Guid id, UpdatePassengerRequestModel request)
        {
            ValidationResult validationResult = this.UpdateValidator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }

            try
            {
                this.PassengerManager.Update(mode, id, request);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }            

            return Ok();
        }

        /// <summary>
        /// Deletes passenger with given ID. This service is idempotent and will return a successful result when there is no passenger record with given ID.
        /// </summary>
        /// <response code="200">Passenger deleted successfuly.</response>
        /// <param name="mode">Passenger mode.</param>
        /// <param name="id">ID of passenger.</param>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetPassengerResponseModel))]
        [HttpDelete("{mode}/{id}")]
        public IActionResult Delete(PassengerMode mode, Guid id)
        {
            this.PassengerManager.Delete(mode, id);

            return Ok();
        }
    }
}
