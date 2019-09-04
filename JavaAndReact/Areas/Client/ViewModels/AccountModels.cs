using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JavaAndReact.Areas.Client.ViewModels
{
    public class ClientAddViewModel
    {
        [Required(ErrorMessage = "Поле не може бути пустим!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Поле не може бути пустим!")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Поле не може бути пустим!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Поле не може бути пустим!")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Поле не може бути пустим!")]
        [EmailAddress(ErrorMessage = "Не правильний формат електронної пошти!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Поле не може бути пустим!")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).{6,24}$", ErrorMessage = "Пароль повинен мати мінімум 6 символів, нижній і верхній регістр, та цифри!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Поле не може бути пустим!")]
        [Compare("Password", ErrorMessage = "Паролі не співпадають!")]
        public string ConfirmPassword { get; set; }

    }
}
