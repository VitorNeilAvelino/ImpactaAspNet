using AutoMapper;
using ExpoCenter.Repositorios.SqlServer;
using Microsoft.AspNetCore.Mvc;

namespace ExpoCenter.Mvc.Controllers
{
    public class ControllerBase : Controller
    {
        protected ExpoCenterDbContext DbContext { get; set; }
        protected IMapper Mapper { get; set; }

        public ControllerBase(ExpoCenterDbContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }
    }
}