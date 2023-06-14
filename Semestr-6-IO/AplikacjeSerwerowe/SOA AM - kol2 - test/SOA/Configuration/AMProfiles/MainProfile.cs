using AutoMapper;
using Model.DataModels;
using ViewModels.ViewModels;

namespace Web.Configuration.AMProfiles
{
    public class MainProfile:Profile
    {
        public MainProfile()
        {
            CreateMap<Zwierze, ZwierzeVM>();
            CreateMap<Zwierze, AddOrUpdateZwierzeVM>();
            CreateMap<AddOrUpdateZwierzeVM, Zwierze>();
        } 
    }
}
