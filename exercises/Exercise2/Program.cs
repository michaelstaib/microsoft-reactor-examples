var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPooledDbContextFactory<AssetContext>(o => o.UseSqlite("Data Source=assets.db"));

builder.Services.AddGraphQLServer();

var app = builder.Build();

app.MapGraphQL();

app.Run();
