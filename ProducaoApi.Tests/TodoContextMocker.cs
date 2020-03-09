using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InterfaceGenerica.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using ProducaoApi.Controllers;
using ProducaoApi.DTOs;
using ProducaoApi.Models;
using Xunit;

public static class ProducaoContextMocker {

    public static ProducaoContext GetProducaoContext () {
        var options = new DbContextOptionsBuilder<ProducaoContext> ()
            .UseInMemoryDatabase ("ProducaoDB")
            .Options;

        ProducaoContext dbContext = new ProducaoContext (options);

        Seed (dbContext);
        return dbContext;
    }

    private static void Seed (this ProducaoContext dbContext) {

        List<Operacao> lo1 = new List<Operacao> ();
        List<Operacao> lo2 = new List<Operacao> ();
        List<Operacao> lo3 = new List<Operacao> ();

        Operacao op1 = new Operacao { nome = "Operacao 1" };
        Operacao op2 = new Operacao { nome = "Operacao 2" };
        Operacao op3 = new Operacao { nome = "Operacao 3" };
        Operacao op4 = new Operacao { nome = "Operacao 4" };
        Operacao op5 = new Operacao { nome = "Operacao 5" };
        Operacao op6 = new Operacao { nome = "Operacao 6" };
        Operacao op7 = new Operacao { nome = "Operacao 7" };
        Operacao op8 = new Operacao { nome = "Operacao 8" };
        Operacao op9 = new Operacao { nome = "Operacao 9" };

        lo1.Add (op1);
        lo1.Add (op2);
        lo1.Add (op3);

        lo2.Add (op4);
        lo2.Add (op5);
        lo2.Add (op6);

        lo3.Add (op7);
        lo3.Add (op8);
        lo3.Add (op9);

        dbContext.PlanosFabrico.Add (new PlanoFabrico { nome = new NomePlanoFabrico { nome = "PlanoFabrico1" }, listaOperacoes = lo1 });
        dbContext.PlanosFabrico.Add (new PlanoFabrico { nome = new NomePlanoFabrico { nome = "PlanoFabrico2" }, listaOperacoes = lo2 });
        dbContext.PlanosFabrico.Add (new PlanoFabrico { nome = new NomePlanoFabrico { nome = "PlanoFabrico3" }, listaOperacoes = lo3 });

        dbContext.Produtos.Add (new Produto { nome = new NomeProduto { nome = "ProdutoBase" }, descricao = new DescricaoProduto { descricao = "Produto por defeito" }, planoFabrico = new NomePlanoFabrico { nome = "PlanoFabrico1" } });

        dbContext.SaveChanges ();

    }
}