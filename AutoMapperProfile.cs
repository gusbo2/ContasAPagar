using AutoMapper;
using ContasAPagar.Data.Entities;
using ContasAPagar.Dtos.Bills;

namespace ContasAPagar
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddBillDto, Bill>();
            CreateMap<UpdatedBillDto, Bill>();
            CreateMap<Bill, GetBillDto>();
        }
    }
}