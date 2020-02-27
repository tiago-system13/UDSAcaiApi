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
    public class TamanhoMapper
    {
        public static void Map(Profile profile)
        {
            profile.CreateMap<TamanhoDto, Tamanho>();

            profile.CreateMap<Tamanho, TamanhoViewModel>();
        }
    }
}
