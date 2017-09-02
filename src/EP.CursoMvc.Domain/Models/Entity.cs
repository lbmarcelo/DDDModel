﻿using System;
using DomainValidation.Validation;

namespace EP.CursoMvc.Domain.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public abstract bool EhValido();
    }
}