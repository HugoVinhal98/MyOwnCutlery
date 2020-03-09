using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProducaoApi.Controllers;
using ProducaoApi.Models;
using ProducaoApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using InterfaceGenerica.ValueObjects;
using Xunit;

namespace ProducaoApi.Tests
{
    public class ProdutoTests
    {
        [Fact]
        public void GetAllProdutos_ShouldReturnAllProdutosDTO(){

            // Arrange
            var TestContext = ProducaoContextMocker.GetProducaoContext();
            var theController = new ProdutoController(TestContext);

            //Act
            var result = theController.GetProdutos();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<ProdutoDTO>>(result);
        }

        [Fact]
        public void GetProdutoByNome_ShouldReturnProdutoDTO(){

            // Arrange
            var TestContext = ProducaoContextMocker.GetProducaoContext();
            var theController = new ProdutoController(TestContext);
            String nome = "ProdutoBase";

            //Act
            var result = theController.GetProdutoByNome(nome);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ActionResult<ProdutoDTO>>(result);
        }
        
    }
}