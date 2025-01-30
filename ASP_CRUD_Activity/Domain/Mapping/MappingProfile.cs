using ASP_CRUD_Activity.Domain.Contract;
using ASP_CRUD_Activity.Domain.Entities;
using AutoMapper;


namespace ASP_CRUD_Activity.Domain.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile() 
        {
            CreateMap<Customer, GetCustomerDto>()
                .ForMember(dest => dest.Cars, opt => opt.MapFrom(src => src.Cars));

            CreateMap<CreateCustomer, Customer>();
            CreateMap<UpdateCustomer, Customer>();
            CreateMap<DeleteCustomer, Customer>();
            CreateMap<GetCustomer, Customer>();

            CreateMap<Car,GetCarDto>();
            CreateMap<CreateCar,Car>();
            CreateMap<UpdateCar,Car>();
            CreateMap<DeleteCar, Car>();

        }
    }
}
