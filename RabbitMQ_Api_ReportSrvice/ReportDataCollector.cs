using Newtonsoft.Json;
using Plain.RabbitMQ;

namespace RabbitMQ_Api_ReportSrvice
{
    public class ReportDataCollector : IHostedService
    {
        private const int _DEFAULT_QUANTITY = 100;
        private readonly ISubscriber _subscriber;
        private readonly IMemoryReportStorage _memorytStorage;
        public ReportDataCollector(ISubscriber subscriber, IMemoryReportStorage memorytStorage)
        {
            _subscriber = subscriber;
            _memorytStorage = memorytStorage;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _subscriber.Subscribe(ProcessMessage);
            return Task.CompletedTask;
        }

        private bool ProcessMessage(string message, IDictionary<string, object> headers)
        {
            if (message.Contains("lllll"))
            {

            }
            else
            {
                var emploees = JsonConvert.DeserializeObject<List<Emploee>>(message);
             
                    _memorytStorage.Add(new Report
                    {
                        Emploes = emploees,
                        Count = _DEFAULT_QUANTITY 
                    });
                }
            return true;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
