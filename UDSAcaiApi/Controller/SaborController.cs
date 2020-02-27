using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UDSAcaiApi.Dominio.Servicos.Interfaces;
using UDSAcaiApi.Models.ViewModel;

namespace UDSAcaiApi.Controller
{
    [Route("api/sabores")]
    [ApiController]
    public class SaborController : ControllerBase
    {
        #region Campos

        private readonly ISaborService _saborService;
        private readonly IMapper _mapper;

        #endregion

        #region Construtor

        public SaborController(ISaborService saborService, IMapper mapper)
        {
            _saborService = saborService;
            _mapper = mapper;
        }

        #endregion

        #region Metodos

        [HttpGet]
        public ActionResult<List<SaborViewModel>> Get()
        {
            var sabores = _saborService.ObterTodos();

            if (!sabores.Any())
            {
                NoContent();
            }
            return Ok(sabores.Select(r => _mapper.Map<SaborViewModel>(r)).ToList());
        }

        #endregion
    }
}