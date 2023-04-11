using AutoMapper;
using LmsAPI.DTO;
using LmsAPI.Models;

namespace LmsAPI.AutoMap
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<GadgetLoan, GadgetLoanDTO>().ReverseMap();
        }
    }
}
