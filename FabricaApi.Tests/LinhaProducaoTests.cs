using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FabricaApi.Controllers;
using FabricaApi.Models;
using FabricaApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using InterfaceGenerica.ValueObjects;
using Xunit;

namespace FabricaApi.Tests
{
    public class LinhaProducaoTests
    {
        [Fact]
        public void GetLinhasProducao_ShouldReturnAllLinhasProducao(){

            // Arrange
            var TestContext = FabricaContextMocker.GetFabricaContext();
            var theController = new LinhaProducaoController(TestContext);

            //Act
            var result = theController.GetLinhasProducao();

            //Assert
            Assert.NotNull(result);

        }

        [Fact]
        public void PostLinhaProducao_ShouldReturnLinhaProducao(){

            // Arrange
            var TestContext = FabricaContextMocker.GetFabricaContext();
            var theController = new LinhaProducaoController(TestContext);

            //Act
            LinhaProducao lp = (new LinhaProducao {descricao = new DescricaoLinhaProducao {descricao = "Linha 1"}} );
            var result = theController.PostLinhaProducao(lp);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Task<ActionResult<LinhaProducao>>>(result);
        }

    }
}