
using ApoioConsultorio.Data.Dto.Procedimento;
using ApoioConsultorio.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApoioConsultorio.Controllers
{
    public class ProcedimentoController : Controller
    {

        private ProcedimentoService _procedimetoService;
        public ProcedimentoController(ProcedimentoService atividadeService)
        {
            _procedimetoService = atividadeService;
        }
        
        public IActionResult Index([FromQuery] int skip = 0, int take = 10,string nameProcedimento ="")
        {

           ( List<ReadProcedimentoDto> read , int total)= _procedimetoService.loadAtividade(skip,take, nameProcedimento);

            ViewBag.totalProcedimento = total.ToString();
            return View(read);
        }

        public IActionResult Procedimento([FromQuery] int skip = 0, int take = 10, string nameProcedimento = "" , bool especial = false)
        {
            (List<ReadProcedimentoDto> read, int total) = _procedimetoService.loadAtividadeComEspecial(skip, take, nameProcedimento,especial);

            ViewBag.totalProcedimento = total.ToString();
            return View(read);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create (CreatedProcedimentoDto dto)
        {
            if (ModelState.IsValid)
            {
                ReadProcedimentoDto result = _procedimetoService.CreateAtividade(dto);
                return RedirectToAction(nameof(Index));
            }

            return View(dto);
          
        }



        public IActionResult Edit (int? id)
        {

            if (id ==null)
            {
                return NotFound();
            }

            ReadProcedimentoDto read = _procedimetoService.buscarProcedimentoPorID(id);
            return View(read);
        }


        [HttpPost]

        public IActionResult Editprocedimento( UpdateProcedimentoDto dto)
        {
            bool result = _procedimetoService.updatadeProcedimento(dto);

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            ReadProcedimentoDto read = _procedimetoService.buscarProcedimentoPorID(id);
            return View(read);
        }

        public IActionResult DeleteProcedimeto(int? id)
        {
            bool result = _procedimetoService.DeletarProcedimento(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Calcular(UpdateProcedimentoDto dto)
        {

            ReadProcedimentoDto read = _procedimetoService.Calcular(dto);
            return View(nameof(Edit),read);
        }


    }
}
