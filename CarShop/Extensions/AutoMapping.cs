using AutoMapper;
using CarShop.Models.DTO;
using CarShop.Models.Requests;
using CarShop.Models.Responses;

namespace CarShop.Extensions
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Car, CarResponse>().ReverseMap();
            CreateMap<Client, ClientResponse>().ReverseMap();
            CreateMap<Part, PartResponse>().ReverseMap();
            CreateMap<Employee, EmployeeResponse>().ReverseMap();
            CreateMap<Service, ServiceResponse>().ReverseMap();

            CreateMap<CarRequest, Car>().ReverseMap();
            CreateMap<ClientRequest, Client>().ReverseMap();
            CreateMap<PartRequest, Part>().ReverseMap();
            CreateMap<EmployeeRequest, Employee>().ReverseMap();
            CreateMap<ServiceRequest, Service>().ReverseMap();

            CreateMap<CarUpdateRequest, Car>().ReverseMap();
            CreateMap<ClientUpdateRequest, Client>().ReverseMap();
            CreateMap<PartUpdateRequest, Part>().ReverseMap();
            CreateMap<EmployeeUpdateRequest, Employee>().ReverseMap();
            CreateMap<ServiceUpdateRequest, Service>().ReverseMap();
        }
    }
}
