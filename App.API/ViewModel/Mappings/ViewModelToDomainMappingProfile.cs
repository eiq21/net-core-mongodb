using AutoMapper;
using App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.API.ViewModel.User;

namespace App.API.ViewModels.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap< CategoryViewModel, Category>()
              .ForMember(s => s.CategoryId,
                  map => map.MapFrom(vm => vm.CategoryId))
              .ForMember(s => s.CategoryName, map =>
                  map.MapFrom(vm => vm.Name))
              .ForMember(s => s.CategoryDescription, map => map.MapFrom(vm => vm.Description));

            CreateMap<RegisterViewModel,User>();
            CreateMap<LoginViewModel, User>();
        }
    }
}
