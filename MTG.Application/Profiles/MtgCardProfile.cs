using AutoMapper;
using MTG.Application.Models;
using MTG.Domain.Models;

namespace MTG.Application.Profiles
{
    public class MtgCardProfile : Profile
    {
        public MtgCardProfile()
        {
            CreateMap<MtgCard, CreateCardResultDTO>()
                .ForMember(dest => dest.Binder, opt => opt.MapFrom(src => src.Binder.Name))
                .ForMember(dest => dest.MtgCardTypes, opt => opt.MapFrom(src => src.MtgTypes.Select(t => t.Name)))
                .ForMember(dest => dest.MtgColors, opt => opt.MapFrom(src => src.MtgColors.Select(c => c.Name)));
        }
    }
}
