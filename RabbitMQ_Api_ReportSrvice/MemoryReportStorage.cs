namespace RabbitMQ_Api_ReportSrvice
{
    public class MemoryReportStorage : IMemoryReportStorage
    {
        private readonly IList<Report> _emploees = new List<Report>();

        public void Add(Report report)
        {
            _emploees.Add(report);
        }

        public IEnumerable<Report> Get()
        {
            return _emploees;
        }
    }
}
