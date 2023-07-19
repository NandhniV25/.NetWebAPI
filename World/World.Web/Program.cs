var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

#region Configure some services (client and server)

builder.Services.AddHttpClient("WorldWebAPI", options =>
{
    options.BaseAddress = new Uri("https://localhost:7284");
});

#endregion

#region Configure some services (client and server)

builder.Services.AddHttpClient("WorldWebAPIs", options =>
{
    options.BaseAddress = new Uri("https://localhost:7284");
});

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
