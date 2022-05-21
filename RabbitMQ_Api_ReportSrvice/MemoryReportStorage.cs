namespace RabbitMQ_Api_ReportSrvice
{
    public class MemoryReportStorage : IMemoryReportStorage
    {
        private readonly IList<Report>  _reports = new List<Report>();

        public void Add(Report report)
        {
            _reports.Add(report);
        }

        public IEnumerable<Report> Get()
        {
            return _reports;
        }
    }
}
