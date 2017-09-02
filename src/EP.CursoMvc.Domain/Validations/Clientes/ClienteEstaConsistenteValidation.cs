using DomainValidation.Validation;
using EP.CursoMvc.Domain.Models;
using EP.CursoMvc.Domain.Specifications.Clientes;

namespace EP.CursoMvc.Domain.Validations.Clientes
{
    public class ClienteEstaConsistenteValidation : Validator<Cliente>
    {
        public ClienteEstaConsistenteValidation()
        {
            var CPFCliente = new ClienteDeveTerCpfValidoSpecification();
            var clienteEmail = new ClienteDeveTerEmailValidoSpecification();
            var clienteMaioridade = new ClienteDeveSerMaiorDeIdadeSpecification();

            base.Add("CPFCliente", new Rule<Cliente>(CPFCliente, "Cliente informou um CPF inválido."));
            base.Add("clienteEmail", new Rule<Cliente>(clienteEmail, "Cliente informou um e-mail inválido."));
            base.Add("clienteMaioridade", new Rule<Cliente>(clienteMaioridade, "Cliente não tem maioridade para cadastro."));
        }
    }
}