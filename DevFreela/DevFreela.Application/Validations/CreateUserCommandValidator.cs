using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Application.Validations
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator() 
        {
            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("E-mail inválido");
        }
    }
}
