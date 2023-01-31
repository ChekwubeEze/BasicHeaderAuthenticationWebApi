using Basic.Auth.Core.ModelsDto;
using FluentValidation;

namespace BasicAtWebApiAuthentication.Applications.ModelsToValidate
{
    public class UserLoginDtoValidator: NullReferenceAbstractValidator<UserLoginDto>
    {
        public UserLoginDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().EmailAddress();
        }
    }
}
