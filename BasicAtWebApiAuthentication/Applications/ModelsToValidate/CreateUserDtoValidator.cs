using Basic.Auth.Core.ModelsDto;
using FluentValidation;

namespace BasicAtWebApiAuthentication.Applications.ModelsToValidate
{
    public class CreateUserDtoValidator: NullReferenceAbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Role).NotEmpty();
        }
    }
}
