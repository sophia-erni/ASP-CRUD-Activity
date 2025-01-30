using ASP_CRUD_Activity.Domain.Contract;
using ASP_CRUD_Activity.Domain.Entities;
using AutoMapper;

namespace ASP_CRUD_Activity.Domain.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Car,GetCarDto>();
            CreateMap<CreateCar,Car>();
            CreateMap<UpdateCar,Car>();
            CreateMap<DeleteCar, Car>();
            CreateMap<GetCar, Car>();
        

        }
    }
}
