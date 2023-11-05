using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VendasApp.Application.Services.Database;
using VendasApp.Application.Services.Database.Interfaces;
using VendasApp.Infra.Data;
using VendasApp.Infra.Data.Repositories;

namespace VendaApp.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<VendasAppContext>();
            services.AddSingleton<IUsuarioRepository, UsuarioRepository>();
            services.AddSingleton<IItemRepository, ItemRepository>();
            services.AddSingleton<IPedidoRepository, PedidoRepository>();
            services.AddSingleton<IClienteRepository, ClienteRepository>();
            services.AddSingleton<UsuarioService>();
            services.AddSingleton<ItemService>();
            services.AddSingleton<PedidoService>();
            services.AddSingleton<ClienteService>();
            return services;
        }
    }
}