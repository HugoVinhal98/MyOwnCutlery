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

    public class OperacaoTests {

        [Fact]
        public void GetOperacaoByNome_ShouldReturnOperacaoDTO () {

            // Arrange
            var TestContext = FabricaContextMocker.GetFabricaContext ();
            var theController = new OperacaoController (TestContext);
            String nome = "Operacao 1";

            //Act
            var result = theController.GetOperacaoByNome (nome);

            //Assert
            Assert.NotNull (result);

        }

    }
}