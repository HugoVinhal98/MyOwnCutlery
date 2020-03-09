using System;
using System.Collections;
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
    [Route ("api/linhaproducaomaquina")]
    [ApiController]
    [EnableCors ("MyPolicy")]
    public class LinhaProducaoMaquinaController : ControllerBase {
        private readonly FabricaContext _context;

        LinhaProducaoMaquinaRepositorio repo;

        public LinhaProducaoMaquinaController (FabricaContext context) {

            _context = context;

            repo = new LinhaProducaoMaquinaRepositorio (_context);

            if (_context.LinhasProducaoMaquina.Count () == 0) {
                // Create a new TipoMaquina_Operacao if collection is empty,
                // which means you can't delete all Operacoes.
                _context.SaveChanges ();
            }

        }

        // GET: api/linhaproducaomaquina
        [HttpGet]
        public IEnumerable<LinhaProducaoMaquinaDTO> GetListaLinhaProducaoMaquina () {

            IEnumerable<LinhaProducaoMaquina> lista = repo.SelectAll ();

            return ToDTO.ListaLinhaProducaoMaquinaToDTO (lista);

        }

        // PUT: api/linhaproducaomaquina/Linha 1
        [HttpPut ("{descricao}")]
        public void PutLinhaProducaoMaquina (String descricao, List<LPMaquinaDTO> l) {

            List<Maquina> listaMaq = _context.Maquinas.ToList ();
            List<Maquina> listaFinal = new List<Maquina> ();
            long id = 0;

            foreach (Maquina maquina in listaMaq) {

                foreach (LPMaquinaDTO m in l) {
                    if (maquina.descricao.descricao == m.descricao) {
                        maquina.posicao = m.posicao;
                        listaFinal.Add (maquina);
                    }
                }

            }

            List<LinhaProducao> listaProducao = _context.LinhasProducao.ToList ();

            foreach (LinhaProducao lp in listaProducao) {
                if (lp.descricao.descricao == descricao) {
                    id = lp.Id;
                }
            }

            repo.DefinirMaquinasDeLP (id, listaFinal);

        }

    }

}