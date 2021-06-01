using System.Collections.Generic;
using AddressBook.Data.Interfaces;
using AddressBook.Data.Models;
using AddressBookApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace AddressBook.Tests.ControllersTests
{
    public class AddressBooksControllerTests
    {
        private readonly Mock<IAddressBookRepository> _mockRepo;
        private readonly AddressBooksController _controller;
        private readonly ILogger<AddressBooksController> _logger;

        public AddressBooksControllerTests()
        {
            _mockRepo = new Mock<IAddressBookRepository>();
            _logger = new Mock<ILogger<AddressBooksController>>().Object;
            _controller = new AddressBooksController(_logger, _mockRepo.Object);

        }

        [Fact]
        public void GetAddress_WhenCalled_ShouldReturnActionResult()
        {
            var address = CreateSampleAddress();

            _mockRepo.Setup(x => x.GetAddress())
                .Returns(address);

            var result = _controller.GetAddress();

            Assert.IsType<ActionResult<Address>>(result);
        }

        [Fact]
        public void Post_WhenCalled_ShouldReturnActionResult()
        {
            var address = CreateSampleAddress();

            _mockRepo.Setup(x => x.CreateAddress(address));

            var result = _controller.CreateAddress(address);
            Assert.IsAssignableFrom<ActionResult>(result);
        }

        private Address CreateSampleAddress()
        {
            return new Address()
            {
                Id = 10,
                Name = "Lukasz",
                LastName = "Nowak",
                Town = "Stryszawa",
                HouseNumber = 10,
                Street = "Kolorowa"
            };
        }

        private IEnumerable<Address> CreateSampleListOfAddress()
        {
            var listOfAddress = new List<Address>();

            var firstAddress = CreateSampleAddress();
            var secondAddress = CreateSampleAddress();
            secondAddress.Id = 11;

            listOfAddress.Add(firstAddress);
            listOfAddress.Add(secondAddress);
            return listOfAddress;
        }
    }
}
