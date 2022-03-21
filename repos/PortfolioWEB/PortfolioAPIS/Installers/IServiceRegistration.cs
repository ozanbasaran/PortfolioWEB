using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PortfolioAPIS.Installers
{
    public interface IServiceRegistration
    {
        void RegisterAppServices(IServiceCollection services, IConfiguration configuration);
    }
}
