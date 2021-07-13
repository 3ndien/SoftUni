namespace PizzaLab.WebAPI.ViewModels
{
    using Microsoft.AspNetCore.Mvc;

    public class BadRequestViewModel : ProblemDetails
    {
        public string Message { get; set; }
    }
}
