using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UDSAcaiApi.Dominio.Entidades;
using UDSAcaiApi.Dominio.Servicos.Interfaces;
using UDSAcaiApi.Models.Dto;
using UDSAcaiApi.Models.ViewModel;

namespace UDSAcaiApi.Controller
{
    [Route("api/pedidos")]
    [ApiController]
    public class PedidoController : ControllerBase
    {

        #region Campos

        private readonly IPedidoService _pedidoService;
        private readonly IMapper _mapper;

        #endregion

        #region Construtor

        public PedidoController(IPedidoService pedidoService, IMapper mapper)
        {
            _pedidoService = pedidoService;
            _mapper = mapper;
        }

        #endregion

        #region Metodos

        [HttpGet]
        [Route("{id:int}/pedido")]
        public ActionResult<List<PedidoViewModel>> Get(int id)
        {
            try
            {
                var Pedido = _pedidoService.ObterPorId(id);

                return Ok(_mapper.Map<PedidoViewModel>(Pedido));
            }
            catch (ArgumentException exception)
            {
                return NotFound(exception.Message);
            }
            
        }

        [HttpGet]
        [Route("{id:int}/historico")]
        public ActionResult<List<HistoricoPedidoViewModel>> GetHistorico(int id)
        {
            try
            {
                var Pedido = _pedidoService.ObterPorId(id);

                return Ok(_mapper.Map<HistoricoPedidoViewModel>(Pedido));
            }
            catch (ArgumentException exception)
            {
                return NotFound(exception.Message);
            }

        }

        [HttpPost]
        public ActionResult Post([FromBody] PedidoDto pedido)
        {
            try
            {
                var resultadoPedido = _pedidoService.Incluir(_mapper.Map<Pedido>(pedido));
                return Ok(_mapper.Map<PedidoViewModel>(resultadoPedido));
            }
            catch (ArgumentException exception)
            {
                return NotFound(exception.Message);
            }   
        }

        #endregion
    }
}