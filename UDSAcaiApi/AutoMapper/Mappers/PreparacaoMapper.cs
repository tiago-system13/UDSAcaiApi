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
    public class PreparacaoMapper
    {
        public static void Map(Profile profile)
        {
            profile.CreateMap<Sabor, SaborViewModel>();
            profile.CreateMap<Tamanho, TamanhoViewModel>();
            profile.CreateMap<Preparacao, PreparacaoViewModel>();
            profile.CreateMap<PreparacaoDto, Preparacao>();
        }
    }
}
