using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FabricaApi.Controllers;
using FabricaApi.Models;
using FabricaApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Moq;
using InterfaceGenerica.ValueObjects;
using Xunit;

namespace FabricaApi.Tests
{
    public class TipoMaquinaOperacaoTests
    {
        [Fact]
        public void GetAllTipoMaquinaOperacao_ShouldReturnAllDTO(){

            // Arrange
            var TestContext = FabricaContextMocker.GetFabricaContext();
            var theController = new TipoMaquinaOperacaoController(TestContext);

            //Act
            var result = theController.GetListaMaquinasOperacao();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<ListaMaquinasOperacaoDTO>>(result);
        }
        
    }
}