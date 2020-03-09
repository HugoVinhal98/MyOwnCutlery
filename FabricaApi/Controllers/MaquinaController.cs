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
    [Route ("api/Maquina")]
    [ApiController]
    [EnableCors ("MyPolicy")]
    public class MaquinaController : ControllerBase {

        private readonly FabricaContext _context;

        MaquinaRepositorio repo;
        TipoMaquinaRepositorio repoTipo;

        public MaquinaController (FabricaContext context) {
            _context = context;
            repo = new MaquinaRepositorio (_context);
            repoTipo = new TipoMaquinaRepositorio (_context);

            if (_context.Maquinas.Count () == 0) {

                _context.Maquinas.Add (new Maquina { descricao = new DescricaoMaquina { descricao = "maquina1" }, marca = new Marca { marca = "Marca1" }, modelo = new Modelo { modelo = "ModeloA" }, posicao = 0, tipoMaquina = 1 });
                _context.Maquinas.Add (new Maquina { descricao = new DescricaoMaquina { descricao = "maquina2" }, marca = new Marca { marca = "Marca2" }, modelo = new Modelo { modelo = "ModeloB" }, posicao = 0, tipoMaquina = 2 });
                _context.Maquinas.Add (new Maquina { descricao = new DescricaoMaquina { descricao = "maquina3" }, marca = new Marca { marca = "Marca1" }, modelo = new Modelo { modelo = "ModeloC" }, posicao = 0, tipoMaquina = 3 });

                _context.SaveChanges ();
            }
        }

        // GET: api/Maquina
        [HttpGet]
        public IEnumerable<MaquinaDTO> GetMaquinas () {

            IEnumerable<Maquina> lista = repo.SelectAll ();
            List<MaquinaDTO> listaFinal = new List<MaquinaDTO> ();
            List<TipoMaquina> listaTipo = _context.TipoMaquinas.ToList ();

            String desc = "";

            foreach (Maquina m in lista) {

                foreach (TipoMaquina tm in listaTipo) {
                    if (tm.Id == m.tipoMaquina) {
                        desc = tm.descricao.descricao;
                    }
                }

                MaquinaDTO dto;

                dto = new MaquinaDTO { descricao = m.descricao.descricao, marca = m.marca.marca, modelo = m.modelo.modelo, descTipoMaquina = desc, ativa = m.ativa };

                listaFinal.Add (dto);

            }

            return listaFinal;
        }

        // GET: api/Maquina/maquinasDeTipoMaquina/Tipo 1
        [HttpGet ("maquinasDeTipoMaquina/{descricao}")]
        public IEnumerable<MaquinaDTO> GetMaquinasTipoMaquina (String descricao) {

            long id = 0;
            List<TipoMaquina> listaTipo = _context.TipoMaquinas.ToList ();
            List<MaquinaDTO> listaFinal = new List<MaquinaDTO> ();

            foreach (TipoMaquina tipo in listaTipo) {
                if (tipo.descricao.descricao == descricao) {
                    id = tipo.Id;
                }
            }

            IEnumerable<Maquina> lista = repo.SelectMaquinasTipoMaquina (id);

            String desc = "";

            foreach (Maquina m in lista) {

                foreach (TipoMaquina tm in listaTipo) {
                    if (tm.Id == m.tipoMaquina) {
                        desc = tm.descricao.descricao;
                    }
                }

                MaquinaDTO dto;

                dto = new MaquinaDTO { descricao = m.descricao.descricao, marca = m.marca.marca, modelo = m.modelo.modelo, descTipoMaquina = desc, ativa = m.ativa };

                listaFinal.Add (dto);

            }

            return listaFinal;
        }

        // GET: api/Maquina/maquina1
        [HttpGet ("{descricao}")]
        public ActionResult<MaquinaDTO> GetMaquinaByDescricao (String descricao) {
            long id = 0;
            List<Maquina> lista = _context.Maquinas.ToList ();

            foreach (Maquina m in lista) {
                if (m.descricao.descricao == descricao) {
                    id = m.Id;
                }
            }

            var maq = repo.SelectById (id);

            if (maq == null) {
                return NotFound ();
            }

            long tipoM = maq.tipoMaquina;

            var tipo = repoTipo.SelectById (tipoM);

            MaquinaDTO dto;

            dto = new MaquinaDTO { descricao = maq.descricao.descricao, marca = maq.marca.marca, modelo = maq.modelo.modelo, descTipoMaquina = tipo.descricao.descricao, ativa = maq.ativa };

            return Ok (dto);
        }

        // GET: api/Maquina/id
        [HttpGet ("byid/{id}")]
        public ActionResult<MaquinaDTO> GetMaquinaById (long id) {

            var maq = repo.SelectById(id);

            if (maq == null) {
                return NotFound ();
            }

            long tipoM = maq.tipoMaquina;

            var tipo = repoTipo.SelectById (tipoM);

            MaquinaDTO dto;

            dto = new MaquinaDTO { descricao = maq.descricao.descricao, marca = maq.marca.marca, modelo = maq.modelo.modelo, descTipoMaquina = tipo.descricao.descricao, ativa = maq.ativa };

            return Ok (dto);
        }

        // POST: api/Maquina
        [HttpPost]
        public ActionResult<Maquina> PostMaquina (MaquinaDTO dto) {

            List<TipoMaquina> listaTiposMaq = _context.TipoMaquinas.ToList ();
            List<Maquina> listaMaq = _context.Maquinas.ToList ();
            int flag = 0;
            long id = 0;

            foreach (Maquina maq in listaMaq) {
                if (dto.descricao == maq.descricao.descricao) {
                    return BadRequest ();
                }
            }

            foreach (TipoMaquina tp in listaTiposMaq) {
                if (dto.descTipoMaquina == tp.descricao.descricao) {
                    flag = 1;
                    id = tp.Id;
                }
            }

            if (flag == 0) {
                return BadRequest ();
            }

            Maquina m = new Maquina { descricao = new DescricaoMaquina { descricao = dto.descricao }, marca = new Marca { marca = dto.marca }, modelo = new Modelo { modelo = dto.modelo }, posicao = 0, tipoMaquina = id, ativa = true };

            return Ok (repo.Insert (m));

        }

        // PUT: api/Maquina/alterarTM/maquina1
        [HttpPut ("alterarTM/{descricao}")]
        public async Task<IActionResult> AlterarTipoMaquina (String descricao, [FromBody] TipoMaquinaDTO dto) {

            long id = 0;
            List<Maquina> listaMaqAlt = _context.Maquinas.ToList ();

            foreach (Maquina maqAlt in listaMaqAlt) {
                if (maqAlt.descricao.descricao == descricao) {
                    id = maqAlt.Id;
                }
            }

            List<TipoMaquina> listaTiposMaq = _context.TipoMaquinas.ToList ();

            TipoMaquina tipo = null;

            foreach (TipoMaquina tp in listaTiposMaq) {
                if (dto.descricao == tp.descricao.descricao) {
                    tipo = new TipoMaquina { descricao = new DescricaoTipoMaquina { descricao = dto.descricao } };
                }
            }

            return Ok (repo.ChangeTipoMaquina (id, tipo));

        }

        // PUT: api/Maquina/alterarAtivada/maquina1
        [HttpPut ("alterarAtivada/{descricao}")]
        public async Task<IActionResult> AlterarAtivada (String descricao) {

            long id = 0;
            List<Maquina> listaMaqAlt = _context.Maquinas.ToList ();

            foreach (Maquina maqAlt in listaMaqAlt) {
                if (maqAlt.descricao.descricao == descricao) {
                    id = maqAlt.Id;
                }
            }

            return Ok (repo.ChangeAtivada (id));

        }

    }

}