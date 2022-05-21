
namespace RabbitMQ_Api_ReportSrvice
{
    public interface IMemoryReportStorage
    {
        void Add(Report emploee);
        IEnumerable<Report> Get();
    }
}