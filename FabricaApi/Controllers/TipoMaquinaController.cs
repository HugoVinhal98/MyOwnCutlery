using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FabricaApi.DTOs;
using FabricaApi.Models;
using FabricaApi.Repo;
using InterfaceGenerica.ValueObjects;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaApi.Controllers {

    [Route ("api/tipoMaquina")]
    [ApiController]
    [EnableCors ("MyPolicy")]
    public class TipoMaquinaController : ControllerBase {
        private readonly FabricaContext _context;

        TipoMaquinaRepositorio repo;

        public TipoMaquinaController (FabricaContext context) {
            _context = context;

            repo = new TipoMaquinaRepositorio (_context);

            if (_context.TipoMaquinas.Count () == 0) {
                // Create a new TipoMaquina if collection is empty,
                // which means you can't delete all TipoMaquina.
                _context.TipoMaquinas.Add (new TipoMaquina { descricao = new DescricaoTipoMaquina { descricao = "Tipo 1" } });
                _context.TipoMaquinas.Add (new TipoMaquina { descricao = new DescricaoTipoMaquina { descricao = "Tipo 2" } });
                _context.TipoMaquinas.Add (new TipoMaquina { descricao = new DescricaoTipoMaquina { descricao = "Tipo 3" } });
                _context.TipoMaquinas.Add (new TipoMaquina { descricao = new DescricaoTipoMaquina { descricao = "Tipo 4" } });
                _context.SaveChanges ();
            }
        }

        // POST: api/tipoMaquina
        [HttpPost]
        public ActionResult<TipoMaquina> PostTipoMaquina (TipoMaquina tp) {

            List<TipoMaquina> listaTiposMaq = _context.TipoMaquinas.ToList ();

            foreach (TipoMaquina tm in listaTiposMaq) {
                if (tp.descricao.Equals (tm.descricao)) {
                    return BadRequest ();
                }
            }

            return repo.Insert (tp);

        }

        // GET: api/tipoMaquina
        [HttpGet]
        public IEnumerable<TipoMaquinaDTO> GetListaTipoMaquina () {

            IEnumerable<TipoMaquina> lista = repo.SelectAll ();

            return ToDTO.ListaTipoMaquinaToDTO (lista);
        }

        // GET: api/tipoMaquina/Tipo 1
        [HttpGet ("{descricao}")]
        public ActionResult<TipoMaquinaDTO> GetTipoMaquinaByDescricao (String descricao) {

            long id = 0;

            List<TipoMaquina> listaTipo = _context.TipoMaquinas.ToList ();

            foreach (TipoMaquina tm in listaTipo) {
                if (tm.descricao.descricao == descricao) {
                    id = tm.Id;
                }
            }

            TipoMaquina tpm = repo.SelectById (id);

            if (tpm == null) {
                return NotFound ();
            }

            return ToDTO.TipoMaquinaToDTO (tpm);

        }

    }

}