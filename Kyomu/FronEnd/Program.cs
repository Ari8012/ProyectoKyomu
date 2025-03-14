using FronEnd.Helpers.Implementations;
using FronEnd.Helpers.Interfaces;  

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddHttpClient<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<ICategoriaHelper, CategoriaHelper>();
builder.Services.AddScoped<IDetallePedidoHelper, DetallePedidoHelper>();
builder.Services.AddScoped<IMetodoPagoHelper, MetodoPagoHelper>();
builder.Services.AddScoped<IPagoHelper, PagoHelper>();
builder.Services.AddScoped<IPedidoHelper, PedidoHelper>();
builder.Services.AddScoped<IPlatilloHelper, PlatilloHelper>();
builder.Services.AddScoped<IReseņaHelper, ReseņaHelper>();
builder.Services.AddScoped<IRolHelper, RolHelper>();
builder.Services.AddScoped<IUsuarioHelper, UsuarioHelper>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
