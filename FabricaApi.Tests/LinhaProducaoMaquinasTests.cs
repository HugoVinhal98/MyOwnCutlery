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
    public class LinhaProducaoMaquinasTests
    {
        [Fact]
        public void GetListaLinhaProducaoMaquina_ShouldReturnListaLinhaProducaoMaquina(){

            // Arrange
            var TestContext = FabricaContextMocker.GetFabricaContext();
            var theController = new LinhaProducaoMaquinaController(TestContext);

            //Act
            var result = theController.GetListaLinhaProducaoMaquina();

            //Assert
            Assert.NotNull(result);

        }

    }
}