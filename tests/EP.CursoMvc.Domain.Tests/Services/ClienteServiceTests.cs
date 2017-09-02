using System;
using EP.CursoMvc.Domain.Interfaces;
using EP.CursoMvc.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace EP.CursoMvc.Domain.Tests.Services
{
    [TestClass]
    public class ClienteServiceTests
    {
        [TestMethod]
        public void ClienteService_ObterClienteAtivo_Cliente()
        {
            // Assert
            var cliente = new Cliente
            {
                Ativo = true,
                Excluido = false
            };

            var id = Guid.NewGuid();
            var repo = MockRepository.GenerateStub<IClienteRepository>();
            repo.Stub(s => s.ObterPorId(id)).Return(cliente);

            // Act
            var clienteReturn = repo.ObterPorId(id);

            // Assert
            Assert.IsTrue(clienteReturn.EhAtivo());
        }
    }
}