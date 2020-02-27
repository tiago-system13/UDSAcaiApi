using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UDSAcaiApi.Dominio.Entidades;
using UDSAcaiApi.Models.Dto;
using UDSAcaiApi.Models.ViewModel;

namespace UDSAcaiApi.AutoMapper.Mappers
{
    public class AdicionalMapper
    {
        public static void Map(Profile profile)
        {
            profile.CreateMap<Adicionais, AdicionalViewModel>();
            profile.CreateMap<AdicionalDto, Adicionais>();
        }
    }
}
