using System.Linq;
using EP.CursoMvc.Domain.Interfaces;
using EP.CursoMvc.Domain.Models;
using EP.CursoMvc.Domain.Validations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace EP.CursoMvc.Domain.Tests.Validations
{

    [TestClass]
    public class ClienteAptoValidationTests
    {
        [TestMethod]
        public void ClienteApto_IsValid_True()
        {
            // Arrange
            var cliente = new Cliente
            {
                CPF = "30390600822",
                Email = "teste@teste.com"
            };

            // Act
            // MOCK
            var repo = MockRepository.GenerateStub<IClienteRepository>();
            repo.Stub(s => s.ObterPorCpf(cliente.CPF)).Return(null);
            repo.Stub(s => s.ObterPorEmail(cliente.Email)).Return(null);

            var validationReturn = new ClienteAptoParaCadastroValidation(repo).Validate(cliente);

            // Assert
            Assert.IsTrue(validationReturn.IsValid);
        }

        [TestMethod]
        public void ClienteApto_IsValid_False()
        {
            // Arrange
            var cliente = new Cliente
            {
                CPF = "30390600822",
                Email = "teste@teste.com"
            };

            // Act
            // MOCK
            var repo = MockRepository.GenerateStub<IClienteRepository>();
            repo.Stub(s => s.ObterPorCpf(cliente.CPF)).Return(cliente);
            repo.Stub(s => s.ObterPorEmail(cliente.Email)).Return(cliente);

            var validationReturn = new ClienteAptoParaCadastroValidation(repo).Validate(cliente);

            // Assert
            Assert.IsFalse(validationReturn.IsValid);
            Assert.IsTrue(validationReturn.Erros.Any(e => e.Message == "Cliente com CPF ou E-mail já cadastrado"));
        }
    }
}