using Microsoft.AspNetCore.Mvc;
using System;
using AddressBook.Data.Interfaces;
using AddressBook.Data.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace AddressBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressBooksController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IAddressBookRepository _addressBookRepository;

        public AddressBooksController(ILogger<AddressBooksController> logger, IAddressBookRepository addressBookRepository)
        {
            _logger = logger;
            _addressBookRepository = addressBookRepository;
        }

        [HttpGet]
        public ActionResult<Address> GetAddress()
        {
            var result = new Address();
            try
            {
                result = _addressBookRepository.GetAddress();
                return CheckResult(result);
            }
            catch (Exception ex)
            {
                return CheckResult(result, ex);
            }
        }

        [HttpGet("{town}")]
        public ActionResult<IEnumerable<Address>> GetAddressTown(string town)
        {
            var result = new List<Address>();
            try
            {
                result = _addressBookRepository.GetAddressTown(town).ToList();
                if (result.Any())
                {
                    return CheckResult(result);
                }
                else
                {
                    result = null;
                    throw new Exception("Not Found any result");
                }
            }
            catch (Exception ex)
            {
                return CheckResult(result, ex);
            }
        }

        [HttpPost]
        public ActionResult CreateAddress([FromBody] Address address)
        {
            try
            {
                if (address == null)
                {
                    _logger.LogError("Error");
                    return NotFound();
                }
                _addressBookRepository.CreateAddress(address);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error");
                return NotFound();
            }
        }

        private ActionResult CheckResult(object result, Exception ex = null)
        {
            if (result is null)
            {
                _logger.LogError(ex, "Error");
                return NotFound(ex.Message);
            }

            _logger.LogInformation("Correctly downloaded");
            return Ok(result);
        }
    }
}
