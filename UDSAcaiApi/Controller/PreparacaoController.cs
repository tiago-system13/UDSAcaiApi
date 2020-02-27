using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UDSAcaiApi.Dominio.Entidades;
using UDSAcaiApi.Dominio.Servicos.Interfaces;
using UDSAcaiApi.Models.Dto;
using UDSAcaiApi.Models.ViewModel;

namespace UDSAcaiApi.Controller
{
    [Route("api/preparacoes")]
    [ApiController]
    public class PreparacaoController : ControllerBase
    {
        #region Campos

        private readonly IPreparacaoService _preparacaoService;
        private readonly IMapper _mapper;

        #endregion

        #region Construtor

        public PreparacaoController(IPreparacaoService PreparacaoService, IMapper mapper)
        {
            _preparacaoService = PreparacaoService;
            _mapper = mapper;
        }

        #endregion

        #region Metodos

        [HttpGet]
        [Route("{saborId:int}/{tamanhoId:int}/preparacao")]
        public ActionResult<List<PreparacaoViewModel>> Get(int saborId, int tamanhoId)
        {
            try
            {
                var preparacao = _preparacaoService.ObterPorSaborTamanho(saborId, tamanhoId);
                return Ok(_mapper.Map<PreparacaoViewModel>(preparacao));
            }
            catch(ArgumentException exception)
            {
                return NotFound(exception.Message);
            }
            
        }

        [HttpPost]
        public ActionResult Post([FromBody] PreparacaoDto preparacao)
        {
            try
            {
                var resultadoPreparacao = _preparacaoService.Incluir(_mapper.Map<Preparacao>(preparacao));
                return Ok(_mapper.Map<PreparacaoViewModel>(resultadoPreparacao));
            }
            catch (ArgumentException exception)
            {
                return NotFound(exception.Message);
            }
          
        }

        #endregion
    }
}