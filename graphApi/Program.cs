using graphApi.DataAccess;
using graphApi.DataAccess.DAO;
using graphApi.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

//TODO: https://www.nuget.org/packages/Slugify.Core/ - url = /id/slug/
//dotnet csharpier .

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SampleAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SampleAppDbContext"))
);

// Add services to the container.
builder.Services.AddControllers();

builder
    .Services.AddEndpointsApiExplorer()
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddFiltering()
    .AddSorting()
    .AddInMemorySubscriptions();

builder.Services.AddScoped<EmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<DepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<PageRepository, PageRepository>();
builder.Services.AddScoped<ProductRepository, ProductRepository>();
builder.Services.AddScoped<CollectionRepository, CollectionRepository>();
builder.Services.AddScoped<MenuRepository, MenuRepository>();
builder.Services.AddScoped<CartRepository, CartRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "allowedOrigin",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
    );
});

builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<SampleAppDbContext>();

    db.Database.EnsureDeleted();
    db.Database.Migrate();

    try
    {
        await Seed.InitAsync(db);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        throw;
    }
}

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}


app.UseCors(builder =>
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
);
app.UseHttpsRedirection();
app.UseRouting();

//app.UseAuthorization();

app.MapControllers();
app.UseWebSockets();

app.MapGraphQL();
app.Run();
