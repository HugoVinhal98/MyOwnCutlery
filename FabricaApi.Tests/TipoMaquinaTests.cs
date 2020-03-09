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
    public class TipoMaquinaTests
    {

        [Fact]
        public void GetListaTipoMaquina_ShouldReturnAllTiposMaquina(){

            // Arrange
            var TestContext = FabricaContextMocker.GetFabricaContext();
            var theController = new TipoMaquinaController(TestContext);

            //Act
            var result = theController.GetListaTipoMaquina();

            //Assert
            Assert.NotNull(result);

        }

        [Fact]
        public void GetTipoMaquinaByDescricao_ShouldReturnTipoMaquina(){

            // Arrange
            var TestContext = FabricaContextMocker.GetFabricaContext();
            var theController = new TipoMaquinaController(TestContext);
            String desc = "maquina1";

            //Act
            var result = theController.GetTipoMaquinaByDescricao(desc);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ActionResult<TipoMaquinaDTO>>(result);

        }

        [Fact]
        public void PostTipoMaquina_ShouldReturnDeletedTipoMaquina(){

            // Arrange
            var TestContext = FabricaContextMocker.GetFabricaContext();
            var theController = new TipoMaquinaController(TestContext);

            //Act
            TipoMaquina tm = new TipoMaquina { descricao = new DescricaoTipoMaquina { descricao = "Tipo 1" } };
            var result = theController.PostTipoMaquina(tm);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ActionResult<TipoMaquina>>(result);

        }

    }
}