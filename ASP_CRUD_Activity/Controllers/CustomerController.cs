using ASP_CRUD_Activity.Domain.Contract;
using ASP_CRUD_Activity.Domain.Entities;
using ASP_CRUD_Activity.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASP_CRUD_Activity.Controllers
{
    [ApiController]
    [Route("api/")]
    public class CustomerController : ControllerBase
    {
        private readonly IBaseRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;

        public CustomerController(IBaseRepository<Customer> customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [HttpGet("customers")]
        public async Task<IActionResult> GetCustomers()
        {
            var customer = await _customerRepository.GetAll(a => a.Cars);
            var customerDtos = _mapper.Map<List<GetCustomerDto>>(customer);
            return Ok(customerDtos);
        }

        [HttpGet("customer/{id}")]
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            var customer = await _customerRepository.Get(id);
            if (customer == null)
            {
                return NotFound();
            }
            var customerDto = _mapper.Map<GetCustomerDto>(customer);
            return Ok(customerDto);
        }

        [HttpPost("customers")]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomer createCustomer)
        {
            var customer = _mapper.Map<Customer>(createCustomer);
            var createdCustomer = await _customerRepository.Add(customer);
            var customerDto = _mapper.Map<GetCustomerDto>(createdCustomer);
            return CreatedAtAction(nameof(GetCustomer), new { id = customerDto.Id }, customerDto);
        }

        [HttpPut("customers/{id}")]
        public async Task<IActionResult> UpdateCustomer(Guid id, [FromBody] UpdateCustomer updateCustomer)
        {
            var customer = await _customerRepository.Get(id);
            if (customer == null)
            {
                return NotFound();
            }
            _mapper.Map(updateCustomer, customer);
            var updatedCustomer = await _customerRepository.Update(customer);
            var customerDto = _mapper.Map<GetCustomerDto>(updatedCustomer);
            return Ok(customerDto);
        }

        [HttpDelete("customer/{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            var customer = await _customerRepository.Delete(id);
            if (customer == null)
            { return NotFound(); }
            var customerDto = _mapper.Map<GetCustomerDto>(customer);
            return Ok(customerDto);
        }
    }
}
