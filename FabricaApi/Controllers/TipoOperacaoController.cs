using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FabricaApi.Models;
using InterfaceGenerica.ValueObjects;
using FabricaApi.Repo;
using FabricaApi.DTOs;
using System;
using Microsoft.AspNetCore.Cors;

namespace FabricaApi.Controllers
{
    [Route("api/TipoOperacao")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class TipoOperacaoController : ControllerBase
    {
        private readonly FabricaContext _context;

        private TipoOperacaoRepositorio repo;

        public TipoOperacaoController(FabricaContext context)
        {
            _context = context;
            repo = new TipoOperacaoRepositorio(_context);

            if (_context.tipoOperacoes.Count() == 0)
            {
                // Create a new TipoOperacao if collection is empty,
                // which means you can't delete all TipoOperacoes.
                _context.tipoOperacoes.Add(new TipoOperacao { nome = new NomeTipoOperacao { nome = "Furar com broca" } , ferramenta = new Ferramenta { descricao = "Broca 5mm" } , tempoSetup = new TempoSetup { tempo = 5 } });
                _context.tipoOperacoes.Add(new TipoOperacao { nome = new NomeTipoOperacao { nome = "Furar com berbequim" } , ferramenta = new Ferramenta { descricao = "Berbequim " } , tempoSetup = new TempoSetup { tempo = 3 } });
                _context.tipoOperacoes.Add(new TipoOperacao { nome = new NomeTipoOperacao { nome = "Lixar" } , ferramenta = new Ferramenta { descricao = "Lixa" } , tempoSetup = new TempoSetup { tempo = 3 } });
                _context.tipoOperacoes.Add(new TipoOperacao { nome = new NomeTipoOperacao { nome = "Martelar" } , ferramenta = new Ferramenta { descricao = "Martelo " } , tempoSetup = new TempoSetup { tempo = 2 } });

                _context.SaveChanges();
            }
        }

        // GET: api/TipoOperacao
        [HttpGet]
        public IEnumerable<TipoOperacao> GetTiposOperacoes()
        {
            IEnumerable<TipoOperacao> lista = repo.SelectAll();

            return lista;
        }

    }

}