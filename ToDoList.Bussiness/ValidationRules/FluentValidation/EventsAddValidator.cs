using FluentValidation;
using ToDoList.Entities.DTO.EventsDTO;

namespace ToDoList.Bussiness.ValidationRules.FluentValidation
{
    public class EventsAddValidator: AbstractValidator<EventsAddDto>
    {
        public EventsAddValidator()
        {
            RuleFor(i => i.Title).NotNull().WithMessage("Etkinlik adı boş bırakılamaz.");
            RuleFor(i => i.StartDate).NotNull().WithMessage("Başlangıç tarihi boş bırakılamaz.");
            RuleFor(i => i.EndDate).NotNull().WithMessage("Bitiş tarihi boş bırakılamaz."); 
        }
    }
}
