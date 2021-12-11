
using AutoMapper;
using Domain.Data.Entities;
using Domain.DTO.GenresDTO;
using Domain.DTO.PersonDTO;

namespace Application.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Genre, GenreDTO>();
        CreateMap<Person, PersonDTO>();
    }
}

