using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UDSAcaiApi.Dominio.Servicos.Interfaces;
using UDSAcaiApi.Models.ViewModel;

namespace UDSAcaiApi.Controller
{
    [Route("api/tamanhos")]
    [ApiController]
    public class TamanhoController : ControllerBase
    {
        #region Campos

        private readonly ITamanhoService _TamanhoService;
        private readonly IMapper _mapper;

        #endregion

        #region Construtor

        public TamanhoController(ITamanhoService TamanhoService, IMapper mapper)
        {
            _TamanhoService = TamanhoService;
            _mapper = mapper;
        }

        #endregion

        #region Metodos

        [HttpGet]
        public ActionResult<List<TamanhoViewModel>> Get()
        {
            var Tamanhoes = _TamanhoService.ObterTodos();

            if (!Tamanhoes.Any())
            {
                NoContent();
            }
            return Ok(Tamanhoes.Select(r => _mapper.Map<TamanhoViewModel>(r)).ToList());
        }

        #endregion
    }
}