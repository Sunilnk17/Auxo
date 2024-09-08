using System;
using System.Globalization;
using AutoMapper;
using Auxo.Models;
using Auxo.Models.Dtos.Responses;

namespace Auxo.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Parts, PartsResponse>()
        .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price.ToString("C", new CultureInfo("en-US"))));

        // Map OrderDetails to SimplifiedOrderDetailsResponse
        CreateMap<OrderDetails, OrderDetailsResponse>()
        .ForMember(dest => dest.TotalPrice,
                opt => opt.MapFrom(src => src.Parts.Price * src.Quantity))
                .ForMember(dest => dest.Part, opt => opt.MapFrom(src => src.Parts));

        // Map Order to SimplifiedOrderResponse
        CreateMap<Orders, OrderResponse>();

        CreateMap<Parts, PartsOrderResponse>();
    }

}
