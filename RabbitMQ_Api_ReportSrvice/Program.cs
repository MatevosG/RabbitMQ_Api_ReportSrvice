using Plain.RabbitMQ;
using RabbitMQ.Client;
using RabbitMQ_Api_ReportSrvice;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IConnectionProvider>(new ConnectionProvider("amqp://guest@localhost:5672"));
builder.Services.AddSingleton<ISubscriber>(x => new Subscriber(x.GetService<IConnectionProvider>(),
                                                         "report_exchange",
                                                         "repor_queu",
                                                         "report.*",
                                                         ExchangeType.Topic
                                                         ));

builder.Services.AddSingleton<IMemoryReportStorage, MemoryReportStorage>();
builder.Services.AddHostedService<ReportDataCollector>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
