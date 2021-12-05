using AutoMapper;
using Domain.DTO;
using Domain.Entities;

public class MappingProfile : Profile 
 {
     public MappingProfile() {
         CreateMap<Gener , GenerDTO>();
     }
 }