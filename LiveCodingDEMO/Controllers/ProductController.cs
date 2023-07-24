using LiveCodingDEMO.DataAccess;
using LiveCodingDEMO.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LiveCodingDEMO.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IRepository _dataRepository;

        public ProductController(ILogger<ProductController> logger, IRepository dataRepository)
        {
            _dataRepository = dataRepository;
            _logger = logger;
        }

        [HttpGet(Name = "GetProduct")]
        public Product Get(int id)
        {
            return _dataRepository.GetProduct(id);
        }
    }
}