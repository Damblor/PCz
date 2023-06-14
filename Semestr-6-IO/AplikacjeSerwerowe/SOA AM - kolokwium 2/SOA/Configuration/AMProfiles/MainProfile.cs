using AutoMapper;
using Model.DataModels;
using ViewModels.ViewModels;
//using Model.DataModels;
//using ViewModels.ViewModels;

namespace Web.Configuration.AMProfiles
{
    public class MainProfile:Profile
    {
        public MainProfile()
        {
            CreateMap<Gra, GraVM>();
            CreateMap<Gra, AddOrUpdateGraVM>();
            CreateMap<AddOrUpdateGraVM, Gra>();
        }
    }
}
