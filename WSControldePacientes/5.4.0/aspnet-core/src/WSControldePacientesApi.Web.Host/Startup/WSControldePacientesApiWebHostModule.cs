using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WSControldePacientesApi.Configuration;

namespace WSControldePacientesApi.Web.Host.Startup
{
    [DependsOn(
       typeof(WSControldePacientesApiWebCoreModule))]
    public class WSControldePacientesApiWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public WSControldePacientesApiWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WSControldePacientesApiWebHostModule).GetAssembly());
        }
    }
}
