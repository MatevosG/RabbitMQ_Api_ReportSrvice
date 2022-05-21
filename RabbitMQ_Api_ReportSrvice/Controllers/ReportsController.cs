using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RabbitMQ_Api_ReportSrvice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IMemoryReportStorage _memoryReportStorage;

        public ReportsController(IMemoryReportStorage memoryReportStorage)
        {
            _memoryReportStorage = memoryReportStorage;
        }

        // GET api/<ReportsController>/5
        [HttpGet("Get")]
        public IEnumerable<Report> Get()
        {
            return _memoryReportStorage.Get().ToList();
        }
    }
}
