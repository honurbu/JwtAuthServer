using FluentValidation;
using JwtAuthServer.Core.DTOs;

namespace JwtAuthServer.API.Validations
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(x=>x.Email).NotEmpty().WithMessage("Email is Required !").EmailAddress().WithMessage("Email is Wrong !");
            RuleFor(x=>x.Password).NotEmpty().WithMessage("Password is Required !");
            RuleFor(x=>x.Username).NotEmpty().WithMessage("Username is Required !");
        }
    }
}
