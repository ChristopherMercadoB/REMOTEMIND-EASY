﻿using FluentValidation.Results;


namespace REMOTEMIND_EASY.Core.Application.Exceptions
{
    public class ValidationException:Exception
    {
        public List<string> Errors { get; }

        public ValidationException() : base("Se han producido uno o mas errores de validacion")
        {
            Errors = new List<string>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            foreach (var item in failures)
            {
                Errors.Add(item.ErrorMessage);
            }
        }
    }
}
