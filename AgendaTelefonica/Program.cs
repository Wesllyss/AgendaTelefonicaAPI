using AgendaTelefonica.context;
using AgendaTelefonica.Interfaces;
using AgendaTelefonica.Repositores;
using AgendaTelefonica.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Registre o DbContext
builder.Services.AddDbContext<ContatoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registre o repositório e o serviço
builder.Services.AddScoped<IContatoRepository, ContatoRepository>(); // Registro correto
builder.Services.AddScoped<ContatoService>();

// Adicione controladores e outros serviços
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // Substitua pelo endereço do seu frontend
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("PermitirFrontend");
app.UseAuthorization();
app.MapControllers();
app.Run();