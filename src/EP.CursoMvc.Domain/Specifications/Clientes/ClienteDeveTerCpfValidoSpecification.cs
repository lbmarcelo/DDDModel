using System;
using DomainValidation.Interfaces.Specification;
using EP.CursoMvc.Domain.Models;
using EP.CursoMvc.Domain.ValueObjects;

namespace EP.CursoMvc.Domain.Specifications.Clientes
{
    public class ClienteDeveTerCpfValidoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return CPF.Validar(cliente.CPF);
        }
    }
}