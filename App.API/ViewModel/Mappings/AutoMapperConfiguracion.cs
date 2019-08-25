using AutoMapper;

namespace App.API.ViewModels.Mappings
{
    public class AutoMapperConfiguracion
    {
        public static void Configure() {

            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}
