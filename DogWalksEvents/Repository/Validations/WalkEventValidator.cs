using DogWalksEvents.Repository.DTOs;
using System.Text.RegularExpressions;

namespace DogWalksEvents.Repository.Validations
{
    /// <summary>
    /// WalkEvent DTO Validator
    /// </summary>
    public class WalkEventValidator : IDisposable
    {
        private static DogWalkEventDTO _dogWalkEventDTO = default!;
        private static string _onlyLetterRegex = @"^[a-zA-Z ]*$";
        private static string _onlyNumberRegex = @"^[0-9]*$";

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
                    ControlName = "txtClientFirstName",
                    Message = "Client's First Name is required"
                });
            }
            else
            {
                if (!Regex.IsMatch(_dogWalkEventDTO.ClientFirstName, _onlyLetterRegex))
                {
                    validationResult.Add(new WalkEventValidationResult
                    {
                        ControlName = "txtClientFirstName",
                        Message = "Client's First Name format allows only letters"
                    });
                }
            }

            if (string.IsNullOrEmpty(_dogWalkEventDTO.ClientLastName.Trim()))
            {
                validationResult.Add(new WalkEventValidationResult
                {
                    ControlName = "txtClientLastName",
                    Message = "Client's Last Name is required"
                });
            }
            else
            {
                if (!Regex.IsMatch(_dogWalkEventDTO.ClientLastName, _onlyLetterRegex))
                {
                    validationResult.Add(new WalkEventValidationResult
                    {
                        ControlName = "txtClientLastName",
                        Message = "Client's Last Name format allows only letters"
                    });
                }
            }

            if (string.IsNullOrEmpty(_dogWalkEventDTO.ClientPhoneNumber.Trim()))
            {
                validationResult.Add(new WalkEventValidationResult
                {
                    ControlName = "txtClientPhoneNumber",
                    Message = "Client's Phone Number is required"
                });
            }
            else
            {
                if (!Regex.IsMatch(_dogWalkEventDTO.ClientPhoneNumber, _onlyNumberRegex))
                {
                    validationResult.Add(new WalkEventValidationResult
                    {
                        ControlName = "txtClientPhoneNumber",
                        Message = "Client's Phone Number format allows only numbers"
                    });
                }
            }

            if (string.IsNullOrEmpty(_dogWalkEventDTO.DogName.Trim()))
            {
                validationResult.Add(new WalkEventValidationResult
                {
                    ControlName = "txtDogName",
                    Message = "Dog's Name is required"
                });
            }
            else
            {
                if (!Regex.IsMatch(_dogWalkEventDTO.DogName, _onlyLetterRegex))
                {
                    validationResult.Add(new WalkEventValidationResult
                    {
                        ControlName = "txtDogName",
                        Message = "Dog's Name format allows only letters"
                    });
                }
            }

            if (string.IsNullOrEmpty(_dogWalkEventDTO.DogBrand.Trim()))
            {
                validationResult.Add(new WalkEventValidationResult
                {
                    ControlName = "txtDogBrand",
                    Message = "Dog's Brand is required"
                });
            }
            else
                {
                    if (!Regex.IsMatch(_dogWalkEventDTO.DogBrand, _onlyLetterRegex))
                    {
                        validationResult.Add(new WalkEventValidationResult
                        {
                            ControlName = "txtDogBrand",
                            Message = "Dog's Brand format allows only letters"
                        });
                    }
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

        public void Dispose()
        {
            _dogWalkEventDTO = default!;
        }
    }
}
