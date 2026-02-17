using DogWalksEvents.Repository.DTOs;
using DogWalksEvents.Repository.Queries;
using DogWalksEvents.UIProcessor;

namespace UnitTests;

[TestClass]
public class UIProcessorHandlerTests
{
    private class FakeMessageService : UIProcessorHandler.IMessageService
    {
        public bool InfoShown { get; private set; }
        public bool ErrorShown { get; private set; }

        public void ShowInfo(string message, string title) => InfoShown = true;
        public void ShowError(string message, string title) => ErrorShown = true;
    }

    // Testable subclass to override DB/command interactions
    private class TestableHandler : UIProcessorHandler
    {
        private readonly Func<string, Task<ClientsQuery?>> _clientResolver;
        private readonly Func<string, string, int, Task<DogsQuery?>> _dogResolver;
        private readonly Func<DogWalkEventDTO, Task<string>> _upsertRunner;
        private readonly Func<string, Task> _deleteRunner;

        public TestableHandler(
            DogWalkEventDTO dto,
            IMessageService messageService,
            Func<string, Task<ClientsQuery?>>? clientResolver = null,
            Func<string, string, int, Task<DogsQuery?>>? dogResolver = null,
            Func<DogWalkEventDTO, Task<string>>? upsertRunner = null,
            Func<string, Task>? deleteRunner = null)
            : base(dto, messageService)
        {
            _clientResolver = clientResolver ?? (s => Task.FromResult<ClientsQuery?>(null));
            _dogResolver = dogResolver ?? ((a, b, c) => Task.FromResult<DogsQuery?>(null));
            _upsertRunner = upsertRunner ?? (d => Task.FromResult(string.Empty));
            _deleteRunner = deleteRunner ?? (id => Task.CompletedTask);
        }

        protected override Task<ClientsQuery?> GetClientByPhone(string phoneNumber) => _clientResolver(phoneNumber);
        protected override Task<DogsQuery?> GetDogByIdentifiers(string name, string brand, int age) => _dogResolver(name, brand, age);
        protected override Task<string> RunUpsertWalkEvent(DogWalkEventDTO dto) => _upsertRunner(dto);
        protected override Task RunDeleteWalkEvent(string id) => _delete_runner_wrapper(id);

        // wrapper to avoid name conflict with base protected method name in the source (keeps code readable)
        private Task _delete_runner_wrapper(string id) => _deleteRunner(id);
    }

    [TestMethod]
    public void ProcessCreate_InvalidData_ReturnsValidationErrors()
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

        var msg = new FakeMessageService();
        var handler = new TestableHandler(dto, msg);

        var result = handler.ProcessCreate();

        Assert.IsFalse(result.IsValidated);
        Assert.IsFalse(result.IsCompleted);
        Assert.IsNotNull(result.ValidationResults);
        Assert.AreNotEqual(0, result.ValidationResults.Count);
    }

    [TestMethod]
    public void ProcessCreate_ValidData_AssignsClientAndDogIdsAndCompletes()
    {
        var dto = new DogWalkEventDTO
        {
            ClientFirstName = "John",
            ClientLastName = "Doe",
            ClientPhoneNumber = "12345",
            DogName = "Rex",
            DogBrand = "Breed",
            DogAge = 3,
            Duration = 30
        };

        var expectedClientId = "client-123";
        var expectedDogId = "dog-456";

        var msg = new FakeMessageService();

        var handler = new TestableHandler(
            dto,
            msg,
            clientResolver: phone => Task.FromResult<ClientsQuery?>(new ClientsQuery { Id = expectedClientId, FirstName = "John", LastName = "Doe", PhoneNumber = phone }),
            dogResolver: (name, brand, age) => Task.FromResult<DogsQuery?>(new DogsQuery { Id = expectedDogId, Name = name, Brand = brand, Age = age }),
            upsertRunner: d => Task.FromResult("ok")
        );

        var result = handler.ProcessCreate();

        Assert.IsTrue(result.IsValidated);
        Assert.IsTrue(result.IsCompleted);
        Assert.IsNotNull(result.ValidationResults);
        Assert.AreEqual(0, result.ValidationResults.Count);
        Assert.AreEqual(expectedClientId, dto.ClientId);
        Assert.AreEqual(expectedDogId, dto.DogId);
    }

    [TestMethod]
    public void ProcessCreate_UpsertThrows_ShowsErrorAndFails()
    {
        var dto = new DogWalkEventDTO
        {
            ClientFirstName = "John",
            ClientLastName = "Doe",
            ClientPhoneNumber = "12345",
            DogName = "Rex",
            DogBrand = "Breed",
            DogAge = 3,
            Duration = 30
        };

        var msg = new FakeMessageService();

        var handler = new TestableHandler(
            dto,
            msg,
            upsertRunner: d => throw new InvalidOperationException("upsert failed")
        );

        var result = handler.ProcessCreate();

        // validator passed so IsValidated remains true; upsert failure results in IsCompleted == false and message shown
        Assert.IsTrue(result.IsValidated);
        Assert.IsFalse(result.IsCompleted);
        Assert.IsNotNull(result.ValidationResults);
        Assert.AreEqual(0, result.ValidationResults.Count);
        Assert.IsTrue(msg.ErrorShown);
    }

    [TestMethod]
    public async Task ProcessDelete_Success_ShowsInfo()
    {
        var dto = new DogWalkEventDTO { Id = "e1", ClientFirstName = "a", ClientLastName = "b", ClientPhoneNumber = "1", DogName = "d", DogBrand = "b", DogAge = 1, Duration = 10 };
        var msg = new FakeMessageService();
        var handler = new TestableHandler(dto, msg, deleteRunner: id => Task.CompletedTask);

        await handler.ProcessDelete();

        Assert.IsTrue(msg.InfoShown);
        Assert.IsFalse(msg.ErrorShown);
    }

    [TestMethod]
    public async Task ProcessDelete_Failure_ShowsError()
    {
        var dto = new DogWalkEventDTO { Id = "e1", ClientFirstName = "a", ClientLastName = "b", ClientPhoneNumber = "1", DogName = "d", DogBrand = "b", DogAge = 1, Duration = 10 };
        var msg = new FakeMessageService();
        var handler = new TestableHandler(dto, msg, deleteRunner: id => throw new InvalidOperationException("delete failed"));

        await handler.ProcessDelete();

        Assert.IsFalse(msg.InfoShown);
        Assert.IsTrue(msg.ErrorShown);
    }

    [TestMethod]
    public void Dispose_CanBeCalledMultipleTimes_NoException()
    {
        var dto = new DogWalkEventDTO
        {
            ClientFirstName = "a",
            ClientLastName = "b",
            ClientPhoneNumber = "1",
            DogName = "d",
            DogBrand = "b",
            DogAge = 1,
            Duration = 10
        };

        var msg = new FakeMessageService();
        var handler = new TestableHandler(dto, msg);

        handler.Dispose();
        handler.Dispose(); // should not throw
    }
}
