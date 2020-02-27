using AutoMapper;
using System.Linq;
using UDSAcaiApi.Dominio.Entidades;
using UDSAcaiApi.Models.Dto;
using UDSAcaiApi.Models.ViewModel;

namespace UDSAcaiApi.AutoMapper.Mappers
{
    public class PedidoMapper
    {
        public static void Map(Profile profile)
        {
            profile.CreateMap<Sabor, SaborViewModel>();

            profile.CreateMap<Tamanho, TamanhoViewModel>();
            
            profile.CreateMap<Preparacao, PreparacaoViewModel>();

            profile.CreateMap<Adicionais, AdicionalViewModel>();

            profile.CreateMap<ItensAdicionaisPedido, ItemAdicionalViewModel>();

            profile.CreateMap<Pedido, PedidoViewModel>();

            profile.CreateMap<Pedido, HistoricoPedidoViewModel>()
                .ForMember(h => h.Sabor, opt => opt.MapFrom(op => op.Preparacao.Sabor.Descricao))
                .ForMember(h => h.Tamanho, opt => opt.MapFrom(op => op.Preparacao.Tamanho.Descricao))
                .ForMember(h => h.Preco, opt => opt.MapFrom(op => op.Preparacao.Valor))
                .ForMember(h => h.Personalizacoes, opt => opt.MapFrom(op => op.ItensAdicionais.Select(a => a.Adicionais)))
                .ForMember(h => h.ValorTotal, opt => opt.MapFrom(op => op.Total));
                

            profile.CreateMap<ItemAdicionalDto, ItensAdicionaisPedido>();

            profile.CreateMap<PedidoDto, Pedido>();


        }
    }
}
