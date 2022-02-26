using CariocaMix.Domain.Models.User;
using CariocaMix.Utils.Converts;
using CariocaMix.Utils.Resources;
using CariocaMix.Utils.Validations;
using FluentValidation;

namespace CariocaMix.Service.Validators.User
{
    public class UserAddModelValidator : AbstractValidator<UserAddModel>
    {
        public UserAddModelValidator()
        {
            RuleFor(x => x.Cpf)
                .NotNull().WithMessage(ConvertReturnMessage.SerializeReturnMessage(0, string.Format(Message.X0_DEVE_SER_PREENCHIDO, Texts.CPF)))
                .NotEmpty().WithMessage(ConvertReturnMessage.SerializeReturnMessage(0, string.Format(Message.X0_DEVE_SER_PREENCHIDO, Texts.CPF)))
                .Must(StringValidator.IsCpf).WithMessage(ConvertReturnMessage.SerializeReturnMessage(0, string.Format(Message.X0_INVALIDO, Texts.CPF)));

            RuleFor(x => x.Name)
                .NotNull().WithMessage(ConvertReturnMessage.SerializeReturnMessage(0, string.Format(Message.X0_DEVE_SER_PREENCHIDO, Texts.NOME)))
                .NotEmpty().WithMessage(ConvertReturnMessage.SerializeReturnMessage(0, string.Format(Message.X0_DEVE_SER_PREENCHIDO, Texts.NOME)));

            RuleFor(x => x.NumberPhone)
                .NotNull().WithMessage(ConvertReturnMessage.SerializeReturnMessage(0, string.Format(Message.X0_DEVE_SER_PREENCHIDO, Texts.TELEFONE)))
                .NotEmpty().WithMessage(ConvertReturnMessage.SerializeReturnMessage(0, string.Format(Message.X0_DEVE_SER_PREENCHIDO, Texts.TELEFONE)));

            RuleFor(x => x.Birthday)
                .NotNull().WithMessage(ConvertReturnMessage.SerializeReturnMessage(0, string.Format(Message.X0_DEVE_SER_PREENCHIDO, Texts.NASCIMENTO)))
                .NotEmpty().WithMessage(ConvertReturnMessage.SerializeReturnMessage(0, string.Format(Message.X0_DEVE_SER_PREENCHIDO, Texts.NASCIMENTO)));

            RuleFor(x => x.Email)
                .NotNull().WithMessage(ConvertReturnMessage.SerializeReturnMessage(0, string.Format(Message.X0_DEVE_SER_PREENCHIDO, Texts.EMAIL)))
                .NotEmpty().WithMessage(ConvertReturnMessage.SerializeReturnMessage(0, string.Format(Message.X0_DEVE_SER_PREENCHIDO, Texts.EMAIL)))
                .Must(StringValidator.IsValidEmail).WithMessage(ConvertReturnMessage.SerializeReturnMessage(0, string.Format(Message.X0_INVALIDO, Texts.EMAIL)));

            RuleFor(x => x.Password)
                .NotNull().WithMessage(ConvertReturnMessage.SerializeReturnMessage(0, string.Format(Message.X0_DEVE_SER_PREENCHIDA, Texts.SENHA)))
                .NotEmpty().WithMessage(ConvertReturnMessage.SerializeReturnMessage(0, string.Format(Message.X0_DEVE_SER_PREENCHIDA, Texts.SENHA)))
                .Must(p => string.IsNullOrEmpty(StringValidator.ValidatePasswordEightCharacters(p)))
                    .WithMessage(p => ConvertReturnMessage.SerializeReturnMessage(0, StringValidator.ValidatePasswordEightCharacters(p.Password)));
        }
    }
}