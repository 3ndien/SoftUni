namespace PizzaLab.WebAPI.ViewModels.Account.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class LoginInputModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
