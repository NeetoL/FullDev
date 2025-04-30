using Data.Login;
using Microsoft.Extensions.DependencyInjection;
using Services.Implementation.Login;
using Services.Implementation.Postagem;
using Services.Implementation.Usuarios;
using Services.Interfaces.Login;
using Services.Interfaces.Postagem;
using Services.Interfaces.Usuarios;

namespace Services.Extensions;
public static class ServiceCollectionExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services) {
        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped<IUsuariosService, UsuariosService>();
        services.AddScoped<IPostagemService, PostagemService>();
        services.AddScoped<IPostagemDAL, PostagemDAL>();
        services.AddScoped<IUsuarioDAL, UsuariosDAL>();
        services.AddScoped<ILoginDAL, LoginDAL>();
        return services;
    }
}