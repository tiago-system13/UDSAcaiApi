using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UDSAcaiApi.Dominio.Servicos.Interfaces;
using UDSAcaiApi.Models.ViewModel;

namespace UDSAcaiApi.Controller
{
    [Route("api/adicionais")]
    [ApiController]
    public class AdicionalController : ControllerBase
    {
        #region Campos

        private readonly IAdicionaisService _adicionaisService;
        private readonly IMapper _mapper;

        #endregion

        #region Construtor

        public AdicionalController(IAdicionaisService AdicionaisService, IMapper mapper)
        {
            _adicionaisService = AdicionaisService;
            _mapper = mapper;
        }

        #endregion

        #region Metodos

        [HttpGet]
        public ActionResult<List<AdicionalViewModel>> Get()
        {
            var Adicionaises = _adicionaisService.ObterTodos();

            if (!Adicionaises.Any())
            {
                NoContent();
            }

            return Ok(Adicionaises.Select(r => _mapper.Map<AdicionalViewModel>(r)).ToList());
        }

        #endregion
    }
}