using AutoMapper;
using PizzaLab.WebAPI.ViewModels.Account.InputModels;
using PizzaLabWebAPI.Data.Models;

namespace PizzaLab.WebAPI.Infrastructure.Helpers
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            this.CreateMap<RegisterInputModel, ApplicationUser>();
        }
    }
}
