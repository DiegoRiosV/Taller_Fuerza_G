using Fuerza_G_Taller.Configuration;
using Fuerza_G_Taller.Factories;

var builder = WebApplication.CreateBuilder(args);

// Leer cadena de conexi�n MySQL
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

// Crear la instancia �nica del administrador
var connectionManager = DatabaseConnectionManager.GetInstance(connectionString);

// Registrar el Singleton
builder.Services.AddSingleton(connectionManager);

// Registrar la f�brica de conexiones
builder.Services.AddScoped<IDbConnectionFactory, MySqlConnectionFactory>();

// Agregar servicios al contenedor
builder.Services.AddRazorPages();

var app = builder.Build();

// Pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

// Servir archivos est�ticos desde wwwroot
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// Mapear Razor Pages
app.MapRazorPages();

app.Run();
