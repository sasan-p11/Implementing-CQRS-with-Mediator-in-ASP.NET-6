
using AutoMapper;
using Domain.Data.Entities;
using Domain.DTO.GenresDTO;

namespace Appllication.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Genre, GenreDTO>();
    }
}

