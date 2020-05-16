using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WSControldePacientesApi.Authorization;

namespace WSControldePacientesApi
{
    [DependsOn(
        typeof(WSControldePacientesApiCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class WSControldePacientesApiApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<WSControldePacientesApiAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(WSControldePacientesApiApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
