using API.Services;
using BusinessLayer.RepoS;
using BusinessLayer.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Installers
{
    public class ServiceInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IFirmaRepo, FirmaRepo>();
            services.AddScoped<ISubeRepo, SubeRepo>();
            services.AddScoped<IBilgisayarBaglantiRepo, BilgisayarBaglantiRepo>();
            services.AddScoped<IYetkiliRepo, YetkiliRepo>();
            services.AddScoped<IProgramRepo, ProgramRepo>();
            services.AddScoped<IRemote_CredRepo, Remote_CredRepo>();
            services.AddScoped<IUrunRepo, UrunRepo>();
            services.AddScoped<IKullaniciRepo, KullaniciRepo>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IRefreshTokenRepo, RefreshTokenRepo>();
            services.AddScoped<IVergiDairesi, VergiDairesiRepo>();
        }
    }
}
