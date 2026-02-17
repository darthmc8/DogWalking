using System.Reflection;
using DogWalksEvents.Repository.DTOs;
using DogWalksEvents.Repository.Validations;

namespace UnitTests
{
    [TestClass]
    public class WalkEventValidatorTests
    {
        [TestMethod]
        public void Validate_AllValid_NoErrors()
        {
            var dto = new DogWalkEventDTO
            {
                ClientFirstName = "John",
                ClientLastName = "Doe",
                ClientPhoneNumber = "1234567890",
                DogName = "Rex",
                DogBrand = "Breed",
                DogAge = 5,
                Duration = 30
            };

            using var validator = new WalkEventValidator(dto);
            var results = validator.Validate();

            Assert.IsNotNull(results);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void Validate_EmptyRequiredFields_ReturnsAllRequiredErrors()
        {
            var dto = new DogWalkEventDTO
            {
                ClientFirstName = string.Empty,
                ClientLastName = string.Empty,
                ClientPhoneNumber = string.Empty,
                DogName = string.Empty,
                DogBrand = string.Empty,
                DogAge = 0,
                Duration = 0
            };

            using var validator = new WalkEventValidator(dto);
            var results = validator.Validate();

            // Expect errors for first name, last name, phone, dog name, dog brand, age and duration = 7
            Assert.IsNotNull(results);
            Assert.AreEqual(7, results.Count);

            var controlNames = results.Select(r => r.ControlName).ToArray();
            CollectionAssert.Contains(controlNames, "txtClientFirstName");
            CollectionAssert.Contains(controlNames, "txtClientLastName");
            CollectionAssert.Contains(controlNames, "txtClientPhoneNumber");
            CollectionAssert.Contains(controlNames, "txtDogName");
            CollectionAssert.Contains(controlNames, "txtDogBrand");
            CollectionAssert.Contains(controlNames, "numDogAge");
            CollectionAssert.Contains(controlNames, "numDuration");
        }

        [TestMethod]
        public void Validate_InvalidFormats_ReturnsFormatErrors()
        {
            var dto = new DogWalkEventDTO
            {
                ClientFirstName = "John123",
                ClientLastName = "Doe@",
                ClientPhoneNumber = "phoneABC",
                DogName = "Rex9",
                DogBrand = "Br33d",
                DogAge = 2,
                Duration = 15
            };

            using var validator = new WalkEventValidator(dto);
            var results = validator.Validate();

            Assert.IsNotNull(results);

            // Expect format errors for first name, last name, phone, dog name and dog brand = 5
            Assert.AreEqual(5, results.Count);

            var controlNames = results.Select(r => r.ControlName).ToArray();
            CollectionAssert.Contains(controlNames, "txtClientFirstName");
            CollectionAssert.Contains(controlNames, "txtClientLastName");
            CollectionAssert.Contains(controlNames, "txtClientPhoneNumber");
            CollectionAssert.Contains(controlNames, "txtDogName");
            CollectionAssert.Contains(controlNames, "txtDogBrand");
        }

        [TestMethod]
        public void Validate_DogAgeOrDurationZero_ReturnsSpecificErrors()
        {
            var dto = new DogWalkEventDTO
            {
                ClientFirstName = "A",
                ClientLastName = "B",
                ClientPhoneNumber = "123",
                DogName = "D",
                DogBrand = "B",
                DogAge = 0,
                Duration = 0
            };

            using var validator = new WalkEventValidator(dto);
            var results = validator.Validate();

            Assert.IsNotNull(results);
            // should contain at least the two numeric errors
            var ageError = results.FirstOrDefault(r => r.ControlName == "numDogAge");
            var durationError = results.FirstOrDefault(r => r.ControlName == "numDuration");

            Assert.IsNotNull(ageError, "Expected an error for DogAge when <= 0");
            Assert.IsNotNull(durationError, "Expected an error for Duration when <= 0");
        }

        [TestMethod]
        public void Dispose_ResetsInternalStaticField()
        {
            var dto = new DogWalkEventDTO
            {
                ClientFirstName = "John",
                ClientLastName = "Doe",
                ClientPhoneNumber = "123",
                DogName = "Rex",
                DogBrand = "Breed",
                DogAge = 1,
                Duration = 10
            };

            var validator = new WalkEventValidator(dto);

            // call Dispose
            validator.Dispose();

            // use reflection to inspect the private static field
            var fld = typeof(WalkEventValidator).GetField("_dogWalkEventDTO", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.IsNotNull(fld, "Expected private static field '_dogWalkEventDTO' to exist");

            var value = fld.GetValue(null);
            Assert.IsNull(value, "Expected _dogWalkEventDTO to be null after Dispose");
        }
    }
}
