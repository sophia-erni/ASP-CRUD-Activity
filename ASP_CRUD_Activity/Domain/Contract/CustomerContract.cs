namespace ASP_CRUD_Activity.Domain.Contract
{
  
        public record CreateCustomer
        {
            public string Name { get; set; }

        }

        public record UpdateCustomer
        {
            public string Name { get; set; }

        }


        public record DeleteCustomer
        {
            public Guid Id { get; set; }

        }

        public record GetCustomer
        {
            public Guid Id { get; set; }

        }

        public class GetCustomerDto
        {
            public Guid Id { get; set; }
            public string Name { get; set; }

            public ICollection<GetCarDto> Cars { get; set; }
        }
    
}
