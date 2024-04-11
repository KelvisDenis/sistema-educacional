using Microsoft.EntityFrameworkCore;
using SistemaEducacional.Infraestrutura;
using SistemaEducacional.Services;
using SistemaEducacional.Services.Interfaces;
using SistemaEducacional.Services.Session;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ModelContext>(op => op.UseNpgsql(builder.Configuration.GetConnectionString("ModelContext")
    ?? throw new InvalidOperationException("Connection string ModelContext not found.")));
builder.Services.AddDistributedMemoryCache();

builder.Services.AddScoped<Isession, Sessao>();
builder.Services.AddScoped<IAluno, AlunoService>();
builder.Services.AddScoped<IDirecao,DirecaoService>();
builder.Services.AddScoped<IDocente, DocenteService>();
builder.Services.AddScoped<IDisciplina, DisciplinaService>();
builder.Services.AddScoped<ITurma, TurmaService>();
builder.Services.AddScoped<INota, NotaService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

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
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
