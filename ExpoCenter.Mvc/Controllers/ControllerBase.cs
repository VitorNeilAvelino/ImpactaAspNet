using AutoMapper;
using ExpoCenter.Repositorios.SqlServer;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace ExpoCenter.Mvc.Controllers
{
    public class ControllerBase : Controller
    {
        protected ExpoCenterDbContext DbContext { get; }
        protected IMapper Mapper { get; }
        public IHttpClientFactory HttpClientFactory { get; }

        public ControllerBase(ExpoCenterDbContext dbContext, IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            DbContext = dbContext;
            Mapper = mapper;
            HttpClientFactory = httpClientFactory;
        }
    }
}