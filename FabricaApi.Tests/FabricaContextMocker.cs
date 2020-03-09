using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FabricaApi.DTOs;
using FabricaApi.Models;
using InterfaceGenerica.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using FabricaApi.Controllers;
using Xunit;

public static class FabricaContextMocker {

    public static FabricaContext GetFabricaContext () {
        var options = new DbContextOptionsBuilder<FabricaContext> ()
            .UseInMemoryDatabase ("FabricaDB")
            .Options;

        FabricaContext dbContext = new FabricaContext (options);

        Seed (dbContext);
        return dbContext;
    }

    private static void Seed (this FabricaContext dbContext) {

        dbContext.Maquinas.Add (new Maquina { descricao = new DescricaoMaquina { descricao = "maquina1" }, marca = new Marca { marca = "Marca1" }, modelo = new Modelo { modelo = "ModeloA" }, posicao = 0, tipoMaquina = 1 });
        dbContext.LinhasProducao.Add(new LinhaProducao {descricao = new DescricaoLinhaProducao {descricao = "Linha 1"}} );
        dbContext.LinhasProducao.Add(new LinhaProducao {descricao = new DescricaoLinhaProducao {descricao = "Linha 2"}} );
        dbContext.Operacoes.Add(new Operacao { nome = new NomeOperacao { nome = "Operacao 1" }, tipoOpId = 1, duracao = new Duracao (2, 5) });
        dbContext.tipoOperacoes.Add(new TipoOperacao { nome = new NomeTipoOperacao { nome = "Furar com broca" } , ferramenta = new Ferramenta { descricao = "Broca 5mm" } , tempoSetup = new TempoSetup { tempo = 5 } });
        dbContext.TipoMaquinas_Operacao.Add(new ListaMaquinasOperacao {idTipoMaquina = 1 , idOperacao = 2} );
        dbContext.TipoMaquinas_Operacao.Add(new ListaMaquinasOperacao {idTipoMaquina = 2 , idOperacao = 4} );
        dbContext.SaveChanges ();

    }
}