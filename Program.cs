// See https://aka.ms/new-console-template for more information
//Top level statements

using Asha.Data;
using dotnet_core_pi3bplus.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Hello, World!");


HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddScoped<ICar, Car>();
builder.Services.AddScoped<IToyotaCar, ToyotaCar>();
builder.Services.AddScoped<IPalisadeCar, PalisadeCar>();
builder.Services.AddTransient<Customer>();


IHost host = builder.Build();
Entry(host.Services);

host.RunAsync().Wait();


static void Entry(IServiceProvider serviceProvider)
{
    Console.WriteLine("Started..");

    Customer cust = serviceProvider.GetRequiredService<Customer>();
    cust.IsDriving();


    Customer anotherCust = serviceProvider.GetRequiredService<Customer>();
    anotherCust.IsDriving();

    TestDb();
}


static void TestDb()
{
    using (var db = new AshaContext())
    {
        db.Database.EnsureCreated();
        db.SaveChanges();
    }
}
