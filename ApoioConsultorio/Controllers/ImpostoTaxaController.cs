using ApoioConsultorio.Data.Dto.ImpostoTaxa;
using ApoioConsultorio.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApoioConsultorio.Controllers
{
    public class ImpostoTaxaController : Controller
    {
        private ImpostoTaxaService _imposotTaxaService;
        public ImpostoTaxaController(ImpostoTaxaService imposotTaxaService)
        {
            _imposotTaxaService = imposotTaxaService;
        }
        public IActionResult Index()
        {
            List<ReadImpostoTaxaDto> read = _imposotTaxaService.BuscarTodasTaxas(99);
            return View(read);
        }


       

        public IActionResult Edit ( int status = 99)
        {
            ReadImpostoTaxaDto read = _imposotTaxaService.buscar(status);

            return View(read);

             
        }

        public IActionResult EditImpsotoTaxa( UpdateImpostotaxaDto dto)
        {

            bool result = _imposotTaxaService.Atualizar(dto);

             return RedirectToAction(nameof(Index));

        }
    }
}
