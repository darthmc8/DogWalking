using DogWalksEvents.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalksEvents.Repository.Validations
{
    /// <summary>
    /// WalkEvent DTO Validator
    /// </summary>
    public class WalkEventValidator
    {
        private static DogWalkEventDTO _dogWalkEventDTO;
        
        public WalkEventValidator(DogWalkEventDTO dogWalkEventDTO)
        {
            _dogWalkEventDTO = dogWalkEventDTO;
        }

        public List<WalkEventValidationResult> Validate()
        {
            var validationResult = new List<WalkEventValidationResult>();

            if (string.IsNullOrEmpty(_dogWalkEventDTO.ClientFirstName.Trim()))
            {
                validationResult.Add(new WalkEventValidationResult
                {
                    ControlName = "txtFirstName",
                    Message = "Client's First Name is required"
                });
            }

            if (string.IsNullOrEmpty(_dogWalkEventDTO.ClientLastName.Trim()))
            {
                validationResult.Add(new WalkEventValidationResult
                {
                    ControlName = "txtLastName",
                    Message = "Client's Last Name is required"
                });
            }

            if (string.IsNullOrEmpty(_dogWalkEventDTO.ClientPhoneNumber.Trim()))
            {
                validationResult.Add(new WalkEventValidationResult
                {
                    ControlName = "txtPhoneNumber",
                    Message = "Client's Phone Number is required"
                });
            }

            if (string.IsNullOrEmpty(_dogWalkEventDTO.DogName.Trim()))
            {
                validationResult.Add(new WalkEventValidationResult
                {
                    ControlName = "txtDogName",
                    Message = "Dog's Name is required"
                });
            }

            if (string.IsNullOrEmpty(_dogWalkEventDTO.DogBrand.Trim()))
            {
                validationResult.Add(new WalkEventValidationResult
                {
                    ControlName = "txtDogBrand",
                    Message = "Dog's Brand is required"
                });
            }

            if (_dogWalkEventDTO.DogAge <= 0)
            {
                validationResult.Add(new WalkEventValidationResult
                {
                    ControlName = "numDogAge",
                    Message = "Dog's Age must be greater than zero"
                });
            }

            if (_dogWalkEventDTO.Duration <= 0)
            {
                validationResult.Add(new WalkEventValidationResult
                {
                    ControlName = "numDuration",
                    Message = "Duration must be grater than zero"
                });
            }

            return validationResult;
        }
    }
}
