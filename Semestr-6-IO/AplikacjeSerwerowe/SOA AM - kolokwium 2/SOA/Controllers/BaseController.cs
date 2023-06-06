using Microsoft.AspNetCore.Mvc;
using AutoMapper;
namespace Web.Controllers
{
    public class BaseController:Controller
    {
        protected readonly IMapper _mapper;
        public BaseController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
