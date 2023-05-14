using AutoMapper;
using Proyecto.Core.DTOs;
using Proyecto.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Infrastructure.Mappings
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Peoples, PeoplesDto>();
            CreateMap<PeoplesDto, Peoples>();
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioDto, Usuario>();
            CreateMap<UsuarioDto, UsuariolOGIN>();
            CreateMap<UsuariolOGIN, UsuarioDto>();
        }
    }
}
