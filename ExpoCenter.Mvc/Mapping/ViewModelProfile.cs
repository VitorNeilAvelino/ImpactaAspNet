using AutoMapper;
using ExpoCenter.Dominio.Entidades;
using ExpoCenter.Mvc.Models;
using System.Collections.Generic;

namespace ExpoCenter.Mvc.Mapping
{
    public class ViewModelProfile : Profile
    {
        public ViewModelProfile()
        {
            CreateMap<Participante, ParticipanteViewModel>().ReverseMap();
            CreateMap<List<Participante>, List<ParticipanteViewModel>>().ReverseMap();
        }
    }
}