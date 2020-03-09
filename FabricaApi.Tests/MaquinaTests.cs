using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FabricaApi.Controllers;
using FabricaApi.DTOs;
using FabricaApi.Models;
using InterfaceGenerica.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace FabricaApi.Tests {

    public class MaquinaTests {

        [Fact]
        public void GetAllMaquinas_ShouldReturnAllMaquinas () {

            // Arrange
            var TestContext = FabricaContextMocker.GetFabricaContext ();
            var theController = new MaquinaController (TestContext);

            //Act
            var result = theController.GetMaquinas ();

            //Assert
            Assert.NotNull (result);

        }

        [Fact]
        public void GetMaquinaDescricao_ShouldReturnMaquinaDTO () {

            // Arrange
            var TestContext = FabricaContextMocker.GetFabricaContext ();
            var theController = new MaquinaController (TestContext);
            String desc = "maquina1";

            //Act
            var result = theController.GetMaquinaByDescricao (desc);

            //Assert
            Assert.NotNull (result);
            Assert.IsType<ActionResult<MaquinaDTO>> (result);
        }

    }
}