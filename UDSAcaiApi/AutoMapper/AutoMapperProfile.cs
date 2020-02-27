using AutoMapper;
using UDSAcaiApi.AutoMapper.Mappers;

namespace UDSAcaiApi.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            SaborMapper.Map(this);
            TamanhoMapper.Map(this);
            PreparacaoMapper.Map(this);
            AdicionalMapper.Map(this);
            PedidoMapper.Map(this);
        }
    }
}
