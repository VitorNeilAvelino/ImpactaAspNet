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
            CreateMap<Participante, ParticipanteIndexViewModel>().ReverseMap();
            CreateMap<List<Participante>, List<ParticipanteIndexViewModel>>().ReverseMap();

            CreateMap<Participante, ParticipanteCreateViewModel>().ReverseMap();
            CreateMap<List<Participante>, List<ParticipanteCreateViewModel>>().ReverseMap();

            CreateMap<Evento, EventoViewModel>().ReverseMap();
            CreateMap<List<Evento>, List<EventoViewModel>>().ReverseMap();

            CreateMap<Evento, EventoGridViewModel>().ReverseMap();
            CreateMap<List<Evento>, List<EventoGridViewModel>>().ReverseMap();
        }
    }
}