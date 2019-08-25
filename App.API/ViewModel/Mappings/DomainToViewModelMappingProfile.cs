using AutoMapper;
using App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.API.ViewModel.User;

namespace App.API.ViewModels.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Category, CategoryViewModel>()
               .ForMember(vm => vm.Name, map =>
                   map.MapFrom(s => s.CategoryName))
               .ForMember(vm=> vm.Description,map=> map.MapFrom(s=>s.CategoryDescription));

            CreateMap<Product, ProductViewModel>()
                .ForMember(vm => vm.CategoryName,
                map => map.MapFrom(s => s.Category.CategoryName));

            CreateMap<User, RegisterViewModel>();
            CreateMap<User, LoginViewModel>();

        }
    }
}
