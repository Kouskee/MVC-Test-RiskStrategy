var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CompanyContext>();

builder.Services.AddScoped<CompanyRepository>();
builder.Services.AddScoped<EmployeeRepository>();
builder.Services.AddScoped<NoteRepository>();
builder.Services.AddScoped<HistoryRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Company}/{action=Index}/{id?}");

_ = new DataPlaceholder(); // Initializer database

app.Run();
