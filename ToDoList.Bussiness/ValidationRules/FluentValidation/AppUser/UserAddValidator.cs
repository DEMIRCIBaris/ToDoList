using FluentValidation;
using ToDoList.Entities.DTO.AppUserDTO;

namespace ToDoList.Bussiness.ValidationRules.FluentValidation.AppUser
{
    public class UserAddValidator:AbstractValidator<UserAddDto>
    {
        public UserAddValidator()
        {
            RuleFor(i => i.UserName).NotNull().WithMessage("Kullanıcı adı boş bırakılamaz");
            RuleFor(i => i.Password).NotNull().WithMessage("Parola alanı boş olamaz");
            RuleFor(i => i.ConfirmPassword).NotNull().WithMessage("Parola onay alanı boş olamaz");
            RuleFor(i => i.ConfirmPassword).Equal(i => i.Password).WithMessage("Parolalar eşleşmiyor");
            RuleFor(i => i.Email).NotNull().WithMessage("Email alanı boş olamaz").EmailAddress().WithMessage("Geçersiz email adresi");
            RuleFor(i => i.Name).NotNull().WithMessage("Ad alanı Boş olamaz");
            RuleFor(i => i.Surname).NotNull().WithMessage("Soyad alanı boş olamaz");
        }
    }
}
