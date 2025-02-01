// See https://aka.ms/new-console-template for more information
//Top level statements

using Asha.Data;
using Asha.Domain;
using dotnet_core_pi3bplus.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Hello, World!");


HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddScoped<ICar, Car>();
builder.Services.AddScoped<IToyotaCar, ToyotaCar>();
builder.Services.AddScoped<IPalisadeCar, PalisadeCar>();
builder.Services.AddTransient<Customer>();

builder.Configuration.AddUserSecrets<Program>();

#region Configuration Settings for SQL Server
builder.Services.Configure<SqlSettings>(builder.Configuration.GetSection("SqlSettings"));
builder.Services.AddScoped<AshaContext>();
#endregion


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

    TestDb(serviceProvider);
}


static void TestDb(IServiceProvider serviceProvider)
{
    try
    {
        var context = serviceProvider.GetRequiredService<AshaContext>();
        context.Database.EnsureCreated();
        //Read books

        var books = context.Books.Include(b => b.Author).ToList();
        if (books.Count == 0)
        {

            books = new List<Book>
        {
        new Book { Title = "Book1", PublishDate = DateOnly.FromDateTime(DateTime.Now),BasePrice = 10},
        new Book { Title = "Book2",PublishDate = DateOnly.FromDateTime(DateTime.Now), BasePrice= 20},
        new Book { Title = "Book3",PublishDate = DateOnly.FromDateTime(DateTime.Now), BasePrice= 30}
        };

            var author = new Author { FirstName = "Hemant", LastName = "Shelar", Books = books };
            context.Authors.Add(author);
            context.SaveChanges();
        }
        else
        {
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} - {book.Author.FirstName} {book.Author.LastName}");
            }

        }


    }
    catch (Exception ex)
    {
        throw;
    }
}
