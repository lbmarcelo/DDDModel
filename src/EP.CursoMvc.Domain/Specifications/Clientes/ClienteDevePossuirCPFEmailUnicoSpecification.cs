using DomainValidation.Interfaces.Specification;
using EP.CursoMvc.Domain.Interfaces;
using EP.CursoMvc.Domain.Models;

namespace EP.CursoMvc.Domain.Specifications.Clientes
{
    public class ClienteDevePossuirCPFEmailUnicoSpecification : ISpecification<Cliente>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteDevePossuirCPFEmailUnicoSpecification(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public bool IsSatisfiedBy(Cliente cliente)
        {
            return _clienteRepository.ObterPorCpf(cliente.CPF) == null &&
                   _clienteRepository.ObterPorEmail(cliente.Email) == null;
        }
    }
}